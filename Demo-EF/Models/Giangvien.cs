using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Demo_EF.Models;

[Table("GIANGVIEN")]
public partial class Giangvien
{
    [Key]
    [Column("MaGV")]
    public int MaGv { get; set; }

    [Column("TenGV")]
    [StringLength(100)]
    public string? TenGv { get; set; }

    [Column(TypeName = "numeric(10, 0)")]
    public decimal? Luong { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string? MaKhoa { get; set; }

    [InverseProperty("MaGvNavigation")]
    public virtual ICollection<Huongdan> Huongdans { get; set; } = new List<Huongdan>();
}
