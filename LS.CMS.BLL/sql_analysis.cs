using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LS.CMS.Common;
using System.IO;

namespace LS.CMS.BLL
{
    public class sql_analysis
    {
        /// <summary>
        /// 获得当天的SQL语句执行次数
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static int GetDayCount(int year, int month, int day)
        {
            string path = LogHelper.GetLogDirectory("SQL")+"/"+ year + "-"+(month<10?"0"+month:month.ToString())+"-"+ (day < 10 ? "0" + day : day.ToString()) + ".txt";
            return File.ReadAllLines(path).Count() / 3;
        }
    }
}
