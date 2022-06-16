using System;
using System.Collections.Generic;

#nullable disable

namespace HR.Models
{
    public partial class KhenThuong
    {
        public string MaNhanVien { get; set; }
        public DateTime ThangThuong { get; set; }
        public string LyDo { get; set; }
        public int? TienThuong { get; set; }

        public virtual NhanVien MaNhanVienNavigation { get; set; }
    }
}
