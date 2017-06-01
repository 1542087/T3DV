namespace CreditManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("KhachHang", Schema = "dbo")]
    public partial class KhachHang
    {
        public KhachHang()
        {
            this.GiaoDich = new HashSet<GiaoDich>();
            this.SoTietKiem = new HashSet<SoTietKiem>();
            this.TaiKhoan = new HashSet<TaiKhoan>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string MaKH { get; set; }
        public string cmnd { get; set; }
        public string TenKH { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string NgaySinh { get; set; }
        public string GioiTinh { get; set; }

        public virtual ICollection<GiaoDich> GiaoDich { get; set; }
        public virtual ICollection<SoTietKiem> SoTietKiem { get; set; }
        public virtual ICollection<TaiKhoan> TaiKhoan { get; set; }
    }
}