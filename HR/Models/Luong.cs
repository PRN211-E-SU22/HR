using System;
using System.Collections.Generic;

#nullable disable

namespace HR.Models
{
    public partial class Luong
    {
        public Luong()
        {
            CapNhatLuongs = new HashSet<CapNhatLuong>();
            ChiTietLuongs = new HashSet<ChiTietLuong>();
        }

        public string MaNhanVien { get; set; }
        public int LuongToiThieu { get; set; }
        public double? HeSoLuong { get; set; }
        public double? Bhxh { get; set; }
        public double? Bhyt { get; set; }
        public double? Bhtn { get; set; }
        public double? PhuCap { get; set; }
        public double? ThueThuNhap { get; set; }

        public virtual NhanVien MaNhanVienNavigation { get; set; }
        public virtual ICollection<CapNhatLuong> CapNhatLuongs { get; set; }
        public virtual ICollection<ChiTietLuong> ChiTietLuongs { get; set; }
    }
}
