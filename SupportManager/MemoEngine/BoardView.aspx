<%@ Page Title="" Language="C#" 
    MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="BoardView.aspx.cs" Inherits="MemoEngine.BoardView" %>

<%@ Register Src="~/Modules/SupportManager/SupportRegistrationUserControl.ascx" TagPrefix="uc1" TagName="SupportRegistrationUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>게시판 상세 보기</h2>


    <p>내용</p>


    <uc1:SupportRegistrationUserControl runat="server" 
        id="SupportRegistrationUserControl" />




</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
