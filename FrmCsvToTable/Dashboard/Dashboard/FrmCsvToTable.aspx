<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmCsvToTable.aspx.cs" Inherits="Dashboard.FrmCsvToTable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnCsvToTable" runat="server" Text="CSV 파일을 테이블로 가져오기" OnClick="btnCsvToTable_Click" />
        </div>
    </form>
</body>
</html>
