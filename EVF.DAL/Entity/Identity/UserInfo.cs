using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVF.DAL.Entity.EVF;

namespace EVF.DAL.Entity.Identity
{
    public partial class UserInfo : IdentityUser
    {
        public int? IdPersonnel { get; set; }

        public string? Nom { get; set; }

        [ForeignKey(nameof(IdPersonnel))]
        public virtual Personnel PersonnelNav { get; set; }

        [InverseProperty(nameof(Parametrage.UserInfoNav))]
        public virtual Parametrage ParametrageNav { get; set; }
    }


}
