using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using LS.CMS.DBUtility;
using LS.CMS.Common;
using LS.CMS.Model;

namespace LS.CMS.DAL
{
    /// <summary>
    /// 用户角色数据访问层
    /// </summary>
    public class ls_role_dal
    {
        private ISession session = NHibernateHelper.GetCurrentSession();

        /// <summary>
        /// 获得所有角色
        /// </summary>
        /// <returns></returns>
        public IList<ls_role> GetAllRoles()
        {
            ICriteria criteria=session.CreateCriteria(typeof(ls_role));
            return criteria.List<ls_role>();
        }

    }
}
