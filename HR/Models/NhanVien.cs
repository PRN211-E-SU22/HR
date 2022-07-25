using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace HR.Models
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            CapNhatTrinhDoHocVans = new HashSet<CapNhatTrinhDoHocVan>();
            LuanChuyenNhanViens = new HashSet<LuanChuyenNhanVien>();
        }

        [Required(ErrorMessage = "Nhập mã nhân viên")]
        [RegularExpression(@"[A-Za-z0-9]*$", ErrorMessage = "Tài khoản chứa kí tự đặc biệt")]
        [MaxLength(30, ErrorMessage = "Vượt quá số kí tự 30")]
        public string MaNhanVien { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Nhập mật khẩu")]
        [MaxLength(50, ErrorMessage = "Vượt quá số kí tự 50")]
        public string MatKhau { get; set; }

        public string HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string QueQuan { get; set; }
        public string HinhAnh { get; set; }
        public int? GioiTinh { get; set; }
        public string DanToc { get; set; }

        [MaxLength(11, ErrorMessage = "sdt tối đa 11 số")]
        [RegularExpression(@"[0-9]*$", ErrorMessage = "chỉ được nhập số")]
        public string SdtNhanVien { get; set; }
        public string MaChucVuNv { get; set; }
        public bool TrangThai { get; set; }
        public string MaPhongBan { get; set; }
        public string MaHopDong { get; set; }
        public string MaChuyenNganh { get; set; }
        public string MaTrinhDoHocVan { get; set; }
        public string Cmnd { get; set; }

        public virtual ChucVuNhanVien MaChucVuNvNavigation { get; set; }
        public virtual ChuyenNganh MaChuyenNganhNavigation { get; set; }
        public virtual HopDong MaHopDongNavigation { get; set; }
        public virtual PhongBan MaPhongBanNavigation { get; set; }
        public virtual TrinhDoHocVan MaTrinhDoHocVanNavigation { get; set; }
        public virtual KhenThuong KhenThuong { get; set; }
        public virtual KyLuat KyLuat { get; set; }
        public virtual Luong Luong { get; set; }
        public virtual ThoiViec ThoiViec { get; set; }
        public virtual ICollection<CapNhatTrinhDoHocVan> CapNhatTrinhDoHocVans { get; set; }
        public virtual ICollection<LuanChuyenNhanVien> LuanChuyenNhanViens { get; set; }
    }
}
