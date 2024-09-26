using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVF.DAL.Entity.EVF;

[PrimaryKey("IdSociete", "IdClient", "IdCommercial", "IdAssistantCommercial")]
[Table("SocieteClient")]
public partial class SocieteClient
{
    [Key]
    public int IdSociete { get; set; }

    [Key]
    public int IdClient { get; set; }

    [Key]
    public int IdCommercial { get; set; }

    [Key]
    public int IdAssistantCommercial { get; set; }

    [ForeignKey("IdAssistantCommercial")]
    [InverseProperty("SocieteClientIdAssistantCommercialNavigations")]
    public virtual Personnel IdAssistantCommercialNavigation { get; set; } = null!;

    [ForeignKey("IdClient")]
    [InverseProperty("SocieteClients")]
    public virtual Client IdClientNavigation { get; set; } = null!;

    [ForeignKey("IdCommercial")]
    [InverseProperty("SocieteClientIdCommercialNavigations")]
    public virtual Personnel IdCommercialNavigation { get; set; } = null!;

    [ForeignKey("IdSociete")]
    [InverseProperty("SocieteClients")]
    public virtual Societe IdSocieteNavigation { get; set; } = null!;
}
