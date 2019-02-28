using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LS.CMS.Model
{
    /// <summary>
    /// 导航实体类
    /// </summary>
    [Serializable]
    public class ls_nav
    {
        public ls_nav()
        {

        }
        /// <summary>
        /// 导航主键
        /// </summary>
        public virtual int id { get; set; }
        /// <summary>
        /// 父ID
        /// </summary>
        public virtual int parent_id { get; set; }
        /// <summary>
        /// 导航名称
        /// </summary>
        public virtual string nav_name { get; set; }
        /// <summary>
        /// 导航标题
        /// </summary>
        public virtual string nav_title { get; set; }
        /// <summary>
        /// 导航图标
        /// </summary>
        public virtual string icon_url { get; set; }
        /// <summary>
        /// 导航地址
        /// </summary>
        public virtual string link_url { get; set; }
        /// <summary>
        /// 导航状态
        /// </summary>
        public virtual int nav_status { get; set; }
        /// <summary>
        /// 导航alt
        /// </summary>
        public virtual string nav_desc { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime create_time { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public virtual IList<ls_role> roles { get; set; }
    }
}
