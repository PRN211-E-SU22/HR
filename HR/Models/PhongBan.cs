using System;
using System.Collections.Generic;

#nullable disable

namespace HR.Models
{
    public partial class PhongBan
    {
        public PhongBan()
        {
            NhanViens = new HashSet<NhanVien>();
        }

        public string MaPhongBan { get; set; }
        public string TenPhongBan { get; set; }
        public string DiaChi { get; set; }
        public string SdtPhongBan { get; set; }

        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
