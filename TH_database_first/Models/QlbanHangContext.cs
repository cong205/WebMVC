using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TH_database_first.Models;

public partial class QlbanHangContext : DbContext
{
    public QlbanHangContext()
    {
    }

    public QlbanHangContext(DbContextOptions<QlbanHangContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblChatlieu> TblChatlieus { get; set; }

    public virtual DbSet<TblChiTietHdban> TblChiTietHdbans { get; set; }

    public virtual DbSet<TblHang> TblHangs { get; set; }

    public virtual DbSet<TblHdban> TblHdbans { get; set; }

    public virtual DbSet<TblKhach> TblKhaches { get; set; }

    public virtual DbSet<TblNhanvien> TblNhanviens { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-SBAL8UV\\SQLEXPRESS;Database=QLBanHang;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblChatlieu>(entity =>
        {
            entity.HasKey(e => e.MaChatlieu).HasName("PK__tblChatl__DDC1A44ED65E8BB3");

            entity.ToTable("tblChatlieu");

            entity.Property(e => e.MaChatlieu)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TenChatlieu).HasMaxLength(50);
        });

        modelBuilder.Entity<TblChiTietHdban>(entity =>
        {
            entity.HasKey(e => new { e.MaHdban, e.MaHang }).HasName("PK__tblChiTi__828C639B1D640EE6");

            entity.ToTable("tblChiTietHDBan", tb => tb.HasTrigger("trg_CapNhatThanhTien"));

            entity.Property(e => e.MaHdban)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaHDBan");
            entity.Property(e => e.MaHang)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.GiamGia).HasDefaultValue(0.0);
            entity.Property(e => e.ThanhTien).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.MaHangNavigation).WithMany(p => p.TblChiTietHdbans)
                .HasForeignKey(d => d.MaHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblChiTie__MaHan__571DF1D5");

            entity.HasOne(d => d.MaHdbanNavigation).WithMany(p => p.TblChiTietHdbans)
                .HasForeignKey(d => d.MaHdban)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblChiTie__MaHDB__5629CD9C");
        });

        modelBuilder.Entity<TblHang>(entity =>
        {
            entity.HasKey(e => e.MaHang).HasName("PK__tblHang__19C0DB1DF4D6CC25");

            entity.ToTable("tblHang");

            entity.Property(e => e.MaHang)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Anh).HasMaxLength(255);
            entity.Property(e => e.DonGiaBan).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DonGiaNhap).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.GhiChu).HasMaxLength(255);
            entity.Property(e => e.MaChatlieu)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TenHang).HasMaxLength(100);

            entity.HasOne(d => d.MaChatlieuNavigation).WithMany(p => p.TblHangs)
                .HasForeignKey(d => d.MaChatlieu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblHang__MaChatl__4BAC3F29");
        });

        modelBuilder.Entity<TblHdban>(entity =>
        {
            entity.HasKey(e => e.MaHdban).HasName("PK__tblHDBan__43106E2A62631B65");

            entity.ToTable("tblHDBan");

            entity.Property(e => e.MaHdban)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaHDBan");
            entity.Property(e => e.MaKhach)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaNhanvien)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TongTien).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.MaKhachNavigation).WithMany(p => p.TblHdbans)
                .HasForeignKey(d => d.MaKhach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblHDBan__MaKhac__534D60F1");

            entity.HasOne(d => d.MaNhanvienNavigation).WithMany(p => p.TblHdbans)
                .HasForeignKey(d => d.MaNhanvien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblHDBan__MaNhan__52593CB8");
        });

        modelBuilder.Entity<TblKhach>(entity =>
        {
            entity.HasKey(e => e.MaKhach).HasName("PK__tblKhach__D0CB8DDD20B910F1");

            entity.ToTable("tblKhach");

            entity.Property(e => e.MaKhach)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.DienThoai).HasMaxLength(20);
            entity.Property(e => e.TenKhach).HasMaxLength(100);
        });

        modelBuilder.Entity<TblNhanvien>(entity =>
        {
            entity.HasKey(e => e.MaNhanvien).HasName("PK__tblNhanv__81C97F05613E4385");

            entity.ToTable("tblNhanvien");

            entity.Property(e => e.MaNhanvien)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.DienThoai).HasMaxLength(20);
            entity.Property(e => e.GioiTinh).HasMaxLength(10);
            entity.Property(e => e.TenNhanvien).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("User");

            entity.Property(e => e.PassWord)
                .HasMaxLength(50)
                .HasColumnName("passWord");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasColumnName("userName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
