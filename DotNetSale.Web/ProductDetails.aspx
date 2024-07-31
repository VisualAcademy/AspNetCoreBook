<%@ Page Title="상품 상세 보기" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="DotNetSale.Web.ProductDetails" %>

<%@ Register src="~/UserControls/ReviewList.ascx" tagprefix="uc1" tagname="ReviewList" %>
<%@ Register src="~/UserControls/AlsoBought.ascx" tagprefix="uc1" tagname="AlsoBought" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>상품 상세 보기</h1>
    <h2>상품 상세 보기 내용 들어오는 곳...</h2>

    <uc1:ReviewList runat="server" id="ReviewList" />

    <uc1:AlsoBought runat="server" id="AlsoBought" />

</asp:Content>
