<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="CongressWrite.aspx.cs" Inherits="CongressManager.Congress.CongressWrite" ValidateRequest="false" %>

<%@ Register Src="~/Congress/Controls/BoardEditorFormControl.ascx" TagPrefix="uc1" TagName="BoardEditorFormControl" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:BoardEditorFormControl runat="server" ID="ctlBoardEditorFormControl" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="FooterContent" runat="server">
    <script>
        $(function() {
            CKEDITOR.replace('txtContent');    
        });
    </script>
</asp:Content>
