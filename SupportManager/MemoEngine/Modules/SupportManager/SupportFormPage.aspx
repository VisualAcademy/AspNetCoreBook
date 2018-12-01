<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="SupportFormPage.aspx.cs" 
    Inherits="MemoEngine.Modules.SupportManager.SupportFormPage" %>

<%@ Register 
    Src="~/Modules/SupportManager/SupportRegistrationFormUserControl.ascx" 
    TagPrefix="uc1" TagName="SupportRegistrationFormUserControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <uc1:SupportRegistrationFormUserControl 
        runat="server" id="SupportRegistrationFormUserControl" />   

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
