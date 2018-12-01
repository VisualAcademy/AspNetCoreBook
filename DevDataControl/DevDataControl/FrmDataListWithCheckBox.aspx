<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmDataListWithCheckBox.aspx.cs" Inherits="DevDataControl.FrmDataListWithCheckBox" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>체크박스 표시 및 체크한 값 가져오기 그리고 체크박스와 히든필드의 값을 함께 가져오기</h3>
            <asp:DataList ID="ctlBoardList" runat="server">
                <ItemTemplate>
                    <%# Eval("TID") %>, <%# Eval("Menu") %>
                    <hr />
                    <asp:CheckBox ID="chkMenu" runat="server" 
                        Text='<%# Eval("TID") %>' 
                        Checked='<%# Convert.ToBoolean(Eval("Menu")) %>' 
                        AutoPostBack="true"
                        OnCheckedChanged="chkMenu_CheckedChanged"
                    />
                    <asp:HiddenField ID="hdnBoardAlias" runat="server" Value='<%# Eval("BoardAlias") %>' />
                </ItemTemplate>
            </asp:DataList>
            <hr />
            <asp:Literal ID="lblCheckedValue" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>

