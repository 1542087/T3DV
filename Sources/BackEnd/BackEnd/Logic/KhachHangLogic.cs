using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditManagement.Models;

namespace BackEnd
{
    class KhachHangLogic
    {
        public bool InsertCustomer(KhachHang customer)
        {
            try
            {
                using (var context = new BankingContext())
                {
                    context.KhachHang.Add(customer);
                    context.SaveChanges();
                    return true;
                }
            }
            catch(Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public bool UpdateCustomer(KhachHang customer)
        {
            try
            {
                using (var context = new BankingContext())
                {
                    context.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public bool DeleteCustomer(List<string> lstKH)
        {
            try
            {
                var ctx = new BankingContext();
                List<KhachHang> lstKhachHang = new List<KhachHang>();
                for (int i = 0; i < lstKH.Count; i++)
                {
                    lstKhachHang.Add(new KhachHang { MaKH = lstKH[i] });
                    ctx.Entry(lstKhachHang[i]).State = System.Data.Entity.EntityState.Deleted;
                }
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }

        }
        public List<KhachHang> SearchAllCustomer()
        {
            List<KhachHang> lstKhachHang = new List<KhachHang>();
            try
            {

                using (var context = new BankingContext())
                {
                    lstKhachHang = context.KhachHang.ToList();
                }

                return lstKhachHang;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<KhachHang> SearchCustomerByCondition(KhachHang sc)
        {
            List<KhachHang> lstKhachhang = new List<KhachHang>();
            try
            {
                var ctx = new BankingContext();
                var query = from ct in ctx.KhachHang
                            select ct;

                if (sc != null)
                {
                    if (sc.MaKH != null)
                    {
                        query = query.Where(p => p.MaKH.Equals(sc.MaKH));
                    }

                    if (sc.cmnd != null)
                    {
                        query = query.Where(p => p.cmnd.Equals(sc.cmnd));
                    }

                    if (sc.TenKH != null)
                    {
                        query = query.Where(p => p.TenKH.Contains(sc.TenKH));
                    }

                    if (sc.SoDienThoai != null)
                    {
                        query = query.Where(p => p.SoDienThoai.Equals(sc.SoDienThoai));
                    }

                    if (sc.NgaySinh != null)
                    {
                        query = query.Where(p => p.NgaySinh.Equals(sc.NgaySinh));
                    }
                    if (sc.GioiTinh != null)
                    {
                        query = query.Where(p => p.GioiTinh.Equals(sc.GioiTinh));
                    }

                }

                lstKhachhang = query.ToList();
                return lstKhachhang;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
