using evf.Controllers;
using evf.Models.Customer;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Microsoft.Identity.Client;
using X.PagedList;

namespace evf.Models
{
    public class IndexViewModel
    {

        private int selectedStatus;

        private string searchedName;
        private string searchedCode;
        private string dateFormatSelected;

        private string focusedInputElement;
        private bool customerFound;
        private string selectedCommercial;
        private Period currentPeriod;

        private readonly Campaign campaigns;

        private IPagedList<CustomersModel> customers;

        private List<CustomersModel> customersListTotal;

        private CustomersModel customer;

        public IStringLocalizer<ForecastEntryController> Localizer { get; set; }


        public IndexViewModel(string[] status)
        {

            this.campaigns = new Campaign();
            this.customer = new CustomersModel();

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

        public IPagedList<CustomersModel> Customers { get => customers; set => customers = value; }
        public CustomersModel Customer { get => customer; set => customer = value; }

        public int SelectedStatus { get => selectedStatus; set => selectedStatus = value; }
   

        public string SearchedName { get => searchedName; set => searchedName = value; }
        public string SearchedCode { get => searchedCode; set => searchedCode = value; }


        public List<SelectListItem> Commerciaux { get; set; }
        public List<SelectListItem> Statuses { get; set; }
        public Campaign Campaigns { get => campaigns; }
        public List<CustomersModel> CustomersListTotal { get => customersListTotal; set => customersListTotal = value; }
        public string SelectedCommercial { get => selectedCommercial; set => selectedCommercial = value; }
        public bool CustomerFound { get => customerFound; set => customerFound = value; }
        public Period CurrentPeriod { get => currentPeriod; set => currentPeriod = value; }
        public string FocusedInputElement { get => focusedInputElement; set => focusedInputElement = value; }
        public string DateFormatSelected { get => dateFormatSelected; set => dateFormatSelected = value; }
    }

   
    public class Campaign
    {
        private readonly int monthStart = 9;
        private readonly int monthEnd = 8;
        private int yearStartCC;
        private int yearEndCC;

        public int MonthStart => monthStart;

        public int MonthEnd => monthEnd;

        public int YearStartCC { get => yearStartCC; }
        public int YearEndCC { get => yearEndCC; }

        public int YearStartNC { get => yearStartCC + 1; }
        public int YearEndNC { get => yearEndCC + 1; }

        public Campaign()
        {
            DateTime currentDate = DateTime.Now;
            int currentMonth = currentDate.Month;
            int currentYear = currentDate.Year;

            if (currentMonth < 09)
            {
                yearStartCC = currentYear - 1;
                yearEndCC = currentYear;
            }
            else
            {

                yearStartCC = currentYear;
                yearEndCC = currentYear + 1;
            }
        }

    }

    public class Period
    {

        private int monthStart;
        private int yearStart;
        private int monthEnd;
        private int yearEnd;

        public int MonthStart { get => monthStart; set => monthStart = value; }
        public int YearStart { get => yearStart; set => yearStart = value; }
        public int MonthEnd { get => monthEnd; set => monthEnd = value; }
        public int YearEnd { get => yearEnd; set => yearEnd = value; }

        public Period(int monthStart, int monthEnd, int yearStart, int yearEnd)
        {
            Campaign Campaigns = new Campaign();
            this.monthStart = monthStart == 0 ? Campaigns.MonthStart : monthStart;
            this.yearStart = yearStart == 0 ? Campaigns.YearStartCC : yearStart;
            this.monthEnd = monthEnd == 0 ? Campaigns.MonthEnd : monthEnd;
            this.yearEnd = yearEnd == 0 ? Campaigns.YearEndCC : yearEnd;
        }
    }
}
