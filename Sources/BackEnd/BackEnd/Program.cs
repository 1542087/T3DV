using CreditManagement.Models;
using System.Collections.Generic;

namespace BackEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            NhanVienLogic nv = new NhanVienLogic();
            NhanVien[] lst = nv.SearchAllStaff();
            string a = "";
        }
    }
}
