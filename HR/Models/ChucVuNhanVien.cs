using System;
using System.Collections.Generic;

#nullable disable

namespace HR.Models
{
    public partial class ChucVuNhanVien
    {
        public ChucVuNhanVien()
        {
            NhanViens = new HashSet<NhanVien>();
        }

        public string MaChucVuNv { get; set; }
        public string TenChucVu { get; set; }
        public double? Hspc { get; set; }

        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
