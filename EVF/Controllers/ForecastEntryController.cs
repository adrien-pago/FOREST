using evf.Models;
using evf.Models.Customer;
using evf.Models.Product;
using EVF.DAL.DataConnection.EVF;
using EVF.DAL.Entity.EVF;
using EVF.DAL.Entity.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;
using Newtonsoft.Json;
using evf.Models.User;
using Microsoft.Extensions.Options;
using System.Globalization;
using Microsoft.Extensions.Primitives;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace evf.Controllers
{

    [Authorize(Roles = "Commercial,AssistantCommercial")]
    public class ForecastEntryController : Controller
    {
        // Declaration of necessary services and dependencies
        private readonly EVFContext _context;
        private readonly UserManager<UserInfo> _userManager;
        private readonly UserInfosViewModel _userInfos;
        private readonly SignInManager<UserInfo> _signInManager;
        private readonly IStringLocalizer<ForecastEntryController> _stringLocalizer;
        private readonly ILogger<ForecastEntryController> _logger;
        private readonly UserInfo _user;
        private readonly IHttpContextAccessor _contextAccessor;

        // Controller constructor to initialize dependencies
        public ForecastEntryController(EVFContext context, UserManager<UserInfo> userManager, SignInManager<UserInfo> signInManager, IHttpContextAccessor contextAccessor, IStringLocalizer<ForecastEntryController> stringLocalizer, ILogger<ForecastEntryController> logger, IOptions<RequestLocalizationOptions> locOptions)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _stringLocalizer = stringLocalizer;
            _logger = logger;
            _contextAccessor = contextAccessor;
            UserInfo user = _userManager.GetUserAsync(contextAccessor.HttpContext.User).Result;
            Personnel userInfos = _context.Personnel.Find(user.IdPersonnel);
            Parametrage paramUser = user.ParametrageNav;
            var requestCulture = contextAccessor.HttpContext.Features.Get<IRequestCultureFeature>();
            var cultureItems = locOptions.Value.SupportedUICultures;
            string langue = paramUser?.LangueBD != null ? paramUser.LangueBD : cultureItems.Contains(requestCulture.RequestCulture.Culture) ? requestCulture.RequestCulture.Culture.Name : locOptions.Value.DefaultRequestCulture.Culture.Name;
            // Initializing the view model containing user information: 
            _userInfos = new UserInfosViewModel(userInfos.IdPersonnel, userInfos.IdRole, userInfos.Nom, userInfos.CodeSap, userInfos.IdSociete, userInfos.Email, langue, dateFormatSelected: paramUser?.FormatDate != null ? paramUser?.FormatDate : "yyyy/MM/dd", decimalFormatCulture: paramUser?.DecimalFormat != null ? paramUser?.DecimalFormat : "en-US", saveType: paramUser?.SaveType != null ? paramUser?.SaveType : "Individual");
        }

        //Action to display the main page(Index)
        [HttpGet]
        public ActionResult Customers(int? page, string sortOrder, int monthStart, int yearStart, int monthEnd, int yearEnd)
        {
            int pageSize = 10;
            int pageNumber = page ?? 1;
            // Initializing client statuses
            string[] status = new string[3];
            status[0] = _stringLocalizer["tableC.headerStatusNew"].Value;
            status[1] = _stringLocalizer["tableC.headerStatusMake"].Value;
            status[2] = _stringLocalizer["tableC.headerStatusMade"].Value;
            List<SocieteClient> societeClient = _context.SocieteClients.Include(n => n.IdClientNavigation).Include(sc => sc.IdCommercialNavigation).Where(sc => (_userInfos.IdRole == 1) ? (sc.IdCommercial == _userInfos.IdPersonnel) : (sc.IdAssistantCommercial == _userInfos.IdPersonnel)).ToList();
            Period currentPeriod = new Period(monthStart, monthEnd, yearStart, yearEnd);
            List<CustomersModel> customers = CustomersModel.CreateCustomerList(societeClient, currentPeriod.MonthStart, currentPeriod.YearStart, currentPeriod.MonthEnd, currentPeriod.YearEnd, _context, _userInfos.IdPersonnel, status);
            // Filtering customers by salespeople for a separate list
            List<CustomersModel> customersByCommerciaux = customers.DistinctBy(c => c.CodeSAPCommercial).ToList();
            // Creation of the list of salespeople to select them in the view
            List<SelectListItem> listCommerciaux = new List<SelectListItem>();
            foreach (var customer in customersByCommerciaux)
            {
                listCommerciaux.Add(new SelectListItem()
                {
                    Value = customer.CodeSAPCommercial,
                   Text = customer.NomCommercial
                });
            }
            customers = CustomersModel.GetCustomersListFiltered(sortOrder, customers, status, null, null, null, 0);
            // Initializing the view model for the Index page
            IndexViewModel indexModel = new IndexViewModel(status)
            {
                Commerciaux = listCommerciaux,
                Customers = new PagedList<CustomersModel>(customers, pageNumber, pageSize),
                CustomersListTotal = customers,
                Localizer = _stringLocalizer,
                CurrentPeriod = currentPeriod,
                DateFormatSelected = _userInfos.DateFormatSelected
            };

            #region ViewBag
            ViewBag.LastUpdateSortParm = String.IsNullOrEmpty(sortOrder) ? "LastUpdate_desc" : "";
            ViewBag.NameSortParm = sortOrder == "Name" ? "Name_desc" : "Name";
            ViewBag.CodeSAPSortParm = sortOrder == "CodeSAP" ? "CodeSAP_desc" : "CodeSAP";
            ViewBag.SortType = String.IsNullOrEmpty(sortOrder) ? "LastUpdate_desc" : sortOrder == "CodeSAP" ? "CodeSAP_desc" : sortOrder == "CodeSAP_desc" ? "CodeSAP" : sortOrder == "Name_desc" ? "Name" : sortOrder == "Name" ? "Name_desc" : "";
            #endregion
            // Rendering the view with the indexModel model
            return View(indexModel);
        }

        [HttpGet]
        public ActionResult FilteredCustomers(int monthStart, int monthEnd, int yearStart, int yearEnd, string searchName, string searchCode, string sortOrder, int selectStatus, int? page, string selectedCommercial, string focusedElement)
        {
            int pageSize = 10;
            int pageNumber = page ?? 1;
            string[] status = new string[3];
            // Initialize customer status labels using localization
            status[0] = _stringLocalizer["tableC.headerStatusNew"].Value;
            status[1] = _stringLocalizer["tableC.headerStatusMake"].Value;
            status[2] = _stringLocalizer["tableC.headerStatusMade"].Value;            
            List<SocieteClient> societeClient = _context.SocieteClients.Include(n => n.IdClientNavigation).Include(sc=>sc.IdCommercialNavigation).Where(sc => (_userInfos.IdRole == 1) ? (sc.IdCommercial == _userInfos.IdPersonnel) : (sc.IdAssistantCommercial == _userInfos.IdPersonnel)).ToList();
            Period currentPeriod = new Period(monthStart, monthEnd, yearStart, yearEnd);
            // Create a list of customers based on the selected period, user information, and statuses            
            List<CustomersModel> customers = CustomersModel.CreateCustomerList(societeClient, currentPeriod.MonthStart, currentPeriod.YearStart, currentPeriod.MonthEnd, currentPeriod.YearEnd, _context, _userInfos.IdPersonnel, status);
            List<CustomersModel> customersByCommerciaux = customers.DistinctBy(c => c.CodeSAPCommercial).ToList();
            List<SelectListItem> listCommerciaux = new List<SelectListItem>();
            foreach (var customer in customersByCommerciaux)
            {
                listCommerciaux.Add(new SelectListItem()
                {
                    Value = customer.CodeSAPCommercial,
                    Text = customer.NomCommercial
                });
            }
            // Filter the customer list based on input parameters
            customers = CustomersModel.GetCustomersListFiltered(sortOrder, customers, status, searchName, searchCode, selectedCommercial, selectStatus);

            // Create the view model for the filtered customers list
            IndexViewModel indexModel = new IndexViewModel(status)
            {
                Commerciaux = listCommerciaux,
                SearchedName = searchName,
                SearchedCode = searchCode,
                SelectedStatus = selectStatus,
                CustomersListTotal = customers,
                SelectedCommercial = selectedCommercial,
                Customers = new PagedList<CustomersModel>(customers, pageNumber, pageSize),
                Localizer = _stringLocalizer,
                FocusedInputElement = focusedElement,
                DateFormatSelected = _userInfos.DateFormatSelected
            };

            #region ViewBag
            ViewBag.LastUpdateSortParm = String.IsNullOrEmpty(sortOrder) ? "LastUpdate_desc" : "";
            ViewBag.NameSortParm = sortOrder == "Name" ? "Name_desc" : "Name";
            ViewBag.CodeSAPSortParm = sortOrder == "CodeSAP" ? "CodeSAP_desc" : "CodeSAP";
            ViewBag.SortType = String.IsNullOrEmpty(sortOrder) ? "LastUpdate_desc" : sortOrder == "CodeSAP" ? "CodeSAP_desc" : sortOrder == "CodeSAP_desc" ? "CodeSAP" : sortOrder == "Name_desc" ? "Name" : sortOrder == "Name" ? "Name_desc" : "";
            #endregion
            // Render a partial view with the filtered customer list
            return PartialView("_FilterCustomersView", indexModel);
        }

        [HttpGet]
        public ActionResult CustomersProducts(int? page, string sortOrder, int monthStart, int monthEnd, int yearStart, int yearEnd, int idCustomer, int idCommercial, string searchDescription, string searchCode, int selectedStatus, string collapsedSubtableId)
        {
            int pageSize = 15;
            int pageNumber = page ?? 1;

            string[] status = new string[3];
            status[0] = _stringLocalizer["tableC.headerStatusNew"].Value;
            status[1] = _stringLocalizer["tableC.headerStatusMake"].Value;
            status[2] = _stringLocalizer["tableC.headerStatusMade"].Value;

           // string codeSAPCustomer = idCustomer;
            Client customer = _context.Clients.First(c => c.IdClient == idCustomer);

            monthStart = monthStart == 0 ? Int32.Parse(TempData.Peek("monthStart").ToString()) : monthStart;
            monthEnd = monthEnd == 0 ? Int32.Parse(TempData.Peek("monthEnd").ToString()) : monthEnd;
            yearStart = yearStart == 0 ? Int32.Parse(TempData.Peek("yearStart").ToString()) : yearStart;
            yearEnd = yearEnd == 0 ? Int32.Parse(TempData.Peek("yearEnd").ToString()) : yearEnd;

            CustomersAViewModel customersArticlesModel = new CustomersAViewModel(status);
            List<ProductsModel> products = ProductsModel.CreateProductsList(_context, customer, idCommercial, monthStart, yearStart, monthEnd, yearEnd, status);

            products = ProductsModel.GetProductsListFiltered(sortOrder, products, status, searchDescription, searchCode, selectedStatus, "customersProducts");

            // Afficher uniquement la liste des statuts (Articles)

            // Stocke la liste des articles

            List<ProductsModel> articlesClientList = new List<ProductsModel>();

            foreach (var art in products)
            {
                ProductsModel article = new ProductsModel()
                {
                    CodeSAP = art.CodeSAP,
                    Description = art.Description,
                    Unite = art.Unite,
                };

                articlesClientList.Add(article);
            }

           customersArticlesModel = new CustomersAViewModel(status)
            {
                CodeSAPCustomer = customer.CodeSap,
                IdClient = customer.IdClient,
                LibelleCustomer = customer.Libelle,
                IdCommercial = idCommercial,
                NomCommercial = _context.Personnel.FirstOrDefault(p => p.IdPersonnel == idCommercial).Nom,
                MonthStart = monthStart,
                YearStart = yearStart,
                MonthEnd = monthEnd,
                YearEnd = yearEnd,
                SearchedProductCode = searchCode,
                SearchedProductDescription = searchDescription,
                SelectedStatus = selectedStatus,
                ProductsListTotal = products,
                Products = new PagedList<ProductsModel>(products, pageNumber, pageSize),
                Localizer = _stringLocalizer,
                CollapsedSubtableId = collapsedSubtableId,
                DateFormatSelected = _userInfos.DateFormatSelected,
                RegexCultureDB = _userInfos.RegexCulture,
                DecimalFormatSelected = _userInfos.DecimalFormatCulture,
                SaveTypeSelected = _userInfos.SaveType
                
           };

            TempData["monthStart"] = monthStart;
            TempData["yearStart"] = yearStart;
            TempData["monthEnd"] = monthEnd;
            TempData["yearEnd"] = yearEnd;
            TempData["articlesCliList"] = JsonConvert.SerializeObject(articlesClientList);

            #region ViewBag
            ViewBag.LastUpdateSortParm = String.IsNullOrEmpty(sortOrder) ? "LastUpdate_desc" : "";
            ViewBag.ProductDescriptionSortParm = sortOrder == "ProductDescription" ? "ProductDescription_desc" : "ProductDescription";
            ViewBag.ProductCodeSAPSortParm = sortOrder == "CodeSAP" ? "CodeSAP_desc" : "CodeSAP";
            ViewBag.SortType = String.IsNullOrEmpty(sortOrder) ? "LastUpdate_desc" : sortOrder == "CodeSAP" ? "CodeSAP_desc" : sortOrder == "CodeSAP_desc" ? "CodeSAP" : sortOrder == "ProductDescription_desc" ? "ProductDescription" : sortOrder == "ProductDescription" ? "ProductDescription_desc" : "";
            #endregion

            return View(customersArticlesModel);
        }

        // save forecast //
        [HttpPost]
        public ActionResult CustomersProducts(IFormCollection formValues, int idArticle, int idClient, int? targetedPage, int idCommercial, string searchedProductDescription, string searchedProductCode, string sortType, int? selectedStatus,decimal tarifAEntered, string collapsedSubtableId)
        {
            //var rqf = _contextAccessor.HttpContext.Features.Get<IRequestCultureFeature>();
            //var currentCulture = rqf.RequestCulture.Culture.Name;
            //CultureInfo cultureInfo = new CultureInfo(currentCulture);
  

            string[] filteredValues = formValues.Keys.Where(k => k.Contains("volume")).ToArray<string>();
            string priceA = formValues["TarifAEntered"];
            decimal.TryParse(priceA, NumberStyles.Any, new CultureInfo(_userInfos.DecimalFormatCulture), out decimal formattedAmount);

            tarifAEntered = formattedAmount;
            

            foreach (var key in formValues.Keys.Where(k => k.Contains("volume")).ToArray<string>())
            {
                int volume = formValues[key][0] == "" ? 0 : Convert.ToInt32(formValues[key][0]);
              
                    int mois = Int32.Parse(key.Split("_").ToList()[1]);
                    int annee = Int32.Parse(key.Split("_").ToList()[2]);
                    Prevision updatedPrev = _context.Previsions.FirstOrDefault(p => p.IdClient == idClient && p.IdArticle == idArticle  && p.IdCommercial == idCommercial && p.Mois == mois && p.Annee == annee) ;
                   

                    if (updatedPrev == null)
                    {
                        Prevision newPrevision = null;
                        newPrevision = new Prevision()
                        {
                            IdClient = idClient,
                            IdArticle = idArticle,
                            Mois = mois,
                            Annee = annee,
                            DateCreation = DateTime.Today,
                            DateModification = DateTime.Today,
                            Volume = volume,
                            IdCommercial = idCommercial

                        };
                        _context.Previsions.Add(newPrevision);
                    }

                    else
                    {
                        if(updatedPrev.Volume != formValues[key])
                        {
                            updatedPrev.DateModification = DateTime.Today;
                            updatedPrev.Volume = volume;
                        }

                    }



            }
            TarifArticle updatedTarifArticle = _context.TarifArticles.FirstOrDefault(t => t.IdClient == idClient && t.IdArticle == idArticle && t.IdCommercial == idCommercial);
            if (updatedTarifArticle == null)
            {
                TarifArticle newTarifArticle = null;
                newTarifArticle = new TarifArticle
                {
                    IdClient = idClient,
                    IdArticle = idArticle,
                    IdCommercial = idCommercial,
                    TarifA = tarifAEntered
                };
                _context.TarifArticles.Add(newTarifArticle);
            }
            else
            {
                updatedTarifArticle.TarifA = tarifAEntered;
            }

            _context.SaveChanges();

            return RedirectToAction("CustomersProducts", new { page = targetedPage, idCustomer = idClient, idCommercial = idCommercial ,searchDescription = searchedProductDescription, searchCode = searchedProductCode, selectedStatus = selectedStatus,sortOrder = sortType, collapsedSubtableId = collapsedSubtableId });

        }

        [HttpGet]
        public ActionResult DeleteNewProduct(int idArticle, int idCustomer,int idCommercial,int monthStart, int yearStart,int monthEnd, int yearEnd, string codeSAPClient, int? page, string searchDescription, string searchCode, string sortOrder, int selectedStatus)
        {

            List<Prevision> deletedForecast = _context.Previsions.Where(p => p.IdClient == idCustomer && p.IdCommercial == idCommercial && p.IdArticle == idArticle && (yearStart == yearEnd ? (p.Annee == yearStart && p.Mois >= monthStart && p.Mois <= monthEnd) : ((p.Annee == yearStart && p.Mois >= monthStart) || (p.Annee == yearEnd && p.Mois <= monthEnd)))).ToList();

            _context.Previsions.RemoveRange(deletedForecast);
            _context.SaveChanges();

            return RedirectToAction("CustomersProducts", new { page = page, idCustomer = idCustomer, idCommercial = idCommercial,  searchDescription = searchDescription  , searchCode = searchCode, selectedStatus = selectedStatus, sortOrder = sortOrder });
        }

        [HttpGet]
        public ActionResult FilteredProducts(int? page, string id, string searchDescription, string searchCode, string sortOrder, int selectedStatus, int idCommercial, string focusedElementId, string collapsedSubtableId)
        {
            int pageSize = 15;
            int pageNumber = page ?? 1;

            string[] status = new string[3];
            status[0] = _stringLocalizer["tableC.headerStatusNew"].Value;
            status[1] = _stringLocalizer["tableC.headerStatusMake"].Value;
            status[2] = _stringLocalizer["tableC.headerStatusMade"].Value;

            int monthStart = Int32.Parse(TempData.Peek("monthStart").ToString());
            int monthEnd = Int32.Parse(TempData.Peek("monthEnd").ToString());
            int yearStart = Int32.Parse(TempData.Peek("yearStart").ToString());
            int yearEnd = Int32.Parse(TempData.Peek("yearEnd").ToString());

            string codeSAPCustomer = id;
            Client customer = _context.Clients.First(c => c.CodeSap == codeSAPCustomer);

            CustomersAViewModel customersArticlesModel = new CustomersAViewModel(status)
            {
                CodeSAPCustomer = codeSAPCustomer,
                LibelleCustomer = customer.Libelle,
                IdClient = customer.IdClient,
                IdCommercial = idCommercial,
                NomCommercial = _context.Personnel.FirstOrDefault(p => p.IdPersonnel == idCommercial).Nom,
                MonthStart = monthStart,
                YearStart = yearStart,
                MonthEnd = monthEnd,
                YearEnd = yearEnd,
                SearchedProductDescription = searchDescription,
                SearchedProductCode = searchCode,
                SelectedStatus = selectedStatus,
                Localizer = _stringLocalizer,
                FocusedElementId = focusedElementId,
                CollapsedSubtableId = collapsedSubtableId,
                DateFormatSelected = _userInfos.DateFormatSelected,
                DecimalFormatSelected = _userInfos.DecimalFormatCulture,
                SaveTypeSelected = _userInfos.SaveType
            };

            List<ProductsModel> products = ProductsModel.CreateProductsList(_context, customer, idCommercial, monthStart, yearStart, monthEnd, yearEnd, status);

            products = ProductsModel.GetProductsListFiltered(sortOrder, products, status, searchDescription, searchCode, selectedStatus, "customersProducts");
            customersArticlesModel.Products = new PagedList<ProductsModel>(products, pageNumber, pageSize);
            customersArticlesModel.ProductsListTotal = products;

            #region ViewBag
            ViewBag.LastUpdateSortParm = String.IsNullOrEmpty(sortOrder) ? "LastUpdate_desc" : "";
            ViewBag.ProductDescriptionSortParm = sortOrder == "ProductDescription" ? "ProductDescription_desc" : "ProductDescription";
            ViewBag.ProductCodeSAPSortParm = sortOrder == "CodeSAP" ? "CodeSAP_desc" : "CodeSAP";
            ViewBag.SortType = String.IsNullOrEmpty(sortOrder) ? "LastUpdate_desc" : sortOrder == "CodeSAP_desc" ? "CodeSAP" : sortOrder == "CodeSAP" ? "CodeSAP_desc" : sortOrder == "ProductDescription_desc" ? "ProductDescription" : sortOrder == "ProductDescription" ? "ProductDescription_desc" : "";
            #endregion

            return PartialView("_FilterCustomersProductsView", customersArticlesModel);
        }

        // open CompanyProducts //
        [HttpGet]
        public ActionResult CompanyProducts(int? page, int idCustomer, string sortOrder, int idCommercial)
        {

            int pageSize = 15;
            int pageNumber = page ?? 1;

            string[] status = new string[3];
            status[0] = _stringLocalizer["tableC.headerStatusNew"].Value;
            status[1] = _stringLocalizer["tableC.headerStatusMake"].Value;
            status[2] = _stringLocalizer["tableC.headerStatusMade"].Value;


            //string codeSAPCustomer = idCustomer;
            Client customer = _context.Clients.First(c => c.IdClient == idCustomer);

    

            List<ProductsModel> articlesClientListSaved = new List<ProductsModel>();

            if (TempData.ContainsKey("articlesCliList"))
            {

                articlesClientListSaved = JsonConvert.DeserializeObject<List<ProductsModel>>(TempData.Peek("articlesCliList").ToString());

            }

            // Get articles de la société
            Societe infoSociete = _context.SocieteClients.Include(n => n.IdSocieteNavigation).First(sc => sc.IdCommercial == idCommercial).IdSocieteNavigation;
            List<Division> divisionsSociete = _context.Societes.Include(s => s.Divisions).ThenInclude(d => d.IdArticles).ThenInclude(a => a.LibelleArticles).First(d => d.IdSociete == infoSociete.IdSociete).Divisions.ToList();
            List<ProductsModel> articlesSocieteList = new List<ProductsModel>();
            List<Article> articlesSociete = new List<Article>();


            articlesSociete.AddRange(divisionsSociete.SelectMany(div => div.IdArticles));

            foreach (var art in articlesSociete)
            {
                ProductsModel article = new ProductsModel()
                {
                    CodeSAP = art.CodeSap,
                    Description = articlesSociete.FirstOrDefault(a => a.CodeSap == art.CodeSap).LibelleArticles.FirstOrDefault(l => l.CodeLangue == "FR").Libelle,
                    Unite = art.Unite,
                };

                articlesSocieteList.Add(article);
            }

            var uniqueArticlesSocieteList = articlesSocieteList.GroupBy(asl => asl.CodeSAP).Select(g => g.First()).ToList();

            List<ProductsModel> finalArticles = uniqueArticlesSocieteList.ExceptBy(articlesClientListSaved.Select(ac => ac.CodeSAP), ac => ac.CodeSAP).ToList();

            finalArticles = ProductsModel.GetProductsListFiltered(sortOrder, finalArticles, status, null, null, 0, "");


            CustomersAViewModel customersArticlesModel = new CustomersAViewModel(status)
            {
                CodeSAPCustomer = customer.CodeSap,
                LibelleCustomer = customer.Libelle,
                IdClient = idCustomer,
                SocieteCustomer = infoSociete.NomSociete,
                ProductsListTotal = finalArticles,
                IdCommercial = idCommercial,
                NomCommercial = _context.Personnel.FirstOrDefault(p => p.IdPersonnel == idCommercial).Nom,
                Products = new PagedList<ProductsModel>(finalArticles, pageNumber, pageSize),
                MonthStart = Int16.Parse(TempData.Peek("monthStart").ToString()),
                MonthEnd = Int16.Parse(TempData.Peek("monthEnd").ToString()),
                YearStart = Int16.Parse(TempData.Peek("yearStart").ToString()),
                YearEnd = Int16.Parse(TempData.Peek("yearEnd").ToString()),
                Localizer = _stringLocalizer,
                DateFormatSelected = _userInfos.DateFormatSelected
            };

            #region ViewBag
            ViewBag.CProductDescriptionSortParm = String.IsNullOrEmpty(sortOrder) ? "ProductDescription_desc" : "";
            ViewBag.CProductCodeSAPSortParm = sortOrder == "CodeSAP" ? "CodeSAP_desc" : "CodeSAP";
            ViewBag.SortType = String.IsNullOrEmpty(sortOrder) ? "ProductDescription_desc" : sortOrder == "CodeSAP" ? "CodeSAP_desc" : sortOrder == "CodeSAP_desc" ? "CodeSAP" : "";
            #endregion

            return View(customersArticlesModel);
        }

        // ADD new product to CustomerProduct  //
        [HttpPost]
        public ActionResult CompanyProducts(int idCustomer, string sortOrder, string listSelectedProducts, string addReturnBtn, string addStayBtn, int idCommercial)
        {
            List<string> selectedProducts = listSelectedProducts.Split(",").SkipLast(1).ToList();
            string[] status = new string[3];
            status[0] = _stringLocalizer["tableC.headerStatusNew"].Value;
            status[1] = _stringLocalizer["tableC.headerStatusMake"].Value;
            status[2] = _stringLocalizer["tableC.headerStatusMade"].Value;

            ViewBag.CProductDescriptionSortParm = String.IsNullOrEmpty(sortOrder) ? "ProductDescription_desc" : "";
            ViewBag.CProductCodeSAPSortParm = sortOrder == "CodeSAP" ? "CodeSAP_desc" : "CodeSAP";
            ViewBag.SortType = String.IsNullOrEmpty(sortOrder) ? "ProductDescription_desc" : sortOrder == "CodeSAP" ? "CodeSAP_desc" : sortOrder == "CodeSAP_desc" ? "CodeSAP" : "";

            // Commercial and customer infos

            //string codeSAPCustomer = idCustomer;
            Client customer = _context.Clients.First(c => c.IdClient == idCustomer);

            CustomersAViewModel customersArticlesModel = new CustomersAViewModel(status);
            customersArticlesModel.CodeSAPCustomer = customer.CodeSap;
            customersArticlesModel.LibelleCustomer = customer.Libelle;
            customersArticlesModel.NomCommercial = _context.Personnel.FirstOrDefault(p => p.IdPersonnel == idCommercial).Nom;

            Societe infoSociete = _context.SocieteClients.Include(n => n.IdSocieteNavigation).First(sc => sc.IdCommercial == idCommercial).IdSocieteNavigation;

            List<Division> divisionsSociete = _context.Societes.Include(s => s.Divisions).ThenInclude(d => d.IdArticles).ThenInclude(l => l.LibelleArticles).First(d => d.IdSociete == infoSociete.IdSociete).Divisions.ToList();
            List<Article> articlesSociete = new List<Article>();

            articlesSociete.AddRange(divisionsSociete.SelectMany(div => div.IdArticles));

            string startDateS = TempData.Peek("monthStart").ToString() + "-" + TempData.Peek("yearStart").ToString();
            string endDateS = TempData.Peek("monthEnd").ToString() + "-" + TempData.Peek("yearEnd").ToString();

            DateTime startDate = DateTime.Parse(startDateS);
            DateTime endDate = DateTime.Parse(endDateS);

            Prevision newPrevision = null;


            foreach (var art in selectedProducts)
            {
                for (var date = startDate.Date; date.Date <= endDate.Date; date = date.AddMonths(1))
                {
                    newPrevision = new Prevision()
                    {
                        IdClient = customer.IdClient,
                        IdArticle = articlesSociete.FirstOrDefault(ac => ac.CodeSap == art).IdArticle,
                        Mois = Int32.Parse(date.Month.ToString()),
                        Annee = Int32.Parse(date.Year.ToString()),
                        DateCreation = DateTime.Today,
                        DateModification = DateTime.Today,
                        Volume = 0,
                        IdCommercial = idCommercial

                    };

                    _context.Previsions.Add(newPrevision);
                }
            }

            _context.SaveChanges();

            // Clique sur ajouter et retourner à la page précédente
            if (addReturnBtn != null)
            {

                TempData.Remove("articlesCliList");

                return RedirectToAction("CustomersProducts", new { idCustomer = idCustomer, monthStart = TempData.Peek("monthStart"), yearStart = TempData.Peek("yearStart"), monthEnd = TempData.Peek("monthEnd"), yearEnd = TempData.Peek("yearEnd"), idCommercial = idCommercial });
            }

            // Clique sur ajouter et rester sur la page
            else
            {

                List<ProductsModel> articlesClientListSaved = new List<ProductsModel>();
                if (TempData.ContainsKey("articlesCliList"))
                {

                    articlesClientListSaved = JsonConvert.DeserializeObject<List<ProductsModel>>(TempData.Peek("articlesCliList").ToString());

                    foreach (var codeArt in selectedProducts)
                    {
                        ProductsModel article = new ProductsModel()
                        {
                            CodeSAP = codeArt,
                            Description = articlesSociete.FirstOrDefault(a => a.CodeSap == codeArt).LibelleArticles.FirstOrDefault(l => l.CodeLangue == "FR").Libelle,
                            Unite = articlesSociete.FirstOrDefault(ac => ac.CodeSap == codeArt).Unite,
                        };

                        articlesClientListSaved.Add(article);
                        //articlesSocieteList.Add(article);
                    }

                    TempData["articlesCliList"] = JsonConvert.SerializeObject(articlesClientListSaved);
                }


                return RedirectToAction("CompanyProducts");
            }

            // return redirect 
            // return View(customersArticlesModel); en sorti de méthode post, utiliser return redirect pour recalculer le modèle via l'action en méthode get
            //return view récupère juste le .cshtml et le complète avec le modèle passé

        }

        [HttpGet]
        public async Task<IActionResult> FilteredCompanyProducts(int? page, int monthStart, int yearStart, int monthEnd, int yearEnd, string id, string sortOrder, string searchDescription, string searchCode, string stringSelectedProducts, int idCommercial, string focusedElementId)
        {
            int pageSize = 15;
            int pageNumber = page ?? 1;

            string[] status = new string[3];
            status[0] = _stringLocalizer["tableC.headerStatusNew"].Value;
            status[1] = _stringLocalizer["tableC.headerStatusMake"].Value;
            status[2] = _stringLocalizer["tableC.headerStatusMade"].Value;

            UserInfo user = await _userManager.GetUserAsync(User);
            string codeSAPCustomer = id;
            Client customer = _context.Clients.First(c => c.CodeSap == codeSAPCustomer);

            string[] selectedProducts = stringSelectedProducts == null ? new string[0] : stringSelectedProducts.Split(",").SkipLast(1).ToArray();

            monthStart = 9;
            yearStart = 2023;
            monthEnd = 8;
            yearEnd = 2024;

            List<Prevision> previsions = _context.Previsions.Include(n => n.IdArticleNavigation).Where(p => p.IdClient == customer.IdClient && p.IdCommercial == idCommercial && (yearStart == yearEnd ? (p.Annee == yearStart && p.Mois >= monthStart && p.Mois <= monthEnd) : ((p.Annee == yearStart && p.Mois >= monthStart) || (p.Annee == yearEnd && p.Mois <= monthEnd)))).ToList();
            List<VentePortefeuille> ventePortefeuille = _context.VentePortefeuilles.Include(n => n.IdArticleNavigation).Where(vp => vp.IdClient == customer.IdClient && vp.IdCommercial == idCommercial).ToList();
            List<VentePortefeuille> vente = ventePortefeuille.Where(vp => vp.TypeVentePort == true && (yearStart == yearEnd ? (vp.Annee == yearStart && vp.Mois >= monthStart && vp.Mois <= monthEnd) : ((vp.Annee == yearStart && vp.Mois >= monthStart) || (vp.Annee == yearEnd && vp.Mois <= monthEnd)))).ToList();
            List<VentePortefeuille> venteN_un = ventePortefeuille.Where(vp => vp.TypeVentePort == true && (yearStart == yearEnd ? (vp.Annee == yearStart - 1 && vp.Mois >= monthStart && vp.Mois <= monthEnd) : ((vp.Annee == yearStart - 1 && vp.Mois >= monthStart) || (vp.Annee == yearEnd - 1 && vp.Mois <= monthEnd)))).ToList();
            List<VentePortefeuille> portefeuille = ventePortefeuille.Where(vp => vp.TypeVentePort == false && (yearStart == yearEnd ? (vp.Annee == yearStart && vp.Mois >= monthStart && vp.Mois <= monthEnd) : ((vp.Annee == yearStart && vp.Mois >= monthStart) || (vp.Annee == yearEnd && vp.Mois <= monthEnd)))).ToList();


            List<Article> articles = new List<Article>();


            articles.AddRange(previsions.Select(prev => prev.IdArticleNavigation));
            articles.AddRange(vente.Select(v => v.IdArticleNavigation));
            articles.AddRange(venteN_un.Select(vn => vn.IdArticleNavigation));
            articles.AddRange(portefeuille.Select(p => p.IdArticleNavigation));


            List<Article> uniqueArticles = articles.DistinctBy(a => a.CodeSap).ToList();

            List<ProductsModel> articlesClientList = new List<ProductsModel>();

            foreach (var art in uniqueArticles)
            {
                ProductsModel article = new ProductsModel()
                {
                    CodeSAP = art.CodeSap,
                    Description = _context.LibelleArticles.First(l => l.IdArticle == art.IdArticle).Libelle,
                    Unite = art.Unite,
                };

                articlesClientList.Add(article);
            }

            Societe infoSociete = _context.SocieteClients.Include(n => n.IdSocieteNavigation).First(sc => sc.IdCommercial == idCommercial).IdSocieteNavigation;
            List<Division> divisionsSociete = _context.Societes.Include(s => s.Divisions).ThenInclude(d => d.IdArticles).First(d => d.IdSociete == infoSociete.IdSociete).Divisions.ToList();

            List<ProductsModel> articlesSocieteList = new List<ProductsModel>();
            List<Article> articlesSociete = new List<Article>();

            articlesSociete.AddRange(divisionsSociete.SelectMany(div => div.IdArticles));

            foreach (var art in articlesSociete)
            {
                ProductsModel article = new ProductsModel()
                {
                    CodeSAP = art.CodeSap,
                    Description = _context.LibelleArticles.First(l => l.IdArticle == art.IdArticle).Libelle,
                    Unite = art.Unite,
                };

                articlesSocieteList.Add(article);
            }

            List<ProductsModel> finalArticles = articlesSocieteList.ExceptBy(articlesClientList.Select(ac => ac.CodeSAP), ac => ac.CodeSAP).ToList();
            finalArticles = ProductsModel.GetProductsListFiltered(sortOrder, finalArticles, status, searchDescription, searchCode, 0, "");

            CustomersAViewModel customersArticlesModel = new CustomersAViewModel(status)
            {
                CodeSAPCustomer = codeSAPCustomer,
                LibelleCustomer = customer.Libelle,
                SocieteCustomer = infoSociete.NomSociete,
                SearchedProductDescription = searchDescription,
                SearchedProductCode = searchCode,
                IdCommercial = idCommercial,
                NomCommercial = _context.Personnel.FirstOrDefault(p => p.IdPersonnel == idCommercial).Nom,
                ProductsListTotal = finalArticles,
                Products = new PagedList<ProductsModel>(finalArticles, pageNumber, pageSize),
                IdClient = customer.IdClient,
                Localizer = _stringLocalizer,
                FocusedElementId = focusedElementId
            };

            CustomersAViewModel customersArticle = null;
            if (TempData.ContainsKey("customersArticlesModels")) customersArticle = (CustomersAViewModel)TempData.Peek("customersArticlesModels");

            #region
            ViewBag.CProductDescriptionSortParm = String.IsNullOrEmpty(sortOrder) ? "ProductDescription_desc" : "";
            ViewBag.CProductCodeSAPSortParm = sortOrder == "CodeSAP" ? "CodeSAP_desc" : "CodeSAP";
            ViewBag.SortType = String.IsNullOrEmpty(sortOrder) ? "ProductDescription_desc" : sortOrder == "CodeSAP" ? "CodeSAP_desc" : sortOrder == "CodeSAP_desc" ? "CodeSAP" : "";
            #endregion

            return PartialView("_FilterCompanyProductsView", customersArticlesModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}