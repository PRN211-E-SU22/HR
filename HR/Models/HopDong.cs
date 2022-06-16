using System;
using System.Collections.Generic;

#nullable disable

namespace HR.Models
{
    public partial class HopDong
    {
        public HopDong()
        {
            NhanViens = new HashSet<NhanVien>();
        }

        public string MaHopDong { get; set; }
        public string LoaiHopDong { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string GhiChu { get; set; }

        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
