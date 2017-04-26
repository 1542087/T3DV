namespace CreditManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class NhanVien
    {
        public NhanVien()
        {
            this.ChiTietGiaoDich = new HashSet<ChiTietGiaoDich>();
            this.SoTietKiem = new HashSet<SoTietKiem>();
            this.TaiKhoan = new HashSet<TaiKhoan>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string MaNV { get; set; }
        public Nullable<int> cmnd { get; set; }
        public string ChucVu { get; set; }
        public string TenNV { get; set; }

        [ForeignKey("ChiNhanhNganHang")]
        public string CNTrucThuoc { get; set; }
        public Nullable<System.DateTime> NgayVaoCongTy { get; set; }
        public Nullable<System.DateTime> NgayRaCongTy { get; set; }
        public string DiaChi { get; set; }
        public Nullable<int> SoDienThoai { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string ChuThich { get; set; }

        public virtual ChiNhanhNganHang ChiNhanhNganHang { get; set; }
        public virtual ICollection<ChiTietGiaoDich> ChiTietGiaoDich { get; set; }
        public virtual ICollection<SoTietKiem> SoTietKiem { get; set; }
        public virtual ICollection<TaiKhoan> TaiKhoan { get; set; }
    }
}