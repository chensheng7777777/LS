using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LS.CMS.Model
{
    /// <summary>
    /// 角色实体类
    /// </summary>
    [Serializable]
    public class ls_role
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ls_role()
        {

        }
        /// <summary>
        /// 角色id
        /// </summary>
        public virtual int id { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public virtual string role_name { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime create_time { get; set; }
        /// <summary>
        /// 角色状态
        /// </summary>
        public virtual int role_status { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public virtual IList<ls_user> users { get; set; }
    }
}
