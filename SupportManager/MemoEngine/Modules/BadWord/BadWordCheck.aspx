<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BadWordCheck.aspx.cs" Inherits="MemoEngine.Modules.BadWord.BadWordCheck" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        비속어 체크: 
        <asp:TextBox ID="txtInput" runat="server"></asp:TextBox>
        <asp:Button ID="btnCheck" runat="server" Text="체크" OnClick="btnCheck_Click" />
        <asp:Label ID="lblDisplay" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
