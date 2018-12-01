<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ScheduleByDomainWrite.aspx.cs" Inherits="DotNetNote.Modules.ScheduleByDomain.ScheduleByDomainWrite" %>

<%@ Register Src="~/Modules/ScheduleByDomain/Controls/ScheduleByDomainWriteControl.ascx" TagPrefix="uc1" TagName="ScheduleByDomainWriteControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <uc1:ScheduleByDomainWriteControl runat="server" id="ScheduleByDomainWriteControl" />

</asp:Content>
