using BackEnd.Logic;
using CreditManagement.Models;
using System.Collections.Generic;

namespace BackEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            NhanVienLogic nv = new NhanVienLogic();
            ReturnObjValueBackEnd lst = nv.SearchAllStaff();
            string a = "";
        }
    }
}
