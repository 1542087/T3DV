namespace CreditManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("GiaoDich", Schema = "dbo")]
    public partial class GiaoDich
    {
        public GiaoDich()
        {
            this.ChiTietGiaoDich = new HashSet<ChiTietGiaoDich>();
        }

        [Key]
        public string MaGD { get; set; }

        public string MaKH { get; set; }
        public Nullable<decimal> SoTien { get; set; }
        public Nullable<System.DateTime> NgayCapNhat { get; set; }

        public virtual ICollection<ChiTietGiaoDich> ChiTietGiaoDich { get; set; }
    }
}