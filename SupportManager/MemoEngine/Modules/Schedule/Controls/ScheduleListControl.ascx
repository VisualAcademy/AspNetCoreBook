<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ScheduleListControl.ascx.cs" Inherits="DotNetNote.Modules.Schedule.Controls.ScheduleListControl" %>
<table border="1" style="width: 100%">
	<tr>
		<td style="text-align: center">
			<h3>
				스케줄 리스트</h3>
		</td>
	</tr>
	<tr>
		<td align="center">
			<asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="380px" NextPrevFormat="ShortMonth" OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged" Width="400px">
				<SelectedDayStyle BackColor="#333399" ForeColor="White" />
				<TodayDayStyle BackColor="#999999" ForeColor="White" />
				<OtherMonthDayStyle ForeColor="#999999" />
				<DayStyle BackColor="#CCCCCC" HorizontalAlign="Left" VerticalAlign="Top" />
				<NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
				<DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
				<TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt"
					ForeColor="White" Height="12pt" />
			</asp:Calendar>
		</td>
	</tr>
	<tr>
		<td align="center">
			<asp:Button ID="btnWrite" runat="server" Text="일정등록" OnClick="btnWrite_Click" /></td>
	</tr>
</table>
