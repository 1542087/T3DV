namespace CreditManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class RutTien
    {
       
        public string MaTK { get; set; }

        public string SoDuTK { get; set; }

        [Range(1, 10000000000)]
        [Required]
        public string SoTien { get; set; }

        public string PhiGiaoDich { get; set; }

    }
}