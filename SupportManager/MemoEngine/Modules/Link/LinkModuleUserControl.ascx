<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LinkModuleUserControl.ascx.cs" Inherits="MemoEngine.Modules.Link.LinkModuleUserControl" %>
<div class="btn-group">
    <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
        즐겨찾기 <span class="caret"></span>
    </button>

    <asp:BulletedList ID="ctlFavorites" runat="server" CssClass="dropdown-menu" role="menu" DisplayMode="HyperLink">
    </asp:BulletedList>

</div>
