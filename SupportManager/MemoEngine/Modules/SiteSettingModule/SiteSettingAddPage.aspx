<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SiteSettingAddPage.aspx.cs" Inherits="SiteSetting.Modules.SiteSettingModule.SiteSettingAddPage" %>

<%@ Register Src="~/Controls/SiteSettingModule/SiteSettingAddUserControl.ascx" TagPrefix="uc1" TagName="SiteSettingAddUserControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <uc1:SiteSettingAddUserControl runat="server" ID="SiteSettingAddUserControl" />
            </div>
        </div>
    </form>
</body>
</html>
