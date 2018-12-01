<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LinkAddUserControl.ascx.cs" Inherits="MemoEngine.Modules.Link.LinkAddUserControl" %>
<h1>링크 메뉴 추가</h1>

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

<asp:Button ID="btnSave" runat="server" Text="저장" OnClick="btnSave_Click" CssClass="btn btn-primary btn-lg" />
<asp:HyperLink ID="lnkLinkList" runat="server" NavigateUrl="LinkList.aspx" CssClass="btn btn-primary btn-lg">리스트</asp:HyperLink>
<hr />

<asp:Label ID="lblError" runat="server" Text=""></asp:Label>
