<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BoardDivisionManagerUserControl.ascx.cs" Inherits="MemoEngine.Modules.DivisionModule.Controls.BoardDivisionManagerUserControl" %>
<%@ Register Src="~/Modules/DivisionModule/Controls/DivisionManagerUserControl.ascx" TagPrefix="uc1" TagName="DivisionManagerUserControl" %>


<h1>게시판에 따른 분류 카테고리 관리</h1>

<h2>게시판 리스트</h2>
<asp:GridView ID="ctlBoardList" runat="server" AutoGenerateColumns="False" DataKeyNames="TID" DataSourceID="sdsBoardList" AllowPaging="True" AllowSorting="True" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" OnSelectedIndexChanged="ctlBoardList_SelectedIndexChanged">
    <Columns>
        <asp:CommandField ShowSelectButton="True"></asp:CommandField>
        <asp:BoundField DataField="TID" HeaderText="TID" ReadOnly="True" InsertVisible="False" SortExpression="TID"></asp:BoundField>
        <asp:BoundField DataField="BoardAlias" HeaderText="BoardAlias" SortExpression="BoardAlias"></asp:BoundField>
        <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title"></asp:BoundField>
    </Columns>
    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510"></FooterStyle>

    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White"></HeaderStyle>

    <PagerStyle HorizontalAlign="Center" ForeColor="#8C4510"></PagerStyle>

    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510"></RowStyle>

    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

    <SortedAscendingCellStyle BackColor="#FFF1D4"></SortedAscendingCellStyle>

    <SortedAscendingHeaderStyle BackColor="#B95C30"></SortedAscendingHeaderStyle>

    <SortedDescendingCellStyle BackColor="#F1E5CE"></SortedDescendingCellStyle>

    <SortedDescendingHeaderStyle BackColor="#93451F"></SortedDescendingHeaderStyle>
</asp:GridView>
<asp:SqlDataSource runat="server" ID="sdsBoardList" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT [TID], [BoardAlias], [Title] FROM [Boards] ORDER BY [TID]"></asp:SqlDataSource>

선택된 게시판의 TID: <asp:TextBox ID="txtTID" runat="server"></asp:TextBox>

<h2>게시판_분류 등록</h2>
게시판: <asp:Label ID="lblBoardName" runat="server" Text=""></asp:Label><br />
분류: <asp:DropDownList ID="ddlDivisionList" runat="server"></asp:DropDownList><br />
<asp:Button ID="btnAddBoardDivision" runat="server" Text="추가" OnClick="btnAddBoardDivision_Click" /><br />
<asp:Label ID="lblId" runat="server" Text=""></asp:Label>

<h2>선택된 게시판의 분류 리스트</h2>
<asp:GridView ID="ctlDivisionListBySeletion" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="sdsDivisionListBySelection" AllowPaging="True" AllowSorting="True" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
    <Columns>
        <asp:CommandField ShowEditButton="False" ShowDeleteButton="True" ShowSelectButton="True"></asp:CommandField>
        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" InsertVisible="False" SortExpression="Id"></asp:BoundField>
<%--        <asp:BoundField DataField="TID" HeaderText="TID" SortExpression="TID"></asp:BoundField>
        <asp:BoundField DataField="DivisionId" HeaderText="DivisionId" SortExpression="DivisionId"></asp:BoundField>--%>
        <asp:BoundField DataField="DivisionName" HeaderText="DivisionName" SortExpression="DivisionName"></asp:BoundField>
        <asp:BoundField DataField="DivisionNameEng" HeaderText="DivisionNameEng" SortExpression="DivisionNameEng"></asp:BoundField>
    </Columns>
    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510"></FooterStyle>

    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White"></HeaderStyle>

    <PagerStyle HorizontalAlign="Center" ForeColor="#8C4510"></PagerStyle>

    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510"></RowStyle>

    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

    <SortedAscendingCellStyle BackColor="#FFF1D4"></SortedAscendingCellStyle>

    <SortedAscendingHeaderStyle BackColor="#B95C30"></SortedAscendingHeaderStyle>

    <SortedDescendingCellStyle BackColor="#F1E5CE"></SortedDescendingCellStyle>

    <SortedDescendingHeaderStyle BackColor="#93451F"></SortedDescendingHeaderStyle>
</asp:GridView>
<asp:SqlDataSource runat="server" ID="sdsDivisionListBySelection" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' DeleteCommand="DELETE FROM [BoardDivisions] WHERE [Id] = @Id" InsertCommand="INSERT INTO [BoardDivisions] ([TID], [DivisionId]) VALUES (@TID, @DivisionId)" 
    SelectCommand="SELECT [Id], [TID], bd.[DivisionId], d.DivisionName, d.DivisionNameEng FROM [BoardDivisions] bd JOIN [Divisions] d ON bd.DivisionId = d.DivisionId WHERE ([TID] = @TID)" UpdateCommand="UPDATE [BoardDivisions] SET [TID] = @TID, [DivisionId] = @DivisionId WHERE [Id] = @Id">
    <DeleteParameters>
        <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="TID" Type="Int32"></asp:Parameter>
        <asp:Parameter Name="DivisionId" Type="Int32"></asp:Parameter>
    </InsertParameters>
    <SelectParameters>
        <asp:ControlParameter ControlID="ctlBoardList" PropertyName="SelectedValue" Name="TID" Type="Int32"></asp:ControlParameter>
    </SelectParameters>
    <UpdateParameters>
        <asp:Parameter Name="TID" Type="Int32"></asp:Parameter>
        <asp:Parameter Name="DivisionId" Type="Int32"></asp:Parameter>
        <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
    </UpdateParameters>
</asp:SqlDataSource>

<hr />

<uc1:DivisionManagerUserControl runat="server" ID="DivisionManagerUserControl" />
