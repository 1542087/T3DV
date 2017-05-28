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
        public virtual DbSet<ChiNhanhNganHang> ChiNhanhNganHang { get; set; }
        public virtual DbSet<ChiTietGiaoDich> ChiTietGiaoDich { get; set; }
        public virtual DbSet<GiaoDich> GiaoDich { get; set; }
        public virtual DbSet<KhachHang> KhachHang { get; set; }
        public virtual DbSet<MSTUSER> MstUser { get; set; }
        public virtual DbSet<NganHang> NganHang { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<SoTietKiem> SoTietKiem { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoan { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
        public NganHang LayTTNganHangTemp()
        {
            NganHang nh = new NganHang();
            nh.MaNH = "NH0001";
            nh.TenNH = "Asia Commercial Joint Stock Bank";
            nh.LoaiNH = "ACB";
            return nh;

        }
    }
}