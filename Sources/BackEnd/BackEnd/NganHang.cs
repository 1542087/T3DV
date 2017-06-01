namespace CreditManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("NganHang", Schema = "dbo")]
    public partial class NganHang
    {
        public NganHang()
        {
            this.ChiNhanhNganHang = new HashSet<ChiNhanhNganHang>();
            this.ChiTietGiaoDich = new HashSet<ChiTietGiaoDich>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string MaNH { get; set; }
        public string TenNH { get; set; }
        public string LoaiNH { get; set; }

        public virtual ICollection<ChiNhanhNganHang> ChiNhanhNganHang { get; set; }
        public virtual ICollection<ChiTietGiaoDich> ChiTietGiaoDich { get; set; }
    }
}