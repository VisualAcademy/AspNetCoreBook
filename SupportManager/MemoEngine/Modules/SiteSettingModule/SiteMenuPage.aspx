<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SiteMenuPage.aspx.cs" Inherits="SiteSetting.Modules.SiteSettingModule.SiteMenuPage" %>

<%@ Register Src="~/Controls/SiteSettingModule/SiteMenuUserControl.ascx" TagPrefix="uc1" TagName="SiteMenuUserControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:SiteMenuUserControl runat="server" ID="SiteMenuUserControl" />
    </div>
    </form>
</body>
</html>
