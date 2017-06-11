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

       /// <summary>
        /// Hàm này để màn hình gọi xử lý thực thi giao dịch
       /// </summary>
       /// <param name="makh"></param>
       /// <param name="manv"></param>
       /// <param name="sotien"></param>
       /// <param name="noidung"></param>
       /// <param name="manguoinhan"></param>
       /// <param name="loaiGD">
       /// 1: gui tien
       /// 2. rut tien
       /// 3. chuyen tien
       /// </param>
       /// <returns></returns>
        public ReturnObjValueBackEnd ThemMoiGiaoDich(string makh, string manv, decimal sotien, 
                                                    string noidung, string manguoinhan, int loaiGD)
        {
            retObjValueBackEnd = new ReturnObjValueBackEnd();
            try
            {
                string macn = "";
                decimal soduttk = 0;
                var ctx = new BankingContext();
                // Lấy mã chi nhánh dựa vào mã nhân viên
                var query = from ct in ctx.NhanVien
                            select ct;
                query = query.Where(p => p.MaNV.Equals(manv));
                macn = query.ToList()[0].CNTrucThuoc;

                // Lấy số dư tài khoản dựa vào makh, manv, macn
                var queryTK = from tk in ctx.TaiKhoan
                                where tk.MaKH.Equals(makh) &&
                                tk.MaNV.Equals(manv) && tk.MaCN.Equals(macn)
                                select tk;
                soduttk = queryTK.ToList()[0].SoDu;

                if (loaiGD != 1){
                    if (soduttk < sotien)
                    {
                        retObjValueBackEnd.Message = "Số tiền giao dịch không hợp lệ.";
                        retObjValueBackEnd.Success = true;
                        return retObjValueBackEnd;
                    }
                }
                // add new table giaodich
                GiaoDich gd = new GiaoDich();
                GiaoDichLogic gdLogic = new GiaoDichLogic();
                gd.MaKH = makh;
                gd.SoTien = sotien;
                gd.NgayCapNhat = DateTime.Now;
                string maxIdGD = "";
                maxIdGD = (from c in ctx.GiaoDich select c.MaGD).Max();

                if (!string.IsNullOrEmpty(maxIdGD))
                {
                    int maxCurrent = Convert.ToInt16(maxIdGD.Substring(2, maxIdGD.Length - 2));
                    int maxNext = maxCurrent + 1;
                    string magdaddnew = maxNext.ToString().PadLeft(4, '0');
                    gd.MaGD = "GD" + magdaddnew;
                }
                else
                {
                    gd.MaGD = "GD0001";
                }

                retObjValueBackEnd = gdLogic.InsertDeal(gd);
                if (retObjValueBackEnd.Success == false)
                {
                    retObjValueBackEnd = null;
                    return retObjValueBackEnd;
                }

                // add table ChTietGiaoDich
                ChiTietGiaoDich ctgd = new ChiTietGiaoDich();
                CTGiaoDichLogic ctgdLogic = new CTGiaoDichLogic();
                ctgd.MaGD = gd.MaGD;
                ctgd.MaKH = gd.MaKH;
                ctgd.NgayGD = gd.NgayCapNhat;
                ctgd.MaNV = manv;
                ctgd.MaCNNH = macn;
                ctgd.SoTienGD = sotien;
                ctgd.NoiDungGD = noidung;
                ctgd.MaTKNguoiNhan = noidung;
                ctgd.MaTKNguoiNhan = manguoinhan;

                retObjValueBackEnd = ctgdLogic.InsertDealDetail(ctgd);
                if(retObjValueBackEnd.Success == false ){
                    retObjValueBackEnd = null;
                    return retObjValueBackEnd;
                }

                retObjValueBackEnd = ctgdLogic.InsertDealDetail(ctgd);

                // Cập nhật số tiền tại table TaiKoan
                TaiKhoan tkupdate = new TaiKhoan();
                TaiKhoanLogic tkupdateLogic = new TaiKhoanLogic();
                tkupdate = queryTK.ToList()[0];
                tkupdate.SoDu = tkupdate.SoDu - (decimal)gd.SoTien;
                retObjValueBackEnd = tkupdateLogic.UpdateAccount(tkupdate);

                // Return mã giao dịch và số dư còn lại
                retObjValueBackEnd.MaGD = gd.MaGD;
                retObjValueBackEnd.SoDuConLai = tkupdate.SoDu;
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
