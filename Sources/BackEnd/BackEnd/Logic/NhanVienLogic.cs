using System;
using System.Collections.Generic;
using System.Linq;
using CreditManagement.Models;
using BackEnd.Logic;

namespace BackEnd
{
    class NhanVienLogic
    {
        ReturnObjValueBackEnd retObjValueBackEnd = new ReturnObjValueBackEnd();

        public ReturnObjValueBackEnd SearchAllStaff()
        {
            List<NhanVien> lstNhanVien = new List<NhanVien>();
            retObjValueBackEnd = new ReturnObjValueBackEnd();
            try
            {
               
                using (var context = new BankingContext())
                {
                    lstNhanVien = context.NhanVien.ToList();
                }

                retObjValueBackEnd.Success = true;
                retObjValueBackEnd.Data = lstNhanVien.ToArray();
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

        public ReturnObjValueBackEnd SearchStaffByCondition(NhanVien sc)
        {
            List<NhanVien> lstNhanVien = new List<NhanVien>();
            retObjValueBackEnd = new ReturnObjValueBackEnd();
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
                retObjValueBackEnd.Success = true;
                retObjValueBackEnd.Data = lstNhanVien.ToArray();
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

        public ReturnObjValueBackEnd InsertStaff(NhanVien staff)
        {
            retObjValueBackEnd = new ReturnObjValueBackEnd();
            try
            {
                string maxId = "";
                var ctx = new BankingContext();
                maxId = (from c in ctx.NhanVien select c.MaNV).Max();
                if (!string.IsNullOrEmpty(maxId))
                {
                    int maxCurrent = Convert.ToInt16(maxId.Substring(2, maxId.Length - 2));
                    int maxNext = maxCurrent + 1;
                    string manv = maxNext.ToString().PadLeft(4, '0');
                    staff.MaNV = "NV" + manv;
                }
                else
                {
                    staff.MaNV = "NV0001";
                }
                ctx.NhanVien.Add(staff);
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

        public ReturnObjValueBackEnd UpdateStaff(NhanVien staff)
        {
            retObjValueBackEnd = new ReturnObjValueBackEnd();
            try
            {
                var ctx = new BankingContext();
                ctx.Entry(staff).State = System.Data.Entity.EntityState.Modified;
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

        public ReturnObjValueBackEnd DeleteStaff(List<string> lstMaNV)
        {
            retObjValueBackEnd = new ReturnObjValueBackEnd();
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
