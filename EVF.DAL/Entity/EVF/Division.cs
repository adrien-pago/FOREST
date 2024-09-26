using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVF.DAL.Entity.EVF;

[Table("Division")]
public partial class Division
{
    [Key]
    public int IdDivision { get; set; }

    public int? IdSociete { get; set; }

    [StringLength(4)]
    [Unicode(false)]
    public string? CodeDivision { get; set; }

    [ForeignKey("IdSociete")]
    [InverseProperty("Divisions")]
    public virtual Societe? IdSocieteNavigation { get; set; }

    [ForeignKey("IdDivision")]
    [InverseProperty("IdDivisions")]
    public virtual ICollection<Article> IdArticles { get; set; } = new List<Article>();
}
