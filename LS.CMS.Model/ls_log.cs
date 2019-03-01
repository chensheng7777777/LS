using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LS.CMS.Model
{
    /// <summary>
    /// 操作日志
    /// </summary>
    [Serializable]
    public class ls_log
    {
        public ls_log()
        {

        }
        /// <summary>
        /// 日志id
        /// </summary>
        public virtual int id { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public virtual int user_id { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public virtual string user_name { get; set; }
        /// <summary>
        /// 操作类型
        /// </summary>
        public virtual string action_type { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string remark { get; set; }
        /// <summary>
        /// 用户登录ip
        /// </summary>
        public virtual string user_ip { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public virtual DateTime add_time { get; set; }
    }
}
