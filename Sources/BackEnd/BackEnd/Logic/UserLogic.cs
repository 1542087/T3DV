using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditManagement.Models;

namespace BackEnd
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

        public bool InsertUser(MSTUSER objInsert)
        {
            try
            {
                var ctx = new BankingContext();
                ctx.MstUser.Add(objInsert);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }

        }

        public bool UpdateUser(MSTUSER objUpdate)
        {
            try
            {
                var ctx = new BankingContext();
                ctx.Entry(objUpdate).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
        public bool DeleteUser(List<string> lstID)
        {
            try
            {
                var ctx = new BankingContext();
                MSTUSER userModel = new MSTUSER();

                for (int i = 0; i < lstID.Count; i++)
                {
                    var query = from user in ctx.MstUser
                                where user.USERID.Equals(lstID[i]) 
                                select user;

                    if (query.ToList().Count > 0)
                    {
                        userModel = query.ToList()[0];
                    }
                    userModel.DELETE_YMD = DateTime.Now;
                    UpdateUser(userModel);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }

        }
    }
}
