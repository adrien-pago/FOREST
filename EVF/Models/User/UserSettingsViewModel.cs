using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace evf.Models.User
{
    public class UserSettingsViewModel
    {
        private int idParametrage;
        private string username;
        private string societe;
        private string email;
        private string langueBD;
        private string formatDate;
        private string formatDecimal;
        private string saveType;

        public List<SelectListItem> LangueOptions { get; set; }
        public List<SelectListItem> FormatDateOptions { get; set; }
        public List<SelectListItem> FormatDecimalOptions { get;set; }
        public List<SelectListItem> SaveTypeOptions { get; set; }

        public int IdParametrage { get => idParametrage; set => idParametrage = value; }
        public string Username { get => username; set => username = value; }
        public string Societe { get => societe; set => societe = value; }
        public string Email { get => email; set => email = value; }
        public string LangueBD { get => langueBD; set => langueBD = value; }

        [DefaultValue("yyyy/MM/dd")]
        public string FormatDate { get => formatDate; set => formatDate = value; }

        [DefaultValue("en-US")]
        public string FormatDecimal { get => formatDecimal; set => formatDecimal = value; }

        [DefaultValue("Individual")]
        public string SaveType { get => saveType; set => saveType = value; }

        public UserSettingsViewModel(string username, string societe, string email, string langueBD, List<SelectListItem> cultureList, string formatDate, List<SelectListItem> formatDateList,string formatDecimal,List<SelectListItem> formatDecimalList, List<SelectListItem> saveTypeList, string saveType)
        {
            LangueOptions = cultureList;
            FormatDateOptions = formatDateList;
            FormatDecimalOptions = formatDecimalList;
            SaveTypeOptions = saveTypeList;
            this.username = username;
            this.societe = societe;
            this.email = email;
            this.langueBD = langueBD;
            this.formatDate = formatDate;
            this.formatDecimal = formatDecimal;
            this.saveType = saveType;
        }

    }
}
