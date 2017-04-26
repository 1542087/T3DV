using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CreditManagement.Models
{
    public class BankingContext : DbContext
    {
        public BankingContext()
            : base("name=BankingSystem") 
        {
        }
        public virtual DbSet<GiaoDich> GiaoDich { get; set; }
        public virtual DbSet<ChiTietGiaoDich> CTGiaoDich { get; set; }
    }
}