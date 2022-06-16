using System;
using System.Collections.Generic;

#nullable disable

namespace HR.Models
{
    public partial class TrinhDoHocVan
    {
        public TrinhDoHocVan()
        {
            NhanViens = new HashSet<NhanVien>();
        }

        public string MaTrinhDoHocVan { get; set; }
        public string TenTrinhDo { get; set; }
        public double? HeSoBac { get; set; }

        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
