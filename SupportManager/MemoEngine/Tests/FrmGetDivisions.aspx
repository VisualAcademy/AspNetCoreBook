<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmGetDivisions.aspx.cs" Inherits="MemoEngine.Tests.FrmGetDivisions" %>

<%@ Register Src="~/Modules/DivisionModule/Controls/DivisionListUserControl.ascx" TagPrefix="uc1" TagName="DivisionListUserControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="lstDivisions" runat="server"></asp:DropDownList>

        <uc1:DivisionListUserControl runat="server" ID="DivisionListUserControl" />

        <hr />

        <asp:Button ID="btnSelectData" runat="server" Text="선택" OnClick="btnSelectData_Click" />
        
        <hr />

        <asp:Label ID="lblDisplay" runat="server" Text=""></asp:Label>

    </div>
    </form>
</body>
</html>
