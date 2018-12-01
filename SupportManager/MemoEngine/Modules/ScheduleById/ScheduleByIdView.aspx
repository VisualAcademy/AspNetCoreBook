<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ScheduleByIdView.aspx.cs" Inherits="MemoEngine.Modules.ScheduleById.ScheduleByIdView" %>

<%@ Register Src="~/Modules/ScheduleById/Controls/ScheduleByIdViewUserControl.ascx" TagPrefix="uc1" TagName="ScheduleByIdViewUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ScheduleByIdViewUserControl runat="server" id="ScheduleByIdViewUserControl" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
