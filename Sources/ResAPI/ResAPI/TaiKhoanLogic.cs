using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditManagement.Models;
namespace ResAPI
{
    class TaiKhoanLogic
    {
        public List<TaiKhoan> SearchAllAccount()
        {
            List<TaiKhoan> lst = new List<TaiKhoan>();
            try
            {

                using (var context = new BankingContext())
                {
                    lst = context.TaiKhoan.ToList();
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TaiKhoan> SearchAccountByCondition(TaiKhoan sc)
        {
            List<TaiKhoan> lst = new List<TaiKhoan>();
            try
            {
                var ctx = new BankingContext();
                var query = from ct in ctx.TaiKhoan
                            select ct;

                if (sc != null)
                {
                    if (sc.MaTK != null)
                    {
                        query = query.Where(p => p.MaTK.Equals(sc.MaTK));
                    }

                    if (sc.SoTK != null)
                    {
                        query = query.Where(p => p.SoTK.Equals(sc.SoTK));
                    }
                    if (sc.MaKH != null)
                    {
                        query = query.Where(p => p.MaKH.Equals(sc.MaKH));
                    }
                    if (sc.NgayTao != null)
                    {
                        query = query.Where(p => p.NgayTao.Equals(sc.NgayTao));
                    }
                    if (sc.NgayHuy != null)
                    {
                        query = query.Where(p => p.NgayHuy.Equals(sc.NgayHuy));
                    }
                    if (sc.MaNV != null)
                    {
                        query = query.Where(p => p.MaNV.Equals(sc.MaNV));
                    }
                    if (sc.MaCN != null)
                    {
                        query = query.Where(p => p.MaCN.Equals(sc.MaCN));
                    }

                    if (sc.ChuThich != null)
                    {
                        query = query.Where(p => p.ChuThich.Contains(sc.ChuThich));
                    }

                }

                lst = query.ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertAccount(TaiKhoan objInsert)
        {
            try
            {
                var ctx = new BankingContext();
                ctx.TaiKhoan.Add(objInsert);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void UpdateAccount(TaiKhoan objUpdate)
        {
            try
            {
                var ctx = new BankingContext();
                ctx.Entry(objUpdate).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteAccount(List<TaiKhoan> lstID)
        {
            try
            {
                var ctx = new BankingContext();
                List<TaiKhoan> lst = new List<TaiKhoan>();
                for (int i = 0; i < lstID.Count; i++)
                {
                    lst.Add(new TaiKhoan { MaKH = lstID[i].MaKH, 
                                           MaNV = lstID[i].MaNV,
                                           MaCN = lstID[i].MaCN});
                    ctx.Entry(lst[i]).State = System.Data.Entity.EntityState.Deleted;
                }
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
