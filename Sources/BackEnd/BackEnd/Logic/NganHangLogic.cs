using System;
using System.Collections.Generic;
using System.Linq;
using CreditManagement.Models;

namespace BackEnd
{
    class NganHangLogic
    {
        public List<CreditManagement.Models.NganHang> SearchAllBanking()
        {
            List<CreditManagement.Models.NganHang> lst = new List<CreditManagement.Models.NganHang>();
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

        public List<CreditManagement.Models.NganHang> SearchBankingByCondition(CreditManagement.Models.NganHang sc)
        {
            List<CreditManagement.Models.NganHang> lst = new List<CreditManagement.Models.NganHang>();
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

        public bool InsertBanking(CreditManagement.Models.NganHang objInsert)
        {
            try
            {
                var ctx = new BankingContext();
                ctx.NganHang.Add(objInsert);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }

        }

        public bool UpdateBanking(CreditManagement.Models.NganHang objUpdate)
        {
            try
            {
                var ctx = new BankingContext();
                ctx.Entry(objUpdate).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public bool DeleteBanking(List<string> lstID)
        {
            try
            {
                var ctx = new BankingContext();
                List<CreditManagement.Models.NganHang> lst = new List<CreditManagement.Models.NganHang>();
                for (int i = 0; i < lstID.Count; i++)
                {
                    lst.Add(new CreditManagement.Models.NganHang { MaNH = lstID[i] });
                    ctx.Entry(lst[i]).State = System.Data.Entity.EntityState.Deleted;
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
    }
}
