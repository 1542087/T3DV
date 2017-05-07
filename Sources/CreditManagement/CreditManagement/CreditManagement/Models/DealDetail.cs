using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CreditManagement.Models
{
    public class DealDetail
    {
        public DataSet ChiTietGD { get; set; }

        public RutTien RutTienModel { get; set; }

        public ChuyenKhoan ChuyenKhoanModel { get; set; }

        public string TenKH { get; set; }

        public List<ChiNhanhNganHang> dsNganHang { get; set; }
    }
}