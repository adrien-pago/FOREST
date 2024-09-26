using System.ComponentModel.DataAnnotations;

namespace EVF.Admin.Areas.Account.Models
{
    public class LoginModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
