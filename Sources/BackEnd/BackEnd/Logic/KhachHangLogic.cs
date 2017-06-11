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
        public ReturnObjValueBackEnd InsertCustomer(KhachHang customer, string manv)
        {
            retObjValueBackEnd = new ReturnObjValueBackEnd();
            string macn = "";
            try
            {
                using (var context = new BankingContext())
                {
                    string maxId = "";
                    maxId = (from c in context.KhachHang select c.MaKH).Max();
                    if (!string.IsNullOrEmpty(maxId))
                    {
                        int maxCurrent = Convert.ToInt16(maxId.Substring(2, maxId.Length - 2));
                        int maxNext = maxCurrent + 1;
                        string makh = maxNext.ToString().PadLeft(4, '0');
                        customer.MaKH = "KH" + makh;
                    }
                    else
                    {
                        customer.MaKH = "KH0001";
                    }

                    context.KhachHang.Add(customer);
                    context.SaveChanges();
                    retObjValueBackEnd.Success = true;
                    // Lấy mã chi nhánh dựa vào mã nhân viên
                    var query = from ct in context.NhanVien
                                select ct;
                    query = query.Where(p => p.MaNV.Equals(manv));
                    macn = query.ToList()[0].CNTrucThuoc;

                    // Tạo tài khoản  mới cho khách hàng vừa mới add mới.
                    TaiKhoan tk = new TaiKhoan();
                    TaiKhoanLogic tklogic = new TaiKhoanLogic();
                    string maxIdTK = "";
                    maxIdTK = (from c in context.TaiKhoan select c.MaTK).Max();
                    if (!string.IsNullOrEmpty(maxIdTK))
                    {
                        int maxCurrent = Convert.ToInt16(maxIdTK.Substring(2, maxId.Length - 2));
                        int maxNext = maxCurrent + 1;
                        string matkaddnew = maxNext.ToString().PadLeft(4, '0');
                        tk.MaTK = "TK" + matkaddnew;
                    }
                    else
                    {
                        customer.MaKH = "TK0001";
                    }

                    if (!string.IsNullOrEmpty(customer.cmnd))
                    {
                        tk.SoTK = int.Parse(customer.cmnd);
                    }
                    else
                    {
                        tk.SoTK = 1234;
                    }

                    tk.MaKH = customer.MaKH;
                    tk.NgayTao = DateTime.Now;
                    tk.MaNV = manv;
                    tk.MaCN = macn;
                    tk.ChuThich = "";
                    tk.SoDu = 0;
                    // add record 
                    retObjValueBackEnd = tklogic.InsertAccount(tk);
                    // Return mã tài khoản
                    retObjValueBackEnd.MaTK = tk.MaTK;
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
