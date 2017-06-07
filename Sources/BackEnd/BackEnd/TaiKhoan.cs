namespace CreditManagement.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

     [Table("TaiKhoan", Schema = "dbo")]
    public partial class TaiKhoan
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string MaTK { get; set; }
        public Nullable<int> SoTK { get; set; }
         [ForeignKey("KhachHang")]
        public string MaKH { get; set; }
        public Nullable<System.DateTime> NgayTao { get; set; }
        public Nullable<System.DateTime> NgayHuy { get; set; }
         [ForeignKey("NhanVien")]
        public string MaNV { get; set; }
          [ForeignKey("ChiNhanhNganHang")]
        public string MaCN { get; set; }
        public string ChuThich { get; set; }
        public decimal SoDu { get; set; }

        public virtual ChiNhanhNganHang ChiNhanhNganHang { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}