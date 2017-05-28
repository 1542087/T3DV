namespace CreditManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("ChiTietGiaoDich", Schema = "dbo")]
    public partial class ChiTietGiaoDich
    {

        [Column(Order = 0), Key, ForeignKey("GiaoDich")]
        public string MaGD { get; set; }

        [ForeignKey("KhachHang")]
        public string MaKH { get; set; }

        [Column(Order = 1), Key]
        public Nullable<System.DateTime> NgayGD { get; set; }

        [ForeignKey("NhanVien")]
        public string MaNV { get; set; }

        [ForeignKey("ChiNhanhNganHang")]
        public string MaCNNH { get; set; }
        public Nullable<decimal> SoTienGD { get; set; }
        public string NoiDungGD { get; set; }
        public string TrangThai { get; set; }
        public Nullable<int> PhiGD { get; set; }
        public string MaTKNguoiNhan { get; set; }

        public virtual ChiNhanhNganHang ChiNhanhNganHang { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        public virtual GiaoDich GiaoDich { get; set; }
    }
}