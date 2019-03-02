using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LS.CMS.BLL;
using LS.CMS.Common;

namespace LS.CMS.Web.tools
{
    /// <summary>
    /// admin_ajax 的摘要说明
    /// </summary>
    public class admin_ajax : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"];
            switch (action)
            {
                case "username_validate":
                    UserNameValidate(context);
                    break;
                default:
                    break;
            }
        }

        public void UserNameValidate(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            string  userName = context.Request.Form["param"];
            string name = context.Request.Form["name"];
            //判断userName是否重复
            ls_user_bll userBll = new ls_user_bll();
            if (userBll.IsUserNameExist(userName))
            {
                context.Response.Write(JSONHelper.SerializeObject(new {  status="n",info="该用户已经存在" }));
            }
            else
            {
                context.Response.Write(JSONHelper.SerializeObject(new { status="y",info="该用户名可用"}));
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}