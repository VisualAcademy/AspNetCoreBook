<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupportRegistrationView.aspx.cs" Inherits="MemoEngine.Modules.SupportManager.SupportRegistrationView" %>

<%@ Register Src="~/Modules/SupportManager/SupportRegistrationViewUserControl.ascx" TagPrefix="uc1" TagName="SupportRegistrationViewUserControl" %>


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
        <uc1:SupportRegistrationViewUserControl runat="server" id="SupportRegistrationViewUserControl" />
    </div>
    </form>
</body>
</html>
