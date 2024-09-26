using evf.Models.Product;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace evf.Areas.Account.Models
{
    public class ListsViewModel
    {
        private string usernameToPost;
        public List<UserModel> UsersList { get; set; }

        public IPagedList<CustomerModel> CustomersList { get; set; }

        public int CustomersListTotal;
        public string UsernameToPost { get => usernameToPost; set => usernameToPost = value; }

        public List<SelectListItem> DistinctAssistantList { get; set; }

        public string SelectedAssistant;

        public List<SelectListItem> DistinctSalespeopleList { get; set; }

        public string SelectedSalesperson;

        public List<SocieteModel> SocieteList { get; set; }
    
        public int IdSociete;
    }
}
