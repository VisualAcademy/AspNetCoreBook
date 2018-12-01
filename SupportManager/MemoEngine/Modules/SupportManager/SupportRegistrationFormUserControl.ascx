<%@ Control 
    Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="SupportRegistrationFormUserControl.ascx.cs" 
    Inherits=
        "MemoEngine.Modules.SupportManager.SupportRegistrationFormUserControl" %>

    <h3>등록 폼</h3>
    
    <asp:HiddenField ID="hdnBoardName" runat="server" />
    <asp:HiddenField ID="hdnNum" runat="server" />


    <table width="100%" border="1" 
           class="table table-bordered table-stripped">
        <tr>
            <td rowspan="4" width="100"
                style="text-align:right;vertical-align:middle;">
                보내는 분
            </td>
            <td width="120" style="text-align:center;">대표자 성함</td>
            <td>
                <asp:TextBox ID="txtName" runat="server" 
                    CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valName" runat="server" 
                    ErrorMessage="이름을 입력하세요." 
                    ControlToValidate="txtName" 
                    ValidationGroup="SupportForm" 
                    Display="Dynamic" 
                    ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align:center;">연락처</td>
            <td>
                <asp:TextBox ID="txtMobile" runat="server" 
                    CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valMobile" runat="server" 
                    ErrorMessage="연락처를 입력하세요." 
                    ControlToValidate="txtMobile" 
                    ValidationGroup="SupportForm" 
                    Display="Dynamic" 
                    ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align:center;">단체명</td>
            <td>
                <asp:TextBox ID="txtCompany" runat="server" 
                    CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valCompany" runat="server" 
                    ErrorMessage="단체명을 입력하세요." 
                    ControlToValidate="txtCompany" 
                    ValidationGroup="SupportForm" 
                    Display="Dynamic" 
                    ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align:center;">운영 홈페이지(URL)</td>
            <td>
                <asp:TextBox ID="txtHomepage" runat="server" 
                    CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center;">일자 및 시간</td>
            <td>
                <asp:TextBox ID="txtDateTime" runat="server" 
                    CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valDateTime" runat="server" 
                    ErrorMessage="일자 및 시간을 입력하세요." 
                    ControlToValidate="txtDateTime" 
                    ValidationGroup="SupportForm" 
                    Display="Dynamic" 
                    ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center;">받는 사람</td>
            <td>
                <asp:TextBox ID="txtRecipient" runat="server" 
                    CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" height="200"
                style="text-align:center;vertical-align:middle;">
                등록 물품
            </td>
            <td>
                * 서포트 물품의 규격 및 품목을 상세히 적어 주시기 바랍니다.
                <asp:TextBox ID="txtProduct" runat="server"
                     CssClass="form-control"
                    TextMode="MultiLine" Columns="80" Rows="10"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valProduct" runat="server" 
                    ErrorMessage="등록 물품을 입력하세요." 
                    ControlToValidate="txtProduct" 
                    ValidationGroup="SupportForm" 
                    Display="Dynamic" 
                    ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>    


    <%--약관 동의--%>
    <asp:Panel ID="divAgreement" runat="server">

        <div class="form-group">
            <label class="col-sm-2 control-label" for="txtAgreement">
                &nbsp;
            </label>
            <div class="col-sm-10">
                <label class="control-label" for="txtAgreement">개인정보의 수집 및 이용에 관한 동의</label>
                <textarea rows="5" class="form-control" id="txtAgreement">
주식회사 []는 개인정보를 중요시하며 개인정보 보호법 등 관계 법령을 준수하고 있습니다. 
주식회사 []는 서포트 신청을 위하여 아래와 같이 서포트 신청자의 개인정보를 수집 및 이용할 예정입니다. 수집된 신청자의 개인정보는 아래 설명된 목적을 위해서만 이용될 것이며, 이외의 다른 용도로 이용되거나 제3자에게 제공되지 않습니다.

수집하려는 개인정보의 항목 
[필수항목] 대표자 성함, 연락처, 받는 사람 (서포트 대상)
[선택항목] 단체명, 운영 홈페이지 (URL)

