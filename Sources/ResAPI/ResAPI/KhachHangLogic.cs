using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditManagement.Models;
using Newtonsoft.Json;
using System.Data.Entity;

namespace ResAPI
{
    class KhachHangLogic
    {
        public void InsertCustomer(string customer)
        {
            KhachHang kh = new KhachHang();
            try
            {
                kh = JsonConvert.DeserializeObject<KhachHang>(customer);

                using (var context = new BankingContext())
                {
                    context.KhachHang.Add(kh);
                    context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateCustomer(string customer)
        {
            KhachHang kh = new KhachHang();
            try
            {
                kh = JsonConvert.DeserializeObject<KhachHang>(customer);

                using (var context = new BankingContext())
                {
                    context.Entry(kh).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
