using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LS.CMS.Common;
using LS.CMS.Model;
using LS.CMS.DBUtility;
using NHibernate;

namespace LS.CMS.DAL
{
    /// <summary>
    /// 日志
    /// </summary>
    public class ls_log_dal
    {
        private ISession session = NHibernateHelper.GetCurrentSession();
        /// <summary>
        /// 保存日志信息
        /// </summary>
        /// <param name="log"></param>
        public void SaveLog(ls_log log)
        {
            try
            {
                using (ITransaction tran=session.BeginTransaction())
                {
                    session.Save(log);
                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                LogHelper.SaveException(ex);
            }
        }
    }
}
