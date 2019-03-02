using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using LS.CMS.Common;
using Quartz;
using Quartz.Impl;

namespace LS.CMS.Web
{
    public class Global : System.Web.HttpApplication
    {
        //调度器
        IScheduler scheduler;
        //调度器工厂
        ISchedulerFactory factory;
        protected void Application_Start(object sender, EventArgs e)
        {
            LogHelper.SaveNoteToLog("App Start...");
            //1、创建一个调度器
            factory = new StdSchedulerFactory();
            scheduler = factory.GetScheduler();
            scheduler.Start();

            //2、创建一个任务
            IJobDetail job = JobBuilder.Create<Jobs.LogJob>().WithIdentity("job1", "group1").Build();

            //3、创建一个触发器
            //DateTimeOffset runTime = DateBuilder.EvenMinuteDate(DateTimeOffset.UtcNow);
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .WithCronSchedule("0/5 * * * * ?")   
                                                       //.StartAt(runTime)
                .Build();

            //4、将任务与触发器添加到调度器中
            scheduler.ScheduleJob(job, trigger);
            //5、开始执行
            scheduler.Start();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //Exception objError = Server.GetLastError().GetBaseException();
            ////清除当前异常 使之不返回到请求页面
            //Server.ClearError();
            //lock (this)
            //{
            //    LogHelper.SaveException(objError);
            //}
            //Server.Transfer("500.html");
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}