using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Demo_EF.Models;

[PrimaryKey("MaSv", "MaGv", "MaDt")]
[Table("HUONGDAN")]
public partial class Huongdan
{
    [Key]
    [Column("MaSV")]
    public int MaSv { get; set; }

    [Key]
    [Column("MaGV")]
    public int MaGv { get; set; }

    [Key]
    [Column("MaDT")]
    [StringLength(10)]
    [Unicode(false)]
    public string MaDt { get; set; } = null!;

    [Column(TypeName = "decimal(5, 2)")]
    public decimal? KetQua { get; set; }

    [ForeignKey("MaDt")]
    [InverseProperty("Huongdans")]
    public virtual Detai MaDtNavigation { get; set; } = null!;

    [ForeignKey("MaGv")]
    [InverseProperty("Huongdans")]
    public virtual Giangvien MaGvNavigation { get; set; } = null!;

    [ForeignKey("MaSv")]
    [InverseProperty("Huongdans")]
    public virtual Sinhvien MaSvNavigation { get; set; } = null!;
}
