using System;
using System.Collections.Generic;
using System.Linq;
using CreditManagement.Models;
using BackEnd.Logic;
namespace BackEnd
{
    class CTGiaoDichLogic
    {
        ReturnObjValueBackEnd retObjValueBackEnd = new ReturnObjValueBackEnd();

        public ReturnObjValueBackEnd SearchAllDealDetail()
        {
            retObjValueBackEnd = new ReturnObjValueBackEnd();
            List<ChiTietGiaoDich> lst = new List<ChiTietGiaoDich>();

            try
            {

                using (var context = new BankingContext())
                {
                    lst = context.ChiTietGiaoDich.ToList();
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

        public ReturnObjValueBackEnd SearchDealDetailByCondition(ChiTietGiaoDich sc)
        {
            List<ChiTietGiaoDich> lst = new List<ChiTietGiaoDich>();
            retObjValueBackEnd = new ReturnObjValueBackEnd();

            try
            {
                var ctx = new BankingContext();
                var query = from ct in ctx.ChiTietGiaoDich
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

                    if (sc.NgayGD != null)
                    {
                        query = query.Where(p => p.NgayGD.Equals(sc.NgayGD));
                    }

                    if (sc.MaNV != null)
                    {
                        query = query.Where(p => p.MaNV.Equals(sc.MaNV));
                    }

                    if (sc.MaCNNH != null)
                    {
                        query = query.Where(p => p.MaCNNH.Equals(sc.MaCNNH));
                    }

                    if (sc.SoTienGD != null)
                    {
                        query = query.Where(p => p.SoTienGD.Equals(sc.SoTienGD));
                    }

                    if (sc.NoiDungGD != null)
                    {
                        query = query.Where(p => p.NoiDungGD.Contains(sc.NoiDungGD));
                    }

                    if (sc.PhiGD != null)
                    {
                        query = query.Where(p => p.PhiGD.Equals(sc.PhiGD));
                    }

                    if (sc.TrangThai != null)
                    {
                        query = query.Where(p => p.TrangThai.Equals(sc.TrangThai));
                    }

                    if (sc.MaTKNguoiNhan != null)
                    {
                        query = query.Where(p => p.MaTKNguoiNhan.Equals(sc.MaTKNguoiNhan));
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

        public ReturnObjValueBackEnd InsertDealDetail(ChiTietGiaoDich objInsert)
        {
            retObjValueBackEnd = new ReturnObjValueBackEnd();
            try
            {
                var ctx = new BankingContext();
                ctx.ChiTietGiaoDich.Add(objInsert);
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

        public ReturnObjValueBackEnd UpdateDealDetail(ChiTietGiaoDich objUpdate)
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

        public ReturnObjValueBackEnd DeleteDealDetail(List<ChiTietGiaoDich> lstID)
        {
            retObjValueBackEnd = new ReturnObjValueBackEnd();

            try
            {
                var ctx = new BankingContext();
                List<ChiTietGiaoDich> lst = new List<ChiTietGiaoDich>();
                for (int i = 0; i < lstID.Count; i++)
                {
                    lst.Add(new ChiTietGiaoDich { MaKH = lstID[i].MaKH, NgayGD = lstID[i].NgayGD });
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
