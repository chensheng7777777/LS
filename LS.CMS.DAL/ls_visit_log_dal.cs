using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LS.CMS.Common;
using LS.CMS.DBUtility;
using LS.CMS.Model;
using NHibernate;
using NHibernate.Cfg;

namespace LS.CMS.DAL
{
    /// <summary>
    /// 访问日志数据访问层
    /// </summary>
    public class ls_visit_log_dal
    {
        private static ISession _session;

        public static ISession session
        {
            get
            {
                if (_session==null)
                {
                    _session = NHibernateHelper._sessionFactory.OpenSession();
                }
                return _session;
            }
        }

        /// <summary>
        /// 批量保存日志
        /// </summary>
        /// <param name="logs"></param>
        /// <returns></returns>
        public bool SaveLogList(List<ls_visit_log> logs)
        {
            ITransaction tran;
            using (tran=session.BeginTransaction())
            {
                try
                {
                    foreach (ls_visit_log log in logs)
                    {
                        session.Save(log);
                    }
                    tran.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    LogHelper.SaveException(ex);
                    tran.Rollback();
                }
                finally
                {
                    if (tran!=null)
                    {
                        try
                        {
                            tran.Dispose();
                        }
                        catch (Exception ex)
                        {
                            LogHelper.SaveException(ex);
                        }
                    }
                }
            }
            return false;
        }

    }
}
