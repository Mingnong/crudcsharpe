using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Demo_EF.Models;

[Table("SINHVIEN")]
public partial class Sinhvien
{
    [Key]
    [Column("MaSV")]
    public int MaSv { get; set; }

    [Column("TenSV")]
    [StringLength(100)]
    public string? TenSv { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string? GioiTinh { get; set; }

    [Column(TypeName = "date")]
    public DateTime? NgaySinh { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string? MaKhoa { get; set; }

    [InverseProperty("MaSvNavigation")]
    public virtual ICollection<Huongdan> Huongdans { get; set; } = new List<Huongdan>();

    [ForeignKey("MaKhoa")]
    [InverseProperty("Sinhviens")]
    public virtual Khoa? MaKhoaNavigation { get; set; }
}
