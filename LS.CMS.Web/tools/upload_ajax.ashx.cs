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
                return;
            }
            string fileName = upFile.FileName;
            byte[] byteData = FileHelper.ConvertStreamToByteBuffer(upFile.InputStream);
            FileSave(context, upFile, false);
        }


        /// <summary>
        /// 统一保存文件
        /// </summary>
        private void FileSave(HttpContext context, HttpPostedFile upFiles, bool isWater)
        {
            if (upFiles == null)
            {
                context.Response.Write(JSONHelper.SerializeObject(new { state ="", msg ="请选择要上传的文件"}));
                return;
            }
            string fileName = upFiles.FileName;
            byte[] byteData = FileHelper.ConvertStreamToByteBuffer(upFiles.InputStream); //获取文件流
            //开始上传
            string remsg = new UpLoad().FileSaveAs(byteData, fileName, false, isWater);
            
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