<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmRequiredFieldValidatorForTextBox.aspx.cs" Inherits="DevValidationControl.FrmRequiredFieldValidatorForTextBox" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>텍스트박스에 대한 입력 유효성 검사</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtOrderDateStart" runat="server" ValidationGroup="OrderSearch"></asp:TextBox>
            <asp:TextBox ID="txtOrderDateEnd" runat="server" ValidationGroup="OrderSearch"></asp:TextBox>
            <asp:Button ID="btnOrderSearch" runat="server" Text="검색"  ValidationGroup="OrderSearch" />
        </div>

        <asp:RequiredFieldValidator ID="valOrderDateStart" runat="server"
            ControlToValidate="txtOrderDateStart" ValidationGroup="OrderSearch"
            ErrorMessage="OrderDateStart" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="valOrderDateEnd" runat="server" 
            ControlToValidate="txtOrderDateEnd" ValidationGroup="OrderSearch"
            ErrorMessage="OrderDateEnd" Display="None"></asp:RequiredFieldValidator>
        <asp:ValidationSummary ID="valSummaryOrderSearch" runat="server"
            ValidationGroup="OrderSearch" ShowMessageBox="true" ShowSummary="false" />
    </form>
</body>
</html>
