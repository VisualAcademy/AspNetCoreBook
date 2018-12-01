<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="FrmFileUpload_Multiple.aspx.cs"
    Inherits="DevStandardControl.FrmFileUpload_Multiple" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>멀티 파일 업로드</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload ID="txtFiles" runat="server" 
                AllowMultiple="true" />
            <asp:Button ID="btnUpload" runat="server"
                Text="파일 업로드" OnClick="btnUpload_Click" />
            <hr />
            <asp:Label ID="lblDisplay" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
