<%@ Page Title="대시보드" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="BoardDivisionManagerPage.aspx.cs" Inherits="MemoEngine.Admin.DivisionModule.BoardDivisionManagerPage" %>

<%@ Register Src="~/Modules/DivisionModule/Controls/BoardDivisionManagerUserControl.ascx" TagPrefix="uc1" TagName="BoardDivisionManagerUserControl" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <uc1:BoardDivisionManagerUserControl runat="server" ID="BoardDivisionManagerUserControl" />

</asp:Content>
