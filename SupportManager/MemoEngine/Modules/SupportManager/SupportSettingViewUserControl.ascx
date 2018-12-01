<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SupportSettingViewUserControl.ascx.cs" Inherits="MemoEngine.Modules.SupportManager.SupportSettingViewUserControl" %>

<div class="container">
    <div class="row">
        <div class="col-md-12">



<h3>서포트 설정 상세보기</h3>

<asp:HyperLink ID="lnkGoBack" runat="server"
    NavigateUrl="SupportSettingListPage.aspx"
    CssClass="btn btn-primary">뒤로</asp:HyperLink>
<hr />
<asp:HiddenField ID="hdnBoardName" runat="server" />
<asp:HiddenField ID="hdnNum" runat="server" />

<div class="row">
    <asp:HyperLink ID="lnkBoardView" runat="server"
        CssClass="btn btn-primary form-control">
        현재 서포트 설정 관련 게시판 상세 보기로 이동
    </asp:HyperLink>
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
            <asp:HyperLinkField 
                ControlStyle-CssClass="btn btn-primary btn-sm"
                HeaderText="상세보기" 
                Text="상세보기"
                DataNavigateUrlFields="Id, BoardName, BoardNum"
                DataNavigateUrlFormatString=
                    "SupportRegistrationView.aspx?Id={0}&BoardName={1}&Num={2}" />
        </Columns>
    </asp:GridView>
</div>



        </div>
    </div>
</div>
