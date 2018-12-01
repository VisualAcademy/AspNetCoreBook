<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddBadWordUserControl.ascx.cs" Inherits="MemoEngine.Controls.BadWord.AddBadWordUserControl" %>
<h1>비속어 등록</h1>
<asp:TextBox ID="txtBadWord" runat="server"></asp:TextBox>
<asp:Button ID="btnAddBadWord" runat="server" Text="등록" OnClick="btnAddBadWord_Click" />

<hr />

<asp:TextBox ID="txtWord" runat="server"></asp:TextBox>
<asp:Button ID="btnAdd" runat="server" Text="추가" OnClick="btnAdd_Click" />
<br />
<asp:Label ID="lblDisplay" runat="server" Text=""></asp:Label>

<hr />

<asp:TextBox ID="txtWords" runat="server" TextMode="MultiLine"></asp:TextBox>
<asp:Button ID="btnAddMulti" runat="server" Text="다중입력" OnClick="btnAddMulti_Click" />
<asp:Label ID="lblError" runat="server" Text=""></asp:Label>

<hr />

<a href="/Admin/BadWord/BadWordList.aspx">리스트 페이지로 이동</a>