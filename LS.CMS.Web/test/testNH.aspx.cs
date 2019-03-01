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
            ls_sysconfig_bll bll = new ls_sysconfig_bll();
            bll.SaveConfig(new ls_sysconfig() { });

        }
    }
}