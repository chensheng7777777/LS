using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LS.CMS.Common
{
    public class LogHelper
    {
        private LogHelper()
        {

        }
        /// <summary>
        /// 日志目录
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public static string GetLogDirectory(string category)
        {
            string baseDirectory = string.Empty;
            baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            if ((baseDirectory[baseDirectory.Length - 1] != '/') && (baseDirectory[baseDirectory.Length - 1] != '\\'))
            {
                baseDirectory = baseDirectory + @"\";
            }
            baseDirectory = string.Format(@"{0}Log\{1}\", baseDirectory, category);
            if (!Directory.Exists(baseDirectory))
            {
                Directory.CreateDirectory(baseDirectory);
            }
            return baseDirectory;
        }


        /// <summary>
        /// 保存HibernateSQL语句
        /// </summary>
        /// <param name="sql"></param>
        public static void SaveSQLToLog(string sql)
        {
            FileStream stream = new FileStream(GetLogDirectory("SQL") + DateTime.Now.ToString("yyyy-MM-dd") + ".txt", FileMode.Append, FileAccess.Write, FileShare.Delete | FileShare.ReadWrite);
            StreamWriter writer = new StreamWriter(stream);
            if (!string.IsNullOrWhiteSpace(sql))
                writer.WriteLine(string.Format("Sql:{0},DateTime:{1}", sql, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff")));
            stream.Flush();
            writer.Close();
            stream.Close();
        }
        /// <summary>
        /// 将访问记录保存到日志中
        /// </summary>
        /// <param name="visit"></param>
        public static void SaveVisitToLog(string visit)
        {
            FileStream stream = new FileStream(GetLogDirectory("VISIT") + DateTime.Now.ToString("yyyy-MM-dd") + ".txt", FileMode.Append, FileAccess.Write, FileShare.Delete | FileShare.ReadWrite);
            StreamWriter writer = new StreamWriter(stream);
            if (!string.IsNullOrWhiteSpace(visit))
                writer.WriteLine(string.Format("Visit:{0},DateTime:{1}", visit, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff")));
            stream.Flush();
            writer.Close();
            stream.Close();
        }

        /// <summary>
        /// 保存日志
        /// </summary>
        /// <param name="note"></param>
        public static void SaveNoteAndException(string note, Exception ex)
        {
            string exNote = string.Empty;

            if (ex != null)
            {
                exNote = "异常信息：" + ex.Message + "</br>\r\n";
                exNote += "Source：" + ex.Source + "</br>\r\n";
                exNote += "StackTrace：" + ex.StackTrace + "</br>\r\n";
            }
            FileStream stream = new FileStream(GetLogDirectory("Common") + DateTime.Now.ToString("yyyy-MM-dd") + ".txt", FileMode.Append, FileAccess.Write, FileShare.Delete | FileShare.ReadWrite);
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine("====");
            if (!string.IsNullOrWhiteSpace(note))
                writer.WriteLine(string.Format("Note:{0}", note));

            if (!string.IsNullOrWhiteSpace(exNote))
                writer.WriteLine(exNote);

            writer.WriteLine(string.Format("DateTime:{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff")));
            stream.Flush();
            writer.Close();
            stream.Close();
        }
        /// <summary>
        /// 保存日志
        /// </summary>
        /// <param name="note"></param>
        public static void SaveException(Exception ex)
        {
            SaveNoteAndException("", ex);
        }
        /// <summary>
        /// 保存日志
        /// </summary>
        /// <param name="note"></param>
        public static void SaveNote(string note)
        {

            SaveNoteAndException(note, null);
        }
    }
}
