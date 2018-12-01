<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ScheduleByIdViewUserControl.ascx.cs" Inherits="MemoEngine.Modules.ScheduleById.Controls.ScheduleByIdViewUserControl" %>
<table border="1" style="width: 100%; padding:10px;">
	<tr>
		<td colspan="2" style="text-align: center">
			<h3>
				SCHEDULE VIEW</h3>
		</td>
	</tr>
	<tr>
		<td style="width: 80px">
			DATE:</td>
		<td>
			<asp:DropDownList ID="lstYear" runat="server">
			</asp:DropDownList>
			<asp:DropDownList ID="ddlMonth" runat="server">
			</asp:DropDownList>
			<asp:DropDownList ID="comDay" runat="server">
			</asp:DropDownList>
			<asp:DropDownList ID="ctlHour" runat="server">
			</asp:DropDownList></td>
	</tr>
	<tr>
		<td style="width: 80px">
			TITLE:</td>
		<td>
			<asp:TextBox ID="txtTitle" runat="server" Width="400px"></asp:TextBox></td>
	</tr>
	<tr>
		<td style="width: 80px">
			CONTENT:</td>
		<td>
			<asp:TextBox ID="txtContent" runat="server" Height="150px" TextMode="MultiLine" Width="400px"></asp:TextBox></td>
	</tr>
	<tr>
		<td colspan="2" style="text-align: center">
			<asp:Button ID="btnModify" runat="server" Text="수정" OnClick="btnModify_Click" CssClass="btn btn-info" />
			<asp:Button ID="btnDelete" runat="server" Text="삭제" OnClick="btnDelete_Click" CssClass="btn btn-info" />
			<asp:Button ID="btnList" runat="server" Text="리스트" OnClick="btnList_Click" CssClass="btn btn-info" /></td>
	</tr>
    <tr>
        <td colspan="2">
            &nbsp;
        </td>
    </tr>
</table>
