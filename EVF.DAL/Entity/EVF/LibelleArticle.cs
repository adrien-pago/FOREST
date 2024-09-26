using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVF.DAL.Entity.EVF;

[Table("LibelleArticle")]
public partial class LibelleArticle
{
    [Key]
    public int IdLibelleArticle { get; set; }

    public int? IdArticle { get; set; }

    [StringLength(20)]
    public string CodeLangue { get; set; } = null!;

    [StringLength(60)]
    public string Libelle { get; set; } = null!;

    [ForeignKey("IdArticle")]
    [InverseProperty("LibelleArticles")]
    public virtual Article? IdArticleNavigation { get; set; }
}
