namespace evf.Areas.Account.Models
{
    public class UserModel
    {
        public string Name { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }

        public int? IdPersonnel {  get; set; }

        public bool IsLockout {  get; set; }

    }
}
