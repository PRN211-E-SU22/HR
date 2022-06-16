using System;
using System.Collections.Generic;

#nullable disable

namespace HR.Models
{
    public partial class ChuyenNganh
    {
        public ChuyenNganh()
        {
            NhanViens = new HashSet<NhanVien>();
        }

        public string MaChuyenNganh { get; set; }
        public string TenChuyenNganh { get; set; }

        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
