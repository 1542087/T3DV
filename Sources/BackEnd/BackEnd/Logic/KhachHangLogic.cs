using System;
using System.Collections.Generic;
using System.Linq;
using CreditManagement.Models;
using BackEnd.Logic;

namespace BackEnd
{
    class KhachHangLogic
    {
        ReturnObjValueBackEnd  retObjValueBackEnd = new ReturnObjValueBackEnd();
        public ReturnObjValueBackEnd InsertCustomer(KhachHang customer)
        {
            retObjValueBackEnd = new ReturnObjValueBackEnd();
            try
            {
                using (var context = new BankingContext())
                {
                    context.KhachHang.Add(customer);
                    context.SaveChanges();
                    retObjValueBackEnd.Success = true;
                    return retObjValueBackEnd;
                }
            }
            catch(Exception ex)
            {
                retObjValueBackEnd.Success = false;
                retObjValueBackEnd.Message = ex.ToString();
                return retObjValueBackEnd;
                throw ex;
            }
        }

        public ReturnObjValueBackEnd UpdateCustomer(KhachHang customer)
        {
            retObjValueBackEnd = new ReturnObjValueBackEnd();

            try
            {
                using (var context = new BankingContext())
                {
                    context.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    retObjValueBackEnd.Success = true;
                    return retObjValueBackEnd;
                }
            }
            catch (Exception ex)
            {
                retObjValueBackEnd.Success = false;
                retObjValueBackEnd.Message = ex.ToString();
                return retObjValueBackEnd;
                throw ex;
            }
        }

        public ReturnObjValueBackEnd DeleteCustomer(List<string> lstKH)
        {
            retObjValueBackEnd = new ReturnObjValueBackEnd();
            try
            {
                var ctx = new BankingContext();
                List<KhachHang> lstKhachHang = new List<KhachHang>();
                for (int i = 0; i < lstKH.Count; i++)
                {
                    lstKhachHang.Add(new KhachHang { MaKH = lstKH[i] });
                    ctx.Entry(lstKhachHang[i]).State = System.Data.Entity.EntityState.Deleted;
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
        public ReturnObjValueBackEnd SearchAllCustomer()
        {
            List<KhachHang> lstKhachHang = new List<KhachHang>();
            try
            {

                using (var context = new BankingContext())
                {
                    lstKhachHang = context.KhachHang.ToList();
                }

                retObjValueBackEnd.Success = true;
                retObjValueBackEnd.Data = lstKhachHang.ToArray();
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

        public ReturnObjValueBackEnd SearchCustomerByCondition(KhachHang sc)
        {
            List<KhachHang> lstKhachhang = new List<KhachHang>();
            retObjValueBackEnd = new ReturnObjValueBackEnd();

            try
            {
                var ctx = new BankingContext();
                var query = from ct in ctx.KhachHang
                            select ct;

                if (sc != null)
                {
                    if (sc.MaKH != null)
                    {
                        query = query.Where(p => p.MaKH.Equals(sc.MaKH));
                    }

                    if (sc.cmnd != null)
                    {
                        query = query.Where(p => p.cmnd.Equals(sc.cmnd));
                    }

                    if (sc.TenKH != null)
                    {
                        query = query.Where(p => p.TenKH.Contains(sc.TenKH));
                    }

                    if (sc.SoDienThoai != null)
                    {
                        query = query.Where(p => p.SoDienThoai.Equals(sc.SoDienThoai));
                    }

                    if (sc.NgaySinh != null)
                    {
                        query = query.Where(p => p.NgaySinh.Equals(sc.NgaySinh));
                    }
                    if (sc.GioiTinh != null)
                    {
                        query = query.Where(p => p.GioiTinh.Equals(sc.GioiTinh));
                    }

                }

                lstKhachhang = query.ToList();
                retObjValueBackEnd.Success = true;
                retObjValueBackEnd.Data = lstKhachhang.ToArray();
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
