using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

using LS.CMS.BLL;
using LS.CMS.Common;
using LS.CMS.Model;


namespace LS.CMS.Web.admin
{
    public class BasePage:System.Web.UI.Page
    {
        protected ls_sysconfig sysConfig;
        public BasePage()
        {
            sysConfig = new ls_sysconfig_bll().LoadConfig();
            this.Load += new EventHandler(BasePage_Load);
        }

        protected void BasePage_Load(object sender,EventArgs e)
        {
#if DEBUG
            HttpContext.Current.Session[LSKeys.SESSION_USER_INFO] = new ls_user_bll().GetCookieUser("chensheng","1234");
#endif

            if (!IsLogin())
            {
                Response.Redirect("/admin/login.aspx");
            }

            //判断是否有访问本页面的权限
            //如果没有跳转的话,记录访问日志(访问日志向队列中推送),在全局任务调度中每60秒完成一次批量写入
            //目前首先记录到数据库中
            VisitLog();



        }

        /// <summary>
        /// 记录用户访问日志
        /// </summary>
        protected void VisitLog()
        {
            //抛出localhost部分(当做分布式时需要将主机以及端口记录)
            ls_visit_log log = new ls_visit_log()
            {
                user_id= GetUserInfo().id,
                user_name=GetUserInfo().user_name,
                visit_time=DateTime.Now,
                visit_url= HttpContext.Current.Request.Url.ToString(),
                user_ip=Utils.GetIPAddress()
            };
            MSMQHelper msmq = new MSMQHelper();
            string msg = JSONHelper.ObjectToJSON(log);
            LogHelper.SaveVisitToLog(msg);
            msmq.Send(msg);
        }




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
            string loginName = Utils.GetCookie(LSKeys.COOKIE_USER_NAME);
            string loginPwd = Utils.GetCookie(LSKeys.COOKIE_PASSWORD);
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

            ls_nav_bll bll = new ls_nav_bll();

            if (!IsLogin())
            {
                return "";
            }
            else
            {
                StringBuilder strNav = new StringBuilder();
                strNav.Append("{ \"navs\":[");
                IList<ls_nav> navs = bll.GetNavs(GetUserInfo().id);
                var topNav = navs.Where(c=>c.parent_id==0);
                foreach(var item in topNav)
                {
                    strNav.Append("{");
                    strNav.Append("\"name\":\""+item.nav_name+"\",");
                    strNav.Append("\"title\":\""+item.nav_title+"\",");
                    strNav.Append("\"icon\":\""+item.icon_url+"\",");
                    strNav.Append("\"url\":\"" + item.link_url + "\",");
                    strNav.Append("\"alt\":\"" + item.nav_desc + "\",");

                    //拼接children字段
                    BuildNavChildren(navs, item.id,strNav);


                    strNav.Append("},");
                }
                strNav.Remove(strNav.Length-1, 1);
                strNav.Append("]}");
                return strNav.ToString();
            }
        }

        protected void BuildNavChildren(IList<ls_nav> list,int parentId,StringBuilder sb)
        {
            sb.Append("\"children\":[");
            var models = list.Where(c=>c.parent_id==parentId);
            foreach (ls_nav item in models)
            {
                sb.Append("{");
                sb.Append("\"name\":\"" + item.nav_name + "\",");
                sb.Append("\"title\":\"" + item.nav_title + "\",");
                sb.Append("\"icon\":\"" + item.icon_url + "\",");
                sb.Append("\"url\":\"" + item.link_url + "\",");
                sb.Append("\"alt\":\"" + item.nav_desc + "\",");
                BuildNavChildren(list,item.id,sb);
                sb.Append("},");
            }
            if (models.Count()>0)
            {
                sb.Remove(sb.Length - 1, 1);
            }
            sb.Append("]");
        }


    }
}