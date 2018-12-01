<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="MemoEngine.Reply.List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>출력</h3>
            <div>
                <asp:GridView ID="ctlReplyList" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderText="제목">
                            <ItemTemplate>
                                <%# FuncStep(Eval("Step")) %>
                                <asp:HyperLink ID="lnkTitle" runat="server"
                                    NavigateUrl='<%# "View.aspx?Num=" + Eval("Num") %>'>
                            <%# Eval("Title") %>
                                </asp:HyperLink>
                                <%# Reply.Common.Board.GetNewImg(Eval("PostDate")) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Ref" DataField="Ref" />
                        <asp:BoundField HeaderText="Step" DataField="Step" />
                        <asp:BoundField HeaderText="RefOrder" DataField="RefOrder" />
                    </Columns>
                    <EmptyDataTemplate>
                        <div>입력된 데이터 없습니다..</div>
                    </EmptyDataTemplate>
                </asp:GridView>
                <asp:HyperLink ID="lnkWrite" runat="server"
                    NavigateUrl="~/Reply/Write.aspx">글쓰기</asp:HyperLink>
            </div>
        </div>
    </form>
</body>
</html>
