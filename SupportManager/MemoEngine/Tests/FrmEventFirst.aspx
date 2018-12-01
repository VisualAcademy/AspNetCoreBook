<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmEventFirst.aspx.cs" Inherits="MemoEngine.Tests.FrmEventFirst" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnEvent" runat="server" Text="이벤트 등록하기" OnClick="btnEvent_Click" />
    </div>
    </form>
</body>
</html>
