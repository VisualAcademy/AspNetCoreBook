<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductCatalog.ascx.cs" Inherits="DotNetSale.Web.UserControls.ProductCatalogUserControl" %>
<%@ Register src="~/UserControls/EventNames.ascx" tagprefix="uc1" tagname="EventNames" %>

<h1>상품 카탈로그</h1>

<h2>신상품</h2>
<uc1:EventNames runat="server" id="EventNamesNew" />

<h2>히트상품</h2>
<uc1:EventNames runat="server" id="EventNamesHit" />

<h2>기획상품</h2>
<uc1:EventNames runat="server" id="EventNamesBest" />
