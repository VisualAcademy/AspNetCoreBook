<%@ Control Language="C#" AutoEventWireup="true"
    CodeBehind="SupportSettingAdminUserControl.ascx.cs"
    Inherits="MemoEngine.Modules.SupportManager.SupportSettingAdminUserControl" %>

<asp:HiddenField ID="hdnBoardName" runat="server" />
<asp:HiddenField ID="hdnNum" runat="server" />

<asp:Panel ID="divSupportSetting" runat="server" Visible="true">

    <h2>서포트 설정</h2>

    <table class="table table-bordered table-stripped">
        <tr>
            <td style="width: 160px;">이벤트 완전 종료</td>
            <td>
                <asp:CheckBox ID="chkIsClosed" runat="server" 
                    Text="체크하면 이벤트가 종료됩니다." />
                <br />
                체크하면 이벤트가 완전 종료되어 신청 및 수정이 되지 않습니다.
            </td>
        </tr>
        <tr>
            <td style="width: 160px;">이벤트 표시 시작</td>
            <td>
                <asp:TextBox ID="txtStartDate" runat="server"
                    CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>이벤트 등록 시작</td>
            <td>
                <asp:TextBox ID="txtEventDate" runat="server"
                    CssClass="form-control"></asp:TextBox>
                이 시간 이후로 등록 버튼 활성화
            </td>
        </tr>
        <tr>
            <td>이벤트 표시 종료</td>
            <td>
                <asp:TextBox ID="txtEndDate" runat="server"
                    CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>최대 등록자 수 제한</td>
            <td>
                <asp:TextBox ID="txtMaxRegistrationCount" runat="server"
                    CssClass="form-control">1000</asp:TextBox>
                (0으로 두면 등록받지 않음(이벤트 완전 종료))
            </td>
        </tr>
        <tr>
            <td>비고</td>
            <td>
                <asp:TextBox ID="txtRemarks" runat="server"
                    CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="설정 저장"
                    OnClick="btnSave_Click"
                    CssClass="btn btn-primary btn-lg" />
                <asp:HyperLink ID="btnGoToBoardView" runat="server"
                    CssClass="btn btn-default btn-lg"
                    >
                    뒤로 이동
                </asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:HyperLink ID="btnSupportListExcel" runat="server"
                    Visible="false">
                    서포트 리스트 엑셀 다운로드</asp:HyperLink>
                <asp:Button ID="btnRegistrationExcel" runat="server" 
                    Text="서포트 리스트 엑셀 다운로드"
                    CssClass="btn btn-danger btn-sm"
                    OnClick="btnRegistrationExcel_Click" />
            </td>
        </tr>
    </table>

</asp:Panel>
