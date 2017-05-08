using CreditManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace CreditManagement.Logic
{
    public class CTGiaoDich
    {
        public List<Tab01Model> GetDealDetail()
        {
            string ds = "";
            BankingContext ct = new BankingContext();
            List<Tab01Model> model = new List<Tab01Model>();
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

            model = (from rw in dt.AsEnumerable()
                                 select new Tab01Model()
                                 {
                                     MaGD = rw["MaGD"].ToString(),
                                     NgayGD = Convert.ToString(rw["NgayGD"]),
                                     TenNV = Convert.ToString(rw["NhanVien"]),
                                     TenCN = Convert.ToString(rw["CNGD"]),
                                     SoTienGD = Convert.ToString(rw["SoTien"])
                                 }).ToList();

            return model;
        }
        public string GetJson(DataTable dt)
        {
            JavaScriptSerializer JSSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> DtRows =
              new List<Dictionary<string, object>>();
            Dictionary<string, object> newrow = null;

            //Code to loop each row in the datatable and add it to the dictionary object
            foreach (DataRow drow in dt.Rows)
            {
                newrow = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    newrow.Add(col.ColumnName.Trim(), drow[col]);
                }
                DtRows.Add(newrow);
            }

            //Serialising the dictionary object to produce json output
            return JSSerializer.Serialize(DtRows);
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