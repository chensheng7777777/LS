using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LS.CMS.Common
{
    public class LSKeys
    {
        #region SESSION KEYS

        /// <summary>
        /// 用户SESSION
        /// </summary>
        public const string SESSION_USER_INFO = "ls_session_user_info";

        /// <summary>
        /// 用户登录次数SESSION
        /// </summary>
        public const string SESSION_LOGIN_SUM = "ls_session_login_sum";


        #endregion



        #region COOKIE KEYS 

        /// <summary>
        /// 用户名COOKIE
        /// </summary>
        public const string COOKIE_USER_NAME = "ls_cookie_user_name";
        /// <summary>
        /// 密码COOKIE
        /// </summary>
        public const string COOKIE_PASSWORD = "ls_cookie_password";

        #endregion


        #region CACHE HELPER

        /// <summary>
        /// 系统配置缓存键
        /// </summary>
        public const string CACHE_SYS_CONFIG = "ls_cache_sys_config";

        #endregion


        #region FILE HELPER
        /// <summary>
        /// 文件系统配置
        /// </summary>
        public const string FILE_SYS_CONFIG = "sysconfig";

        #endregion
    }
}
