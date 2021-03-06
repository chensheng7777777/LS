﻿using System;
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
                BindPageSizeTxt();
                BindRoleDropDownList();
                BindUserList();
            }
        }


        /// <summary>
        /// 绑定数据
        /// </summary>
        protected void BindUserList(string pageIndex=null)
        {
            string startTime = txtStartTime.Text;
            string endTime = txtEndTime.Text;
            this.page = LSRequest.GetQueryInt("page",1);
            if (!string.IsNullOrEmpty(pageIndex))
            {
                this.page = Convert.ToInt32(pageIndex);
            }
            this.pageSize = GetPageSize(10);
            string name = txtKeywords.Text;
            int role_id = Utils.StrToInt(this.ddlRole.SelectedValue, 0);
            int totalCount;
            IList<ls_user> users = new ls_user_bll().GetPagedUserList(this.page,this.pageSize, name, startTime, endTime, role_id,out totalCount);

            //为Repeater绑定数据
            rptList.DataSource = users;
            rptList.DataBind();
            string pageUrl = Utils.CombUrlTxt("user_list.aspx","page={0}", "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, totalCount, pageUrl, 8);
        }


        protected void BindPageSizeTxt()
        {
            this.txtPageNum.Text = GetPageSize(10).ToString();
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
            BindUserList();
        }

        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            //如果是点击搜索,那么需要回到第一页
            BindUserList("1");
        }

        protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindUserList("1");
        }
        /// <summary>
        /// 删除按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            List<int> ids = new List<int>();
            for (int i=0;i<rptList.Items.Count;i++)
            {
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                HiddenField hf = (HiddenField)rptList.Items[i].FindControl("hidId");
                if (cb.Checked)
                {
                    ids.Add(Convert.ToInt32(hf.Value));
                }
            }
            ls_user_bll userBLL = new ls_user_bll();
            if (userBLL.DeleteUsers(ids))
            {
                
                JscriptMsg("删除成功", Utils.CombUrlTxt("user_list.aspx","page={0}",this.page.ToString()));
                
            }
            else
            {
                JscriptMsg("删除失败","");
            }
        }
    }
}