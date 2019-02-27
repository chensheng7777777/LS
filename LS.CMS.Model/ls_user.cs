using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LS.CMS.Model
{
    /// <summary>
    /// 用户实体类
    /// </summary>
    [Serializable]
    public class ls_user
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ls_user()
        {

        }
        /// <summary>
        /// 用户id
        /// </summary>
        public virtual int id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public virtual string user_name { get; set; }
        /// <summary>
        /// 用户手机
        /// </summary>
        public virtual string user_mobile { get; set; }
        /// <summary>
        /// 用户邮箱
        /// </summary>
        public virtual string user_email { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public virtual string user_password { get; set; }
        /// <summary>
        /// 用户加密盐
        /// </summary>
        public virtual string user_salt { get; set; }
        /// <summary>
        /// 用户头像
        /// </summary>
        public virtual string user_avatar { get; set; }
        /// <summary>
        /// 用户性别
        /// </summary>
        public virtual int user_gender { get; set; }
        /// <summary>
        /// 用户生日
        /// </summary>
        public virtual DateTime? user_birth { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public virtual string nick_name { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public virtual string real_name { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime create_time { get; set; }
        /// <summary>
        /// 创建ip
        /// </summary>
        public virtual string create_ip { get; set; }
        /// <summary>
        /// 用户状态
        /// </summary>
        public virtual int user_status { get; set; }
        /// <summary>
        /// 用户角色
        /// </summary>
        public virtual IList<ls_role> user_roles { get; set; }
    }
}
