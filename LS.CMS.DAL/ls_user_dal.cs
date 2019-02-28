using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LS.CMS.Model;
using LS.CMS.DBUtility;
using NHibernate;
using LS.CMS.Common;
using NHibernate.Criterion;

namespace LS.CMS.DAL
{
    public class ls_user_dal
    {
        private ISession db = NHibernateHelper.GetCurrentSession();
        /// <summary>
        /// 获取用户加密盐
        /// </summary>
        /// <param name="loginName">登录名称</param>
        /// <returns>用户加密盐</returns>
        public string GetSalt(string loginName)
        {
            StringBuilder hql = new StringBuilder();
            hql.Append("select user_salt from ls_user");
            if (RegexUtil.IsMobilePhone(loginName))//如果是手机号
            {
                hql.Append(" where user_mobile=?");
            }
            else if (RegexUtil.IsEmail(loginName))//如果是邮箱
            {
                hql.Append(" where user_email=?");
            }
            else
            {
                hql.Append(" where user_name=?");
            }
            IQuery query = db.CreateQuery(hql.ToString());
            query.SetParameter(0, loginName);
            object obj = query.UniqueResult();
            if (obj == null)
            {
                return "";
            }
            else
            {
                return (string)obj;
            }
        }

        /// <summary>
        /// 根据登录名密码获取用户
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <param name="loginPwd">密码</param>
        /// <param name="isEncrypt">密码是否需要加密</param>
        /// <returns>用户实体</returns>
        public ls_user GetUser(string loginName,string loginPwd,bool isEncrypt)
        {
            ICriteria criteria = db.CreateCriteria(typeof(ls_user));
            if (isEncrypt)//如果需要对密码进行加密
            {
                string salt = this.GetSalt(loginName);//获得用户加密盐
                if (string.IsNullOrEmpty(salt))//如果无法获得用户加密盐
                {
                    return null;
                }
                loginPwd = DESEncrypt.Encrypt(loginPwd, salt);
            }
            if (RegexUtil.IsMobilePhone(loginName))
            {
                criteria.Add(Expression.Eq("user_mobile", loginName));
            }
            else if (RegexUtil.IsEmail(loginName))
            {
                criteria.Add(Expression.Eq("user_email", loginName));
            }
            else
            {
                criteria.Add(Expression.Eq("user_name",loginName));
            }
            criteria.Add(Expression.Eq("user_password",loginPwd));
            return criteria.UniqueResult<ls_user>();
        }

    }
}
