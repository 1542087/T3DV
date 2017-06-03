using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditManagement.Models;
namespace BackEnd
{
    class SoTietKiemLogic
    {
        public List<SoTietKiem> SearchAllSaveMoney()
        {
            List<SoTietKiem> lst = new List<SoTietKiem>();
            try
            {

                using (var context = new BankingContext())
                {
                    lst = context.SoTietKiem.ToList();
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SoTietKiem> SearchSaveMoneyByCondition(SoTietKiem sc)
        {
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
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool InsertSaveMoney(SoTietKiem objInsert)
        {
            try
            {
                var ctx = new BankingContext();
                ctx.SoTietKiem.Add(objInsert);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }

        }

        public bool UpdateSaveMoney(SoTietKiem objUpdate)
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

        public bool DeleteSaveMoney(List<SoTietKiem> lstID)
        {
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
