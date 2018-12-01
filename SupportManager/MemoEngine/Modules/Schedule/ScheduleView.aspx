<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ScheduleView.aspx.cs" Inherits="DotNetNote.Modules.Schedule.ScheduleView" %>

<%@ Register Src="~/Modules/Schedule/Controls/ScheduleViewControl.ascx" TagPrefix="uc1" TagName="ScheduleViewControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <uc1:ScheduleViewControl runat="server" id="ScheduleViewControl" />

</asp:Content>
