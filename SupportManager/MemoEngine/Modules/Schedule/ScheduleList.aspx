<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ScheduleList.aspx.cs" Inherits="DotNetNote.Modules.Schedule.ScheduleList" %>
<%@ Register src="Controls/ScheduleListControl.ascx" tagname="ScheduleListControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ScheduleListControl ID="ScheduleListControl1" runat="server" />
</asp:Content>
