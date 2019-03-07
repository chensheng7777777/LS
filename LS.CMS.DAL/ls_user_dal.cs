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
using System.Data.SqlClient;
using System.Data;

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
        /// 根据id获取用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ls_user GetUserById(int id)
        {
            return db.Load<ls_user>(id);
        }

        /// <summary>
        /// 使用hql更新
        /// </summary>
        /// <param name="usr"></param>
        public void UpdateUser(ls_user usr)
        {
            IQuery query = db.CreateQuery("update ls_user set user_email=:user_email,nick_name=:nick_name,user_status=:user_status,user_mobile=:user_mobile,user_gender=:user_gender,user_birth=:user_birth,user_avatar=:user_avatar where id=:id");
            query.SetString("user_email", usr.user_email);
            query.SetString("nick_name", usr.nick_name);
            query.SetInt32("user_status", usr.user_status);
            query.SetString("user_mobile", usr.user_mobile);
            query.SetInt32("user_gender", usr.user_gender);
            query.SetParameter("user_birth",usr.user_birth);
            query.SetString("user_avatar",usr.user_avatar);
            query.SetInt32("id",usr.id);
            query.ExecuteUpdate();
        }

        /// <summary>
        /// 判断用户名是否存在
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>是否存在</returns>
        public bool IsUserNameExist(string userName)
        {
            string sql = "select count(1) from dbo.ls_user where user_name=@user_name";
            SqlParameter[] parameters = 
            {
                new SqlParameter("@user_name",userName)
            };
            int result = 0;
            try
            {
                result = (int)SqlHelper.ExecuteScalar(SqlHelper.CMS_CONNECTIONSTRING, CommandType.Text, sql, parameters);
            }
            catch (Exception e)
            {
                LogHelper.SaveException(e);
            }
            return result > 0;
        }


        public bool IsUserNameExists(string userName)
        {
            ICriteria criteria = db.CreateCriteria(typeof(ls_user));
            criteria.Add(Restrictions.Eq("user_name",userName));
            return ((int)criteria.SetProjection(Projections.RowCount()).UniqueResult()>0);
        }


        /// <summary>
        /// 保存用户
        /// </summary>
        /// <param name="usr"></param>
        /// <returns></returns>
        public ls_user SaveUser(ls_user usr)
        {
            object id=db.Save(usr);
            usr.id = (int)id;
            return usr;
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

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool DeleteUsers(List<int> ids)
        {
            bool result = false;
            ITransaction tran=db.BeginTransaction();
            try
            {
                foreach (int id in ids)
                {
                    db.Delete(new ls_user() {id=id });
                }
                tran.Commit();
                result = true;
            }
            catch (Exception ex)
            {
                LogHelper.SaveException(ex);
                tran.Rollback();
            }
            finally
            {
                tran.Dispose();
            }
            return result;
        }


        /// <summary>
        /// 获取用户分页
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="name"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public IList<ls_user> GetPagedUserList(int pageIndex, int pageSize, string name, string startTime, string endTime, int role_id,out int totalCount)
        {
            //ICriteria criteria = db.CreateCriteria(typeof(ls_user));
            //Disjunction dis = Restrictions.Disjunction();
            //if (!string.IsNullOrEmpty(name))
            //{
            //    dis.Add(Restrictions.Like("user_name","%"+name+"%"));
            //}
            //if (!string.IsNullOrEmpty(startTime))
            //{
            //    dis.Add(Restrictions.Gt("create_time",Convert.ToDateTime(startTime)));
            //}
            //if (!string.IsNullOrEmpty(endTime))
            //{
            //    dis.Add(Restrictions.Lt("create_time", Convert.ToDateTime(endTime)));
            //}
            //criteria.Add(dis);
            //totalCount=(int)criteria.SetProjection(Projections.RowCount()).UniqueResult();
            //criteria.SetFirstResult(pageIndex*pageSize);
            //criteria.SetMaxResults(pageSize);
            //return criteria.List<ls_user>();
            ICriteria criteria = db.CreateCriteria(typeof(ls_user),"t1");
           
            if (!string.IsNullOrEmpty(name))
            {
                criteria.Add(Restrictions.Like("user_name", "%" + name + "%"));
            }
            if (!string.IsNullOrEmpty(startTime))
            {
                criteria.Add(Restrictions.Gt("create_time", Convert.ToDateTime(startTime)));
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                criteria.Add(Restrictions.Lt("create_time", Convert.ToDateTime(endTime)));
            }
            if (role_id>0)
            {
                criteria.CreateAlias("user_roles", "t2");
                criteria.Add(Restrictions.Eq("t2.id", role_id));
            }
            ICriteria totalCriteria = (ICriteria)criteria.Clone();
            totalCount = (int)totalCriteria.SetProjection(Projections.RowCount()).UniqueResult();
            criteria.AddOrder(Order.Desc("id"));
            criteria.SetFirstResult((pageIndex - 1) * pageSize);
            criteria.SetMaxResults(pageSize);
            return criteria.List<ls_user>();
        }

    }
}
