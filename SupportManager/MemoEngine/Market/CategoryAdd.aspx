<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="CategoryAdd.aspx.cs" Inherits="MemoEngine.Market.CategoryAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>카테고리 등록</h1>

    카테고리 이름: <asp:TextBox ID="txtCategoryName" runat="server"></asp:TextBox>
    <asp:Button ID="btnAddCategory" runat="server" Text="추가" OnClick="btnAddCategory_Click" />

    <hr />

    <asp:GridView ID="ctlCategoryList" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="CategoryId" HeaderText="카테고리 번호" />
            <asp:TemplateField HeaderText="카테고리 이름">
                <ItemTemplate>
                    <%# Eval("CategoryName") %>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <div>
                <h2>현재 등록된 카테고리가 없습니다.</h2>
            </div>
        </EmptyDataTemplate>
    </asp:GridView>

</asp:Content>
