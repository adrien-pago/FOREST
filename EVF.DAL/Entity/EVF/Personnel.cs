using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVF.DAL.Entity.EVF;

public partial class Personnel
{
    [Key]
    public int IdPersonnel { get; set; }

    [StringLength(100)]
    public string Nom { get; set; } = null!;

    [Column("CodeSAP")]
    [StringLength(15)]
    public string CodeSap { get; set; } = null!;

    public int IdRole { get; set; }

    public int? IdSociete { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Email { get; set; }

    [ForeignKey("IdSociete")]
    [InverseProperty("Personnel")]
    public virtual Societe? IdSocieteNavigation { get; set; }

    [InverseProperty("IdCommercialNavigation")]
    public virtual ICollection<Prevision> Previsions { get; set; } = new List<Prevision>();

    [InverseProperty("IdAssistantCommercialNavigation")]
    public virtual ICollection<SocieteClient> SocieteClientIdAssistantCommercialNavigations { get; set; } = new List<SocieteClient>();

    [InverseProperty("IdCommercialNavigation")]
    public virtual ICollection<SocieteClient> SocieteClientIdCommercialNavigations { get; set; } = new List<SocieteClient>();

    [InverseProperty("IdCommercialNavigation")]
    public virtual ICollection<TarifArticle> TarifArticles { get; set; } = new List<TarifArticle>();

    [InverseProperty("IdCommercialNavigation")]
    public virtual ICollection<VentePortefeuille> VentePortefeuilles { get; set; } = new List<VentePortefeuille>();
}
