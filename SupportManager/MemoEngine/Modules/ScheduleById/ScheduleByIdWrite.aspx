<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ScheduleByIdWrite.aspx.cs" Inherits="MemoEngine.Modules.ScheduleById.ScheduleByIdWrite" %>

<%@ Register Src="~/Modules/ScheduleById/Controls/ScheduleByIdWriteUserControl.ascx" TagPrefix="uc1" TagName="ScheduleByIdWriteUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ScheduleByIdWriteUserControl runat="server" id="ScheduleByIdWriteUserControl" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
