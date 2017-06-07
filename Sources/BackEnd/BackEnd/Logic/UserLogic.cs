using System;
using System.Collections.Generic;
using System.Linq;
using CreditManagement.Models;
using BackEnd.Logic;

namespace BackEnd
{
    class UserLogic
    {
        ReturnObjValueBackEnd retObjValueBackEnd = new ReturnObjValueBackEnd();

        /// <summary>
        /// Lấy thông tin nhân viên dựa vào useris và password
        /// </summary>
        /// <param name="userId">user id</param>
        /// <param name="pass">password</param>
        /// <returns></returns>
        public ReturnObjValueBackEnd CheckLogin(string userId, string pass)
        {
            NhanVien lstTTNhanVien = new NhanVien();
            retObjValueBackEnd = new ReturnObjValueBackEnd();

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

                retObjValueBackEnd.Success = true;
                retObjValueBackEnd.Data = lstTTNhanVien;
                return retObjValueBackEnd;
            }
            catch (Exception ex)
            {
                retObjValueBackEnd.Success = false;
                retObjValueBackEnd.Message = ex.ToString();
                return retObjValueBackEnd;
                throw ex;
            }
        }

        public ReturnObjValueBackEnd InsertUser(MSTUSER objInsert)
        {
            retObjValueBackEnd = new ReturnObjValueBackEnd();
            try
            {
                var ctx = new BankingContext();
                ctx.MstUser.Add(objInsert);
                ctx.SaveChanges();
                retObjValueBackEnd.Success = true;
                return retObjValueBackEnd;
            }
            catch (Exception ex)
            {
                retObjValueBackEnd.Success = false;
                retObjValueBackEnd.Message = ex.ToString();
                return retObjValueBackEnd;
                throw ex;
            }

        }

        public ReturnObjValueBackEnd UpdateUser(MSTUSER objUpdate)
        {
            retObjValueBackEnd = new ReturnObjValueBackEnd();

            try
            {
                var ctx = new BankingContext();
                ctx.Entry(objUpdate).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                retObjValueBackEnd.Success = true;
                return retObjValueBackEnd;
            }
            catch (Exception ex)
            {
                retObjValueBackEnd.Success = false;
                retObjValueBackEnd.Message = ex.ToString();
                return retObjValueBackEnd;
                throw ex;
            }
        }
        public ReturnObjValueBackEnd DeleteUser(List<string> lstID)
        {
            retObjValueBackEnd = new ReturnObjValueBackEnd();

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
                retObjValueBackEnd.Success = true;
                return retObjValueBackEnd;
            }
            catch (Exception ex)
            {
                retObjValueBackEnd.Success = false;
                retObjValueBackEnd.Message = ex.ToString();
                return retObjValueBackEnd;
                throw ex;
            }

        }
    }
}
