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
        public int id { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public int user_id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string user_name { get; set; }
        /// <summary>
        /// 用户ip
        /// </summary>
        public string user_ip { get; set; }
        /// <summary>
        /// 访问时间
        /// </summary>
        public DateTime visit_time { get; set; }
        /// <summary>
        /// 访问url
        /// </summary>
        public string visit_url { get; set; }
        /// <summary>
        /// 用户地区
        /// </summary>
        public string visit_area { get; set; }
        /// <summary>
        /// 用户操作系统
        /// </summary>
        public string visit_os { get; set; }
        /// <summary>
        /// 用户浏览器
        /// </summary>
        public string visit_browser { get; set; }
    }
}
