<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_list.aspx.cs" Inherits="LS.CMS.Web.admin.users.user_list" %>
<%@ Import Namespace="LS.CMS.Common" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>会员管理</title>
    <link rel="stylesheet" type="text/css" href="../../scripts/artdialog/ui-dialog.css" />
    <link rel="stylesheet" type="text/css" href="../../css/pagination.css" />
    <link rel="stylesheet" type="text/css" href="../skin/icon/iconfont.css" />
    <link rel="stylesheet" type="text/css" href="../skin/default/style.css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script src="../../scripts/datepicker/WdatePicker.js"></script>
    <script src="../js/common.js"></script>
    <script src="../js/main.js"></script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i class="iconfont icon-up"></i><span>返回上一页</span></a>
  <a href="../center.aspx" class="home"><i class="iconfont icon-home"></i><span>首页</span></a>
  <i class="arrow iconfont icon-arrow-right"></i>
  <span>会员管理</span>
  <i class="arrow iconfont icon-arrow-right"></i>
  <span>会员列表</span>
</div>
<!--/导航栏-->

<!--工具栏-->
<div id="floatHead" class="toolbar-wrap">
  <div class="toolbar">
    <div class="box-wrap">
      <a class="menu-btn"><i class="iconfont icon-more"></i></a>
      <div class="l-list">
        <ul class="icon-list">
          <li><a href="user_edit.aspx?action=<%=LSEnums.ActionEnum.Add %>"><i class="iconfont icon-close"></i><span>新增</span></a></li>
          <li><a href="javascript:;" onclick="checkAll(this);"><i class="iconfont icon-check"></i><span>全选</span></a></li>
          <li><asp:LinkButton ID="btnDelete" runat="server" OnClientClick="return ExePostBack('btnDelete');" ><i class="iconfont icon-delete"></i><span>删除</span></asp:LinkButton></li>
        </ul>
        <div class="menu-list">
          <div class="rule-single-select">
            <asp:DropDownList ID="ddlRole" runat="server" AutoPostBack="True" ></asp:DropDownList>
          </div>
          <asp:TextBox ID="txtStartTime" runat="server" CssClass="input rule-date-input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
          -
          <asp:TextBox ID="txtEndTime" runat="server" CssClass="input rule-date-input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
        </div>
      </div>
      <div class="r-list">
        <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
        <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" ><i class="iconfont icon-search"></i></asp:LinkButton>
      </div>
    </div>
  </div>
</div>
<!--/工具栏-->





    <!--  内容底部 -->
<div class="line20"></div>
<div class="pagelist">
  <div class="l-btns">
    <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);" OnTextChanged="txtPageNum_TextChanged"></asp:TextBox><span>条/页</span>
  </div>
  <div id="PageContent" runat="server" class="default"></div>
</div>


</form>
</body>
</html>
