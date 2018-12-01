<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ScheduleByIdWriteUserControl.ascx.cs" Inherits="MemoEngine.Modules.ScheduleById.Controls.ScheduleByIdWriteUserControl" %>
<table border="1" style="width: 100%">
    <tr>
        <td colspan="2" style="text-align: center">
            <h3>SCHEDULE ADD(관리자 전용)</h3>
        </td>
    </tr>
    <tr>
        <td style="width: 80px">일시:</td>
        <td>

            <asp:DropDownList ID="txtCategoryName" runat="server">
            </asp:DropDownList>

            <asp:DropDownList ID="lstYear" runat="server">
            </asp:DropDownList>
            <asp:DropDownList ID="ddlMonth" runat="server">
            </asp:DropDownList>
            <asp:DropDownList ID="comDay" runat="server">
            </asp:DropDownList>
            <asp:DropDownList ID="ctlHour" runat="server">
            </asp:DropDownList>
            <asp:DropDownList ID="ctlMinute" runat="server">
            </asp:DropDownList>
            <asp:DropDownList ID="ctlIcon" runat="server">
                <asp:ListItem Value="A">A</asp:ListItem>
                <asp:ListItem Value="B">B</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="width: 80px">제목:</td>
        <td>
            <asp:TextBox ID="txtTitle" runat="server" Width="400px"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="width: 80px">내용:</td>
        <td>
            <asp:TextBox ID="txtContent" runat="server" Height="150px" TextMode="MultiLine" Width="400px"></asp:TextBox></td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:Button ID="btnWrite" runat="server" Text="입력" OnClick="btnWrite_Click" CssClass="btn btn-info" />
            <a href="ScheduleByIdList.aspx" class="btn btn-info">리스트</a>
        </td>
    </tr>
</table>


<hr />

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Num" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True">
    <Columns>
        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True"></asp:CommandField>
        <asp:BoundField DataField="Num" HeaderText="Num" ReadOnly="True" InsertVisible="False" SortExpression="Num"></asp:BoundField>
        <asp:BoundField DataField="CategoryName" HeaderText="CategoryName" SortExpression="CategoryName"></asp:BoundField>
        <asp:BoundField DataField="SYear" HeaderText="SYear" SortExpression="SYear"></asp:BoundField>
        <asp:BoundField DataField="SMonth" HeaderText="SMonth" SortExpression="SMonth"></asp:BoundField>
        <asp:BoundField DataField="SDay" HeaderText="SDay" SortExpression="SDay"></asp:BoundField>
        <asp:BoundField DataField="SHour" HeaderText="SHour" SortExpression="SHour"></asp:BoundField>
        <asp:BoundField DataField="SMinute" HeaderText="SMinute" SortExpression="SMinute"></asp:BoundField>
        <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title"></asp:BoundField>
        <asp:BoundField DataField="Content" HeaderText="Content" SortExpression="Content"></asp:BoundField>
        <asp:BoundField DataField="Icon" HeaderText="Icon" SortExpression="Icon"></asp:BoundField>
        <asp:BoundField DataField="PostDate" HeaderText="PostDate" SortExpression="PostDate"></asp:BoundField>
        <asp:BoundField DataField="ParentId" HeaderText="ParentId" SortExpression="ParentId"></asp:BoundField>
    </Columns>
</asp:GridView>
<asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' DeleteCommand="DELETE FROM [ScheduleById] WHERE [Num] = @Num" InsertCommand="INSERT INTO [ScheduleById] ([CategoryName], [SYear], [SMonth], [SDay], [SHour], [Title], [Content], [PostDate], [SMinute], [Icon], [ParentId]) VALUES (@CategoryName, @SYear, @SMonth, @SDay, @SHour, @Title, @Content, @PostDate, @SMinute, @Icon, @ParentId)" SelectCommand="SELECT * FROM [ScheduleById] ORDER BY [Num] DESC" UpdateCommand="UPDATE [ScheduleById] SET [CategoryName] = @CategoryName, [SYear] = @SYear, [SMonth] = @SMonth, [SDay] = @SDay, [SHour] = @SHour, [Title] = @Title, [Content] = @Content, [PostDate] = @PostDate, [SMinute] = @SMinute, [Icon] = @Icon, [ParentId] = @ParentId WHERE [Num] = @Num">
    <DeleteParameters>
        <asp:Parameter Name="Num" Type="Int32"></asp:Parameter>
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="CategoryName" Type="String"></asp:Parameter>
        <asp:Parameter Name="SYear" Type="Int16"></asp:Parameter>
        <asp:Parameter Name="SMonth" Type="Int16"></asp:Parameter>
        <asp:Parameter Name="SDay" Type="Int16"></asp:Parameter>
        <asp:Parameter Name="SHour" Type="Int16"></asp:Parameter>
        <asp:Parameter Name="Title" Type="String"></asp:Parameter>
        <asp:Parameter Name="Content" Type="String"></asp:Parameter>
        <asp:Parameter Name="PostDate" Type="DateTime"></asp:Parameter>
        <asp:Parameter Name="SMinute" Type="Int16"></asp:Parameter>
        <asp:Parameter Name="Icon" Type="String"></asp:Parameter>
        <asp:Parameter Name="ParentId" Type="Int32"></asp:Parameter>
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="CategoryName" Type="String"></asp:Parameter>
        <asp:Parameter Name="SYear" Type="Int16"></asp:Parameter>
        <asp:Parameter Name="SMonth" Type="Int16"></asp:Parameter>
        <asp:Parameter Name="SDay" Type="Int16"></asp:Parameter>
        <asp:Parameter Name="SHour" Type="Int16"></asp:Parameter>
        <asp:Parameter Name="Title" Type="String"></asp:Parameter>
        <asp:Parameter Name="Content" Type="String"></asp:Parameter>
        <asp:Parameter Name="PostDate" Type="DateTime"></asp:Parameter>
        <asp:Parameter Name="SMinute" Type="Int16"></asp:Parameter>
        <asp:Parameter Name="Icon" Type="String"></asp:Parameter>
        <asp:Parameter Name="ParentId" Type="Int32"></asp:Parameter>
        <asp:Parameter Name="Num" Type="Int32"></asp:Parameter>
    </UpdateParameters>
</asp:SqlDataSource>
