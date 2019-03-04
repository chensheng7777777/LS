using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LS.CMS.Common;
using LS.CMS.Model;
using LS.CMS.BLL;


namespace LS.CMS.Web.tools
{
    /// <summary>
    /// upload_ajax 的摘要说明
    /// </summary>
    public class upload_ajax : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"].ToLower();
            switch (action)
            {
                case "uploadfile":
                    UploadFile(context);
                    break;
                default:
                    break;
            }
        }

        private void UploadFile(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            ls_sysconfig_bll bll = new ls_sysconfig_bll();
            ls_sysconfig sysConfig = bll.LoadConfig();

            string _delfile = LSRequest.GetString("DelFilePath"); //要删除的文件
            string fileName = LSRequest.GetString("name"); //文件名
            byte[] byteData = FileHelper.ConvertStreamToByteBuffer(context.Request.InputStream);
            bool _iswater = false; //默认不打水印
            bool _isthumbnail = false; //默认不生成缩略图

            if (LSRequest.GetQueryString("IsWater") == "1")
            {
                _iswater = true;
            }
            if (LSRequest.GetQueryString("IsThumbnail") == "1")
            {
                _isthumbnail = true;
            }
            if (byteData.Length == 0)
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"请选择要上传文件！\"}");
                return;
            }
            UpLoad upLoad = new UpLoad();
            string msg = upLoad.FileSaveAs(byteData, fileName, _isthumbnail, _iswater);
            //删除已存在的旧文件
            if (!string.IsNullOrEmpty(_delfile))
            {
                upLoad.DeleteFile(_delfile);
            }
            //返回成功信息
            context.Response.Write(msg);
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}