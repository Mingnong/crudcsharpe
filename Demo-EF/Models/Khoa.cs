using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Demo_EF.Models;

[Table("KHOA")]
public partial class Khoa
{
    [Key]
    [StringLength(5)]
    [Unicode(false)]
    public string MaKhoa { get; set; } = null!;

    [StringLength(50)]
    public string? TenKhoa { get; set; }

    [Column("SDT")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Sdt { get; set; }

    [InverseProperty("MaKhoaNavigation")]
    public virtual ICollection<Sinhvien> Sinhviens { get; set; } = new List<Sinhvien>();
}
