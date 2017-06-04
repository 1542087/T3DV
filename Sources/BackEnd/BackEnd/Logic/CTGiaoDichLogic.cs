using System;
using System.Collections.Generic;
using System.Linq;
using CreditManagement.Models;
namespace BackEnd
{
    class CTGiaoDichLogic
    {
        public ChiTietGiaoDich[] SearchAllDealDetail()
        {
            List<ChiTietGiaoDich> lst = new List<ChiTietGiaoDich>();
            try
            {

                using (var context = new BankingContext())
                {
                    lst = context.ChiTietGiaoDich.ToList();
                }

                return lst.ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ChiTietGiaoDich[] SearchDealDetailByCondition(ChiTietGiaoDich sc)
        {
            List<ChiTietGiaoDich> lst = new List<ChiTietGiaoDich>();
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
                return lst.ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool InsertDealDetail(ChiTietGiaoDich objInsert)
        {
            try
            {
                var ctx = new BankingContext();
                ctx.ChiTietGiaoDich.Add(objInsert);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }

        }

        public bool UpdateDealDetail(ChiTietGiaoDich objUpdate)
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

        public bool DeleteDealDetail(List<ChiTietGiaoDich> lstID)
        {
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
