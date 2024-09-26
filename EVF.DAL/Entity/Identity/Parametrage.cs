using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVF.DAL.Entity.Identity
{
    public class Parametrage
    {
        [Key]
        public int IdParametrage { get; set; }

      
        public string IdAspUser { get; set; }

        public string LangueBD { get; set; }

        public bool VuMAJ { get; set; }

        public string FormatDate { get; set; } = "yyyy/MM/dd";

        public string DecimalFormat { get; set; } = "en-US";

        public string SaveType { get; set; } = "Individual";

        [ForeignKey(nameof(IdAspUser))]
        [InverseProperty(nameof(UserInfo.ParametrageNav))]
        public UserInfo UserInfoNav { get; set; }
    }
}
