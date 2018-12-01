<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScheduleByCommunityList.aspx.cs" Inherits="DotNetNote.Modules.ScheduleByCommunity.ScheduleByCommunityList" %>

<%@ Register Src="~/Modules/ScheduleByCommunity/Controls/ScheduleByCommunityListControl.ascx" TagPrefix="uc1" TagName="ScheduleByCommunityListControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:ScheduleByCommunityListControl runat="server" ID="ScheduleByCommunityListControl" />
    </div>
    </form>
</body>
</html>
