<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Write.aspx.cs" Inherits="MemoEngine.Reply.Write" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>
                <asp:Literal ID="ltrTitle" runat="server" Text="글 쓰기"></asp:Literal></h3>
            <div>
                이름:
            <asp:TextBox ID="txtName" runat="server" /><br />
                이메일:
            <asp:TextBox ID="txtEmail" runat="server" /><br />
                홈페이지:
            <asp:TextBox ID="txtHomepage" runat="server" /><br />
                제목:
            <asp:TextBox ID="txtTitle" runat="server" /><br />
                내용:
            <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Columns="20" Rows="5">
            </asp:TextBox><br />
                인코딩:
            <asp:RadioButtonList ID="lstEncoding" runat="server" RepeatDirection="Horizontal"
                RepeatLayout="Flow">
                <asp:ListItem Selected="True">Text</asp:ListItem>
                <asp:ListItem>HTML</asp:ListItem>
                <asp:ListItem>Mixed</asp:ListItem>
            </asp:RadioButtonList>
                <br />
                비밀번호:
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br />
                <br />
                <asp:Button ID="btnWrite" runat="server" Text="저장" Height="21px"
                    OnClick="btnWrite_Click" />
                <asp:HyperLink ID="btnList" runat="server" Text="리스트" NavigateUrl="List.aspx" />
            </div>
        </div>
    </form>
</body>
</html>
