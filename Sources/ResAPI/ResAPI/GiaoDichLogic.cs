using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditManagement.Models;
namespace ResAPI
{
    class GiaoDichLogic
    {
        public List<GiaoDich> SearchAllDeal()
        {
            List<GiaoDich> lst = new List<GiaoDich>();
            try
            {

                using (var context = new BankingContext())
                {
                    lst = context.GiaoDich.ToList();
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GiaoDich> SearchDealDetailByCondition(GiaoDich sc)
        {
            List<GiaoDich> lst = new List<GiaoDich>();
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
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertDeal(GiaoDich objInsert)
        {
            try
            {
                var ctx = new BankingContext();
                ctx.GiaoDich.Add(objInsert);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void UpdateDeal(GiaoDich objUpdate)
        {
            try
            {
                var ctx = new BankingContext();
                ctx.Entry(objUpdate).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteDeal(List<GiaoDich> lstID)
        {
            try
            {
                var ctx = new BankingContext();
                List<GiaoDich> lst = new List<GiaoDich>();
                for (int i = 0; i < lstID.Count; i++)
                {
                    lst.Add(new GiaoDich { MaGD = lstID[i].MaGD });
                    ctx.Entry(lst[i]).State = System.Data.Entity.EntityState.Deleted;
                }
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
