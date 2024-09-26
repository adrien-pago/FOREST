using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVF.DAL.Entity.EVF;

[Table("Prevision")]
public partial class Prevision
{
    [Key]
    public int IdPrevision { get; set; }

    public int IdClient { get; set; }

    public int IdArticle { get; set; }

    public int? Mois { get; set; }

    public int? Annee { get; set; }

    [Column(TypeName = "date")]
    public DateTime? DateCreation { get; set; }

    [Column(TypeName = "date")]
    public DateTime? DateModification { get; set; }

    public int Volume { get; set; }

    public int IdCommercial { get; set; }

    [ForeignKey("IdArticle")]
    [InverseProperty("Previsions")]
    public virtual Article IdArticleNavigation { get; set; } = null!;

    [ForeignKey("IdClient")]
    [InverseProperty("Previsions")]
    public virtual Client IdClientNavigation { get; set; } = null!;

    [ForeignKey("IdCommercial")]
    [InverseProperty("Previsions")]
    public virtual Personnel IdCommercialNavigation { get; set; } = null!;
}
