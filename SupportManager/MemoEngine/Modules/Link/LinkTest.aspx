<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LinkTest.aspx.cs" Inherits="MemoEngine.Modules.Link.LinkTest" %>

<%@ Register Src="~/Modules/Link/LinkModuleUserControl.ascx" TagPrefix="uc1" TagName="LinkModuleUserControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.9.0.min.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:LinkModuleUserControl runat="server" id="LinkModuleUserControl" />
    </div>
    </form>
</body>
</html>
