using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVF.DAL.Entity.EVF;

[Table("Article")]
public partial class Article
{
    [Key]
    public int IdArticle { get; set; }

    public int? IdType { get; set; }

    [Column("CodeSAP")]
    [StringLength(20)]
    public string CodeSap { get; set; } = null!;

    [StringLength(20)]
    public string Unite { get; set; } = null!;

    [ForeignKey("IdType")]
    [InverseProperty("Articles")]
    public virtual TypeArticle? IdTypeNavigation { get; set; }

    [InverseProperty("IdArticleNavigation")]
    public virtual ICollection<LibelleArticle> LibelleArticles { get; set; } = new List<LibelleArticle>();

    [InverseProperty("IdArticleNavigation")]
    public virtual ICollection<Prevision> Previsions { get; set; } = new List<Prevision>();

    [InverseProperty("IdArticleNavigation")]
    public virtual ICollection<TarifArticle> TarifArticles { get; set; } = new List<TarifArticle>();

    [InverseProperty("IdArticleNavigation")]
    public virtual ICollection<VentePortefeuille> VentePortefeuilles { get; set; } = new List<VentePortefeuille>();

    [ForeignKey("IdArticle")]
    [InverseProperty("IdArticles")]
    public virtual ICollection<Division> IdDivisions { get; set; } = new List<Division>();
}
