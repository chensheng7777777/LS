using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LS.CMS.DAL;
using LS.CMS.Model;
using LS.CMS.Common;


namespace LS.CMS.BLL
{
    /// <summary>
    /// 日志业务逻辑类
    /// </summary>
    public class ls_log_bll
    {
        private ls_log_dal dal = new ls_log_dal();
        /// <summary>
        /// 保存日志
        /// </summary>
        /// <param name="log"></param>
        public void SaveLog(ls_log log)
        {
            dal.SaveLog(log);
        }
    }
}
