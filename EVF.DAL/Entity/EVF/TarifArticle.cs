using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVF.DAL.Entity.EVF;

[Table("TarifArticle")]
public partial class TarifArticle
{
    [Key]
    public int IdTarifArticle { get; set; }

    public int IdCommercial { get; set; }

    public int IdClient { get; set; }

    public int IdArticle { get; set; }

    [Column(TypeName = "decimal(10, 4)")]
    public decimal TarifA { get; set; }

    [ForeignKey("IdArticle")]
    [InverseProperty("TarifArticles")]
    public virtual Article IdArticleNavigation { get; set; } = null!;

    [ForeignKey("IdClient")]
    [InverseProperty("TarifArticles")]
    public virtual Client IdClientNavigation { get; set; } = null!;

    [ForeignKey("IdCommercial")]
    [InverseProperty("TarifArticles")]
    public virtual Personnel IdCommercialNavigation { get; set; } = null!;
}
