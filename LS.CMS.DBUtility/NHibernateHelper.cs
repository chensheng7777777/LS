using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LS.CMS.DBUtility
{
    public sealed class NHibernateHelper
    {
        private const string CurrentSessionKey = "ls.current_session";
        private static readonly ISessionFactory _sessionFactory;

        static NHibernateHelper()
        {
            _sessionFactory = new Configuration().Configure().BuildSessionFactory();
        }

        public static ISession GetCurrentSession()
        {
            var context = HttpContext.Current;
            var currentSession = context.Items[CurrentSessionKey] as ISession;

            if (currentSession == null)
            {
                currentSession = _sessionFactory.OpenSession(new TextSQLwatcher());
                context.Items[CurrentSessionKey] = currentSession;
            }

            return currentSession;
        }

        public static void CloseSession()
        {
            var context = HttpContext.Current;
            var currentSession = context.Items[CurrentSessionKey] as ISession;

            if (currentSession == null)
            {
                return;
            }

            currentSession.Close();
            context.Items.Remove(CurrentSessionKey);
        }

        public static void CloseSessionFactory()
        {
            if (_sessionFactory != null)
            {
                _sessionFactory.Close();
            }
        }
    }
}
