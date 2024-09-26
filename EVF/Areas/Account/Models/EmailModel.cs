using System.ComponentModel.DataAnnotations;

namespace evf.Areas.Account.Models
{
    public class EmailModel
    {
        private string email;

        [Required]
        public string Email { get => email; set => email = value; }
    }
}
