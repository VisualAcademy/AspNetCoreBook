<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ScheduleWrite.aspx.cs" Inherits="DotNetNote.Modules.Schedule.ScheduleWrite" %>
<%@ Register src="Controls/ScheduleWriteControl.ascx" tagname="ScheduleWriteControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ScheduleWriteControl ID="ScheduleWriteControl1" runat="server" />
</asp:Content>
