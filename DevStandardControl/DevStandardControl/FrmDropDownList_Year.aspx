<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="FrmDropDownList_Year.aspx.cs" 
    Inherits="DevStandardControl.FrmDropDownList_Year" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>드롭다운리스트로 년월 표시</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>최근 5년동안의 년도</h1>
            <asp:DropDownList ID="ddlYear" runat="server"></asp:DropDownList>

            <h2>선언적 방식</h2>
            <asp:DropDownList ID="ddlMonth" runat="server">
                <asp:ListItem Value="1">1월</asp:ListItem>
                <asp:ListItem Value="2">2월</asp:ListItem>
            </asp:DropDownList>

            <h2>프로그래밍 방식</h2>
            <asp:DropDownList ID="lstMonth" runat="server"></asp:DropDownList>
        </div>
    </form>
</body>
</html>
