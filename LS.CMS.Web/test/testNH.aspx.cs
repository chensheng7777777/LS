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
            //using (ITransaction tran=session.BeginTransaction())
            //{
            //    var role = new ls_role()
            //    {
            //        create_time = DateTime.Now,
            //        role_name = "1",
            //        role_status = 0
            //    };
            //    ls_user user = new ls_user()
            //    {
            //        user_name = "ccc",
            //        nick_name = "c",
            //        create_time = DateTime.Now,
            //        user_birth = null,
            //        user_password = "ccc",
            //        user_salt = "123456",
            //        user_status = 0,
            //    };
            //    ls_user user1 = new ls_user()
            //    {
            //        user_name = "ccc",
            //        nick_name = "c",
            //        create_time = DateTime.Now,
            //        user_birth = null,
            //        user_password = "ccc",
            //        user_salt = "123456",
            //        user_status = 0,
            //    };
            //    ls_user user2 = new ls_user()
            //    {
            //        user_name = "ccc",
            //        nick_name = "c",
            //        create_time = DateTime.Now,
            //        user_birth = null,
            //        user_password = "ccc",
            //        user_salt = "123456",
            //        user_status = 0,
            //    };
            //    ls_user user3 = new ls_user()
            //    {
            //        user_name = "ccc",
            //        nick_name = "c",
            //        create_time = DateTime.Now,
            //        user_birth = null,
            //        user_password = "ccc",
            //        user_salt = "123456",
            //        user_status = 0,
            //    };
            //    ls_user user4 = new ls_user()
            //    {
            //        user_name = "ccc",
            //        nick_name = "c",
            //        create_time = DateTime.Now,
            //        user_birth = null,
            //        user_password = "ccc",
            //        user_salt = "123456",
            //        user_status = 0,
            //    };
            //    role.users = new List<ls_user>
            //    {
            //        user,user1,user2,user3,user4
            //    };
            //    session.Save(user);
            //    session.Save(user1);
            //    session.Save(user2);
            //    session.Save(user3);
            //    session.Save(user4);
            //    session.Save(role);
            //    tran.Commit();
            //}

            //var models=session.Get<ls_role>(14);

            using (ITransaction tran = session.BeginTransaction())
            {
                //ls_role role = new ls_role()
                //{
                //    create_time=DateTime.Now,
                //    role_name="sss",
                //    role_status=0,   
                //};
                //ls_nav nav1 = new ls_nav()
                //{
                //    create_time=DateTime.Now,
                //    nav_title="ss",
                //    nav_status=0,
                //    nav_name="s",
                //    icon_url="s",
                //    nav_desc="ss",
                //    parent_id=0,
                //};
                //ls_nav nav2 = new ls_nav()
                //{
                //    create_time = DateTime.Now,
                //    nav_title = "ss",
                //    nav_status = 0,
                //    nav_name = "s",
                //    icon_url = "s",
                //    nav_desc = "ss",
                //    parent_id = 0,
                //};
                //ls_nav nav3 = new ls_nav()
                //{
                //    create_time = DateTime.Now,
                //    nav_title = "ss",
                //    nav_status = 0,
                //    nav_name = "s",
                //    icon_url = "s",
                //    nav_desc = "ss",
                //    parent_id = 0,
                //};

                //role.navs =new List<ls_nav>{ nav1,nav2,nav3};
                //session.Save(nav1);
                //session.Save(nav2);
                //session.Save(nav3);
                //session.Save(role);
                //tran.Commit();
                var model = (ls_user)session.Get(typeof(ls_user), 20);
                model.user_roles.Add(new ls_role()
                {
                    create_time=DateTime.Now,
                    role_name="jjj",
                    role_status=0
                });
                session.Save(model);
                tran.Commit();
            }
        }
    }
}