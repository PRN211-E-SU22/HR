using System;
using System.Collections.Generic;

#nullable disable

namespace HR.Models
{
    public partial class ThoiViec
    {
        public string MaNhanVien { get; set; }
        public string Lydo { get; set; }
        public DateTime NgayThoiViec { get; set; }

        public virtual NhanVien MaNhanVienNavigation { get; set; }
    }
}
