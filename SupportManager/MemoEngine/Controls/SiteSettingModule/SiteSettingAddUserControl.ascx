<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SiteSettingAddUserControl.ascx.cs" Inherits="SiteSetting.Controls.SiteSettingModule.SiteSettingAddUserControl" %>
<div class="panel panel-default">
    <div class="panel-heading">사이트 정보 입력</div>
    <div class="panel-body">

        <div class="form-group">
            <label for="form-group-input" class="col-sm-2 control-label">메뉴 보이기 1</label>
            <div class="col-sm-10">

                <asp:CheckBox ID="chkShowMenu1" runat="server" />

            </div>
        </div>

        <div class="form-group">
            <label for="form-group-input" class="col-sm-2 control-label">&nbsp;</label>
            <div class="col-sm-10">
                <asp:Button ID="btnAdd" runat="server" Text="설정 저장" OnClick="btnAdd_Click" />
            </div>
        </div>

    </div>
</div>
<hr />
<asp:Label ID="lblDisplay" runat="server" Text="" ForeColor="Red"></asp:Label>
