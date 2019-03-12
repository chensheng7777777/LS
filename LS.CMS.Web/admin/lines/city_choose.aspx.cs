using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LS.CMS.Model;
using LS.CMS.BLL;

namespace LS.CMS.Web.admin.lines
{
    public partial class city_choose : System.Web.UI.Page
    {
        protected List<tour_area> proviences=new List<tour_area>();
        protected List<tour_area> hotProviences=new List<tour_area>();
        tour_area_bll bll=new tour_area_bll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                proviences = bll.GetAreaInChina();
                string chinaCode = bll.GetChinaCode();
                hotProviences = bll.GetHotArea(chinaCode, 2);
            }
        }
    }
}