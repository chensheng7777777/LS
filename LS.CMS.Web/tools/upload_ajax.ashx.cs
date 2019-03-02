using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LS.CMS.Common;


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
            context.Response.ContentType = "text/plain";
            HttpPostedFile upFile = context.Request.Files["upfile"];
            if (upFile==null)
            {
                context.Response.Write(JSONHelper.SerializeObject(new {  state="n",error="请选择上传文件" }));
            }
            string fileName = upFile.FileName;
            byte[] byteData = FileHelper.ConvertStreamToByteBuffer(upFile.InputStream);
            
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