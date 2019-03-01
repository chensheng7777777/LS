using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LS.CMS.DAL;
using LS.CMS.Model;
using LS.CMS.Common;


namespace LS.CMS.BLL
{
    /// <summary>
    /// 系统配置业务逻辑类
    /// </summary>
    public class ls_sysconfig_bll
    {
        private ls_sysconfig_dal dal = new ls_sysconfig_dal();

        /// <summary>
        /// 获得系统配置
        /// </summary>
        /// <returns></returns>
        public ls_sysconfig LoadConfig()
        {
            ls_sysconfig model = CacheHelper.Get<ls_sysconfig>(LSKeys.CACHE_SYS_CONFIG);
            if (model==null)
            {
                model = dal.LoadConfig(Utils.GetXmlMapPath(LSKeys.FILE_SYS_CONFIG));
                CacheHelper.Insert(LSKeys.CACHE_SYS_CONFIG, model, Utils.GetXmlMapPath(LSKeys.FILE_SYS_CONFIG));
            }
            return model;
        }

        /// <summary>
        /// 保存配置信息
        /// </summary>
        /// <param name="config"></param>
        public void SaveConfig(ls_sysconfig config)
        {
            dal.SaveConfig(config,Utils.GetXmlMapPath(LSKeys.FILE_SYS_CONFIG));
        }


    }
}
