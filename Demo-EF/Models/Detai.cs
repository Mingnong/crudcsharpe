using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Demo_EF.Models;

[Table("DETAI")]
public partial class Detai
{
    [Key]
    [Column("MaDT")]
    [StringLength(10)]
    [Unicode(false)]
    public string MaDt { get; set; } = null!;

    [Column("TenDT")]
    [StringLength(50)]
    public string? TenDt { get; set; }

    [Column(TypeName = "numeric(10, 0)")]
    public decimal? KinhPhi { get; set; }

    [StringLength(50)]
    public string? NoiThucTap { get; set; }

    [InverseProperty("MaDtNavigation")]
    public virtual ICollection<Huongdan> Huongdans { get; set; } = new List<Huongdan>();
}
