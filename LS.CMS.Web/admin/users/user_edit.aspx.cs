using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LS.CMS.Model;
using LS.CMS.BLL;
using LS.CMS.Common;

namespace LS.CMS.Web.admin.users
{
    public partial class user_edit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindControl();
            }
        }

        protected void BindControl()
        {
            ls_user_bll bll = new ls_user_bll();
            ls_user usr=bll.GetUserById(LSRequest.GetQueryInt("id"));
            if (usr == null)
            {
                Response.Redirect("user_list.aspx");
            }
            else
            {
                this.hidId.Value = usr.id.ToString();
                this.txtEmail.Text = usr.user_email;
                this.txtMobile.Text = usr.user_mobile;
                this.txtUserName.Text = usr.user_name;
                this.txtNickName.Text = usr.nick_name;
                this.rblSex.SelectedIndex = usr.user_gender;
                this.rblStatus.SelectedIndex = usr.user_status;
                this.txtAvatar.Text = usr.user_avatar;
                if (usr.user_birth.HasValue)
                {
                    this.txtBirthday.Text = usr.user_birth.Value.ToString("yyyy-MM-dd");
                }
                this.txtAvatar.Text = usr.user_avatar;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ls_user usr = new ls_user()
            {
                id=Convert.ToInt32(this.hidId.Value),
                user_email=this.txtEmail.Text,
                nick_name=this.txtNickName.Text,
                user_status=Convert.ToInt32(this.rblStatus.SelectedValue),
                user_mobile=this.txtMobile.Text,
                user_gender=Convert.ToInt32(this.rblSex.SelectedValue),
                user_avatar=txtAvatar.Text
            };
            if (!string.IsNullOrEmpty(txtBirthday.Text))
            {
                usr.user_birth = Convert.ToDateTime(txtBirthday.Text);
            }
            ls_user_bll bll = new ls_user_bll();
            bll.UpdateUser(usr);
            JscriptMsg("修改成功","user_list.aspx");
        }
    }
}