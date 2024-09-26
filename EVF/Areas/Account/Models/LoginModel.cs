using System.ComponentModel.DataAnnotations;

namespace evf.Areas.Account.Models
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
