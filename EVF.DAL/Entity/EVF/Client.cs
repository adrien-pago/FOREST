using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVF.DAL.Entity.EVF;

[Table("Client")]
public partial class Client
{
    [Key]
    public int IdClient { get; set; }

    [Column("CodeSAP")]
    [StringLength(10)]
    public string CodeSap { get; set; } = null!;

    [StringLength(200)]
    public string Libelle { get; set; } = null!;

    [Column("ISOPays")]
    [StringLength(2)]
    public string Isopays { get; set; } = null!;

    [StringLength(3)]
    public string? Region { get; set; }

    [InverseProperty("IdClientNavigation")]
    public virtual ICollection<Prevision> Previsions { get; set; } = new List<Prevision>();

    [InverseProperty("IdClientNavigation")]
    public virtual ICollection<SocieteClient> SocieteClients { get; set; } = new List<SocieteClient>();

    [InverseProperty("IdClientNavigation")]
    public virtual ICollection<TarifArticle> TarifArticles { get; set; } = new List<TarifArticle>();

    [InverseProperty("IdClientNavigation")]
    public virtual ICollection<VentePortefeuille> VentePortefeuilles { get; set; } = new List<VentePortefeuille>();
}
