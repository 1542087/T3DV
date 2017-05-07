namespace CreditManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

      [Table("SoTietKiem", Schema = "dbo")]
    public partial class SoTietKiem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string MaSTK { get; set; }
         [ForeignKey("KhachHang")]
        public string MaKH { get; set; }
        public Nullable<System.DateTime> NgayTao { get; set; }
        public Nullable<System.DateTime> NgayHuy { get; set; }
          [ForeignKey("NhanVien")]
        public string MaNV { get; set; }
         [ForeignKey("ChiNhanhNganHang")]
        public string MaCN { get; set; }
        public string LoaiTK { get; set; }
        public Nullable<decimal> SoTien { get; set; }

        public virtual ChiNhanhNganHang ChiNhanhNganHang { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}