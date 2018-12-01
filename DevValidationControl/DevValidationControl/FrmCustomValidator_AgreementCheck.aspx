<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="FrmCustomValidator_AgreementCheck.aspx.cs" 
    Inherits="DevValidationControl.FrmCustomValidator_AgreementCheck" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>약관 동의 체크</title>
    <script>
    function CheckNecessary(sender, args) {
        if (document.getElementById(
            "<%= chkNecessary.ClientID %>").checked == true) {
            args.IsValid = true;
        }
        else {
            args.IsValid = false;
        }
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:CheckBox ID="chkNecessary" runat="server" />
            동의합니다.
            <asp:CustomValidator ID="valNecessary" runat="server"
                ErrorMessage="동의하셔야 합니다."
                Display="Dynamic"
                ClientValidationFunction="CheckNecessary"
                ValidationGroup="SupportForm">
            </asp:CustomValidator>

            <asp:Button ID="btnSave" runat="server" Text="등록하기"
                ValidationGroup="SupportForm"
                CssClass="btn btn-primary btn-lg" />
        </div>
    </form>
</body>
</html>
