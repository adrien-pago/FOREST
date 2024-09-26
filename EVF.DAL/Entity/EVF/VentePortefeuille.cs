using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVF.DAL.Entity.EVF;

[Table("VentePortefeuille")]
public partial class VentePortefeuille
{
    [Key]
    public int IdVentePort { get; set; }

    public int IdClient { get; set; }

    public int IdCommercial { get; set; }

    public int IdArticle { get; set; }

    public int Mois { get; set; }

    public int Annee { get; set; }

    public bool TypeVentePort { get; set; }

    public int Volume { get; set; }

    [ForeignKey("IdArticle")]
    [InverseProperty("VentePortefeuilles")]
    public virtual Article IdArticleNavigation { get; set; } = null!;

    [ForeignKey("IdClient")]
    [InverseProperty("VentePortefeuilles")]
    public virtual Client IdClientNavigation { get; set; } = null!;

    [ForeignKey("IdCommercial")]
    [InverseProperty("VentePortefeuilles")]
    public virtual Personnel IdCommercialNavigation { get; set; } = null!;
}
