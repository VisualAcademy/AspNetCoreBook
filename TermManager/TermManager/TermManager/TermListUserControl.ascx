<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TermListUserControl.ascx.cs" Inherits="TermManager.TermManager.TermListUserControl" %>

<style>
    .myHeaderStyle3 {
        font-family: 'Malgun Gothic';
        color: navy;
    }
</style>

<h3 class="myHeaderStyle3" 
    onmouseover="this.style.backgroundColor='yellow';"
    onmouseout="this.style.backgroundColor='';">용어 리스트</h3>

<asp:GridView ID="ctlTermList" runat="server"></asp:GridView>

