using CreditManagement.Models;
using System.Collections.Generic;

namespace BackEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            NhanVienLogic nv = new NhanVienLogic();
            NganHangLogic nh = new NganHangLogic();
            List<NhanVien> lst = new List<NhanVien>();
            List<NganHang> lstNH = new List<NganHang>();
            lst = nv.SearchAllStaff();
            string a = "";
        }
    }
}
