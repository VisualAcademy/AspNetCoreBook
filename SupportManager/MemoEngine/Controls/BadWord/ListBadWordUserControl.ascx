<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListBadWordUserControl.ascx.cs" Inherits="MemoEngine.Controls.BadWord.ListBadWordUserControl" %>

<asp:GridView ID="ctlBadWordManager" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="sdsBadWordManager" AllowPaging="True" AllowSorting="True">
    <Columns>
        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True"></asp:CommandField>
        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" InsertVisible="False" SortExpression="Id"></asp:BoundField>
        <asp:BoundField DataField="Word" HeaderText="Word" SortExpression="Word"></asp:BoundField>
    </Columns>
</asp:GridView>
<asp:SqlDataSource runat="server" ID="sdsBadWordManager" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' DeleteCommand="DELETE FROM [BadWords] WHERE [Id] = @Id" InsertCommand="INSERT INTO [BadWords] ([Word]) VALUES (@Word)" SelectCommand="SELECT * FROM [BadWords] ORDER BY [Word]" UpdateCommand="UPDATE [BadWords] SET [Word] = @Word WHERE [Id] = @Id">
    <DeleteParameters>
        <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="Word" Type="String"></asp:Parameter>
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="Word" Type="String"></asp:Parameter>
        <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
    </UpdateParameters>
</asp:SqlDataSource>

<hr />

<asp:HyperLink ID="lnkGoAdd" runat="server" NavigateUrl="~/Admin/BadWord/BadWordWrite.aspx">추가</asp:HyperLink>

<hr />

<asp:GridView ID="ctlBadWordList" runat="server">
    <Columns>
        <asp:HyperLinkField HeaderText="번호" DataTextField="Id" 
            DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Admin/BadWord/BadWordView.aspx?Id={0}" />
    </Columns>
</asp:GridView>
