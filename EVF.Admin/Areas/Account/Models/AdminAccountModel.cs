using EVF.DAL.DataConnection.EVF;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;



namespace EVF.Admin.Areas.Account.Models
{
    public class AdminAccountModel
    {
        public AdminAccountModel() { }
        public string Username { get; set; }
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
