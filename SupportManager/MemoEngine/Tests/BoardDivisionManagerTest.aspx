<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BoardDivisionManagerTest.aspx.cs" Inherits="MemoEngine.Tests.BoardDivisionManagerTest" %>

<%@ Register Src="~/Modules/DivisionModule/Controls/BoardDivisionManagerUserControl.ascx" TagPrefix="uc1" TagName="BoardDivisionManagerUserControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:BoardDivisionManagerUserControl runat="server" id="BoardDivisionManagerUserControl" />
    </div>
    </form>
</body>
</html>
