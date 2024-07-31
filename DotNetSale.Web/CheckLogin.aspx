<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckLogin.aspx.cs" Inherits="DotNetSale.Web.CheckLoginPage" %>

<%@ Register src="~/UserControls/CheckLogin.ascx" tagprefix="uc1" tagname="CheckLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <uc1:CheckLogin runat="server" ID="CheckLogin" />

</asp:Content>
