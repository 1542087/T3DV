using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditManagement.Models;

namespace ResAPI
{
    class UserLogic
    {
        /// <summary>
        /// Lấy thông tin nhân viên dựa vào useris và password
        /// </summary>
        /// <param name="userId">user id</param>
        /// <param name="pass">password</param>
        /// <returns></returns>
        public NhanVien CheckLogin(string userId, string pass)
        {
            NhanVien lstTTNhanVien = new NhanVien();
            try
            {
                using (var ct = new BankingContext())
                {
                    var query = from user in ct.MstUser
                                join nv in ct.NhanVien on user.USERID equals nv.MaNV
                                where user.USERID.Equals(userId) && user.PASSWD.Equals(pass)
                                select nv;

                    if (query.ToList().Count > 0)
                    {
                        lstTTNhanVien = query.ToList()[0];

                    }
                }
                
                return lstTTNhanVien;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }
    }
}
