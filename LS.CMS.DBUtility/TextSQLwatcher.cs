using NHibernate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LS.CMS.Common;

namespace LS.CMS.DBUtility
{
    public class TextSQLwatcher: EmptyInterceptor
    {
        public override NHibernate.SqlCommand.SqlString OnPrepareStatement(NHibernate.SqlCommand.SqlString sql)
        {
            LogHelper.SaveSQLToLog(sql.ToString());
            return base.OnPrepareStatement(sql);
        }
    }
}