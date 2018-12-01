<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GetBadWordUserControl.ascx.cs" Inherits="MemoEngine.Controls.BadWord.GetBadWordUserControl" %>
<h1>비속어 상세보기</h1>

<asp:TextBox ID="txtWord" runat="server"></asp:TextBox>

<hr />

<asp:HyperLink ID="lnkGoList" runat="server" NavigateUrl="~/Admin/BadWord/BadWordList.aspx">리스트</asp:HyperLink>

<asp:LinkButton ID="btnModify" runat="server" OnClick="btnModify_Click">수정</asp:LinkButton>

<asp:LinkButton ID="btnDelete" runat="server" 
    OnClientClick="return confirm('정말로 삭제');" OnClick="btnDelete_Click">삭제</asp:LinkButton>

<hr />

<asp:Literal ID="strDisplay" runat="server"></asp:Literal>