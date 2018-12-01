<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupportSettingView.aspx.cs" Inherits="MemoEngine.Modules.SupportManager.SupportSettingView" %>

<%@ Register Src="~/Modules/SupportManager/SupportSettingViewUserControl.ascx" TagPrefix="uc1" TagName="SupportSettingViewUserControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="/Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:SupportSettingViewUserControl runat="server" id="SupportSettingViewUserControl" />
    </div>
    </form>
</body>
</html>
