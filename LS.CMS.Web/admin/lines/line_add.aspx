<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="line_add.aspx.cs" Inherits="LS.CMS.Web.admin.lines.line_add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <link rel="stylesheet" type="text/css" href="../../scripts/artdialog/ui-dialog.css" />
    <link rel="stylesheet" type="text/css" href="../skin/icon/iconfont.css" />
    <link rel="stylesheet" type="text/css" href="../skin/default/style.css" />
    <title></title>
    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/webuploader/webuploader.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/ueditor.all.min.js"> </script>
    <script type="text/javascript" charset="utf-8" src="../../editor/lang/zh-cn/zh-cn.js"></script>
    <script src="../js/uploader.js"></script>
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
            <a href="user_list.aspx"><span>线路管理</span></a>
            <i class="arrow iconfont icon-arrow-right"></i>
            <span>新增线路</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">基本信息</a></li>
                        <li><a href="javascript:;">SEO</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            
            
            
            
            
            

            <dl>
                <dt>线路名称</dt>
                <dd>
                    <asp:TextBox ID="txtLineName" runat="server" CssClass="input normal" datatype="*2-32" errormsg="线路名称2-32位之间" ajaxurl="../../tools/tour_ajax.ashx?action=linename_validate"></asp:TextBox>
                    <span class="Validform_checktip">*线路名称</span></dd>
            </dl>
            
            
            
            
            

            
            <dl>
                <dt>副标题</dt>
                <dd>
                    <asp:TextBox ID="txtPassword1" runat="server" CssClass="input normal" datatype="*"></asp:TextBox>
                    <span class="Validform_checktip">线路副标题</span></dd>
            </dl>
            
            
            
            <dl>
                <dt>出发城市</dt>
                <dd>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="input normal" datatype="*"></asp:TextBox>
                </dd>
            </dl>
            
            
            
            
            
            
            

            


            <dl>
                <dt>线路类型</dt>
                <dd>
                    <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="rbl" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="0" Selected="True">周边旅游</asp:ListItem>
                            <asp:ListItem Value="1">国内旅游</asp:ListItem>
                            <asp:ListItem Value="2">出境旅游</asp:ListItem>
                            <asp:ListItem Value="3">港澳台旅游</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <span class="Validform_checktip">*必须选择类型</span>
                </dd>
            </dl>
           
            <dl>
                <dt>编号</dt>
                <dd>
                    <asp:TextBox ID="txtLineNumber" runat="server" CssClass="input normal" nullmsg="请设置编号" errormsg="线路编号必须是数字" sucmsg=" " datatype="/^\d+$/"></asp:TextBox>
                    <span class="Validform_checktip">*线路编号</span></dd>
            </dl>
           
            <dl>
                <dt>线路主题</dt>
                <dd>
                    <div class="rule-multi-porp">
                        <asp:CheckBoxList ID="cblGroupId" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem>古镇游</asp:ListItem>
                            <asp:ListItem>山水游</asp:ListItem>
                            <asp:ListItem>海岛游</asp:ListItem>
                            <asp:ListItem>乐园游</asp:ListItem>
                            <asp:ListItem>蜜月游</asp:ListItem>
                            <asp:ListItem>爸妈游</asp:ListItem>
                            <asp:ListItem>亲子游</asp:ListItem>
                            <asp:ListItem>温泉游</asp:ListItem>
                        </asp:CheckBoxList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>缩略图</dt>
                <dd>
                    <asp:TextBox ID="txtThumb" runat="server" CssClass="input normal upload-path"></asp:TextBox>
                    <div class="upload-box upload-img"></div>
                </dd>
            </dl>
            <dl>
                <dt>目的城市</dt>
                <dd>

                </dd>
                <dd>

                </dd>
            </dl>
        </div>

        <div class="tab-content" style="display: none;">
            <dl>
                <dt>真实姓名</dt>
                <dd>
                    <asp:TextBox ID="txtRealName" runat="server" CssClass="input normal"></asp:TextBox></dd>
            </dl>
            <dl>
                <dt>注册IP</dt>
                <dd>
                    <asp:Label ID="lblRegIP" Text="-" runat="server"></asp:Label></dd>
            </dl>
            <dl>
                <dt>注册IP</dt>
                <dd>
                    <asp:Label ID="lbError" runat="server" Text="" Style="color: red; font-size: 16px; margin-left: 40px;"></asp:Label>
                </dd>
            </dl>
        </div>
        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-wrap">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
        </div>
        <!--/工具栏-->

    </form>
</body>
</html>
