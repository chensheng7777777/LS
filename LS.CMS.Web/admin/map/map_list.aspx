<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="map_list.aspx.cs" Inherits="LS.CMS.Web.admin.map.map_list" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript" src="https://webapi.amap.com/maps?v=1.4.13&key=<%=sysConfig.gaode_jskey %>"></script>
    <script>
        window.onload = function () {
             var aMap = new AMap.Map("container");
        }
       


    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="container" style="width:800px;height:400px;">

        </div>
    </form>
</body>
</html>
