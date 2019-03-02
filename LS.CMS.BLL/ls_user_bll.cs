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
        /// 删除用户
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool DeleteUsers(List<int> ids)
        {
            return userdal.DeleteUsers(ids);
        }

        /// <summary>
        /// 根据id获取用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ls_user GetUserById(int id)
        {
            return userdal.GetUserById(id);
        }

        public void UpdateUser(ls_user usr)
        {
            userdal.UpdateUser(usr);
        }


        /// <summary>
        /// 判断用户名是否存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool IsUserNameExist(string userName)
        {
            return userdal.IsUserNameExists(userName);
        }
        /// <summary>
        /// 保存用户
        /// </summary>
        /// <param name="usr"></param>
        /// <returns></returns>
        public bool SaveUser(ls_user usr)
        {
            return userdal.SaveUser(usr).id>0;
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


        public IList<ls_user> GetPagedUserList(int pageIndex,int pageSize,string name,string startTime,string endTime,int role_id,out int totalCount)
        {
            return userdal.GetPagedUserList(pageIndex,pageSize,name,startTime,endTime,role_id,out totalCount);
        }


    }
}
