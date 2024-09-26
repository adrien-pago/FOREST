using evf.Models.Product;
using EVF.DAL.DataConnection.EVF;
using EVF.DAL.Entity.EVF;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace evf.Models.Customer
{
    public class CustomersModel
    {  
        private int idClient;
        private string codeSAP;
        private string libelle;
        private string nomCommercial;
        private string codeSAPCommercial;
        private int idCommercial;
        private string region;
        private string statut;
        private DateTime? dateModification;
        private int nbJours;

        public int IdClient { get => idClient; set => idClient = value; }
        public string CodeSAP { get => codeSAP; set => codeSAP = value; }

        public string Libelle { get => libelle; set => libelle = value; }
        public string Region { get => region; set => region = value; }

        public string Statut { get => statut; set => statut = value; }
        public string NomCommercial { get => nomCommercial; set => nomCommercial = value; }
        public string CodeSAPCommercial { get => codeSAPCommercial; set => codeSAPCommercial = value; }

        public int IdCommercial { get => idCommercial; set => idCommercial = value; }
        public DateTime? DateModification { get => dateModification; set => dateModification = value; }
        public int NbJours { get => nbJours; set => nbJours = value; }

        public static List<CustomersModel> CreateCustomerList(List<SocieteClient> societeClient, int monthStart, int yearStart, int monthEnd, int yearEnd, EVFContext context, int? userId, string[] status)
        {
            List<CustomersModel> customers = new List<CustomersModel>();
            foreach (var societeC in societeClient)
            {
               Client client = societeC.IdClientNavigation;

               Personnel commercial = societeC.IdCommercialNavigation;  


                string statusFinal = "";


                // Utiliser l'autre model pour récuperer le statut des articles
                CustomersAViewModel customersArticlesModel = new CustomersAViewModel(status);

                List<ProductsModel> products = ProductsModel.CreateProductsList(context, client, commercial.IdPersonnel, monthStart, yearStart, monthEnd, yearEnd, status);
                List<string> allStatuses = new List<string>();

                allStatuses.AddRange(products.Select(p => p.Statut));

                if (allStatuses.Distinct().Count() == 1 && allStatuses[0].Split("_")[1] == "3") {
                    statusFinal = status[2];
                }
                else if (products.Count() == 0)
                {
                    statusFinal = status[0];
                }
                else
                {
                    statusFinal = status[1];
                }


                CustomersModel customer = new CustomersModel()
                {
                    IdClient = client.IdClient,
                    CodeSAP = client.CodeSap,
                    Libelle = client.Libelle,
                    Region = client.Region,
                    Statut = statusFinal,
                    IdCommercial = commercial.IdPersonnel,
                    NomCommercial = commercial.Nom,
                    CodeSAPCommercial = commercial.CodeSap,
                    DateModification = products.Count != 0 ? products.OrderByDescending(p => p.DateModification).First().DateModification : null,
                    NbJours = products.Count != 0 ? products.OrderByDescending(p => p.DateModification).First().NbJours : 0
                };
                customers.Add(customer);
            }
        
            return customers;
        }

        public static List<CustomersModel> GetCustomersListFiltered(string sortOrder, List<CustomersModel> customers, string[] status, string searchName, string searchCode, string selectedCommercial, int selectStatus)
        {
            // Filter customers by name if searchName is provided
            if (searchName != null)
            {
                customers = customers.Where(c => c.Libelle.ToUpper().Contains(searchName.ToUpper())).ToList();
            }

            // Filter customers by code if searchCode is provided
            if (searchCode != null)
            {
                customers = customers.Where(c => c.CodeSAP.Contains(searchCode)).ToList();
            }

            // Filter customers by status if a valid status is selected
            if (selectStatus < status.Length + 1 && selectStatus != 0)
            {
                customers = customers.Where(c => c.Statut == status[selectStatus - 1]).ToList();
            }

            // Filter customers by selected commercial if provided and not the default value ("1")
            if (selectedCommercial != "1" && selectedCommercial != null)
            {
                customers = customers.Where(c => c.CodeSAPCommercial == selectedCommercial).ToList();
            }

            // Filter customers based on the sortOrder parameter
            switch (sortOrder)
            {
                case "Name_desc":
                    customers = customers.OrderByDescending(c => c.Libelle).ToList();
                    break;
                case "Name":
                    customers = customers.OrderBy(c => c.Libelle).ToList();
                    break;
                case "CodeSAP":
                    customers = customers.OrderBy(c => Convert.ToInt32(c.CodeSAP)).ToList();
                    break;
                case "CodeSAP_desc":
                    customers = customers.OrderByDescending(c => Convert.ToInt32(c.CodeSAP)).ToList();
                    break;
                case "LastUpdate_desc":
                    customers = customers.OrderByDescending(c => c.DateModification).ToList();
                    break;
                default:
                    customers = customers.OrderBy(c => c.DateModification).ToList();
                    break;
            }

            // Return the filtered and sorted list of customers
            return customers;
        }
    }
}
