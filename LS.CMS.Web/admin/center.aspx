﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="center.aspx.cs" Inherits="LS.CMS.Web.admin.center" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>管理首页</title>
    <link rel="stylesheet" type="text/css" href="skin/icon/iconfont.css" />
    <link rel="stylesheet" type="text/css" href="skin/default/style.css" />
    <script type="text/javascript" charset="utf-8" src="../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="js/common.js"></script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i class="iconfont icon-up"></i><span>返回上一页</span></a>
  <a href="javascript:;"><i class="iconfont icon-home"></i><span>首页</span></a>
  <i class="arrow iconfont icon-arrow-right"></i>
  <span>管理中心</span>
</div>
<!--/导航栏-->

<!--内容-->
<div class="line10"></div>
<div class="nlist-1">
  <ul>
    <li><p>本次登录IP：<asp:Literal ID="litIP" runat="server" Text="-" /></p></li>
    <li><p>上次登录IP：<asp:Literal ID="litBackIP" runat="server" Text="-" /></p></li>
    <li><p>上次登录时间：<asp:Literal ID="litBackTime" runat="server" Text="-" /></p></li>
  </ul>
</div>
<div class="line10"></div>

<div class="nlist-2">
  <h3><i class="iconfont icon-setting"></i>站点信息</h3>
  <ul>
    <li><p>站点名称：<%=sysConfig.web_name %></p></li>
    <li><p>公司名称：<%=sysConfig.web_company %></p></li>
    <li><p>附件上传目录：<%=sysConfig.file_path %></p></li>
    <li><p>服务器名称：<%=Server.MachineName%></p></li>
    <li><p>服务器IP：<%=Request.ServerVariables["LOCAL_ADDR"] %></p></li>
    <li><p>NET框架版本：<%=Environment.Version.ToString()%></p></li>
    <li><p>操作系统：<%=Environment.OSVersion.ToString()%></p></li>
    <li><p>IIS环境：<%=Request.ServerVariables["SERVER_SOFTWARE"]%></p></li>
    <li><p>服务器端口：<%=Request.ServerVariables["SERVER_PORT"]%></p></li>
    <li><p>目录物理路径：<%=Request.ServerVariables["APPL_PHYSICAL_PATH"]%></p></li>
    <li><p>版本更新：<asp:Literal ID="LitUpgrade" runat="server"/></p></li>
  </ul>
</div>
<div class="line20"></div>

<%--<div class="nlist-3">
  <ul>
    <li><a onclick="parent.linkMenuTree(true, 'sys_config');" href="javascript:;"><i class="iconfont icon-setting"></i></a><span>系统设置</span></li>
    <li><a onclick="parent.linkMenuTree(true, 'sys_site_manage');" href="javascript:;"><i class="iconfont icon-site"></i></a><span>站点管理</span></li>
    <li><a onclick="parent.linkMenuTree(true, 'sys_site_templet');" href="javascript:;"><i class="iconfont icon-templet"></i></a><span>模板管理</span></li>
    <li><a onclick="parent.linkMenuTree(true, 'sys_builder_html');" href="javascript:;"><i class="iconfont icon-build"></i></a><span>生成静态</span></li>
    <li><a onclick="parent.linkMenuTree(true, ' sys_plugin_config ');" href="javascript:;"><i class="iconfont icon-app"></i></a><span>插件配置</span></li>
    <li><a onclick="parent.linkMenuTree(true, 'user_list');" href="javascript:;"><i class="iconfont icon-user"></i></a><span>会员管理</span></li>
    <li><a onclick="parent.linkMenuTree(true, 'manager_list');" href="javascript:;"><i class="iconfont icon-manager"></i></a><span>管理员</span></li>
    <li><a onclick="parent.linkMenuTree(true, 'manager_log');" href="javascript:;"><i class="iconfont icon-log"></i></a><span>系统日志</span></li>
  </ul>
</div>--%>

<div class="nlist-4">
  <h3><i class="iconfont icon-edit"></i>首页</h3>
  <ul>
    <li>WELCOME</li>
  </ul>
  <h3><i class="iconfont icon-message"></i>官方消息</h3>
  <ul>
    <asp:Literal ID="LitNotice" runat="server"/>
  </ul>
</div>
<!--/内容-->
</form>
</body>
</html>
