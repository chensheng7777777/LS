using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LS.CMS.Model
{
    /// <summary>
    /// 系统配置信息类
    /// </summary>
    [Serializable]
    public class ls_sysconfig
    {
        /// <summary>
        /// 网站名称
        /// </summary>
        public string web_name { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string web_company { get; set; }
        /// <summary>
        /// 网站名称
        /// </summary>
        public string web_address { get; set; }
        /// <summary>
        /// 网站备案号
        /// </summary>
        public string web_crod { get; set; }
        /// <summary>
        /// 后台管理日志
        /// </summary>
        public int log_status { get; set; }
        /// <summary>
        /// 网站关闭状态
        /// </summary>
        public int web_status { get; set; }
        /// <summary>
        /// 关闭原因
        /// </summary>
        public string web_close_reason { get; set; }
        /// <summary>
        /// 网站统计代码
        /// </summary>
        public string web_count_code { get; set; }
        /// <summary>
        /// 附件上传目录
        /// </summary>
        public string file_path { get; set; }
        /// <summary>
        /// 文件保存方式
        /// </summary>
        public int file_save { get; set; }
        /// <summary>
        /// 附件上传类型
        /// </summary>
        public string file_extension { get; set; }
        /// <summary>
        /// 视频上传类型
        /// </summary>
        public string video_extension { get; set; }
        /// <summary>
        /// 文件上传大小
        /// </summary>
        public string attach_size { get; set; }
        /// <summary>
        /// 视频上传大小
        /// </summary>
        public int video_size { get; set; }
        /// <summary>
        /// 图片上传大小
        /// </summary>
        public int img_size { get; set; }
        /// <summary>
        /// 图片最大高度(像素)
        /// </summary>
        public int img_max_height { get; set; }
        /// <summary>
        /// 图片最大宽度(像素)
        /// </summary>
        public int img_max_width { get; set; }
        /// <summary>
        /// 生成缩略图高度(像素)
        /// </summary>
        public int thumbnail_height { get; set; }
        /// <summary>
        /// 生成缩略图宽度(像素)
        /// </summary>
        public int thumbnail_width { get; set; }
        /// <summary>
        /// 缩略图生成方式
        /// </summary>
        public string thubnail_mode { get; set; }
        /// <summary>
        /// 图片水印类型
        /// </summary>
        public int watermark_type { get; set; }
        /// <summary>
        /// 图片水印位置
        /// </summary>
        public int watermark_position { get; set; }
        /// <summary>
        /// 图片生成质量
        /// </summary>
        public int watermark_img_quality { get; set; }
        /// <summary>
        /// 图片水印文件
        /// </summary>
        public string watermark_pic { get; set; }
        /// <summary>
        /// 水印透明度
        /// </summary>
        public int watermark_transparency { get; set; }
        /// <summary>
        /// 水印文字
        /// </summary>
        public string watermark_text { get; set; }
        /// <summary>
        /// 文字字体
        /// </summary>
        public string watermark_font { get; set; }
        /// <summary>
        ///文字大小(像素)
        /// </summary>
        public int watermark_fontsize { get; set; }
    }
}
