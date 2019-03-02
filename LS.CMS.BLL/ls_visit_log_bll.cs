using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LS.CMS.Common;
using LS.CMS.DAL;
using LS.CMS.Model;

namespace LS.CMS.BLL
{
    public class ls_visit_log_bll
    {
        private ls_visit_log_dal dal = new ls_visit_log_dal();
        /// <summary>
        /// 批量保存日志
        /// </summary>
        /// <param name="logs"></param>
        /// <returns></returns>
        public bool SaveLogs(List<ls_visit_log> logs)
        {
            return dal.SaveLogList(logs);
        }

    }
}
