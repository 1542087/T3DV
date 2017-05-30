namespace CreditManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

     [Table("ChuyenKhoan", Schema = "dbo")]
    public class ChuyenKhoan
    {
           [Display(Name = "MaTK")]
        public string MaTK { get; set; }

        public string SoDuTK { get; set; }

        public string HinhThucCK { get; set; }

        public string NganHang { get; set; }

        [Required]
        [Display(Name = "Tài khoản đến")]
        public string TaiKhoanDen { get; set; }

        [Required]
        [Range(1, 10000000000)]
        [DataType(DataType.Currency)]
        public string SoTien { get; set; }

        public string PhiGiaoDich { get; set; }

        public string NoiDung { get; set; }
    }
}