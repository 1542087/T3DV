using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditManagement.Models;
namespace ResAPI
{
    class NganHangLogic
    {
        public List<NganHang> SearchAllBanking()
        {
            List<NganHang> lst = new List<NganHang>();
            try
            {

                using (var context = new BankingContext())
                {
                    lst = context.NganHang.ToList();
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<NganHang> SearchBankingByCondition(NganHang sc)
        {
            List<NganHang> lst = new List<NganHang>();
            try
            {
                var ctx = new BankingContext();
                var query = from ct in ctx.NganHang
                            select ct;

                if (sc != null)
                {
                    if (sc.MaNH != null)
                    {
                        query = query.Where(p => p.MaNH.Equals(sc.MaNH));
                    }

                    if (sc.TenNH != null)
                    {
                        query = query.Where(p => p.TenNH.Contains(sc.TenNH));
                    }

                    if (sc.LoaiNH != null)
                    {
                        query = query.Where(p => p.LoaiNH.Equals(sc.LoaiNH));
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

        public void InsertBanking(NganHang objInsert)
        {
            try
            {
                var ctx = new BankingContext();
                ctx.NganHang.Add(objInsert);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void UpdateBanking(NganHang objUpdate)
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

        public void DeleteBanking(List<string> lstID)
        {
            try
            {
                var ctx = new BankingContext();
                List<NganHang> lst = new List<NganHang>();
                for (int i = 0; i < lstID.Count; i++)
                {
                    lst.Add(new NganHang { MaNH = lstID[i] });
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
