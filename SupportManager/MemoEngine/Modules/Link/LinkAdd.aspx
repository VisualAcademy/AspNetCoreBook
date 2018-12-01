<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LinkAdd.aspx.cs" Inherits="MemoEngine.Modules.Link.LinkAdd" %>

<%@ Register Src="~/Modules/Link/LinkAddUserControl.ascx" TagPrefix="uc1" TagName="LinkAddUserControl" %>


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
        <uc1:LinkAddUserControl runat="server" id="LinkAddUserControl" />
    </div>
    </form>
</body>
</html>
