using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LS.CMS.Model;
using LS.CMS.Common;
using LS.CMS.DAL;


namespace LS.CMS.BLL
{
    /// <summary>
    /// 角色业务逻辑层
    /// </summary>
    public class ls_role_bll
    {
        private ls_role_dal dal = new ls_role_dal();
        /// <summary>
        /// 获得所有角色
        /// </summary>
        /// <returns></returns>
        public IList<ls_role> GetAllRoles()
        {
            return dal.GetAllRoles();
        }
    }
}
