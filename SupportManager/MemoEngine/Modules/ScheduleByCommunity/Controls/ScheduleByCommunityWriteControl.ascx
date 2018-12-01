<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ScheduleByCommunityWriteControl.ascx.cs" Inherits="DotNetNote.Modules.ScheduleByCommunity.Controls.ScheduleByCommunityWriteControl" %>
<table border="1" style="width: 100%">
	<tr>
		<td colspan="2" style="text-align: center">
			<h3>
				스케줄 입력하기</h3>
		</td>
	</tr>
	<tr>
		<td style="width: 80px">
			일시:</td>
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
			제목:</td>
		<td>
			<asp:TextBox ID="txtTitle" runat="server" Width="400px"></asp:TextBox></td>
	</tr>
	<tr>
		<td style="width: 80px">
			내용:</td>
		<td>
			<asp:TextBox ID="txtContent" runat="server" Height="150px" TextMode="MultiLine" Width="400px"></asp:TextBox></td>
	</tr>
	<tr>
		<td colspan="2" style="text-align: center">
			<asp:Button ID="btnWrite" runat="server" Text="입력" OnClick="btnWrite_Click" />
			<asp:Button ID="btnList" runat="server" Text="리스트" OnClick="btnList_Click" /></td>
	</tr>
</table>
