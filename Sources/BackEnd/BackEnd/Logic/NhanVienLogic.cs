using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditManagement.Models;

namespace BackEnd
{
    class NhanVienLogic
    {
        public List<NhanVien> SearchAllStaff()
        {
            List<NhanVien> lstNhanVien = new List<NhanVien>();
            try
            {
               
                using (var context = new BankingContext())
                {
                    lstNhanVien = context.NhanVien.ToList();
                }

                return lstNhanVien;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<NhanVien> SearchStaffByCondition(NhanVien sc)
        {
            List<NhanVien> lstNhanVien = new List<NhanVien>();
            try
            {
                var ctx = new BankingContext();
                var query = from ct in ctx.NhanVien
                            select ct;
                if (sc != null)
                {
                    if (sc.MaNV  != null)
                    {
                        query = query.Where(p => p.MaNV.Equals(sc.MaNV));
                    }

                    if (sc.cmnd != null)
                    {
                        query = query.Where(p => p.cmnd.Equals(sc.cmnd));
                    }

                    if (sc.ChucVu != null)
                    {
                        query = query.Where(p => p.ChucVu.Equals(sc.ChucVu));
                    }

                    if (sc.TenNV != null)
                    {
                        query = query.Where(p => p.TenNV.Contains(sc.TenNV));
                    }

                    if (sc.CNTrucThuoc != null)
                    {
                        query = query.Where(p => p.CNTrucThuoc.Equals(sc.CNTrucThuoc));
                    }

                    if (sc.SoDienThoai != null)
                    {
                        query = query.Where(p => p.SoDienThoai.Equals(sc.SoDienThoai));
                    }
                    
                    if (sc.NgaySinh != null)
                    {
                        query = query.Where(p => p.NgaySinh.Equals(sc.NgaySinh));
                    }
                   
                }

                lstNhanVien = query.ToList();
                return lstNhanVien;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool InsertStaff(NhanVien staff)
        {
            try
            {
                var ctx = new BankingContext();
                ctx.NhanVien.Add(staff);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
           
        }

        public bool UpdateStaff(NhanVien staff)
        {
            try
            {
                var ctx = new BankingContext();
                ctx.Entry(staff).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public bool DeleteStaff(List<string> lstMaNV)
        {
            try
            {
                var ctx = new BankingContext();
                List<NhanVien> lstNV = new List<NhanVien>();
                for (int i = 0; i < lstMaNV.Count; i++)
                {
                    lstNV.Add(new NhanVien { MaNV = lstMaNV[i] });
                    ctx.Entry(lstNV[i]).State = System.Data.Entity.EntityState.Deleted;
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
