using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LS.CMS.Common;
using LS.CMS.Model;
using LS.CMS.BLL;

namespace LS.CMS.Web.admin.users
{
    public partial class user_list : BasePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRoleDropDownList();
            }
        }


        /// <summary>
        /// 绑定数据
        /// </summary>
        protected void BindUserList()
        {
            string startTime = txtStartTime.Text;
            string endTime = txtEndTime.Text;
            this.page = LSRequest.GetQueryInt("page",1);
            this.pageSize = GetPageSize(10);
            string name = txtKeywords.Text;

           
        }



        /// <summary>
        /// 返回用户pageSize
        /// </summary>
        /// <param name="defaultSize"></param>
        /// <returns></returns>
        private int GetPageSize(int defaultSize)
        {
            int _pageSize;
            if (int.TryParse(Utils.GetCookie("user_list_page_size"),out _pageSize))
            {
                if (_pageSize>0)
                {
                    return _pageSize;
                }
            }
            return defaultSize;
        }
        /// <summary>
        /// 绑定角色下拉框
        /// </summary>
        private void BindRoleDropDownList()
        {
            ls_role_bll bll = new ls_role_bll();
            IList<ls_role> roleList = bll.GetAllRoles();//获得所有角色

            //清空下拉框
            this.ddlRole.Items.Clear();
            //添加一个默认项
            this.ddlRole.Items.Add(new ListItem("所有角色",""));
            //循环列表添加角色下拉框
            foreach (ls_role role in roleList)
            {
                this.ddlRole.Items.Add(new ListItem(role.role_name,role.id.ToString()));
            }

        }






        /// <summary>
        /// 切换每页显示条数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pageSize;
            if (int.TryParse(txtPageNum.Text.Trim(),out _pageSize))
            {
                if (_pageSize>0)
                {
                    Utils.WriteCookie("user_list_page_size", _pageSize.ToString(), 14400);
                    this.pageSize = _pageSize;
                }
            }
        }
    }
}