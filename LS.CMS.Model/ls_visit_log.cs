using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LS.CMS.Model
{
    /// <summary>
    /// 访问日志
    /// </summary>
    [Serializable]
    public class ls_visit_log
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ls_visit_log()
        {

        }

        /// <summary>
        /// 编号
        /// </summary>
        public virtual string id { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public virtual int user_id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public virtual string user_name { get; set; }
        /// <summary>
        /// 用户ip
        /// </summary>
        public virtual string visit_ip { get; set; }
        /// <summary>
        /// 访问时间
        /// </summary>
        public virtual DateTime visit_time { get; set; }
        /// <summary>
        /// 访问url
        /// </summary>
        public virtual string visit_url { get; set; }
        /// <summary>
        /// 用户地区
        /// </summary>
        public virtual string visit_area { get; set; }
        /// <summary>
        /// 用户操作系统
        /// </summary>
        public virtual string visit_os { get; set; }
        /// <summary>
        /// 用户浏览器
        /// </summary>
        public virtual string visit_browser { get; set; }
    }
}
