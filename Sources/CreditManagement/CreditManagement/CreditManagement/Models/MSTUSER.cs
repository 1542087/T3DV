namespace CreditManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("MSTUSER", Schema = "dbo")]
    public partial class MSTUSER
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal PSN_CD { get; set; }
        public string USERID { get; set; }
        public string PASSWD { get; set; }
        public string USERNAME { get; set; }
        public Nullable<System.DateTime> DELETE_YMD { get; set; }
        public Nullable<System.DateTime> INSERT_YMD { get; set; }
    }
}