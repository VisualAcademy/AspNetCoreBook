<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="List.aspx.cs" 
    Inherits="Basic.Basic.List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <style>
        th {
            text-align: center;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>기본형 게시판 리스트</h2>

    <asp:HyperLink ID="lnkWrite" runat="server"
        NavigateUrl="Write.aspx"
        CssClass="btn btn-primary">
        글쓰기</asp:HyperLink>

    <asp:GridView ID="ctlBasicList" runat="server"
        ItemType="Basic.Models.Basic"
        CssClass="table table-bordered table-hover table-striped"
        HeaderStyle-HorizontalAlign="Center"
        AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField HeaderText="번호"
                HeaderStyle-Width="50px"
                ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <%# Item.Id %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="제 목"
                ItemStyle-HorizontalAlign="Left"
                HeaderStyle-Width="350px">
                <ItemTemplate>
                    <asp:HyperLink ID="lnkTitle" runat="server"
                        NavigateUrl=
                        '<%# "View.aspx?Id=" + Item.Id %>'>
                        <%# Item.Title %>
                    </asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Name" HeaderText="작성자"
                HeaderStyle-Width="60px"
                ItemStyle-HorizontalAlign="Center"></asp:BoundField>
            <asp:TemplateField HeaderText="작성일"
                ItemStyle-Width="90px"
                ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <%# Item.PostDate.ToString("yyyy-MM-dd") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ReadCount" HeaderText="조회수"
                ItemStyle-HorizontalAlign="Right"
                HeaderStyle-Width="60px"></asp:BoundField>
        </Columns>
    </asp:GridView>

</asp:Content>
