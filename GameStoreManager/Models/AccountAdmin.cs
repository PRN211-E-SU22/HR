using System;
using System.Collections.Generic;

#nullable disable

namespace GameStoreManager.Models
{
    public partial class AccountAdmin
    {
        public int AccountId { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
