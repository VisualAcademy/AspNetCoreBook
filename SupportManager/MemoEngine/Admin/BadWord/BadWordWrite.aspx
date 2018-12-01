<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="BadWordWrite.aspx.cs" Inherits="MemoEngine.Admin.BadWord.BadWordWrite" %>

<%@ Register Src="~/Controls/BadWord/AddBadWordUserControl.ascx" TagPrefix="uc1" TagName="AddBadWordUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <uc1:AddBadWordUserControl runat="server" ID="AddBadWordUserControl" />

</asp:Content>
