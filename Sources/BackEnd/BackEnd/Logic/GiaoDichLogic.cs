using System;
using System.Collections.Generic;
using System.Linq;
using CreditManagement.Models;
using BackEnd.Logic;
namespace BackEnd
{
    class GiaoDichLogic
    {
        ReturnObjValueBackEnd retObjValueBackEnd = new ReturnObjValueBackEnd();

        public ReturnObjValueBackEnd SearchAllDeal()
        {
            List<GiaoDich> lst = new List<GiaoDich>();
            retObjValueBackEnd = new ReturnObjValueBackEnd();
            try
            {

                using (var context = new BankingContext())
                {
                    lst = context.GiaoDich.ToList();
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

        public ReturnObjValueBackEnd SearchDealDetailByCondition(GiaoDich sc)
        {
            List<GiaoDich> lst = new List<GiaoDich>();
            retObjValueBackEnd = new ReturnObjValueBackEnd();

            try
            {
                var ctx = new BankingContext();
                var query = from ct in ctx.GiaoDich
                            select ct;

                if (sc != null)
                {
                    if (sc.MaGD != null)
                    {
                        query = query.Where(p => p.MaGD.Equals(sc.MaGD));
                    }

                    if (sc.MaKH != null)
                    {
                        query = query.Where(p => p.MaKH.Equals(sc.MaKH));
                    }

                    if (sc.SoTien != null)
                    {
                        query = query.Where(p => p.SoTien.Equals(sc.SoTien));
                    }

                    if (sc.NgayCapNhat != null)
                    {
                        query = query.Where(p => p.NgayCapNhat.Equals(sc.NgayCapNhat));
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

        public ReturnObjValueBackEnd InsertDeal(GiaoDich objInsert)
        {
            retObjValueBackEnd = new ReturnObjValueBackEnd();
            try
            {
                var ctx = new BankingContext();
                ctx.GiaoDich.Add(objInsert);
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

        public ReturnObjValueBackEnd UpdateDeal(GiaoDich objUpdate)
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

        public ReturnObjValueBackEnd DeleteDeal(List<string> lstID)
        {
            retObjValueBackEnd = new ReturnObjValueBackEnd();

            try
            {
                var ctx = new BankingContext();
                List<GiaoDich> lst = new List<GiaoDich>();
                for (int i = 0; i < lstID.Count; i++)
                {
                    lst.Add(new GiaoDich { MaGD = lstID[i]});
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
