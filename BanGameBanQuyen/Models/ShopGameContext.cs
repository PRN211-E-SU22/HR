using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace GameStoreManager.Models
{
    public partial class ShopGameContext : DbContext
    {
        public ShopGameContext()
        {
        }

        public ShopGameContext(DbContextOptions<ShopGameContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountAdmin> AccountAdmins { get; set; }
        public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual DbSet<DanhMucSp> DanhMucSps { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseSqlServer(config.GetConnectionString("MyConStr"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AccountAdmin>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PK__AccountA__349DA586F125ABA7");

                entity.ToTable("AccountAdmin");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.MatKhau)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TaiKhoan)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ChiTietDonHang>(entity =>
            {
                entity.HasKey(e => e.MaCtdh)
                    .HasName("PK__ChiTietD__1E4E40F07144E9F1");

                entity.ToTable("ChiTietDonHang");

                entity.Property(e => e.MaCtdh).HasColumnName("MaCTDH");

                entity.Property(e => e.MaDh).HasColumnName("MaDH");

                entity.Property(e => e.MaSp).HasColumnName("MaSP");

                entity.HasOne(d => d.MaDhNavigation)
                    .WithMany(p => p.ChiTietDonHangs)
                    .HasForeignKey(d => d.MaDh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChiTietDon__MaDH__403A8C7D");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.ChiTietDonHangs)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChiTietDon__MaSP__412EB0B6");
            });

            modelBuilder.Entity<DanhMucSp>(entity =>
            {
                entity.HasKey(e => e.MaDm)
                    .HasName("PK__DanhMucS__2725866E3F8293B4");

                entity.ToTable("DanhMucSP");

                entity.Property(e => e.MaDm).HasColumnName("MaDM");

                entity.Property(e => e.AnhDm).HasColumnName("AnhDM");

                entity.Property(e => e.MoTaDm)
                    .HasMaxLength(500)
                    .HasColumnName("MoTaDM");

                entity.Property(e => e.TenDm)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("TenDM");
            });

            modelBuilder.Entity<DonHang>(entity =>
            {
                entity.HasKey(e => e.MaDh)
                    .HasName("PK__DonHang__27258661C82A228A");

                entity.ToTable("DonHang");

                entity.Property(e => e.MaDh).HasColumnName("MaDH");

                entity.Property(e => e.MaKh).HasColumnName("MaKH");

                entity.Property(e => e.NgayTao).HasColumnType("date");

                entity.Property(e => e.NgayThanhToan).HasColumnType("date");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.DonHangs)
                    .HasForeignKey(d => d.MaKh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DonHang__MaKH__4222D4EF");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.MaKh)
                    .HasName("PK__KhachHan__2725CF1E613B5902");

                entity.ToTable("KhachHang");

                entity.Property(e => e.MaKh).HasColumnName("MaKH");

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.Diachi)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Ngaysinh).HasColumnType("date");

                entity.Property(e => e.TenKh)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("TenKH");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSp)
                    .HasName("PK__SanPham__2725081C6FC6CBEB");

                entity.ToTable("SanPham");

                entity.Property(e => e.MaSp).HasColumnName("MaSP");

                entity.Property(e => e.AnhSp)
                    .IsRequired()
                    .HasColumnName("AnhSP");

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.GiaSp).HasColumnName("GiaSP");

                entity.Property(e => e.MaDm).HasColumnName("MaDM");

                entity.Property(e => e.MotaSp)
                    .IsRequired()
                    .HasColumnName("MotaSP");

                entity.Property(e => e.NgaySua).HasColumnType("date");

                entity.Property(e => e.TenSp)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("TenSP");

                entity.Property(e => e.VideoSp).HasColumnName("VideoSP");

                entity.HasOne(d => d.MaDmNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.MaDm)
                    .HasConstraintName("FK__SanPham__MaDM__4316F928");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
