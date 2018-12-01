<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="FrmDropDownListRedirect.aspx.cs" 
    Inherits="DevStandardControl.FrmDropDownListRedirect" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>드롭다운리스트 선택시 특정 게시판으로 이동하기 샘플</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="lstBoard" runat="server" 
                AutoPostBack="true" OnSelectedIndexChanged="lstBoard_SelectedIndexChanged">
                <asp:ListItem Value="Notice">공지사항</asp:ListItem>
                <asp:ListItem Value="Free">자유게시판</asp:ListItem>
            </asp:DropDownList>
        </div>
    </form>
</body>
</html>
