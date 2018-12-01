<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DivisionManagerUserControl.ascx.cs" Inherits="MemoEngine.Modules.DivisionModule.Controls.DivisionManagerUserControl" %>
<h1>분류(Divisions) 관리자</h1>

<h2>리스트</h2>
<asp:GridView ID="ctlDivisionList" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataKeyNames="DivisionId" DataSourceID="sdsDivisionList">
    <Columns>
        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
        <asp:BoundField DataField="DivisionId" HeaderText="번호" InsertVisible="False" ReadOnly="True" SortExpression="DivisionId" />
        <asp:BoundField DataField="DivisionName" HeaderText="분류명 한글" SortExpression="DivisionName" />
        <asp:BoundField DataField="DivisionNameEng" HeaderText="분류명 영문" SortExpression="DivisionNameEng" />
    </Columns>
    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
    <SortedAscendingCellStyle BackColor="#FFF1D4" />
    <SortedAscendingHeaderStyle BackColor="#B95C30" />
    <SortedDescendingCellStyle BackColor="#F1E5CE" />
    <SortedDescendingHeaderStyle BackColor="#93451F" />
</asp:GridView>
<asp:SqlDataSource ID="sdsDivisionList" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [Divisions] WHERE [DivisionId] = @DivisionId" InsertCommand="INSERT INTO [Divisions] ([DivisionName], [DivisionNameEng]) VALUES (@DivisionName, @DivisionNameEng)" SelectCommand="SELECT [DivisionId], [DivisionName], [DivisionNameEng] FROM [Divisions] ORDER BY [DivisionName]" UpdateCommand="UPDATE [Divisions] SET [DivisionName] = @DivisionName, [DivisionNameEng] = @DivisionNameEng WHERE [DivisionId] = @DivisionId">
    <DeleteParameters>
        <asp:Parameter Name="DivisionId" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="DivisionName" Type="String" />
        <asp:Parameter Name="DivisionNameEng" Type="String" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="DivisionName" Type="String" />
        <asp:Parameter Name="DivisionNameEng" Type="String" />
        <asp:Parameter Name="DivisionId" Type="Int32" />
    </UpdateParameters>
</asp:SqlDataSource>

<h2>데이터 입력</h2>
<asp:FormView ID="ctlDivisionAdd" runat="server" DataSourceID="sdsDivisionAdd" DataKeyNames="DivisionId" DefaultMode="Insert" OnItemInserted="ctlDivisionAdd_ItemInserted">
    <EditItemTemplate>
        DivisionId:
        <asp:Label ID="DivisionIdLabel1" runat="server" Text='<%# Eval("DivisionId") %>' />
        <br />
        DivisionName:
        <asp:TextBox ID="DivisionNameTextBox" runat="server" Text='<%# Bind("DivisionName") %>' />
        <br />
        DivisionNameEng:
        <asp:TextBox ID="DivisionNameEngTextBox" runat="server" Text='<%# Bind("DivisionNameEng") %>' />
        <br />
        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
        &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
    </EditItemTemplate>
    <InsertItemTemplate>
        분류명 한글:
        <asp:TextBox ID="DivisionNameTextBox" runat="server" Text='<%# Bind("DivisionName") %>' />
        <br />
        분류명 영문:
        <asp:TextBox ID="DivisionNameEngTextBox" runat="server" Text='<%# Bind("DivisionNameEng") %>' />
        <br />
        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
        &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
    </InsertItemTemplate>
    <ItemTemplate>
        DivisionId:
        <asp:Label ID="DivisionIdLabel" runat="server" Text='<%# Eval("DivisionId") %>' />
        <br />
        DivisionName:
        <asp:Label ID="DivisionNameLabel" runat="server" Text='<%# Bind("DivisionName") %>' />
        <br />
        DivisionNameEng:
        <asp:Label ID="DivisionNameEngLabel" runat="server" Text='<%# Bind("DivisionNameEng") %>' />
        <br />
        <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
        &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" />
        &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="New" />
    </ItemTemplate>
</asp:FormView>
<asp:SqlDataSource ID="sdsDivisionAdd" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [Divisions] WHERE [DivisionId] = @DivisionId" InsertCommand="INSERT INTO [Divisions] ([DivisionName], [DivisionNameEng]) VALUES (@DivisionName, @DivisionNameEng)" SelectCommand="SELECT [DivisionId], [DivisionName], [DivisionNameEng] FROM [Divisions]" UpdateCommand="UPDATE [Divisions] SET [DivisionName] = @DivisionName, [DivisionNameEng] = @DivisionNameEng WHERE [DivisionId] = @DivisionId">
    <DeleteParameters>
        <asp:Parameter Name="DivisionId" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="DivisionName" Type="String" />
        <asp:Parameter Name="DivisionNameEng" Type="String" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="DivisionName" Type="String" />
        <asp:Parameter Name="DivisionNameEng" Type="String" />
        <asp:Parameter Name="DivisionId" Type="Int32" />
    </UpdateParameters>
</asp:SqlDataSource>

