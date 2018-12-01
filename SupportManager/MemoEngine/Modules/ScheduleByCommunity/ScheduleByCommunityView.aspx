<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScheduleByCommunityView.aspx.cs" Inherits="DotNetNote.Modules.ScheduleByCommunity.ScheduleByCommunityView" %>

<%@ Register Src="~/Modules/ScheduleByCommunity/Controls/ScheduleByCommunityViewControl.ascx" TagPrefix="uc1" TagName="ScheduleByCommunityViewControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:ScheduleByCommunityViewControl runat="server" ID="ScheduleByCommunityViewControl" />
    </div>
    </form>
</body>
</html>
