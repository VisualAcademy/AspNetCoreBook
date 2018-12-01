<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LinkList.aspx.cs" Inherits="MemoEngine.Modules.Link.LinkList" %>

<%@ Register Src="~/Modules/Link/LinkListUserControl.ascx" TagPrefix="uc1" TagName="LinkListUserControl" %>


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
        <uc1:LinkListUserControl runat="server" id="LinkListUserControl" />
    </div>
    </form>
</body>
</html>
