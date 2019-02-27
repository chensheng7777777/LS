using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NHibernate;
using LS.CMS.DBUtility;
using LS.CMS.Model;

namespace LS.CMS.Web.test
{
    public partial class testNH : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            ls_user user = new ls_user()
            {
                user_name="ccc",
                nick_name="c",
                create_time=DateTime.Now,
                user_birth=null,
                user_password="ccc",
                user_salt="123456",
                user_status=0,
                user_roles=new List<ls_role>()
                {
                    new ls_role()
                    {
                        role_name="ddd",
                        create_time=DateTime.Now,
                        role_status=0,
                    },
                    new ls_role()
                    {
                        role_name="ddds",
                        create_time=DateTime.Now,
                        role_status=0,
                    }
                }
            };
            session.Save(user);
        }
    }
}