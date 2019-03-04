using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LS.CMS.Common;
using LS.CMS.Model;
using LS.CMS.BLL;

namespace LS.CMS.Web.Jobs
{
    public class LogJob:IJob
    {
        private MSMQHelper msmq = new MSMQHelper();
        private ls_visit_log_bll bll = new ls_visit_log_bll();
        public void Execute(IJobExecutionContext context)
        {
            //List<string> list = msmq.GetAllMessage();
            //if (list.Count<=0)
            //{
            //    return;
            //}
            //List<ls_visit_log> logs = new List<ls_visit_log>();
            //foreach (string item in list)
            //{
            //    logs.Add(JSONHelper.DeserializeJsonToObject<ls_visit_log>(item));
            //}
            //if (bll.SaveLogs(logs))
            //{
            //    msmq.Clear();
            //    LogHelper.SaveNoteToLog(DateTime.Now.ToString() + "清空消息队列成功");
            //}
            //else
            //{
            //    LogHelper.SaveNoteToLog(DateTime.Now.ToString() + "批量写入访问日志失败");
            //}
        }
    }
}