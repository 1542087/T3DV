using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditManagement.Models;

namespace ResAPI
{
    class Program
    {
        //solution 2
        static void Main(string[] args)
        {
            NhanVienLogic nv = new NhanVienLogic();
            string a = nv.GetAll();
            string b = "";
           
            
        }

        public MSTUSER CheckLogin(MSTUSER user)
        {
            List<MSTUSER> lUser = null;
            try
            {
                using (var context = new BankingContext())
                {
                    lUser = context.MstUser.Where(s => s.USERID == user.USERID 
                                                    && s.PASSWD == user.PASSWD 
                                                    && s.DELETE_YMD == null).ToList();

                }

                if (lUser.Count == 1)
                {
                    return lUser[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }
    }
}
