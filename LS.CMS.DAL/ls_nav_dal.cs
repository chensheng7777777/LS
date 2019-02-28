using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LS.CMS.Common;
using LS.CMS.DBUtility;
using LS.CMS.Model;
using NHibernate;
using NHibernate.Criterion;

namespace LS.CMS.DAL
{
    /// <summary>
    /// 系统导航数据访问类
    /// </summary>
    public class ls_nav_dal
    {
        private ISession session = NHibernateHelper.GetCurrentSession();

        /// <summary>
        /// 根据用户id获取用户所有的导航
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns>导航集合</returns>
        public IList<ls_nav> GetNavs(int userId)
        {
            return session.CreateSQLQuery("select t3.* from dbo.ls_user_role as t1 inner join dbo.ls_role_nav as t2 on t1.role_id=t2.role_id inner join dbo.ls_nav as t3 on t2.nav_id=t3.id where t1.user_id=:user_id").SetInt32("user_id", userId).List<ls_nav>();

        }

    }
}
