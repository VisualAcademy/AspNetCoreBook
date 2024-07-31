<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventNames.aspx.cs" Inherits="DotNetSale.Web.EventNamesTest" %>

<%@ Register src="~/UserControls/EventNames.ascx" tagprefix="uc1" tagname="EventNames" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>신상품, 기획상품, 히트상품 테스트 페이지</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:EventNames runat="server" ID="EventNames" />

            <uc1:EventNames runat="server" ID="EventNames1" />
        </div>
    </form>
</body>
</html>
