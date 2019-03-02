using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NHibernate;
using LS.CMS.DBUtility;
using LS.CMS.Model;
using LS.CMS.BLL;

namespace LS.CMS.Web.test
{
    public partial class testNH : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //int count=sql_analysis.GetDayCount(2019,3,1);
            ls_visit_log_bll bll = new ls_visit_log_bll();
            bll.SaveLogs(new List<ls_visit_log>() {
                new ls_visit_log()
                {
                    user_id=1,
                    user_name="1",
                    visit_time=DateTime.Now,
                    visit_url="123"
                }
            });

        }
    }
}