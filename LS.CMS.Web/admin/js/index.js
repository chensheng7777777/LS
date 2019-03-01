
$(function () {

    $(".icon-menu").click(function () {
        toggleMainMenu();
    });    

    $(".left-toggle").click(function () {
        $(".nav-container").slideToggle("fast");
        if ($(this).find("i").hasClass("icon-arrow-down")) {
            $(this).find("i").removeClass("icon-arrow-down");
            $(this).find("i").addClass("icon-arrow-up");
        } else {
            $(this).find("i").removeClass("icon-arrow-up");
            $(this).find("i").addClass("icon-arrow-down");
        }
    });

    loadMenuTree();


    //加载完成左侧导航之后完成点击+,-切换
    $(".nav-container .expandable").click(function () {
        //首先改变其余的导航
        var other = $(this).parent().parent().siblings("li").children("a").children(".expandable");
        for (var i = 0; i < other.length; i++) {
            if (other.eq(i).hasClass("icon-open")) {
                other.eq(i).removeClass("icon-open");
                other.eq(i).addClass("icon-close");
            }
            if (other.eq(i).parent().parent().children("ul").css("display")=="block") {
                other.eq(i).parent().parent().children("ul").slideUp("fast");
            }
        }
        if ($(this).hasClass("icon-close")) {
            $(this).removeClass("icon-close");
            $(this).addClass("icon-open");

            //将下面的ul节点展开
            $(this).parent().parent().children("ul").slideDown("fast");


        } else {

            $(this).removeClass("icon-open");
            $(this).addClass("icon-close");
            //将下面的ul节点收起
            $(this).parent().parent().children("ul").slideUp("fast");
        }
        return false;
    });


});

//切换左侧导航显示和隐藏
function toggleMainMenu() {
    $("body").toggleClass("lay-mini");
}

//生成左侧导航
function loadMenuTree() {
    var container = $(".nav-container");
    //生成第一级导航
    for (var i = 0; i < navObjs["navs"].length; i++) {
        var defaultIcon = "icon iconfont icon-folder";
        if (navObjs["navs"][i]["icon"]) {
            defaultIcon = navObjs["navs"][i]["icon"];
        }
        var defaultRight = "";
        if (navObjs["navs"][i]["children"].length>0) {
            defaultRight = "<b class=\"expandable iconfont icon-close\"></b>";
        }
        var defaultUrl = "";
        if (navObjs["navs"][i]["url"]) {
            defaultUrl ="href=\"" +navObjs["navs"][i]["url"]+"\"";
        }

        var li = $("<li><a navid=\"" + navObjs["navs"][i]["name"] + "\" target=\"mainframe\" "+ defaultUrl+"><i class=\"" + defaultIcon + "\"></i><span>" + navObjs["navs"][i]["title"] + "</span>" + defaultRight + "</a></li>");
        //递归生成下级节点
        buildMenuChildren(li, navObjs["navs"][i]["children"]);
        container.append(li);
    }
}

//递归生成子节点
function buildMenuChildren(liParent, navs) {
    if (navs.length<=0) {
        return;
    }
    //首先隐藏,点击的时候进行切换
    var ul = $("<ul style='display:none;'></ul>");
    //获取父节点到左侧的距离
    var leftWidth = liParent.css("marginLeft");
    ul.css("marginLeft",leftWidth+15+"px");
    for (var i = 0; i < navs.length;i++) {
        var defaultIcon = "icon iconfont icon-folder";
        var defaultRight = "";
        if (navs[i]["children"].length > 0) {
            defaultRight = "<b class=\"expandable iconfont icon-close\"></b>";
        } else {
            defaultIcon = "icon iconfont icon-file";
        }
        if (navs[i]["icon"]) {
            defaultIcon = navs[i]["icon"];
        }
        var defaultUrl = "";
        if (navs[i]["url"]) {
            defaultUrl = "href=\""+ navs[i]["url"]+"\"";
        }
        var li = $("<li><a navid=\"" + navs[i]["name"] + "\" target=\"mainframe\" " + defaultUrl +"><i class=\"" + defaultIcon + "\"></i><span>" + navs[i]["title"] + "</span>" + defaultRight + "</a></li>");
        buildMenuChildren(li, navs[i]["children"]);
        ul.append(li);
    }
    ul.appendTo(liParent);
}



