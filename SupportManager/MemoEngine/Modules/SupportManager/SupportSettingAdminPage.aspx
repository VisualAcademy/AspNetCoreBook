<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SupportSettingAdminPage.aspx.cs" Inherits="MemoEngine.Modules.SupportManager.SupportSettingAdminPage" %>

<%@ Register Src="~/Modules/SupportManager/SupportSettingAdminUserControl.ascx" TagPrefix="uc1" TagName="SupportSettingAdminUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <uc1:SupportSettingAdminUserControl runat="server" id="SupportSettingAdminUserControl" />


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
