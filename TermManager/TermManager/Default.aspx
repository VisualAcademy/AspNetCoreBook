<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TermManager.Default" %>

<%@ Register Src="~/TermManager/TermListUserControl.ascx" TagPrefix="uc1" TagName="TermListUserControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>용어 관리자</h1>
            용어:
            <asp:TextBox ID="txtTerm" runat="server"></asp:TextBox><br />
            설명:
            <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox><br />
            <asp:Button ID="btnSave" runat="server" Text="저장" OnClick="btnSave_Click" />
            <hr />
            <asp:GridView ID="ctlTermList" runat="server"></asp:GridView>
            <hr />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" InsertVisible="False" SortExpression="Id"></asp:BoundField>
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title"></asp:BoundField>
                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description"></asp:BoundField>
                    <asp:BoundField DataField="CreationDate" HeaderText="CreationDate" SortExpression="CreationDate"></asp:BoundField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:TermManagerConnectionString %>' SelectCommand="SELECT [Id], [Title], [Description], [CreationDate] FROM [Terms] ORDER BY [Id] DESC"></asp:SqlDataSource>


            <uc1:TermListUserControl runat="server" id="TermListUserControl" />

        </div>
    </form>
</body>
</html>
