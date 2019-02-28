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
    public class ls_nav_bll
    {
        private ls_nav_dal navDAL = new ls_nav_dal();

        public IList<ls_nav> GetNavs(int userId)
        {
            return navDAL.GetNavs(userId);
        }
    }
}
