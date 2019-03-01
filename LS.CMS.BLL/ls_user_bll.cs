using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LS.CMS.DAL;
using LS.CMS.Model;
using LS.CMS.Common;

namespace LS.CMS.BLL
{
    public class ls_user_bll
    {
        private ls_user_dal userdal = new ls_user_dal();
        /// <summary>
        /// 获取用户加密盐
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public string GetSalt(string loginName)
        {
            string result = null;
            if (string.IsNullOrEmpty(loginName))
            {
                result = "";
            }
            else
            {
                try
                {
                    result = userdal.GetSalt(loginName);
                }
                catch (Exception ex)
                {
                    LogHelper.SaveException(ex);
                }
            }
            return result;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public ls_user Login(string loginName,string password)
        {
            return userdal.GetUser(loginName, password, true);
        }

        /// <summary>
        /// 从cookie中记录的用户名和密码登录
        /// </summary>
        /// <param name="cookieUserName"></param>
        /// <param name="cookiePassword"></param>
        /// <returns></returns>
        public ls_user GetCookieUser(string cookieUserName,string cookiePassword)
        {
            return userdal.GetUser(cookieUserName,cookiePassword,false);
        }


        public IList<ls_user> GetPagedUserList(int pageIndex,int pageSize,string name,string startTime,string endTime,out int totalCount)
        {
            return userdal.GetPagedUserList(pageIndex,pageSize,name,startTime,endTime,out totalCount);
        }


    }
}
