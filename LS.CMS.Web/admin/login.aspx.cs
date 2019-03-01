using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LS.CMS.BLL;
using LS.CMS.Common;
using LS.CMS.Model;

namespace LS.CMS.Web.admin
{
    public partial class login : System.Web.UI.Page
    {
        protected ls_sysconfig sysConfig;
        protected void Page_Load(object sender, EventArgs e)
        {
            sysConfig = new ls_sysconfig_bll().LoadConfig();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string userPwd = txtPassword.Text;
            if (Session[LSKeys.SESSION_LOGIN_SUM] == null)
            {
                Session[LSKeys.SESSION_LOGIN_SUM] = 1;
            }
            else
            {
                Session[LSKeys.SESSION_LOGIN_SUM] = Convert.ToInt32(Session[LSKeys.SESSION_LOGIN_SUM])+1;
            }
            if (Convert.ToInt32(Session[LSKeys.SESSION_LOGIN_SUM])>5)
            {
                msgtip.InnerText = "您登录失败已经超过五次,请关闭浏览器重试";
                return;
            }
            ls_user_bll userBLL = new ls_user_bll();
            ls_user user=userBLL.Login(userName, userPwd);
            if (user == null)
            {
                msgtip.InnerText = "用户名密码错误";
            }
            else
            {
                Session[LSKeys.SESSION_USER_INFO] = user;
                Response.Cookies[LSKeys.COOKIE_USER_NAME].Value = userName;
                Response.Cookies[LSKeys.COOKIE_PASSWORD].Value = user.user_password;
                //登录成功记录登录日志
                if (sysConfig.log_status>0)
                {
                    new ls_log_bll().SaveLog(new ls_log()
                    {
                        user_id=user.id,
                        user_name=user.nick_name,
                        action_type=LSEnums.ActionEnum.Login.ToString(),
                        add_time=DateTime.Now,
                        user_ip=LSRequest.GetIP()
                    });
                }
                Response.Redirect("index.aspx");
            }
        }
    }
}