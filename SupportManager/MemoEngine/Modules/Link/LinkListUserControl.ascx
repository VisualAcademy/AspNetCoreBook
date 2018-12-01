<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LinkListUserControl.ascx.cs" Inherits="MemoEngine.Modules.Link.LinkListUserControl" %>
<h3>링크 리스트</h3>

<asp:GridView ID="ctlLinkList" runat="server" CssClass="table table-bordered table-condenced table-hover">
    <Columns>
        <asp:TemplateField HeaderText="링크 제목">
            <ItemTemplate>

                <a href="LinkView.aspx?Id=<%# Eval("Id") %>">
                    <%# Eval("Title") %>
                </a>

            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

<hr />

<asp:HyperLink ID="lnkLinkAdd" runat="server" NavigateUrl="LinkAdd.aspx" CssClass="btn btn-primary btn-lg">글쓰기</asp:HyperLink>
