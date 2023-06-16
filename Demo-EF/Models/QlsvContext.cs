using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Demo_EF.Models;

public partial class QlsvContext : DbContext
{
    public QlsvContext()
    {
    }

    public QlsvContext(DbContextOptions<QlsvContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Detai> Detais { get; set; }

    public virtual DbSet<Giangvien> Giangviens { get; set; }

    public virtual DbSet<Huongdan> Huongdans { get; set; }

    public virtual DbSet<Khoa> Khoas { get; set; }

    public virtual DbSet<Sinhvien> Sinhviens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=DB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Detai>(entity =>
        {
            entity.Property(e => e.MaDt).IsFixedLength();
        });

        modelBuilder.Entity<Giangvien>(entity =>
        {
            entity.Property(e => e.MaGv).ValueGeneratedNever();
            entity.Property(e => e.MaKhoa).IsFixedLength();
        });

        modelBuilder.Entity<Huongdan>(entity =>
        {
            entity.Property(e => e.MaDt).IsFixedLength();

            entity.HasOne(d => d.MaDtNavigation).WithMany(p => p.Huongdans).HasConstraintName("FK_HUONGDAN_DETAI");

            entity.HasOne(d => d.MaGvNavigation).WithMany(p => p.Huongdans).HasConstraintName("FK_HUONGDAN_GIANGVIEN");

            entity.HasOne(d => d.MaSvNavigation).WithMany(p => p.Huongdans).HasConstraintName("FK_HUONGDAN_SINHVIEN");
        });

        modelBuilder.Entity<Khoa>(entity =>
        {
            entity.Property(e => e.MaKhoa).IsFixedLength();
            entity.Property(e => e.Sdt).IsFixedLength();
            entity.Property(e => e.Filter)
            .HasMaxLength(255)
            .HasComputedColumnSql("LOWER([MaKhoa] + [TenKhoa] + [SDT])");
        });

        modelBuilder.Entity<Sinhvien>(entity =>
        {
            entity.Property(e => e.MaSv).ValueGeneratedNever();
            entity.Property(e => e.GioiTinh).IsFixedLength();
            entity.Property(e => e.MaKhoa).IsFixedLength();

            entity.HasOne(d => d.MaKhoaNavigation).WithMany(p => p.Sinhviens)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_SINHVIEN_KHOA");
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
