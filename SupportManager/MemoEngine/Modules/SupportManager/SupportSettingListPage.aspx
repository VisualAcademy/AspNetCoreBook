<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupportSettingListPage.aspx.cs" Inherits="MemoEngine.Modules.SupportManager.SupportSettingListPage" %>

<%@ Register Src="~/Modules/SupportManager/SupportSettingListUserControl.ascx" TagPrefix="uc1" TagName="SupportSettingListUserControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:SupportSettingListUserControl runat="server" id="SupportSettingListUserControl" />
        </div>
    </form>
</body>
</html>
