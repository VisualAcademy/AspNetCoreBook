<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="FrmBlobUpload.aspx.cs" 
    Inherits="DevAzureBlobStorage.FrmBlobUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload ID="txtFileName" runat="server" />
            <asp:Button ID="btnUpload" runat="server" Text="업로드"
                OnClick="btnUpload_Click" />
            <hr />
            <asp:Image ID="imgFile" runat="server" />
        </div>
    </form>
</body>
</html>
