using System;
using System.Collections.Generic;

#nullable disable

namespace HR.Models
{
    public partial class CapNhatTrinhDoHocVan
    {
        public int MaCapNhat { get; set; }
        public string MaNhanVien { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public string MaTrinhDoTruoc { get; set; }
        public string MaTrinhDoCapNhat { get; set; }

        public virtual NhanVien MaNhanVienNavigation { get; set; }
    }
}
