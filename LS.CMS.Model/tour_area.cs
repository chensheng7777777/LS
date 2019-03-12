using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LS.CMS.Model
{
    /// <summary>
    /// 地区信息
    /// </summary>
    [Serializable]
    public class tour_area
    {
        public tour_area()
        { }

        /// <summary>
        /// 地区id
        /// </summary>
        public virtual int id { get; set; }
        /// <summary>
        /// 地区名称
        /// </summary>
        public virtual string area_name { get; set; }
        /// <summary>
        /// 地区类型(0:洲,1:国家,2:省,3:城市)
        /// </summary>
        public virtual int area_type { get; set; }
        /// <summary>
        /// 地区编号
        /// </summary>
        public virtual string area_code { get; set; }
        /// <summary>
        /// 父级编号
        /// </summary>
        public virtual string parent_code { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public virtual string area_longitude { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public virtual string area_latitude { get; set; }
        /// <summary>
        /// 点击次数(作为热门城市使用)
        /// </summary>
        public virtual int? key_times { get; set; }
        /// <summary>
        /// 地区英文名称
        /// </summary>
        public virtual string area_en { get; set; }
        /// <summary>
        /// 地区别名
        /// </summary>
        public virtual string area_alias { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime create_time { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public virtual int create_user { get; set; }
    }
}
