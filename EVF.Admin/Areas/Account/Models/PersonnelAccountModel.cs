using EVF.DAL.DataConnection.EVF;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EVF.Admin.Areas.Account.Models
{
    public class PersonnelAccountModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

        public int IdPersonnelSel { get; set; }

        public List<SelectListItem> PersonnelList { get; set; }


        public PersonnelAccountModel() { }

        public void getPersonnelList(EVFContext context, RoleManager<IdentityRole> rolesManager)
        {
            //List<SelectListItem> roles = new List<SelectListItem>();
            //rolesManager.Roles.ToList().ForEach(r =>
            //{
            //    var roleName = r.Name == "AssistantCommercial" ? "Assistante commerciale" : r.Name;
            //    roles.Add(new SelectListItem()
            //    {
            //        Value = r.NormalizedName,
            //        Text = roleName
            //    });
            //});

            //RolesList = roles;

            List<SelectListItem> personnelList = new List<SelectListItem>();
            context.Personnel.ToList().ForEach(p =>
            {
                personnelList.Add(new SelectListItem()
                {
                    Value = p.IdPersonnel.ToString(),
                    Text = rolesManager.Roles.FirstOrDefault(r => r.Id == p.IdRole.ToString()).NormalizedName + "-" + p.Nom + '-' + p.CodeSap,
                });
            });

            PersonnelList = personnelList;

        }

    }
}
