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
            List<string> lst = new List<string>();
            lst.Add("NV0099");
            nv.DeleteStaff(lst);
            
        }
    }
}
