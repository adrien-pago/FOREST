using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVF.DAL.Entity.EVF;

[Table("PatchNote")]
public partial class PatchNote
{
    [StringLength(50)]
    public string? Titre { get; set; }

    public string? Explication { get; set; }

    [Column(TypeName = "date")]
    public DateTime? Date { get; set; }

    [Key]
    public int IdPatchNote { get; set; }

    [StringLength(8)]
    public string? VersionMajeur { get; set; }

    [StringLength(8)]
    public string? NumeroCorrectif { get; set; }
}
