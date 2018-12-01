<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScheduleByCommunityWrite.aspx.cs" Inherits="DotNetNote.Modules.ScheduleByCommunity.ScheduleByCommunityWrite" %>

<%@ Register Src="~/Modules/ScheduleByCommunity/Controls/ScheduleByCommunityWriteControl.ascx" TagPrefix="uc1" TagName="ScheduleByCommunityWriteControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:ScheduleByCommunityWriteControl runat="server" ID="ScheduleByCommunityWriteControl" />
    </div>
    </form>
</body>
</html>
