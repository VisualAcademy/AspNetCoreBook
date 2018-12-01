<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LinkView.aspx.cs" Inherits="MemoEngine.Modules.Link.LinkView" %>

<%@ Register Src="~/Modules/Link/LinkViewUserControl.ascx" TagPrefix="uc1" TagName="LinkViewUserControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:LinkViewUserControl runat="server" id="LinkViewUserControl" />
    </div>
    </form>
</body>
</html>
