using EVF.DAL.DataConnection.EVF;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace evf.Areas.Account.Models
{
    public class PersonnelAccountModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        

        [Required]
        public string Role { get; set; }

        public string IdPersonnelSel { get; set; }

        public List<SelectListItem> PersonnelList { get; set; }


        public PersonnelAccountModel() { }

        public void getPersonnelList(EVFContext context, RoleManager<IdentityRole> rolesManager)
        {

            List<SelectListItem> personnelList = new List<SelectListItem>();
            context.Personnel.ToList().ForEach(p =>
            {
                personnelList.Add(new SelectListItem()
                {
                    Value = p.IdPersonnel.ToString() + "-" + p.CodeSap,
                    Text = p.Nom + " / " + p.CodeSap + " / " + rolesManager.Roles.FirstOrDefault(r => r.Id == p.IdRole.ToString()).NormalizedName,
                });
            });

            PersonnelList = personnelList.OrderBy(p => p.Text).ToList();

        }

    }
}
