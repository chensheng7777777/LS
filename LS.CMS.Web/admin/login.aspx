﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="LS.CMS.Web.admin.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>管理员登录</title>
    <link rel="stylesheet" type="text/css" href="skin/icon/iconfont.css" />
    <link rel="stylesheet" type="text/css" href="skin/default/style.css" />
    <script type="text/javascript" src="../scripts/jquery/jquery-1.11.2.min.js"></script>
</head>
<body class="loginbody">
    <form id="form1" runat="server">
        <div style="width: 100%; height: 100%; min-width: 300px; min-height: 260px;"></div>
        <div class="login-wrap">
            <div class="login-logo">LOGO</div>
            <div class="login-form">
                <div class="col">
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="login-input" placeholder="管理员账号" title="管理员账号"></asp:TextBox>
                    <label class="icon" for="txtUserName"><i class="iconfont icon-user"></i></label>
                </div>
                <div class="col">
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="login-input" TextMode="Password" placeholder="管理员密码" title="管理员密码"></asp:TextBox>
                    <label class="icon" for="txtPassword"><i class="iconfont icon-key"></i></label>
                </div>
                <div class="col">
                    <asp:Button ID="btnSubmit" runat="server" Text="登 录" CssClass="login-btn" />
                </div>
            </div>
            <div class="login-tips"><i class="iconfont icon-info"></i>
                <p id="msgtip" runat="server">请输入用户名和密码</p>
            </div>
        </div>

        <div class="copy-right">
            <p>版权所有 北京市垃视广告传媒有限公司 Copyright © 2011 - 2022 ls.net Inc. All Rights Reserved.</p>
        </div>
    </form>
</body>
</html>
