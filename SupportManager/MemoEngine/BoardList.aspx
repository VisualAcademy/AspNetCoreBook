<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BoardList.aspx.cs" Inherits="MemoEngine.BoardList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <a href="BoardView.aspx?BoardName=Event&Num=1">
        1번 글 보기 
    </a>
    <hr />
    <a href="BoardView.aspx?BoardName=Support&Num=1234">
        1234번 글 보기 
    </a>
    <hr />
    <a href="BoardView.aspx?BoardName=Support&Num=1235">
        1235번 글 보기 
    </a>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
