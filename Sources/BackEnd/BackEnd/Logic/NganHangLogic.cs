using System;
using System.Collections.Generic;
using System.Linq;
using CreditManagement.Models;
using BackEnd.Logic;

namespace BackEnd
{
    class NganHangLogic
    {
        ReturnObjValueBackEnd retObjValueBackEnd = new ReturnObjValueBackEnd();
        public ReturnObjValueBackEnd SearchAllBanking()
        {
            List<CreditManagement.Models.NganHang> lst = new List<CreditManagement.Models.NganHang>();
            retObjValueBackEnd = new ReturnObjValueBackEnd();

            try
            {

                using (var context = new BankingContext())
                {
                   lst = context.NganHang.ToList();
                }

                retObjValueBackEnd.Success = true;
                retObjValueBackEnd.Data = lst.ToArray();
                return retObjValueBackEnd;
            }
            catch (Exception ex)
            {
                retObjValueBackEnd.Success = false;
                retObjValueBackEnd.Message = ex.ToString();
                return retObjValueBackEnd;
                throw ex;
            }
        }

        public ReturnObjValueBackEnd SearchBankingByCondition(CreditManagement.Models.NganHang sc)
        {
            List<CreditManagement.Models.NganHang> lst = new List<CreditManagement.Models.NganHang>();
            retObjValueBackEnd = new ReturnObjValueBackEnd();

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

                retObjValueBackEnd.Success = true;
                retObjValueBackEnd.Data = lst.ToArray();
                return retObjValueBackEnd;
            }
            catch (Exception ex)
            {
                retObjValueBackEnd.Success = false;
                retObjValueBackEnd.Message = ex.ToString();
                return retObjValueBackEnd;
                throw ex;
            }
        }

        public ReturnObjValueBackEnd InsertBanking(CreditManagement.Models.NganHang objInsert)
        {
            retObjValueBackEnd = new ReturnObjValueBackEnd();
            try
            {
                var ctx = new BankingContext();
                ctx.NganHang.Add(objInsert);
                ctx.SaveChanges();
                retObjValueBackEnd.Success = true;
                return retObjValueBackEnd;
            }
            catch (Exception ex)
            {
                retObjValueBackEnd.Success = false;
                retObjValueBackEnd.Message = ex.ToString();
                return retObjValueBackEnd;
                throw ex;
            }

        }

        public ReturnObjValueBackEnd UpdateBanking(CreditManagement.Models.NganHang objUpdate)
        {
            retObjValueBackEnd = new ReturnObjValueBackEnd();

            try
            {
                var ctx = new BankingContext();
                ctx.Entry(objUpdate).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                retObjValueBackEnd.Success = true;
                return retObjValueBackEnd;
            }
            catch (Exception ex)
            {
                retObjValueBackEnd.Success = false;
                retObjValueBackEnd.Message = ex.ToString();
                return retObjValueBackEnd;
                throw ex;
            }
        }

        public ReturnObjValueBackEnd DeleteBanking(List<string> lstID)
        {
            retObjValueBackEnd = new ReturnObjValueBackEnd();

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
                retObjValueBackEnd.Success = true;
                return retObjValueBackEnd;
            }
            catch (Exception ex)
            {
                retObjValueBackEnd.Success = false;
                retObjValueBackEnd.Message = ex.ToString();
                return retObjValueBackEnd;
                throw ex;
            }

        }
    }
}
