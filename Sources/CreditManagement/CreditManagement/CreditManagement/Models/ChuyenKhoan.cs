using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CreditManagement.Models
{
    public class ChuyenKhoan
    {
        public string MaTK { get; set; }

        public string HinhThucCK { get; set; }

        public string MaTKDen { get; set; }

        [StringLength(10)]
        public int SoTien { get; set; }

        [StringLength(100)]
        public string NoiDung { get; set; }

        [StringLength(100)]
        public int PhiGD { get; set; }
    }
}