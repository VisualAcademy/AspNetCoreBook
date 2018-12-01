<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LinkViewUserControl.ascx.cs" Inherits="MemoEngine.Modules.Link.LinkViewUserControl" %>
<h1>링크 상세 보기</h1>


<div class="form-group">
    <label for="txtTitle" class="col-sm-2 control-label">타이틀</label>
    <div class="col-sm-10">
        <input type="text" class="form-control" id="txtTitle" placeholder="타이틀" runat="server">
    </div>
</div>
<div class="form-group">
    <label for="txtUrl" class="col-sm-2 control-label">URL</label>
    <div class="col-sm-10">
        <input type="text" class="form-control" id="txtUrl" placeholder="URL" runat="server">
    </div>
</div>
<div class="form-group">
    <label for="txtViewOrder" class="col-sm-2 control-label">보이기 순서</label>
    <div class="col-sm-10">
        <input type="text" class="form-control" id="txtViewOrder" placeholder="보이기 순서" runat="server">
    </div>
</div>
<div class="form-group">
    <label for="txtDescription" class="col-sm-2 control-label">설명</label>
    <div class="col-sm-10">
        <input type="text" class="form-control" id="txtDescription" placeholder="설명" runat="server">
    </div>
</div>

<asp:Button ID="btnModify" runat="server" Text="수정"  CssClass="btn btn-primary btn-lg" OnClick="btnModify_Click" />
<asp:Button ID="btnDelete" runat="server" Text="삭제"  CssClass="btn btn-primary btn-lg" 
    OnClick="btnDelete_Click" OnClientClick="return window.confirm('정말로 삭제하시겠습니까?');" />
<asp:HyperLink ID="lnkLinkList" runat="server" NavigateUrl="LinkList.aspx" CssClass="btn btn-primary btn-lg">리스트</asp:HyperLink>
<hr />

<asp:Label ID="lblError" runat="server" Text=""></asp:Label>


