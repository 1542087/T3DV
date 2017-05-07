using CreditManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace CreditManagement.Logic
{
    public class CTGiaoDich
    {
        public DataSet GetDealDetail()
        {
            DataSet ds = new DataSet();
            BankingContext ct = new BankingContext();
            var query = from ctgd in ct.ChiTietGiaoDich
                        join kh in ct.KhachHang on ctgd.MaKH equals kh.MaKH
                        join nv in ct.NhanVien on ctgd.MaNV equals nv.MaNV
                        join cnnh in ct.ChiNhanhNganHang on ctgd.MaCNNH equals cnnh.MaCN
                        select new
                        {
                            MaGD = ctgd.MaGD,
                            NgayGD = ctgd.NgayGD,
                            NhanVien = nv.TenNV,
                            CNGD = cnnh.TenCN,
                            SoTien = ctgd.SoTienGD
                        };


            DataTable dt = LINQToDataTable(query);

            ds.Tables.Add(dt);

            return ds;
        }

        public DealDetail ShowDataToScreen()
        {
            string maKH = null;
            DealDetail model = new DealDetail();
            maKH = HttpContext.Current.Session["MAKH"].ToString();

            using (var context = new BankingContext())
            {
                var kh = context.KhachHang
                                .Where(b => b.MaKH == maKH)
                                .FirstOrDefault();

                model.TenKH = kh.TenKH;
            }

            model.ChiTietGD = GetDealDetail();
            model.ChuyenKhoanModel = DataChuyenKhoan(maKH);
            model.RutTienModel = DataRutTien(maKH);
            using (var context = new BankingContext())
            {
                model.dsNganHang = context.ChiNhanhNganHang.ToList();
            }

            return model;
        }

        public ChuyenKhoan DataChuyenKhoan(string maKH)
        {
            ChuyenKhoan model = new ChuyenKhoan();

            using (var context = new BankingContext())
            {
                var tk = context.TaiKhoan
                                .Where(b => b.MaKH == maKH)
                                .FirstOrDefault();

                var gd = context.GiaoDich
                                .Where(b => b.MaKH == maKH)
                                .FirstOrDefault();

                model.MaTK = tk.MaTK;


                model.SoDuTK = gd.SoTien.ToString();

            }

            return model;
        }

        public RutTien DataRutTien(string maKH)
        {
            RutTien model = new RutTien();

            using (var context = new BankingContext())
            {
                var tk = context.TaiKhoan
                                .Where(b => b.MaKH == maKH)
                                .FirstOrDefault();

                var gd = context.GiaoDich
                                .Where(b => b.MaKH == maKH)
                                .FirstOrDefault();

                model.MaTK = tk.MaTK;


                model.SoDuTK = gd.SoTien.ToString();

            }
          
            return model;
        }
        public DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();
            PropertyInfo[] oProps = null;
            if (varlist == null) return dtReturn;
            foreach (T rec in varlist)
            {
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;


                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }


                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }

                DataRow dr = dtReturn.NewRow();

                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
                    (rec, null);
                }

                dtReturn.Rows.Add(dr);
            }

            return dtReturn;
        }

    }
}