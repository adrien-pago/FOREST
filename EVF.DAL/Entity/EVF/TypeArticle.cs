using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVF.DAL.Entity.EVF;

[Table("TypeArticle")]
public partial class TypeArticle
{
    [Key]
    public int IdType { get; set; }

    [StringLength(10)]
    public string? CodeLangue { get; set; }

    [StringLength(60)]
    public string? Libelle { get; set; }

    [InverseProperty("IdTypeNavigation")]
    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
}
