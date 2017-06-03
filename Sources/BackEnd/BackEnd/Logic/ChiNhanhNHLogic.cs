using System;
using System.Collections.Generic;
using System.Linq;
using CreditManagement.Models;
namespace BackEnd
{
    class ChiNhanhNHLogic
    {
        public List<ChiNhanhNganHang> SearchAllBankBranches()
        {
            List<ChiNhanhNganHang> lst = new List<ChiNhanhNganHang>();
            try
            {

                using (var context = new BankingContext())
                {
                    lst = context.ChiNhanhNganHang.ToList();
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ChiNhanhNganHang> SearchBankBranchesByCondition(ChiNhanhNganHang sc)
        {
            List<ChiNhanhNganHang> lst = new List<ChiNhanhNganHang>();
            try
            {
                var ctx = new BankingContext();
                var query = from ct in ctx.ChiNhanhNganHang
                            select ct;

                if (sc != null)
                {
                    if (sc.MaCN != null)
                    {
                        query = query.Where(p => p.MaCN.Equals(sc.MaCN));
                    }

                    if (sc.LoaiCN != null)
                    {
                        query = query.Where(p => p.LoaiCN.Equals(sc.LoaiCN));
                    }

                    if (sc.DTNoiBo != null)
                    {
                        query = query.Where(p => p.DTNoiBo.Equals(sc.DTNoiBo));
                    }

                    if (sc.TenCN != null)
                    {
                        query = query.Where(p => p.TenCN.Contains(sc.TenCN));
                    }

                    if (sc.DiaChi != null)
                    {
                        query = query.Where(p => p.DiaChi.Contains(sc.DiaChi));
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

        public bool InsertBankBranches(ChiNhanhNganHang objInsert)
        {
            try
            {
                var ctx = new BankingContext();
                ctx.ChiNhanhNganHang.Add(objInsert);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }

        }

        public bool UpdateBankBranches(ChiNhanhNganHang objUpdate)
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

        public bool DeleteBankBranches(List<string> lstID)
        {
            try
            {
                var ctx = new BankingContext();
                List<ChiNhanhNganHang> lst = new List<ChiNhanhNganHang>();
                for (int i = 0; i < lstID.Count; i++)
                {
                    lst.Add(new ChiNhanhNganHang { MaCN = lstID[i] });
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
