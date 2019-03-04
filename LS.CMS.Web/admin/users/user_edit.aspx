<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_edit.aspx.cs" Inherits="LS.CMS.Web.admin.users.user_edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>编辑会员</title>
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <link rel="stylesheet" type="text/css" href="../../scripts/artdialog/ui-dialog.css" />
    <link rel="stylesheet" type="text/css" href="../skin/icon/iconfont.css" />
    <link rel="stylesheet" type="text/css" href="../skin/default/style.css" />
    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/webuploader/webuploader.min.js"></script>
    <script src="../../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/uploader.js"></script>
    <script src="../js/common.js"></script>
    <script src="../js/main.js"></script>
    <script>
        $(function () {
             $("#form1").initValidform();
            //初始化上传控件
            $(".upload-img").InitUploader({ sendurl: "../../tools/upload_ajax.ashx", swf: "../../scripts/webuploader/uploader.swf" });
        });

    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="user_list.aspx" class="back"><i class="iconfont icon-up"></i><span>返回列表页</span></a>
            <a href="../center.aspx"><i class="iconfont icon-home"></i><span>首页</span></a>
            <i class="arrow iconfont icon-arrow-right"></i>
            <a href="user_list.aspx"><span>会员管理</span></a>
            <i class="arrow iconfont icon-arrow-right"></i>
            <span>编辑会员</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->


        <div class="tab-content">
            <dl>
                <dt>用户状态</dt>
                <dd>
                    <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="rblStatus" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="0" Selected="True">正常</asp:ListItem>
                            <asp:ListItem Value="1">待验证</asp:ListItem>
                            <asp:ListItem Value="2">待审核</asp:ListItem>
                            <asp:ListItem Value="3">禁用</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <span class="Validform_checktip">*暂时没用</span>
                </dd>
            </dl>
            <dl>
                <dt>用户名</dt>
                <dd>
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="input normal" disabled="disabled"></asp:TextBox>
            </dl>
            <dl>
                <dt>邮箱账号</dt>
                <dd>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="input normal" ></asp:TextBox>
                    <span class="Validform_checktip">*邮箱</span></dd>
            </dl>
            <dl>
                <dt>用户昵称</dt>
                <dd>
                    <asp:TextBox ID="txtNickName" runat="server" CssClass="input normal"></asp:TextBox></dd>
            </dl>
            <dl>
                <dt>上传头像</dt>
                <dd>
                    <asp:TextBox ID="txtAvatar" runat="server" CssClass="input normal upload-path"></asp:TextBox>
                    <div class="upload-box upload-img"></div>
                </dd>
            </dl>
            <dl>
                <dt>用户性别</dt>
                <dd>
                    <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="rblSex" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="0" Selected="True">男</asp:ListItem>
                            <asp:ListItem Value="1">女</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>生日日期</dt>
                <dd>
                    <asp:TextBox ID="txtBirthday" runat="server" CssClass="input rule-date-input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" " />
                </dd>
            </dl>
            <dl>
                <dt>手机号码</dt>
                <dd>
                    <asp:TextBox ID="txtMobile" runat="server" CssClass="input normal"></asp:TextBox></dd>
            </dl>
        </div>

        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-wrap">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click"  />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
            <asp:HiddenField ID="hidId" runat="server" />
        </div>
        <!--/工具栏-->

    </form>
</body>
</html>
