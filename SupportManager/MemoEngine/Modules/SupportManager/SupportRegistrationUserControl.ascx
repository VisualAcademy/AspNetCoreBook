<%@ Control 
    Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="SupportRegistrationUserControl.ascx.cs" 
    Inherits=
        "MemoEngine.Modules.SupportManager.SupportRegistrationUserControl" %>

<%--<h3>공급자 등록</h3>--%>

<asp:Panel ID="divAdminView" runat="server" CssClass="text-center"
    BorderColor="Red" BorderWidth="1px" BorderStyle="Solid">
    <hr />
<%--    <a href=
        "/Modules/SupportManager/SupportSettingAdminPage.aspx?BoardName=Support&Num=1234"
        class="btn btn-primary btn-lg"
        >
        SupportSettingAdminPage.aspx : 관리
    </a>--%>

    <asp:HyperLink ID="btnSupportManager" runat="server" 
        CssClass="btn btn-primary btn-lg">
        설정 관리
    </asp:HyperLink>

    <asp:Panel ID="pnlNotYet" runat="server" Visible="false">
        <div class="alert alert-warning alert-dismissible" role="alert">
            아직 이벤트 설정이 되지 않았습니다. 
            [설정 관리] 버튼을 클릭하여 세부 설정을 완료하세요.
        </div>
    </asp:Panel>

</asp:Panel>

<asp:Panel ID="divUserView" runat="server" 
    BorderColor="blue" BorderWidth="1px" BorderStyle="Solid">
    <div class="text-center">
    <%--    <a href=
            "/Modules/SupportManager/SupportFormPage.aspx?BoardName=Support&Num=1234"
            class="btn btn-primary btn-lg"
            >
            신청하기 
        </a>--%>
        <asp:HyperLink ID="btnRegistration" runat="server"
            CssClass="btn btn-primary btn-lg"
            Text="신청하기"></asp:HyperLink>
        <asp:Button ID="btnRemoveRegistration" runat="server" Text="등록취소"
            CssClass="btn btn-danger btn-sm"
            Width="150px"
            OnClick="btnRemoveRegistration_Click"
            Visible="false"
            OnClientClick=
                "return window.confirm('등록을 취소하시겠습니까?');" />

    </div>
    <div class="row" style="padding: 20px">
        <div style="font-weight: bold; padding-bottom: 10px">
            서포트 등록 리스트
        </div>
        <asp:GridView ID="ctlSupportList" runat="server" 
            AutoGenerateColumns="false" 
            CssClass="table table-bordered table-hover">
            <Columns>
                <asp:TemplateField HeaderText="등록 순서" 
                    ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="등록자" 
                    ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <span style="font-size: 9pt;">
                            <%# Eval("Name").ToString() %>
                        </span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="등록일" DataField="CreationDate" 
                    ItemStyle-HorizontalAlign="Center" />
            </Columns>
        </asp:GridView>
    </div>
    <div class="row" style="text-align: center;">
        <hr />
    </div>
</asp:Panel>
<asp:Panel ID="divClosedMessage" runat="server" Visible="false">
    <div class="alert alert-warning alert-dismissible text-center" role="alert">
        <strong>이벤트가 종료되었습니다.</strong> 
    </div>
</asp:Panel>

