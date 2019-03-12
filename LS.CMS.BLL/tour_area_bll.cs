using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using LS.CMS.Common;
using LS.CMS.DAL;
using LS.CMS.Model;

namespace LS.CMS.BLL
{
    /// <summary>
    /// 地区业务逻辑类
    /// </summary>
    public class tour_area_bll
    {
        private tour_area_dal dal=new tour_area_dal();
        /// <summary>
        /// 获取前十条点击数据
        /// </summary>
        /// <returns></returns>
        public List<tour_area> GetTop10Area()
        {
            return dal.GetTopAreaInfo(10);
        }

        /// <summary>
        /// 获取国内的省
        /// </summary>
        /// <returns></returns>
        public List<tour_area> GetAreaInChina()
        {
            //首先获取中国的code 
            object code = CacheHelper.Get("china_code");
            if (code == null)
            {
                code = dal.GetAreaCodeByName("中国");
                CacheHelper.Insert("china_code",code);
            }

            string chinaCode = Utils.ObjectToStr(code);
            return dal.GetAreaByParent(chinaCode,2);
        }

        public string GetAreaCode(string name)
        {
            return dal.GetAreaCodeByName(name);
        }

        public string GetChinaCode()
        {
            object code = CacheHelper.Get("china_code");
            if (code == null)
            {
                code = dal.GetAreaCodeByName("中国");
                CacheHelper.Insert("china_code", code);
            }

            return Utils.ObjectToStr(code);
        }



        public List<tour_area> GetHotArea(string parentCode,int type)
        {
            return dal.GetTopAreaByParent(parentCode);
        }


        public IList<tour_area> GetAllAreas()
        {
            return dal.GetAllAreas();
        }


    }
}
