using System;
using System.Collections.Generic;

#nullable disable

namespace HR.Models
{
    public partial class KyLuat
    {
        public string MaNhanVien { get; set; }
        public string LyDo { get; set; }
        public DateTime ThangKiLuat { get; set; }
        public int? TienKyLuat { get; set; }

        public virtual NhanVien MaNhanVienNavigation { get; set; }
    }
}
