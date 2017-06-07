using System;
using System.Collections.Generic;
using System.Linq;
using CreditManagement.Models;
using BackEnd.Logic;
namespace BackEnd
{
    class ChiNhanhNHLogic
    {
        ReturnObjValueBackEnd retObjValueBackEnd = new ReturnObjValueBackEnd();
        public ReturnObjValueBackEnd SearchAllBankBranches()
        {
            List<ChiNhanhNganHang> lst = new List<ChiNhanhNganHang>();
            retObjValueBackEnd = new ReturnObjValueBackEnd();

            try
            {

                using (var context = new BankingContext())
                {
                    lst = context.ChiNhanhNganHang.ToList();
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

        public ReturnObjValueBackEnd SearchBankBranchesByCondition(ChiNhanhNganHang sc)
        {
            List<ChiNhanhNganHang> lst = new List<ChiNhanhNganHang>();
            retObjValueBackEnd = new ReturnObjValueBackEnd();

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

        public ReturnObjValueBackEnd InsertBankBranches(ChiNhanhNganHang objInsert)
        {
            retObjValueBackEnd = new ReturnObjValueBackEnd();

            try
            {
                var ctx = new BankingContext();
                ctx.ChiNhanhNganHang.Add(objInsert);
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

        public ReturnObjValueBackEnd UpdateBankBranches(ChiNhanhNganHang objUpdate)
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

        public ReturnObjValueBackEnd DeleteBankBranches(List<string> lstID)
        {
            retObjValueBackEnd = new ReturnObjValueBackEnd();

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
