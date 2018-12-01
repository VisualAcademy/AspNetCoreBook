<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="BadWordList.aspx.cs" Inherits="MemoEngine.Admin.BadWord.BadWordList" %>

<%@ Register Src="~/Controls/BadWord/ListBadWordUserControl.ascx" TagPrefix="uc1" TagName="ListBadWordUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <uc1:ListBadWordUserControl runat="server" id="ListBadWordUserControl" />

</asp:Content>
