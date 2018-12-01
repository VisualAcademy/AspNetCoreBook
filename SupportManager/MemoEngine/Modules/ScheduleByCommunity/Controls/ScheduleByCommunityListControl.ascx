<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ScheduleByCommunityListControl.ascx.cs" Inherits="DotNetNote.Modules.ScheduleByCommunity.Controls.ScheduleByCommunityListControl" %>


<div class="row">

    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">



        <table border="0" style="width: 100%">
            <tr>
                <td style="text-align: center">
                    <h3>스케줄 리스트</h3>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" 
                        BorderColor="#FFCC66" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="300px" 
                        OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged" 
                        BorderWidth="1px" DayNameFormat="Shortest" ShowGridLines="True" 
                        Width="350px" OnVisibleMonthChanged="Calendar1_VisibleMonthChanged">
                        <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                        <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                        <OtherMonthDayStyle ForeColor="#CC9966" />
                        <DayStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                        <DayHeaderStyle Height="1px" BackColor="#FFCC66" Font-Bold="True" />
                        <SelectorStyle BackColor="#FFCC66" />
                        <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt"
                            ForeColor="#FFFFCC" />
                    </asp:Calendar>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnWrite" runat="server" Text="일정등록" OnClick="btnWrite_Click" /></td>
            </tr>
        </table>



    </div>
    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">

        <h3> 세부 일정 리스트</h3>


        <asp:GridView ID="ctlMonthlyList" runat="server" AutoGenerateColumns="false">
            <EmptyDataTemplate>
                <div class="well">
                    <p>등록된 일정이 없습니다.</p>
                </div>
            </EmptyDataTemplate>
            <Columns>
                <asp:TemplateField HeaderText="Date" ItemStyle-Width="100px">
                    <ItemTemplate>
                        <a href="<%# String.Format("ScheduleByCommunityView.aspx?SYear={0}&SMonth={1}&SDay={2}&Num={3}", Eval("SYear"), Eval("SMonth"), Eval("SDay"), Eval("Num"))   %>">
                            <%# String.Format("{0:yyyy-MM-dd}", (new DateTime(Convert.ToInt32(Eval("SYear")), Convert.ToInt32(Eval("SMonth")), Convert.ToInt32(Eval("SDay")) )) ) %>
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Event Title" ItemStyle-Width="300px">
                    <ItemTemplate>
                        <a href="<%# String.Format("ScheduleByCommunityView.aspx?SYear={0}&SMonth={1}&SDay={2}&Num={3}", Eval("SYear"), Eval("SMonth"), Eval("SDay"), Eval("Num"))   %>">
                            <%# Eval("Title") %>
                        </a>
                    </ItemTemplate>                    
                </asp:TemplateField>
            </Columns>
        </asp:GridView>



    </div>
</div>
