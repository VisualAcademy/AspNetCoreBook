<%@ Control Language="C#" AutoEventWireup="true" 
    CodeBehind="SupportRegistrationViewUserControl.ascx.cs" 
    Inherits="MemoEngine.Modules.SupportManager.SupportRegistrationViewUserControl" %>

<div class="container">
    <div class="row">
        <div class="col-md-12">



<h2>서포트 등록 상세 보기</h2>

<asp:HyperLink ID="lnkGoBack" runat="server"
    CssClass="btn btn-primary">뒤로</asp:HyperLink>

<asp:DetailsView ID="ctlSupportRegistration" runat="server"
    CssClass="table table-bordered table-condenced table-hover"
    Height="50px" Width="125px" AutoGenerateRows="False" DataKeyNames="Id" DataSourceID="sdsSupportRegistrationById">
    <Fields>
        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" InsertVisible="False" SortExpression="Id"></asp:BoundField>
        <asp:BoundField DataField="SupportSettingId" HeaderText="SupportSettingId" SortExpression="SupportSettingId"></asp:BoundField>
        <asp:BoundField DataField="BoardName" HeaderText="BoardName" SortExpression="BoardName"></asp:BoundField>
        <asp:BoundField DataField="BoardNum" HeaderText="BoardNum" SortExpression="BoardNum"></asp:BoundField>
        <asp:BoundField DataField="BoardTitle" HeaderText="BoardTitle" SortExpression="BoardTitle"></asp:BoundField>
        <asp:BoundField DataField="CreationDate" HeaderText="CreationDate" SortExpression="CreationDate"></asp:BoundField>
        <asp:BoundField DataField="UserId" HeaderText="UserId" SortExpression="UserId"></asp:BoundField>
        <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username"></asp:BoundField>
        <asp:BoundField DataField="NickName" HeaderText="NickName" SortExpression="NickName"></asp:BoundField>
        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"></asp:BoundField>
        <asp:BoundField DataField="Mobile" HeaderText="Mobile" SortExpression="Mobile"></asp:BoundField>
        <asp:BoundField DataField="Company" HeaderText="Company" SortExpression="Company"></asp:BoundField>
        <asp:BoundField DataField="Homepage" HeaderText="Homepage" SortExpression="Homepage"></asp:BoundField>
        <asp:BoundField DataField="SupportDate" HeaderText="SupportDate" SortExpression="SupportDate"></asp:BoundField>
        <asp:BoundField DataField="Recipient" HeaderText="Recipient" SortExpression="Recipient"></asp:BoundField>
        <asp:TemplateField HeaderText="등록 물품">
            <ItemTemplate>
<textarea cols="80" rows="20">
<%# Eval("Product") %>
</textarea>
            </ItemTemplate>
        </asp:TemplateField>
    </Fields>
</asp:DetailsView>

<asp:SqlDataSource runat="server" ID="sdsSupportRegistrationById" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT * FROM [SupportRegistrations] WHERE ([Id] = @Id)">
    <SelectParameters>
        <asp:QueryStringParameter QueryStringField="Id" Name="Id" Type="Int32"></asp:QueryStringParameter>
    </SelectParameters>
</asp:SqlDataSource>



        </div>
    </div>
</div>
