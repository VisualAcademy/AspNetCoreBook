<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="BadWordView.aspx.cs" Inherits="MemoEngine.Admin.BadWord.BadWordView" %>

<%@ Register Src="~/Controls/BadWord/GetBadWordUserControl.ascx" TagPrefix="uc1" TagName="GetBadWordUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <uc1:GetBadWordUserControl runat="server" ID="GetBadWordUserControl" />

</asp:Content>
