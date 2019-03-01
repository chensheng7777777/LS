﻿using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LS.CMS.Model;

namespace LS.CMS.Web.admin
{
    public partial class index : BasePage
    {
        protected ls_user UserInfo;
        protected string navObj;
        protected void Page_Load(object sender, EventArgs e)
        {
            UserInfo = GetUserInfo();
            navObj = GetNavObjs();
        }
    }
}