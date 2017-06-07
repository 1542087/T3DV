using System;
using System.Collections.Generic;
using System.Linq;
using CreditManagement.Models;
using BackEnd.Logic;
namespace BackEnd
{
    class TaiKhoanLogic
    {
        ReturnObjValueBackEnd retObjValueBackEnd = new ReturnObjValueBackEnd();
        public ReturnObjValueBackEnd SearchAllAccount()
        {
            List<TaiKhoan> lst = new List<TaiKhoan>();
            retObjValueBackEnd = new ReturnObjValueBackEnd();

            try
            {

                using (var context = new BankingContext())
                {
                    lst = context.TaiKhoan.ToList();
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

        public ReturnObjValueBackEnd SearchAccountByCondition(TaiKhoan sc)
        {
            List<TaiKhoan> lst = new List<TaiKhoan>();
            retObjValueBackEnd = new ReturnObjValueBackEnd();
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

        public ReturnObjValueBackEnd InsertAccount(TaiKhoan objInsert)
        {
            retObjValueBackEnd = new ReturnObjValueBackEnd();
            try
            {
                var ctx = new BankingContext();
                ctx.TaiKhoan.Add(objInsert);
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

        public ReturnObjValueBackEnd UpdateAccount(TaiKhoan objUpdate)
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

        public ReturnObjValueBackEnd DeleteAccount(List<TaiKhoan> lstID)
        {
            retObjValueBackEnd = new ReturnObjValueBackEnd();

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
