namespace CreditManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ChiNhanhNganHang
    {
        public ChiNhanhNganHang()
        {
            this.NhanVien = new HashSet<NhanVien>();
            this.ChiTietGiaoDich = new HashSet<ChiTietGiaoDich>();
            this.SoTietKiem = new HashSet<SoTietKiem>();
            this.TaiKhoan = new HashSet<TaiKhoan>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string MaCN { get; set; }
        public string LoaiCN { get; set; }
        public string DiaChi { get; set; }
        public string TenCN { get; set; }
        public Nullable<int> DTNoiBo { get; set; }
         [ForeignKey("NganHang")]
        public string LoaiNH { get; set; }
        public string ChuThich { get; set; }

        public virtual ICollection<NhanVien> NhanVien { get; set; }
        public virtual NganHang NganHang { get; set; }
        public virtual ICollection<ChiTietGiaoDich> ChiTietGiaoDich { get; set; }
        public virtual ICollection<SoTietKiem> SoTietKiem { get; set; }
        public virtual ICollection<TaiKhoan> TaiKhoan { get; set; }
    }
}