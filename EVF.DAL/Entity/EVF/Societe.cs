using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVF.DAL.Entity.EVF;

[Table("Societe")]
public partial class Societe
{
    [Key]
    public int IdSociete { get; set; }

    [StringLength(20)]
    public string NomSociete { get; set; } = null!;

    [StringLength(20)]
    public string OrgCommerciale { get; set; } = null!;

    [StringLength(20)]
    public string CodeLangue { get; set; } = null!;

    [StringLength(4)]
    [Unicode(false)]
    public string? CodeSociete { get; set; }

    [InverseProperty("IdSocieteNavigation")]
    public virtual ICollection<Division> Divisions { get; set; } = new List<Division>();

    [InverseProperty("IdSocieteNavigation")]
    public virtual ICollection<Personnel> Personnel { get; set; } = new List<Personnel>();

    [InverseProperty("IdSocieteNavigation")]
    public virtual ICollection<SocieteClient> SocieteClients { get; set; } = new List<SocieteClient>();
}
