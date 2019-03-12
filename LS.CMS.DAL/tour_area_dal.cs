using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using IBatisNet.DataMapper;
using LS.CMS.Common;
using LS.CMS.DBUtility;
using LS.CMS.Model;
using NHibernate;
using NHibernate.Criterion;

namespace LS.CMS.DAL
{
    public class tour_area_dal
    {
        /// <summary>
        /// 查询前十条数据
        /// </summary>
        /// <returns></returns>
        public List<tour_area> GetTopAreaInfo(int count)
        {
            List<tour_area> list=new List<tour_area>();
            string sql = "select top "+count+" * from dbo.tour_area order by key_times desc";
            DataSet ds = DbHelperSQL.Query(sql);
            if(ds.Tables[0].Rows.Count>0)
            {
                DataRowCollection rows = ds.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    list.Add(DataRowToModel(row));
                }
            }

            return list;
        }

        public IList<tour_area> GetAllAreas()
        {
            ISqlMapper mapper = Mapper.Instance();
            IList<tour_area> areas = mapper.QueryForList<tour_area>("SelectAllArea", null);
            return areas;
        }


        public List<tour_area> GetTopAreaInfoIn(int count,string parentCode)
        {
            List<tour_area> list=new List<tour_area>();
            string sql = $"select top {count} from dbo.tour_area where parent_code=@parent_code order by key_times desc";
            DataSet ds = DbHelperSQL.Query(sql,new SqlParameter("@parent_code",parentCode));
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRowCollection rows = ds.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    list.Add(DataRowToModel(row));
                }
            }
            return list;
        }

        /// <summary>
        /// 根据名称获取
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetAreaCodeByName(string name)
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            string hql = "select area_code from tour_area where area_name=:area_name";
            IQuery query = session.CreateQuery(hql);
            query.SetString("area_name",name);
            return Utils.ObjectToStr(query.UniqueResult());
        }


        public List<tour_area> GetAreaByParent(string parentCode,int type)
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            ICriteria criteria = session.CreateCriteria(typeof(tour_area));
            criteria.Add(Restrictions.Eq("parent_code",parentCode));
            criteria.Add(Restrictions.Eq("area_type",type));
            criteria.AddOrder(Order.Asc("id"));
            return criteria.List<tour_area>().ToList();
        }

        public List<tour_area> GetTopAreaByParent(string parentCode)
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            ICriteria criteria = session.CreateCriteria(typeof(tour_area));
            criteria.Add(Restrictions.Eq("parent_code", parentCode));
            criteria.AddOrder(Order.Desc("key_times"));
            criteria.SetMaxResults(10);
            return criteria.List<tour_area>().ToList();
        }



        public tour_area DataRowToModel(DataRow row)
        {
            tour_area model = new tour_area();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["area_name"] != null)
                {
                    model.area_name = row["area_name"].ToString();
                }
                if (row["area_type"] != null && row["area_type"].ToString() != "")
                {
                    model.area_type = int.Parse(row["area_type"].ToString());
                }
                if (row["area_code"] != null)
                {
                    model.area_code = row["area_code"].ToString();
                }
                if (row["parent_code"] != null)
                {
                    model.parent_code = row["parent_code"].ToString();
                }
                if (row["area_longitude"] != null)
                {
                    model.area_longitude = row["area_longitude"].ToString();
                }
                if (row["area_latitude"] != null)
                {
                    model.area_latitude = row["area_latitude"].ToString();
                }
                if (row["key_times"] != null && row["key_times"].ToString() != "")
                {
                    model.key_times = int.Parse(row["key_times"].ToString());
                }
                if (row["area_en"] != null)
                {
                    model.area_en = row["area_en"].ToString();
                }
                if (row["area_alias"] != null)
                {
                    model.area_alias = row["area_alias"].ToString();
                }
                if (row["create_time"] != null && row["create_time"].ToString() != "")
                {
                    model.create_time = DateTime.Parse(row["create_time"].ToString());
                }
                if (row["create_user"] != null && row["create_user"].ToString() != "")
                {
                    model.create_user = int.Parse(row["create_user"].ToString());
                }
            }
            return model;
        }

    }
}
