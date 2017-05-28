using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditManagement.Models;
using Newtonsoft.Json;

namespace ResAPI
{
    class NhanVienLogic
    {
        public string GetAll()
        {
            NhanVien nv = new NhanVien();
            string result = string.Empty;
            List<NhanVien> lstNhanVien = new List<NhanVien>();
            try
            {
               
                using (var context = new BankingContext())
                {
                    lstNhanVien = context.NhanVien.ToList();
                   
                }
                result = JsonConvert.SerializeObject(lstNhanVien);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
