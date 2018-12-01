<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ScheduleByDomainView.aspx.cs" Inherits="DotNetNote.Modules.ScheduleByDomain.ScheduleByDomainView" %>

<%@ Register Src="~/Modules/ScheduleByDomain/Controls/ScheduleByDomainViewControl.ascx" TagPrefix="uc1" TagName="ScheduleByDomainViewControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <uc1:ScheduleByDomainViewControl runat="server" id="ScheduleByDomainViewControl" />

</asp:Content>
