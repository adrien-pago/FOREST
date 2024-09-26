using evf.Controllers;
using evf.Models.Product;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using X.PagedList;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace evf.Models.Customer
{
    public class CustomersAViewModel
    {
        private int monthStart;
        private int idArticle;
        private int idClient;
        private int idCommercial;
        private string nomCommercial;
        private Date dateModification;
        private int yearStart;
        private int monthEnd;
        private int yearEnd;
        private int selectedStatus;
        private bool productFound;
        private string codeSAPCustomer;
        private string libelleCustomer;
        private string searchedProductCode;
        private string searchedProductDescription;
        private string dateFormatSelected;
        private string focusedElementId;
        private string societeCustomer;
        private int? targetedPage;
        private string sortType;
        private IPagedList<ProductsModel> products;
        private List<ProductsModel> selectedProducts;
        private List<ProductsModel> productsListTotal;
        private ProductsModel product;
        private string listSelectedProducts;
        private string listNewForecasts;
        private string collapsedSubtableId;
        private string regexCultureDB;
        private string decimalFormatSelected;
        private string saveTypeSelected;


        public CustomersAViewModel(string[] status)
        {
            this.product = new ProductsModel();
            Statuses = new List<SelectListItem>();
            selectedStatus = 4;

            for (var i = 0; i < status.Count(); i++)
            {
                Statuses.Add(new SelectListItem()
                {
                    Text = status[i].Split('_')[0],
                    Value = (i+1).ToString()
                });

            }
        }


        public int MonthStart { get => monthStart; set => monthStart = value; }
        public int YearStart { get => yearStart; set => yearStart = value; }
        public int MonthEnd { get => monthEnd; set => monthEnd = value; }
        public int YearEnd { get => yearEnd; set => yearEnd = value; }
        public string CodeSAPCustomer { get => codeSAPCustomer; set => codeSAPCustomer = value; }
        public string LibelleCustomer { get => libelleCustomer; set => libelleCustomer = value; }

        public string SearchedProductCode { get => searchedProductCode; set => searchedProductCode = value; }

        public string SearchedProductDescription { get => searchedProductDescription; set => searchedProductDescription = value; }

        public string SocieteCustomer { get => societeCustomer; set => societeCustomer = value; }
        public IPagedList<ProductsModel> Products { get => products; set => products = value; }
        public List<ProductsModel> ProductsListTotal { get => productsListTotal; set => productsListTotal = value; }
        public ProductsModel Product { get => product; set => product = value; }
        public int SelectedStatus { get => selectedStatus; set => selectedStatus = value; }
        public List<SelectListItem> Statuses { get; set; }
        public List<ProductsModel> SelectedProducts { get => selectedProducts; set => selectedProducts = value; }
        public string ListSelectedProducts { get => listSelectedProducts; set => listSelectedProducts = value; }
        public string ListNewForecasts { get => listNewForecasts; set => listNewForecasts = value; }
        public int IdArticle { get => idArticle; set => idArticle = value; }
        public int IdClient { get => idClient; set => idClient = value; }
        public int? TargetedPage { get => targetedPage; set => targetedPage = value; }
        public string SortType { get => sortType; set => sortType = value; }
        public int IdCommercial { get => idCommercial; set => idCommercial = value; }
        public string NomCommercial { get => nomCommercial; set => nomCommercial = value; }

        public bool ProductFound { get => productFound; set => productFound = value; }
        public Date DateModification { get => dateModification; set => dateModification = value; }
        

        public IStringLocalizer<ForecastEntryController> Localizer { get; set; }
        public string FocusedElementId { get => focusedElementId; set => focusedElementId = value; }
        public string CollapsedSubtableId { get => collapsedSubtableId; set => collapsedSubtableId = value; }
        public string DateFormatSelected { get => dateFormatSelected; set => dateFormatSelected = value; }
        public string RegexCultureDB { get => regexCultureDB; set => regexCultureDB = value; }
        public string DecimalFormatSelected { get => decimalFormatSelected; set => decimalFormatSelected = value; }
        public string SaveTypeSelected { get => saveTypeSelected; set => saveTypeSelected = value; }
    }
}
