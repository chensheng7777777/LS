//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace LS.CMS.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class ls_nav
    {
        public int id { get; set; }
        public int parent_id { get; set; }
        public string nav_name { get; set; }
        public string nav_title { get; set; }
        public string icon_url { get; set; }
        public string link_url { get; set; }
        public int nav_status { get; set; }
        public string nav_desc { get; set; }
        public System.DateTime create_time { get; set; }
    }
}
