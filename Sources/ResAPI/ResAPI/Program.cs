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
            NganHangLogic nh = new NganHangLogic();
            List<NhanVien> lst = new List<NhanVien>();
            List<NganHang> lstNH = new List<NganHang>();

            ///lst.Add("NV0099");
            lst = nv.SearchAllStaff();
            lstNH = nh.SearchAllBanking();
            string a = "";
            
        }
    }
}
