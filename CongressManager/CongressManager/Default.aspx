<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CongressManager.Default" %>

<%@ Register Src="~/Congress/Controls/MainSummaryWithThumbNail.ascx" TagPrefix="uc1" TagName="MainSummaryWithThumbNail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1>협회 관리 홈페이지</h1>

    <uc1:MainSummaryWithThumbNail runat="server" id="MainSummaryWithThumbNail" />

</asp:Content>

