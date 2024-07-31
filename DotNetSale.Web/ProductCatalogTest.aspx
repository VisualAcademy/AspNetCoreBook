<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductCatalogTest.aspx.cs" Inherits="DotNetSale.Web.ProductCatalogTest" %>

<%@ Register src="~/UserControls/ProductCatalog.ascx" tagprefix="uc1" tagname="ProductCatalog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <uc1:ProductCatalog runat="server" id="ProductCatalog" />

</asp:Content>
