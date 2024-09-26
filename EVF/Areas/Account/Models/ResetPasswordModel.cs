using System.ComponentModel.DataAnnotations;

namespace evf.Areas.Account.Models
{
    public class ResetPasswordModel
    {
        private string email;
        private string password;
        private string confirmPassword;

        public string Email { get => email; set => email = value; }

        [DataType(DataType.Password)]
        public string Password { get => password; set => password = value; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get => confirmPassword; set => confirmPassword = value; }
    }
}
