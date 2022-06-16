using System;
using System.Collections.Generic;

#nullable disable

namespace HR.Models
{
    public partial class CapNhatLuong
    {
        public int Id { get; set; }
        public string MaNhanVien { get; set; }
        public int LuongHienTai { get; set; }
        public int LuongSauCapNhat { get; set; }
        public double? Bhxh { get; set; }
        public double? Bhyt { get; set; }
        public double? Bhtn { get; set; }
        public double? PhuCap { get; set; }
        public double? ThueThuNhap { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public double? HeSoLuong { get; set; }

        public virtual Luong MaNhanVienNavigation { get; set; }
    }
}
