using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace HR.Models
{
    public partial class QuanLyNhanSuContext : DbContext
    {
        public QuanLyNhanSuContext()
        {
        }

        public QuanLyNhanSuContext(DbContextOptions<QuanLyNhanSuContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CapNhatLuong> CapNhatLuongs { get; set; }
        public virtual DbSet<CapNhatTrinhDoHocVan> CapNhatTrinhDoHocVans { get; set; }
        public virtual DbSet<ChiTietLuong> ChiTietLuongs { get; set; }
        public virtual DbSet<ChucVuNhanVien> ChucVuNhanViens { get; set; }
        public virtual DbSet<ChuyenNganh> ChuyenNganhs { get; set; }
        public virtual DbSet<HopDong> HopDongs { get; set; }
        public virtual DbSet<KhenThuong> KhenThuongs { get; set; }
        public virtual DbSet<KyLuat> KyLuats { get; set; }
        public virtual DbSet<LuanChuyenNhanVien> LuanChuyenNhanViens { get; set; }
        public virtual DbSet<Luong> Luongs { get; set; }
        public virtual DbSet<LuongA1gv> LuongA1gvs { get; set; }
        public virtual DbSet<LuongA21pg> LuongA21pgs { get; set; }
        public virtual DbSet<LuongA31g> LuongA31gs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhongBan> PhongBans { get; set; }
        public virtual DbSet<ThoiViec> ThoiViecs { get; set; }
        public virtual DbSet<TrinhDoHocVan> TrinhDoHocVans { get; set; }

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

            modelBuilder.Entity<CapNhatLuong>(entity =>
            {
                entity.HasIndex(e => e.MaNhanVien, "IX_FK_CapNhatLuong_Luong");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bhtn).HasColumnName("BHTN");

                entity.Property(e => e.Bhxh).HasColumnName("BHXH");

                entity.Property(e => e.Bhyt).HasColumnName("BHYT");

                entity.Property(e => e.MaNhanVien)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NgayCapNhat).HasColumnType("datetime");

                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithMany(p => p.CapNhatLuongs)
                    .HasForeignKey(d => d.MaNhanVien)
                    .HasConstraintName("FK_CapNhatLuong_Luong");
            });

            modelBuilder.Entity<CapNhatTrinhDoHocVan>(entity =>
            {
                entity.HasKey(e => e.MaCapNhat);

                entity.HasIndex(e => e.MaNhanVien, "IX_FK_CapNhatTrinhDoHocVan_NhanVien");

                entity.Property(e => e.MaNhanVien)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MaTrinhDoCapNhat)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MaTrinhDoTruoc)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NgayCapNhat).HasColumnType("datetime");

                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithMany(p => p.CapNhatTrinhDoHocVans)
                    .HasForeignKey(d => d.MaNhanVien)
                    .HasConstraintName("FK_CapNhatTrinhDoHocVan_NhanVien");
            });

            modelBuilder.Entity<ChiTietLuong>(entity =>
            {
                entity.HasKey(e => new { e.MaChiTietBangLuong, e.MaNhanVien });

                entity.HasIndex(e => e.MaNhanVien, "IX_FK_ChiTietLuong_Luong");

                entity.Property(e => e.MaChiTietBangLuong)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MaNhanVien)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Bhtn).HasColumnName("BHTN");

                entity.Property(e => e.Bhxh).HasColumnName("BHXH");

                entity.Property(e => e.Bhyt).HasColumnName("BHYT");

                entity.Property(e => e.NgayNhanLuong).HasColumnType("datetime");

                entity.Property(e => e.TongTienLuong)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithMany(p => p.ChiTietLuongs)
                    .HasForeignKey(d => d.MaNhanVien)
                    .HasConstraintName("FK_ChiTietLuong_Luong");
            });

            modelBuilder.Entity<ChucVuNhanVien>(entity =>
            {
                entity.HasKey(e => e.MaChucVuNv);

                entity.Property(e => e.MaChucVuNv)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("MaChucVuNV");

                entity.Property(e => e.Hspc).HasColumnName("HSPC");

                entity.Property(e => e.TenChucVu)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ChuyenNganh>(entity =>
            {
                entity.HasKey(e => e.MaChuyenNganh);

                entity.Property(e => e.MaChuyenNganh)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TenChuyenNganh).HasMaxLength(50);
            });

            modelBuilder.Entity<HopDong>(entity =>
            {
                entity.HasKey(e => e.MaHopDong);

                entity.Property(e => e.MaHopDong)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LoaiHopDong).HasMaxLength(50);

                entity.Property(e => e.NgayBatDau).HasColumnType("datetime");

                entity.Property(e => e.NgayKetThuc).HasColumnType("datetime");
            });

            modelBuilder.Entity<KhenThuong>(entity =>
            {
                entity.HasKey(e => e.MaNhanVien);

                entity.Property(e => e.MaNhanVien)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ThangThuong).HasColumnType("datetime");

                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithOne(p => p.KhenThuong)
                    .HasForeignKey<KhenThuong>(d => d.MaNhanVien)
                    .HasConstraintName("FK__Thuong__MaNhanVien");
            });

            modelBuilder.Entity<KyLuat>(entity =>
            {
                entity.HasKey(e => e.MaNhanVien);

                entity.Property(e => e.MaNhanVien)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ThangKiLuat).HasColumnType("datetime");

                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithOne(p => p.KyLuat)
                    .HasForeignKey<KyLuat>(d => d.MaNhanVien)
                    .HasConstraintName("FK_KyLuat_KyLuat");
            });

            modelBuilder.Entity<LuanChuyenNhanVien>(entity =>
            {
                entity.HasKey(e => new { e.MaNhanVien, e.Id });

                entity.Property(e => e.MaNhanVien)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.NgayChuyen).HasColumnType("datetime");

                entity.Property(e => e.PhongBanChuyen)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PhongBanDen)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithMany(p => p.LuanChuyenNhanViens)
                    .HasForeignKey(d => d.MaNhanVien)
                    .HasConstraintName("FK__LuanChuyen__MaNhanVien");
            });

            modelBuilder.Entity<Luong>(entity =>
            {
                entity.HasKey(e => e.MaNhanVien);

                entity.Property(e => e.MaNhanVien)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Bhtn).HasColumnName("BHTN");

                entity.Property(e => e.Bhxh).HasColumnName("BHXH");

                entity.Property(e => e.Bhyt).HasColumnName("BHYT");

                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithOne(p => p.Luong)
                    .HasForeignKey<Luong>(d => d.MaNhanVien)
                    .HasConstraintName("FK_Luong_NhanVien");
            });

            modelBuilder.Entity<LuongA1gv>(entity =>
            {
                entity.HasKey(e => e.BacLuong);

                entity.ToTable("LuongA1GV");
            });

            modelBuilder.Entity<LuongA21pg>(entity =>
            {
                entity.HasKey(e => e.BacLuong);

                entity.ToTable("LuongA21PGS");
            });

            modelBuilder.Entity<LuongA31g>(entity =>
            {
                entity.HasKey(e => e.BacLuong);

                entity.ToTable("LuongA31GS");
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNhanVien);

                entity.HasIndex(e => e.MaChucVuNv, "IX_FK_NhanVien_ChucVuNhanVien");

                entity.HasIndex(e => e.MaTrinhDoHocVan, "IX_FK_NhanVien_TrinhDoHocVan");

                entity.HasIndex(e => e.MaChuyenNganh, "IX_FK__NhanVien__MaChuyenNganh");

                entity.HasIndex(e => e.MaHopDong, "IX_FK__NhanVien__MaHopDong");

                entity.HasIndex(e => e.MaPhongBan, "IX_FK__NhanVien__MaPhongBan");

                entity.Property(e => e.MaNhanVien)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Cmnd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CMND");

                entity.Property(e => e.DanToc).HasMaxLength(10);

                entity.Property(e => e.HoTen).HasMaxLength(50);

                entity.Property(e => e.MaChucVuNv)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("MaChucVuNV");

                entity.Property(e => e.MaChuyenNganh)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MaHopDong)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MaPhongBan)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MaTrinhDoHocVan)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MatKhau)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.QueQuan).HasMaxLength(100);

                entity.Property(e => e.SdtNhanVien)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("sdt_NhanVien");

                entity.HasOne(d => d.MaChucVuNvNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.MaChucVuNv)
                    .HasConstraintName("FK_NhanVien_ChucVuNhanVien");

                entity.HasOne(d => d.MaChuyenNganhNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.MaChuyenNganh)
                    .HasConstraintName("FK__NhanVien__MaChuyenNganh");

                entity.HasOne(d => d.MaHopDongNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.MaHopDong)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__NhanVien__MaHopDong");

                entity.HasOne(d => d.MaPhongBanNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.MaPhongBan)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__NhanVien__MaPhongBan");

                entity.HasOne(d => d.MaTrinhDoHocVanNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.MaTrinhDoHocVan)
                    .HasConstraintName("FK_NhanVien_TrinhDoHocVan");
            });

            modelBuilder.Entity<PhongBan>(entity =>
            {
                entity.HasKey(e => e.MaPhongBan);

                entity.Property(e => e.MaPhongBan)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DiaChi).HasMaxLength(50);

                entity.Property(e => e.SdtPhongBan)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("sdt_PhongBan");

                entity.Property(e => e.TenPhongBan)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ThoiViec>(entity =>
            {
                entity.HasKey(e => e.MaNhanVien);

                entity.Property(e => e.MaNhanVien)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NgayThoiViec).HasColumnType("datetime");

                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithOne(p => p.ThoiViec)
                    .HasForeignKey<ThoiViec>(d => d.MaNhanVien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ThoiViec__MaNhanVien");
            });

            modelBuilder.Entity<TrinhDoHocVan>(entity =>
            {
                entity.HasKey(e => e.MaTrinhDoHocVan);

                entity.Property(e => e.MaTrinhDoHocVan)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TenTrinhDo).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
