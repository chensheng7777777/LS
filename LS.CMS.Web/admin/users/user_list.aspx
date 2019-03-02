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
        <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="lbtnSearch_Click" ><i class="iconfont icon-search"></i></asp:LinkButton>
      </div>
    </div>
  </div>
</div>
<!--/工具栏-->

    <!-- 用户列表 -->
    <div class="table-container">
<asp:Repeater ID="rptList" runat="server">
<HeaderTemplate>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
  <tr>
    <th width="8%">选择</th>
    <th align="left" colspan="2">用户名</th>
    <th align="left" width="12%">邮箱</th>
    <th width="8%">手机</th>
    <th width="8%">性别</th>
    <th width="8%">操作</th>
  </tr>
</HeaderTemplate>
<ItemTemplate>
  <tr>
    <td align="center">
      <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" style="vertical-align:middle;" />
      <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
    </td>
    <td width="64">
      <a class="user-avatar" href="user_edit.aspx?action=<%#LSEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>">
        <%#Utils.ObjectToStr(Eval("user_avatar")) != "" ? "<img width=\"64\" height=\"64\" src=\"" + Eval("user_avatar") + "\" />" : "<i class=\"iconfont icon-user-full\"></i>"%>
      </a>
    </td>
    <td>
      <div class="user-box">
        <h4><b><%#Eval("user_name")%></b> (昵称：<%#Eval("nick_name")%>)</h4>
        <i>注册时间：<%#string.Format("{0:g}",Eval("create_time"))%></i><span><a class="amount" href="amount_log.aspx?keywords=<%#Eval("id")%>" title="登录记录"><i class="iconfont icon-count"></i></a><a class="card" href="recharge_list.aspx?keywords=<%#Eval("id")%>" title="访问记录"><i class="iconfont icon-order"></i></a><%#Utils.ObjectToStr(Eval("user_mobile")) != "" ? "<a class=\"sms\" href=\"javascript:;\" onclick=\"PostSMS('" + Eval("mobile") + "');\" title=\"发送手机短信通知\"><i class=\"iconfont icon-mail\"></i></a>" : ""%></span></div>
    </td>
    <td><%#Eval("user_email")%></td>
    <td><%#Eval("user_mobile")%></td>
    <td align="center"><%#Utils.ObjectToStr(Eval("user_gender"))=="0"?"男":"女"%></td>
    <td align="center"><a href="user_edit.aspx?action=<%#LSEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>">修改</a></td>
  </tr>
</ItemTemplate>
<FooterTemplate>
  <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"9\">暂无记录</td></tr>" : ""%>
</table>
</FooterTemplate>
</asp:Repeater>
</div>



    <!--  内容底部 -->
<div class="line20"></div>
<div class="pagelist">
  <div class="l-btns">
    <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);" OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
  </div>
  <div id="PageContent" runat="server" class="default"></div>
</div>


</form>
</body>
</html>
