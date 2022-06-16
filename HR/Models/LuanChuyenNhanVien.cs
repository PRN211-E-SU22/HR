using System;
using System.Collections.Generic;

#nullable disable

namespace HR.Models
{
    public partial class LuanChuyenNhanVien
    {
        public string MaNhanVien { get; set; }
        public int Id { get; set; }
        public DateTime NgayChuyen { get; set; }
        public string LyDoChuyen { get; set; }
        public string PhongBanChuyen { get; set; }
        public string PhongBanDen { get; set; }

        public virtual NhanVien MaNhanVienNavigation { get; set; }
    }
}
