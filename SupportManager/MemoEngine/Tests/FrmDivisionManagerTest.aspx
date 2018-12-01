<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmDivisionManagerTest.aspx.cs" Inherits="MemoEngine.Tests.FrmDivisionManagerTest" %>

<%@ Register Src="~/Modules/DivisionModule/Controls/DivisionManagerUserControl.ascx" TagPrefix="uc1" TagName="DivisionManagerUserControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:DivisionManagerUserControl runat="server" id="DivisionManagerUserControl" />
    </div>
    </form>
</body>
</html>
