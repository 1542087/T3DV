using System;
using System.Collections.Generic;
using System.Linq;
using CreditManagement.Models;
using BackEnd.Logic;
namespace BackEnd
{
    class SoTietKiemLogic
    {
        ReturnObjValueBackEnd retObjValueBackEnd = new ReturnObjValueBackEnd();
        public ReturnObjValueBackEnd SearchAllSaveMoney()
        {
            List<SoTietKiem> lst = new List<SoTietKiem>();
            try
            {

                using (var context = new BankingContext())
                {
                    lst = context.SoTietKiem.ToList();
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

        public ReturnObjValueBackEnd SearchSaveMoneyByCondition(SoTietKiem sc)
        {
            retObjValueBackEnd = new ReturnObjValueBackEnd();
            List<SoTietKiem> lst = new List<SoTietKiem>();
            try
            {
                var ctx = new BankingContext();
                var query = from ct in ctx.SoTietKiem
                            select ct;

                if (sc != null)
                {
                    if (sc.MaSTK != null)
                    {
                        query = query.Where(p => p.MaSTK.Equals(sc.MaSTK));
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

                    if (sc.LoaiTK != null)
                    {
                        query = query.Where(p => p.LoaiTK.Equals(sc.LoaiTK));
                    }
                    if (sc.SoTien != null)
                    {
                        query = query.Where(p => p.SoTien.Equals(sc.SoTien));
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

        public ReturnObjValueBackEnd InsertSaveMoney(SoTietKiem objInsert)
        {
            retObjValueBackEnd = new ReturnObjValueBackEnd();
            try
            {
                var ctx = new BankingContext();
                string maxId = "";
                maxId = (from c in ctx.SoTietKiem select c.MaSTK).Max();

                if (!string.IsNullOrEmpty(maxId))
                {
                    int maxCurrent = Convert.ToInt16(maxId.Substring(3, maxId.Length - 2));
                    int maxNext = maxCurrent + 1;
                    string mastkaddnew = maxNext.ToString().PadLeft(4, '0');
                    objInsert.MaSTK = "STK" + mastkaddnew;
                }
                else
                {
                    objInsert.MaSTK = "STK0001";
                }

                ctx.SoTietKiem.Add(objInsert);
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

        public ReturnObjValueBackEnd UpdateSaveMoney(SoTietKiem objUpdate)
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

        public ReturnObjValueBackEnd DeleteSaveMoney(List<SoTietKiem> lstID)
        {
            retObjValueBackEnd = new ReturnObjValueBackEnd();
            try
            {
                var ctx = new BankingContext();
                List<SoTietKiem> lst = new List<SoTietKiem>();
                for (int i = 0; i < lstID.Count; i++)
                {
                    lst.Add(new SoTietKiem { MaKH = lstID[i].MaKH, 
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
