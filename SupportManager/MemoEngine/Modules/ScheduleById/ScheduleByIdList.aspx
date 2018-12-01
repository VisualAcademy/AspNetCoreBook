<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ScheduleByIdList.aspx.cs" Inherits="MemoEngine.Modules.ScheduleById.ScheduleByIdList" %>

<%@ Register Src="~/Modules/ScheduleById/Controls/ScheduleByIdListUserControl.ascx" TagPrefix="uc1" TagName="ScheduleByIdListUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ScheduleByIdListUserControl runat="server" id="ScheduleByIdListUserControl" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
