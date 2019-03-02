using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LS.CMS.Common;
using LS.CMS.Model;


namespace LS.CMS.Web.Jobs
{
    public class LogJob:IJob
    {
        private MSMQHelper msmq = new MSMQHelper();
        public void Execute(IJobExecutionContext context)
        {
            List<string> list = msmq.GetAllMessage();
            foreach (string item in list)
            {
                LogHelper.SaveNote(item);
            }
        }
    }
}