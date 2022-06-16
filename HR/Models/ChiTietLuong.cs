using System;
using System.Collections.Generic;

#nullable disable

namespace HR.Models
{
    public partial class ChiTietLuong
    {
        public string MaChiTietBangLuong { get; set; }
        public string MaNhanVien { get; set; }
        public double LuongCoBan { get; set; }
        public double? Bhxh { get; set; }
        public double? Bhyt { get; set; }
        public double? Bhtn { get; set; }
        public double? PhuCap { get; set; }
        public double? ThueThuNhap { get; set; }
        public int? TienThuong { get; set; }
        public int? TienPhat { get; set; }
        public DateTime NgayNhanLuong { get; set; }
        public string TongTienLuong { get; set; }

        public virtual Luong MaNhanVienNavigation { get; set; }
    }
}
