<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="city_choose.aspx.cs" Inherits="LS.CMS.Web.admin.lines.city_choose" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../scripts/artdialog/ui-dialog.css" />
    <link rel="stylesheet" type="text/css" href="../skin/icon/iconfont.css" />
    <link rel="stylesheet" type="text/css" href="../skin/default/style.css" />
    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script src="../js/common.js"></script>
    <script src="../js/main.js"></script>
    <style>
        .area-item {
            width:100%;
            margin-bottom:50px;
        }
            .area-item h2 {
                /*background:#0065D9;
                padding:5px 10px;
                width:100%;
                color:#fff;*/
            }

    </style>
    <script>
        $(function() {
            $(".item-choose").click(function() {
                var type = $(this).attr("data-type");
                var code = $(this).attr("data-code");
                $(".multi-porp").eq(0).empty();
                $.ajax({
                    type: "post",
                    url: "/tools/area_ajax.ashx",
                    dataType:"json",
                    data: {
                        code: code,
                        type: type,
                        action:get_area_info
                    },
                    success: function(data) {

                    }
                });
            });
        });
    </script>
</head>
<body>
    
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div id="floatHead" class="content-tab-wrap">
    <div class="content-tab">
        <div class="content-tab-ul-wrap">
            <ul>
                <li><a class="selected" href="javascript:;">国内</a></li>
                <li><a href="javascript:;">国外</a></li>
            </ul>
        </div>
    </div>
</div>

    <div class="tab-content">
        
        <div class="area-item">
            <h2 class="">选择地区:<span>亚洲</span>>><span>中国</span></h2>
            <div class="line20"></div>
            <div class="multi-porp">
                <ul>
                <% foreach (var item in proviences)
                   {
                        %>
                        <li><a href="javascript:;" data-code="<%=item.area_code %>" data-type="<%=item.area_type %>" class="item-choose"><%=item.area_name %></a><i class="iconfont icon-check-mark"></i></li>
                    <%
                   }%>
                </ul>
            </div>
            
            

        </div>    
        <div class="line20"></div>
        <div class="area-item">
            <h2>热门推荐</h2>
            <div class="line20"></div>
            <div class="multi-porp">
                <ul>
                    <% foreach (var item in hotProviences)
                       {
                    %>
                        <li><a href="javascript:;" data-code="<%=item.area_code %>" data-type="<%=item.area_type %>" class="item-choose"><%=item.area_name %></a><i class="iconfont icon-check-mark"></i></li>
                    <%
                   }%>
                </ul>
            </div>
        </div>
            
        
    </div>

    <div class="tab-content" style="display: none;">
        
    </div>


</body>
</html>
