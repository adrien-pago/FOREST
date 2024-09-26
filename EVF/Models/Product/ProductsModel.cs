using EVF.DAL.DataConnection.EVF;
using EVF.DAL.Entity.EVF;
using evf.Models.Customer;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace evf.Models.Product { 
    public class ProductsModel
    {
        private int idArticle;
        private string codeSAP;
        private string description;
        private string unite;
        private string statut;
        private decimal? tarifArticle;
        private DateTime? dateModification;
        private List<Prevision> listArticlePrevision;
        private List<Prevision> listArticlePrevisionN_un;
        private List<VentePortefeuille> listArticleLivreeN;
        private List<VentePortefeuille> listArticleLivreeN_un;
        private List<VentePortefeuille> listArticlePortefeuille;
        private int nbJours;


        public int IdArticle { get => idArticle; set => idArticle = value; }
        public string CodeSAP { get => codeSAP; set=> codeSAP = value; }
        public string Description { get => description; set => description = value; }
        public string Unite { get => unite; set => unite = value; }
        public string Statut { get => statut; set => statut = value; }
        public DateTime? DateModification { get => dateModification; set => dateModification = value; }


        public List<Prevision> ListArticlePrevision { get => listArticlePrevision; set => listArticlePrevision = value; }
        public List<VentePortefeuille> ListArticleLivreeN { get => listArticleLivreeN; set => listArticleLivreeN = value; }
        public List<VentePortefeuille> ListArticleLivreeN_un { get => listArticleLivreeN_un; set => listArticleLivreeN_un = value; }
        public List<VentePortefeuille> ListArticlePortefeuille { get => listArticlePortefeuille; set => listArticlePortefeuille = value; }
        public List<Prevision> ListArticlePrevisionN_un { get => listArticlePrevisionN_un; set => listArticlePrevisionN_un = value; }
        public decimal? TarifArticle { get => tarifArticle; set => tarifArticle = value; }
        public int NbJours { get => nbJours; set => nbJours = value; }

        public static List<ProductsModel> CreateProductsList(EVFContext context,Client customer, int? idCommercial, int monthStart, int yearStart, int monthEnd, int yearEnd, string[] status)
        {
            DateTime startDate = DateTime.Parse(monthStart.ToString() + "-" + yearStart.ToString());
            DateTime endDate = DateTime.Parse(monthEnd.ToString() + "-" + yearEnd.ToString());

            //Requêtes principales
            List<Prevision> previsions = context.Previsions.Include(n => n.IdArticleNavigation).Where(p => p.IdClient == customer.IdClient && p.IdCommercial == idCommercial && (yearStart == yearEnd ? (p.Annee == yearStart && p.Mois >= monthStart && p.Mois <= monthEnd) : ((p.Annee == yearStart && p.Mois >= monthStart) || (p.Annee == yearEnd && p.Mois <= monthEnd)))).ToList();
            List<Prevision> previsionsN_un = context.Previsions.Include(n => n.IdArticleNavigation).Where(p => p.IdClient == customer.IdClient && p.IdCommercial == idCommercial && (yearStart == yearEnd ? (p.Annee == yearStart - 1 && p.Mois >= monthStart && p.Mois <= monthEnd) : ((p.Annee == yearStart - 1 && p.Mois >= monthStart) || (p.Annee == yearEnd - 1 && p.Mois <= monthEnd)))).ToList();

            List<VentePortefeuille> ventePortefeuille = context.VentePortefeuilles.Include(n => n.IdArticleNavigation).Where(vp => vp.IdClient == customer.IdClient && vp.IdCommercial == idCommercial).ToList();


            List<VentePortefeuille> vente = ventePortefeuille.Where(vp => vp.TypeVentePort == true && (yearStart == yearEnd ? (vp.Annee == yearStart && vp.Mois >= monthStart && vp.Mois <= monthEnd) : ((vp.Annee == yearStart && vp.Mois >= monthStart) || (vp.Annee == yearEnd && vp.Mois <= monthEnd)))).ToList();
            List<VentePortefeuille> venteN_un = ventePortefeuille.Where(vp => vp.TypeVentePort == true && (yearStart == yearEnd ? (vp.Annee == yearStart - 1 && vp.Mois >= monthStart && vp.Mois <= monthEnd) : ((vp.Annee == yearStart - 1 && vp.Mois >= monthStart) || (vp.Annee == yearEnd - 1 && vp.Mois <= monthEnd)))).ToList();
            List<VentePortefeuille> portefeuille = ventePortefeuille.Where(vp => vp.TypeVentePort == false && (yearStart == yearEnd ? (vp.Annee == yearStart && vp.Mois >= monthStart && vp.Mois <= monthEnd) : ((vp.Annee == yearStart && vp.Mois >= monthStart) || (vp.Annee == yearEnd && vp.Mois <= monthEnd)))).ToList();

      

            //Ajouter les articles en commun dans une seule variable
            List<Article> articles = new List<Article>();


            articles.AddRange(previsions.Select(prev => prev.IdArticleNavigation));
            articles.AddRange(vente.Select(v => v.IdArticleNavigation));
            articles.AddRange(venteN_un.Select(vn => vn.IdArticleNavigation));
            articles.AddRange(portefeuille.Select(p => p.IdArticleNavigation));

            List<Article> uniqueArticles = articles.DistinctBy(a => a.CodeSap).ToList();

            List<ProductsModel> articlesList = new List<ProductsModel>();

            //Itérer la variable qui contient les articles et ajouter dans une nouvelle liste; c'est cette dernière qu'on affiche dans la vue
            foreach (var art in uniqueArticles)
            {
                List<Prevision> articlePrevList = previsions.Where(prev => prev.IdArticle == art.IdArticle).ToList();
                List<Prevision> articlePrevN_unList = previsionsN_un.Where(prev => prev.IdArticle == art.IdArticle).ToList();
                List<VentePortefeuille> articlePortefeuille = portefeuille.Where(prev => prev.IdArticle == art.IdArticle).ToList();
                List<VentePortefeuille> articleLivreeN = vente.Where(prev => prev.IdArticle == art.IdArticle).ToList();
                List<VentePortefeuille> articleLivreeN_un = venteN_un.Where(prev => prev.IdArticle == art.IdArticle).ToList();

                // Liste à itérer
                List<Prevision> listArticlePrevisionV = new List<Prevision>();
                List<Prevision> listArticlePrevisionN_unV = new List<Prevision>();
                List<VentePortefeuille> listArticlePortefeuille = new List<VentePortefeuille>();
                List<VentePortefeuille> listArticleLivreeN = new List<VentePortefeuille>();
                List<VentePortefeuille> listArticleLivreeN_un = new List<VentePortefeuille>();

                for (var date = startDate.Date; date.Date <= endDate.Date; date = date.AddMonths(1)) {
                    // Prévision individuelle
                    Prevision prevArticle = new Prevision();
                    prevArticle.IdClient = customer.IdClient;
                    prevArticle.IdCommercial = idCommercial.Value;
                    prevArticle.IdArticle = art.IdArticle;
                    prevArticle.Mois = date.Month;
                    prevArticle.Annee = date.Year;
               
                    if (articlePrevList.Where(p => p.Mois == date.Month && p.Annee == date.Year).Count() != 0 && articlePrevList.Where(p => p.Mois == date.Month && p.Annee == date.Year).Sum(p => p.Volume) != 0)
                        {
                        prevArticle.IdPrevision = articlePrevList.FirstOrDefault(p => p.Mois == date.Month && p.Annee == date.Year).IdPrevision;
                        prevArticle.Volume = articlePrevList.FirstOrDefault(p => p.Mois == date.Month && p.Annee == date.Year).Volume;
                        prevArticle.DateModification = articlePrevList.FirstOrDefault(p => p.Mois == date.Month && p.Annee == date.Year).DateModification;

                        }
                        else
                    {
                        prevArticle.Volume = 0;
                        
                    }
                    listArticlePrevisionV.Add(prevArticle);


                    Prevision prevN_unArticle = new Prevision();
                    prevN_unArticle.IdClient = customer.IdClient;
                    prevN_unArticle.IdCommercial = idCommercial.Value;
                    prevN_unArticle.IdArticle = art.IdArticle;
                    prevN_unArticle.Mois = date.Month;
                    prevN_unArticle.Annee = date.Year;

                    if (articlePrevN_unList.Where(p => p.Mois == date.Month && p.Annee == date.Year - 1).Count() != 0 && articlePrevN_unList.Where(p => p.Mois == date.Month && p.Annee == date.Year - 1).Sum(p => p.Volume) != 0)
                    {
                        prevN_unArticle.Volume = articlePrevN_unList.FirstOrDefault(p => p.Mois == date.Month && p.Annee == date.Year - 1).Volume;
                        prevN_unArticle.IdPrevision = articlePrevN_unList.FirstOrDefault(p => p.Mois == date.Month && p.Annee == date.Year - 1).IdPrevision;

                    }
                    else
                    {
                        prevN_unArticle.Volume = 0;
                       
                    }
                    listArticlePrevisionN_unV.Add(prevN_unArticle);

                    VentePortefeuille portArticle = new VentePortefeuille();
                    portArticle.IdClient = customer.IdClient;
                    portArticle.IdCommercial = idCommercial.Value;
                    portArticle.IdArticle = art.IdArticle;
                    portArticle.Mois = date.Month;
                    portArticle.Annee = date.Year;

                    if (articlePortefeuille.Where(p => p.Mois == date.Month && p.Annee == date.Year).Count() != 0 && articlePortefeuille.Where(p => p.Mois == date.Month && p.Annee == date.Year).Sum(p => p.Volume) != 0)
                    {
                        portArticle.Volume = articlePortefeuille.FirstOrDefault(p => p.Mois == date.Month && p.Annee == date.Year).Volume;
                        portArticle.IdVentePort = articlePortefeuille.FirstOrDefault(p => p.Mois == date.Month && p.Annee == date.Year).IdVentePort;

                    }
                    else
                    {
                        portArticle.Volume = 0;
                      
                    }

                    listArticlePortefeuille.Add(portArticle);

                    VentePortefeuille livreeN_Article = new VentePortefeuille();
                    livreeN_Article.IdClient = customer.IdClient;
                    livreeN_Article.IdCommercial = idCommercial.Value;
                    livreeN_Article.IdArticle = art.IdArticle;
                    livreeN_Article.Mois = date.Month;
                    livreeN_Article.Annee = date.Year;

                    if (articleLivreeN.Where(p => p.Mois == date.Month && p.Annee == date.Year).Count() != 0 && articleLivreeN.Where(p => p.Mois == date.Month && p.Annee == date.Year).Sum(p => p.Volume) != 0)
                    {
                        livreeN_Article.Volume = articleLivreeN.FirstOrDefault(p => p.Mois == date.Month && p.Annee == date.Year).Volume;
                        livreeN_Article.IdVentePort = articleLivreeN.FirstOrDefault(p => p.Mois == date.Month && p.Annee == date.Year).IdVentePort;

                       
                    }
                    else
                    {
                        livreeN_Article.Volume = 0;
                       
                    }
                    listArticleLivreeN.Add(livreeN_Article);

                    VentePortefeuille livreeNun_Article = new VentePortefeuille();
                    livreeNun_Article.IdClient = customer.IdClient;
                    livreeNun_Article.IdCommercial = idCommercial.Value;
                    livreeNun_Article.IdArticle = art.IdArticle;
                    livreeNun_Article.Mois = date.Month;
                    livreeNun_Article.Annee = date.Year;

                    if (articleLivreeN_un.Where(p => p.Mois == date.Month && p.Annee == date.Year - 1).Count() != 0 && articleLivreeN_un.Where(p => p.Mois == date.Month && p.Annee == date.Year - 1).Sum(p => p.Volume) != 0)
                    {
                        livreeNun_Article.Volume = articleLivreeN_un.FirstOrDefault(p => p.Mois == date.Month && p.Annee == date.Year - 1).Volume;
                        livreeNun_Article.IdVentePort = articleLivreeN_un.FirstOrDefault(p => p.Mois == date.Month && p.Annee == date.Year - 1).IdVentePort;
                    }
                    else
                    {
                        livreeNun_Article.Volume = 0;
                    }

                    listArticleLivreeN_un.Add(livreeNun_Article);
                }
                

                int volSum = articlePrevList.Sum(p => p.Volume);
                int volSumPrevN_un = articlePrevN_unList.Sum(p => p.Volume);
                DateTime? todayDate = DateTime.Now;
                DateTime? last_Update = listArticlePrevisionV.OrderByDescending(p => p.DateModification).First().DateModification == null ? todayDate : listArticlePrevisionV.OrderByDescending(p => p.DateModification).First().DateModification;
              

                bool saisiesPrev = (articlePrevList.Count != 0 && volSum != 0 && (todayDate - last_Update).Value.Days <= 30) ? true : false;
                bool presencePrevN_un = (articlePrevN_unList.Count != 0 && volSumPrevN_un != 0) ? true : false;
                bool presencePort = (articlePortefeuille.Count != 0) ? true : false;
                bool presenceVenteN_un = (articleLivreeN_un.Count != 0) ? true : false;
                bool presenceVente = (articleLivreeN.Count != 0) ? true : false;

                List<TarifArticle> listTarifArt = context.TarifArticles.Where(t => t.IdCommercial == idCommercial && t.IdArticle == art.IdArticle && t.IdClient == customer.IdClient).ToList();

                decimal? tarifA = listTarifArt.Count() != 0 ? listTarifArt.First().TarifA : 0;

                ProductsModel article = new ProductsModel()
                {
                    CodeSAP = art.CodeSap,
                    Description = context.LibelleArticles.First(l => l.IdArticle == art.IdArticle).Libelle,
                    Unite = art.Unite,
                    IdArticle = art.IdArticle,
                    DateModification = listArticlePrevisionV.Count != 0 ? listArticlePrevisionV.OrderByDescending(p => p.DateModification).First().DateModification : null,
                    ListArticlePrevision = listArticlePrevisionV.OrderBy(p => p.Annee.ToString()).ToList(),
                    ListArticlePrevisionN_un = listArticlePrevisionN_unV.OrderBy(p => p.Annee.ToString()).ToList(),
                    ListArticlePortefeuille = listArticlePortefeuille.OrderBy(p => p.Annee.ToString()).ToList(),
                    ListArticleLivreeN = listArticleLivreeN.OrderBy(p => p.Annee.ToString()).ToList(),
                    ListArticleLivreeN_un = listArticleLivreeN_un.OrderBy(p => p.Annee.ToString()).ToList(),
                    Statut = saisiesPrev == true ? status[2] : ((presencePort == true || presenceVenteN_un == true || presenceVente == true) ? status[1] : status[0]),
                    TarifArticle = tarifA,
                    NbJours = (todayDate - last_Update).Value.Days != 0 ? (todayDate - last_Update).Value.Days : 0
                };

                articlesList.Add(article);
            }

            return articlesList;
        }

        public static List<ProductsModel> GetProductsListFiltered(string sortOrder, List<ProductsModel> products, string[] status, string searchDescription, string searchCode, int selectedStatus, string ownerName)
        {

            if (searchCode != null)
            {
                products = products.Where(ca => ca.CodeSAP.Contains(searchCode)).ToList();
            }
            if (searchDescription != null)
            {
                products = products.Where(ca => ca.Description.ToUpper().Contains(searchDescription.ToUpper())).ToList();

            }

            selectedStatus = selectedStatus == 0 ? 4 : selectedStatus;

            if (selectedStatus < status.Length + 1 && selectedStatus != 0)
            {
                products = products.Where(c => c.Statut == status[selectedStatus - 1]).ToList();
            }

            switch (sortOrder)
            {
                case "ProductDescription_desc":
                    products = products.OrderByDescending(c => c.Description).ToList();
                    break;
                case "ProductDescription":
                    products = products.OrderBy(c => c.Description).ToList();
                    break;
                case "CodeSAP":
                    products = products.OrderBy(c => Convert.ToInt32(c.CodeSAP)).ToList();
                    break;
                case "CodeSAP_desc":
                    products = products.OrderByDescending(c => Convert.ToInt32(c.CodeSAP)).ToList();
                    break;
                case "LastUpdate_desc":
                    products = products.OrderByDescending(c => c.DateModification).ToList();
                    break;
                default:
                    if (ownerName == "customersProducts")
                    {
                        products = products.OrderBy(c => c.DateModification).ToList();
                    }
                    else
                    {
                        products = products.OrderBy(c => c.Description).ToList();
                    }
                    break;
            }
            return products;
        }
    }
}
