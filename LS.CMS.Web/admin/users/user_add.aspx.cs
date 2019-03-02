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
    public partial class user_add : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.lblRegIP.Text = Utils.GetIPAddress();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ls_user usr = new ls_user()
            {
                user_status = Convert.ToInt32(this.rblStatus.SelectedValue),
                user_email=txtEmail.Text,
                user_salt=Guid.NewGuid().ToString().Substring(0,6),
                create_ip=this.lblRegIP.Text,
                create_time=DateTime.Now,
                nick_name=txtNickName.Text,
                real_name=txtRealName.Text,
                user_gender=Convert.ToInt32(rblSex.SelectedValue),
                user_mobile=txtMobile.Text,
                user_name=txtUserName.Text
            };
            if (!string.IsNullOrEmpty(txtBirthday.Text))
            {
                usr.user_birth = Convert.ToDateTime(txtBirthday.Text);
            }
            //为密码加密
            usr.user_password = DESEncrypt.Encrypt(txtPassword.Text, usr.user_salt) ;
            ls_user_bll userBLL = new ls_user_bll();
            if (userBLL.SaveUser(usr))
            {
                Response.Redirect("user_list.aspx");
            }
            else
            {
                lbError.Text = "保存失败";
            }
        }
    }
}