개인정보의 수집이용목적
[필수항목] 서포트 신청자 확인, 받는 사람 (서포트 대상) 확인
[선택항목] 서포트 단체 정보 확인

개인정보의 보유 및 이용기간: 관계법령의 규정에 따라 귀하의 개인정보를 보존하여야 하는 경우에 해당하지 않는 한, 귀하의 개인정보는 귀하가 신청하신 서포트의 전달이 완료될 때까지 보유 및 이용될 예정입니다.

귀하는 위와 같은 개인정보의 수집 및 이용에 대한 동의를 거부할 권리가 있습니다. 필수항목의 수집 및 이용에 대해 동의하지 않는 경우 서포트 신청서가 접수되지 않으며, 선택항목의 수집 및 이용에 대해 동의하지 않을 수 있음을 알려 드립니다. 
                </textarea>
            </div>
        </div>
        <div>
            &nbsp;
        </div>

        <table align="center">
            <tr>
                <td>본인은 상기 내용을 상세히 읽어 보았고,</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>상기 필수항목의 수집 및 이용에 대해</td>
                <td>
                    <asp:CheckBox ID="chkNecessary" runat="server" />
                        동의합니다.
<script>
    function CheckNecessary(sender, args) {
        if (document.getElementById("<%= chkNecessary.ClientID %>").checked == true) {
            args.IsValid = true;
        }
        else {
            args.IsValid = false;
        }
    }
</script>
                    <asp:CustomValidator ID="valNecessary" runat="server"
                        ErrorMessage="필수항목에 동의하셔야 합니다."
                        ClientValidationFunction="CheckNecessary"
                        ValidationGroup="SupportForm">
                    </asp:CustomValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>상기 선택항목의 수집 및 이용에 대해</td>
                <td>
                    <asp:CheckBox ID="chkOption" runat="server" />
                        동의합니다.
<script>
    function CheckOption(sender, args) {
        if (document.getElementById("<%= chkOption.ClientID %>").checked == true) {
            args.IsValid = true;
        }
        else {
            args.IsValid = false;
        }
    }
</script>
                    <asp:CustomValidator ID="valOption" runat="server"
                        ErrorMessage="선택항목에 동의하셔야 합니다."
                        ClientValidationFunction="CheckOption"
                        ValidationGroup="SupportForm">
                    </asp:CustomValidator>

                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <%= DateTime.Now.Year %>년 
                    <%= DateTime.Now.Month %>월 
                    <%= DateTime.Now.Day %>일
                </td>
                <td></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="text-right">성명: </td>
                <td>
                    <asp:TextBox ID="txtAgreementName" runat="server" 
                    CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="font-style:italic;">
                    <asp:Panel ID="divError" runat="server">
                        개인정보의 수집 및 이용에 관한 동의에 동의하셔야 
                        [등록]을 하실 수 있습니다.
                    </asp:Panel>
                    <asp:Label ID="lblError" runat="server" 
                        ForeColor="Red" Visible="false"
                        Text="약관 체크와 이름 입력을 확인하세요."></asp:Label>
                </td>
            </tr>
        </table>
        <br />
    </asp:Panel>
    

    <div class="text-center">
        <asp:Button ID="btnSave" runat="server" Text="등록하기"
            OnClick="btnSave_Click"
            ValidationGroup="SupportForm"
            CssClass="btn btn-primary btn-lg" />
        <asp:Button ID="btnModify" runat="server" Text="수정하기"
            OnClick="btnSave_Click"
            ValidationGroup="SupportForm"
            Visible="false"
            CssClass="btn btn-primary" />
        <asp:Button ID="btnDelete" runat="server" Text="등록 삭제(취소)하기"
            OnClientClick="return confirm('정말로 취소하시겠습니까?');"
            OnClick="btnSave_Click"
            ValidationGroup="SupportForm"
            Visible="false"
            CssClass="btn btn-danger btn-sm" />

        <asp:HyperLink ID="btnGoToBoardView" runat="server"
            CssClass="btn btn-default btn-sm"
            >
            뒤로 이동
        </asp:HyperLink>
    </div>

    <br />
    <br />
