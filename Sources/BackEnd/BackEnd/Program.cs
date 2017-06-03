using CreditManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
