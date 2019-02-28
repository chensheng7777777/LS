using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using LS.CMS.BLL;
using LS.CMS.Common;
using LS.CMS.Model;


namespace LS.CMS.Web.admin
{
    public class BasePage:System.Web.UI.Page
    {

        /// <summary>
        /// 判断是否登录
        /// </summary>
        /// <returns></returns>
        public bool IsLogin()
        {
            if (HttpContext.Current.Session[LSKeys.SESSION_USER_INFO]!=null)
            {
                return true;
            }
            string loginName = HttpContext.Current.Request.Cookies[LSKeys.COOKIE_USER_NAME].Value;
            string loginPwd = HttpContext.Current.Request.Cookies[LSKeys.COOKIE_PASSWORD].Value;
            if (!string.IsNullOrEmpty(loginName) && !string.IsNullOrEmpty(loginPwd))
            {
                ls_user_bll userBLL = new ls_user_bll();
                ls_user user = userBLL.GetCookieUser(loginName, loginPwd);
                if (user!=null)
                {
                    HttpContext.Current.Session[LSKeys.SESSION_USER_INFO] = user;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 获取登录的用户信息
        /// </summary>
        /// <returns></returns>
        public ls_user GetUserInfo()
        {
            if (IsLogin())
            {
                return (ls_user)HttpContext.Current.Session[LSKeys.SESSION_USER_INFO];
            }
            return null;
        }

        public string GetNavObjs()
        {


            return "";


        }


    }
}