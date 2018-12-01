<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ScheduleByDomainList.aspx.cs" Inherits="DotNetNote.Modules.ScheduleByDomain.ScheduleByDomainList" %>
<%@ Register src="Controls/ScheduleByDomainListControl.ascx" tagname="ScheduleByDomainListControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ScheduleByDomainListControl ID="ScheduleByDomainListControl1" runat="server" />
</asp:Content>
