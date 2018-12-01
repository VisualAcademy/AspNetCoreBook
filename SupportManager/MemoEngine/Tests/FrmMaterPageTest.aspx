<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmMaterPageTest.aspx.cs" Inherits="MemoEngine.Tests.FrmMaterPageTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <link href="../Content/themes/base/all.css" rel="stylesheet" />
    <%--<link href="../Content/themes/base/datepicker.css" rel="stylesheet" />--%>
    <script src="../Scripts/jQueryUI/datepicker-ko.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    날짜선택기: <input type="text" name="txtDate1" id="txtDate1" value="" />
    <script>
        $(function () {
            $('#txtDate1').datepicker();
        });
    </script>

    <hr />

    만약, 서버 컨트롤을 사용한다면?
    <asp:TextBox ID="txtDate2" runat="server"></asp:TextBox>
    <script>
        $(function () {
            $('#<%= txtDate2.ClientID %>').datepicker();
        });
    </script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
