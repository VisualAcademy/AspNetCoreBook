<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ScheduleByIdListUserControl.ascx.cs" Inherits="MemoEngine.Modules.ScheduleById.Controls.ScheduleByIdListUserControl" %>

<div class="row">

    <div class="col-lg-7 col-md-7 col-sm-8 col-xs-12">

        <h3>SCHEDULE</h3>

        <asp:Calendar ID="Calendar1" runat="server" BackColor="White"
            BorderColor="#CCCCCC" Font-Names="맑은 고딕" Font-Size="8pt" ForeColor="#999999" Height="380px"
            OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged"
            BorderWidth="1px" DayNameFormat="Shortest" ShowGridLines="True" NextMonthText="&gt;&nbsp;&nbsp;" PrevMonthText="&nbsp;&nbsp;&lt;"
            Width="100%" OnVisibleMonthChanged="Calendar1_VisibleMonthChanged" CellPadding="5" Style="opacity: 0.8;">
            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
            <TodayDayStyle BackColor="#ededed" ForeColor="Red" />
            <OtherMonthDayStyle ForeColor="#CC9966" />
            <DayStyle HorizontalAlign="Left" VerticalAlign="Top" />
            <NextPrevStyle Font-Size="9pt" ForeColor="Black" />
            <DayHeaderStyle Height="30px" BackColor="White" Font-Bold="True" HorizontalAlign="Center" BorderColor="#d3d3d3" BorderStyle="Solid" BorderWidth="0" />
            <SelectorStyle BackColor="#FFCC66" />
            <TitleStyle BackColor="#f8f5f2" Font-Bold="True" Font-Size="9pt" ForeColor="Black" BorderColor="#CCCCCC" Height="40px" BorderWidth="0" CssClass="CalendarTitleStyle_Padding" />
            <WeekendDayStyle BorderColor="#CCCCCC" />
        </asp:Calendar>


        <div class="text-center">
            <asp:Button ID="btnWrite" runat="server" Text="일정등록" OnClick="btnWrite_Click" CssClass="btn btn-primary" />
        </div>


    </div>
    <div class="col-lg-5 col-md-5 col-sm-8 col-xs-12">


        <asp:GridView ID="ctlMonthlyList" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-condensed table-hover" Visible="false">
            <EmptyDataTemplate>
                <div class="well text-center">
                    <p>
                        이번 주에
                        <br />
                        등록된 일정이 없습니다.
                    </p>
                </div>
            </EmptyDataTemplate>
            <Columns>
                <asp:TemplateField HeaderText="Date" ItemStyle-Width="120px" ItemStyle-Font-Size="11px">
                    <ItemTemplate>
                        <%--                        <a href="<%# ResolveUrl("~/Modules/ScheduleById/") + String.Format("ScheduleByIdView.aspx?SYear={0}&SMonth={1}&SDay={2}&Num={3}", Eval("SYear"), Eval("SMonth"), Eval("SDay"), Eval("Num"))   %>">--%>
                        <a href="#">
                            <%# String.Format("{0:yyyy-MM-dd}", (new DateTime(Convert.ToInt32(Eval("SYear")), Convert.ToInt32(Eval("SMonth")), Convert.ToInt32(Eval("SDay")) )) ) %>
                        </a>
                    </ItemTemplate>

                    <ItemStyle Font-Size="11px" Width="120px"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Event" ItemStyle-Width="300px" ItemStyle-Font-Size="11px">
                    <ItemTemplate>
                        <%--                        <a href="<%# ResolveUrl("~/Modules/ScheduleById/") + String.Format("ScheduleByIdView.aspx?SYear={0}&SMonth={1}&SDay={2}&Num={3}", Eval("SYear"), Eval("SMonth"), Eval("SDay"), Eval("Num"))   %>">--%>
                        <a href="#">
                            <%# Eval("Title") %>
                            <br />
                            <span class="glyphicon glyphicon-arrow-right"></span>
                            <%# Eval("Content") %>
                        </a>
                    </ItemTemplate>

                    <ItemStyle Font-Size="11px" Width="300px"></ItemStyle>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle Font-Size="10pt" />
            <RowStyle Height="20px" />
        </asp:GridView>



        <asp:Repeater ID="lstMonthlyList" runat="server">
            <HeaderTemplate>
                <div id="sche-list">
                    <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <strong><%# String.Format("{0:yyyy-MM-dd}", (new DateTime(Convert.ToInt32(Eval("SYear")), Convert.ToInt32(Eval("SMonth")), Convert.ToInt32(Eval("SDay")) )) ) %> </strong><span style="font-size: 8pt;"><%--[<%# String.Format("{0:00}:{1:00}", Convert.ToInt32(Eval("SHour")), Convert.ToInt32(Eval("SMinute"))) %>]--%></span>
                    <p class="sche-text">
                        <img src='<%# "/images/bbs/sch_icon_" + ((Eval("Icon") != null) ? Eval("Icon").ToString() : "") + ".gif" %>' />
                        <%# Eval("Title") %><br />
                        <%--<%# Eval("Content") %>--%></p>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
        </div>

            </FooterTemplate>
        </asp:Repeater>



    </div>
</div>
