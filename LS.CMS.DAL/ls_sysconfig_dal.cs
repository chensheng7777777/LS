using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LS.CMS.Model;
using LS.CMS.Common;


namespace LS.CMS.DAL
{
    public class ls_sysconfig_dal
    {
        private static object lockHelper = new object();

        /// <summary>
        /// 读取站点配置文件
        /// </summary>
        /// <param name="configPath"></param>
        /// <returns></returns>
        public ls_sysconfig LoadConfig(string configPath)
        {
            return (ls_sysconfig)SerializationHelper.Load(typeof(ls_sysconfig),configPath);
        }
        /// <summary>
        /// 写入站点配置文件
        /// </summary>
        /// <param name="config"></param>
        /// <param name="configFilePath"></param>
        public void SaveConfig(ls_sysconfig config,string configFilePath)
        {
            lock (lockHelper)
            {
                SerializationHelper.Save(config, configFilePath);
            }
        }
        

    }
}
