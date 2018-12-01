<%@ Page Title="사용자 정보 - 게시판" Language="C#"
    MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="UserInfor.aspx.cs" Inherits="MemoEngine.UserInfor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <style>
        .UserInfor {
            font-size: 9pt;
            font-family: 'Malgun Gothic', Tahoma, Verdana, sans-serif;
        }

            .UserInfor dt {
                float: left;
                width: 105px;
                text-align: right;
                margin-right: 10px;
                padding: 5px;
            }

            .UserInfor dd {
                padding: 5px;
                font-weight: bold;
            }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <img src="/images/title_55x55_help.gif" style="float: left;" />
        <h2 style="margin-left: 65px;">
            나의 회원 정보 보기(My Account Property)
        </h2>
        <p style="margin-left: 65px;">
            <asp:Label ID="lblUserId" runat="server" Text=""></asp:Label>
            (<asp:Label ID="lblUserName" runat="server" Text=""></asp:Label>) 
            님의 회원 정보는 다음과 같습니다.
        </p>
    </div>
    <hr style="clear: both;" />
    
    <div style="font-size: 9pt; color: #ff0000;">
        <asp:Label ID="lblDisplay" runat="server" Text=""></asp:Label>
    </div>

    <!-- 회원 정보 요약 출력 영역 -->
    <div class="panel panel-default">
        <div class="panel-heading">
            <span style="font-size: 11pt; font-weight: bold;">
                <img src="./images/contacts.gif" 
                    style="border-width: 0px;" alt="contacts" />
                <asp:Literal ID="strProfile" runat="server">
                    회원 정보</asp:Literal></span>
        </div>
        <div class="panel-body">
            <dl class="UserInfor">
                <dt>
                    <asp:Literal ID="strUserId" 
                        runat="server">아이디:</asp:Literal>
                </dt>
                <dd>
                    <asp:Label ID="lblDomainId" 
                        runat="server">Abcd</asp:Label></dd>
                <dt>
                    <asp:Literal ID="strUserName" 
                        runat="server">이름:</asp:Literal></dt>
                <dd>
                    <asp:Label ID="lblName" 
                        runat="server">홍길동</asp:Label></dd>
                <dt>Last Login Date:</dt>
                <dd>
                    <%
                        if (Session["LastLoginDate"] != null)
                        {
                            if (Session["LastLoginDate"].ToString() == "")
                            {
                                Response.Write("처음 방문 하셨습니다.");
                            }
                            else
                            {
                                Response.Write(
                                    Session["LastLoginDate"].ToString());
                            }
                        }
                    %>
                    &nbsp;
                </dd>
                <dt>Last Login IP:</dt>
                <dd><%= Session["LastLoginIP"] != null ? 
                            Session["LastLoginIP"].ToString() : "-" %></dd>
                <dt>Visit Count:</dt>
                <dd><%= Session["VisitedCount"] != null ? 
                            Session["VisitedCount"].ToString() : "-" %></dd>
            </dl>
        </div>
    </div>
    <!-- 회원 정보 요약 출력 영역 -->


    <!-- 비밀번호 변경 DataList 출력--> 
    <div class="panel panel-default" style="height: 245px;">
        <div class="panel-heading">
            <span style="font-size: 11pt;"><b>
                <img src="./images/drafts.gif" border="0" alt="drafts" />
                <asp:Literal ID="strChangePassword" runat="server">
                    비밀번호 변경</asp:Literal></b></span>
            <asp:ValidationSummary ID="valSummaryUserInforPassword"
                runat="server" ShowMessageBox="true" ShowSummary="false"
                ValidationGroup="UserInforPassword" />
        </div>
        <div class="panel-body">


        <dl class="UserInfor">
            <dt>
                <asp:Literal ID="strCurrentPassword" runat="server">
                    현재 비밀번호</asp:Literal>: 
            </dt>
            <dd>
                <asp:TextBox ID="txtPassword" runat="server" 
                    TextMode="Password" CssClass="form-control input-sm" 
                    Style="display: inline;width:250px;"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valPassword" runat="server" 
                    ControlToValidate="txtPassword" Display="None" 
                    ErrorMessage="'현재 비밀번호'를 입력해주십시오." 
                    ValidationGroup="UserInforPassword">
                </asp:RequiredFieldValidator>
            </dd>
            <dt>
                <asp:Literal ID="strNewPassword" runat="server">
                    새 비밀번호</asp:Literal>: </dt>
            <dd>
                <asp:TextBox ID="txtPasswordNew" runat="server" 
                    TextMode="Password" CssClass="form-control input-sm" 
                    Style="display: inline;width:250px;"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valPasswordNew" 
                    runat="server" 
                    ControlToValidate="txtPasswordNew" 
                    Display="None" 
                    ErrorMessage="'새 비밀번호'를 입력해주십시오." 
                    ValidationGroup="UserInforPassword">
                </asp:RequiredFieldValidator>
            </dd>
            <dt>
                <asp:Literal ID="strPasswordConfirm" runat="server">
                    비밀번호 확인</asp:Literal>: </dt>
            <dd>
                <asp:TextBox ID="txtPasswordConfirm" runat="server" 
                    TextMode="Password" CssClass="form-control input-sm" 
                    Style="display: inline;width:250px;"></asp:TextBox>
                <asp:CompareValidator ID="valPasswordConfirm" 
                    runat="server" 
                    ControlToValidate="txtPasswordConfirm" 
                    ControlToCompare="txtPasswordNew" 
                    Display="None" 
                    ErrorMessage=
                        "'새 비밀번호'와 '확인 비밀번호'가 일치하지 않습니다." 
                    ValidationGroup="UserInforPassword">
                </asp:CompareValidator>
            </dd>
            <dt style="clear: left;"></dt>
            <dd>
                <asp:Button ID="btnChangePassword" runat="server" 
                    Text="비밀번호 변경" 
                    OnClick="btnChangePassword_Click" 
                    ValidationGroup="UserInforPassword" 
                    CssClass="btn btn-primary btn-sm" />
            </dd>
        </dl>

        </div>
    </div>
    <!-- 비밀번호 변경 DataList 출력--> 


    <!-- 프로필 상세 정보 출력 -->
    <div class="panel panel-default" style="height: 370px;">
        <div class="panel-heading">
            <span style="font-size: 11pt;"><b>
                <img src="./images/info.gif" border="0" alt="info" />
                <asp:Literal ID="strMoreInformation" runat="server">
                    상세 정보</asp:Literal></b></span>
            <asp:ValidationSummary ID="valUserInforForm"
                runat="server" ShowMessageBox="true" ShowSummary="false"
                ValidationGroup="UserInforForm" />
        </div>
        <div class="panel-body">

        <dl class="UserInfor">
            <dt>
                <asp:Literal ID="strEmail" runat="server">
                    E-mail</asp:Literal>: 
            </dt>
            <dd>
                <asp:TextBox ID="txtEmail" runat="server"
                    CssClass="form-control input-sm"
                    Style="display: inline;width:250px;"></asp:TextBox>
                <asp:RegularExpressionValidator ID="valEmail" runat="server"
                    ControlToValidate="txtEmail" 
                    Display="None" 
                    ErrorMessage="'이메일'을 정확히 입력하시오." 
                    ValidationGroup="UserInforForm" 
                    ValidationExpression=
                        "\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                </asp:RegularExpressionValidator>
            </dd>
            <dt>
                <asp:Literal ID="strDescription" runat="server">
                    소개</asp:Literal>: </dt>
            <dd>
                <asp:TextBox ID="txtDescription" runat="server" 
                    CssClass="form-control input-sm" 
                    Style="display: inline;width:250px;"></asp:TextBox>
            </dd>
            <dt>
                <asp:Literal ID="strPhoneNumber" runat="server">
                    전화번호</asp:Literal>: </dt>
            <dd>
                <asp:TextBox ID="txtPhoneNumber" runat="server" 
                    CssClass="form-control input-sm" 
                    Style="display: inline;width:250px;"></asp:TextBox>
            </dd>
            <dt>
                <asp:Literal ID="strAddress" runat="server">
                    주소</asp:Literal>: </dt>
            <dd>
                <asp:TextBox ID="txtAddress" runat="server" 
                    CssClass="form-control input-sm" 
                    Style="display: inline;width:250px;"></asp:TextBox>
            </dd>
            <dt>
                <asp:Literal ID="strGender" runat="server">
                    성별</asp:Literal>: </dt>
            <dd>
                <label class="radio-inline">
                    <input type="radio" name="optGender" 
                        id="optGenderMan" value="남자" 
                        runat="server" />
                    <asp:Literal ID="strMale" runat="server">
                        남자
                    </asp:Literal>
                </label>
                <label class="radio-inline">
                    <input type="radio" name="optGender" 
                        id="optGenderWomen" value="여자" 
                        runat="server" />
                    <asp:Literal ID="strFemale" runat="server">
                        여자
                    </asp:Literal>
                </label>
            </dd>
            <dt>
                <asp:Literal ID="strBirthDate" runat="server">
                    생년월일</asp:Literal>: </dt>
            <dd>
                <asp:DropDownList ID="lstYear" runat="server"
                    CssClass="form-control input-sm"
                    style="width:90px;display:inline;">
                    <asp:ListItem Value="0">년</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="lstMonth" runat="server"
                    CssClass="form-control input-sm"
                    style="width:60px;display:inline;">
                    <asp:ListItem Value="0">월</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="lstDay" runat="server"
                    CssClass="form-control input-sm"
                    style="width:60px;display:inline;">
                    <asp:ListItem Value="0">일</asp:ListItem>
                </asp:DropDownList>
            </dd>
            <dt>
                <asp:Literal ID="strCountry" runat="server">
                    국가</asp:Literal>: </dt>
            <dd>
                <asp:DropDownList ID="lstCountry" runat="server"
                    CssClass="form-control input-sm"
                    style="display: inline;width:250px;">
                </asp:DropDownList>
            </dd>
            <dt style="clear: left;"></dt>
            <dd>
                <asp:Button ID="btnChangeProfile" runat="server" 
                    Text="프로필 바꾸기"                     
                    ValidationGroup="UserInforForm" 
                    CssClass="btn btn-primary btn-sm" 
                    OnClick="btnChangeProfile_Click" />
            </dd>
        </dl>

        </div>
    </div>
    <!-- 프로필 상세 정보 출력 -->

    <!-- 회원 탈퇴 -->
    <div class="panel panel-default">
        <div class="panel-heading">
            <span style="font-size: 11pt;"><b>
                <img src="./images/stop.gif" border="0" alt="stop" />
                <asp:Literal ID="strMemberSescession" runat="server">
                    회원 탈퇴</asp:Literal></b></span>
            <asp:ValidationSummary ID="valDeleteMemterSummary"
                runat="server" ShowMessageBox="true" ShowSummary="false"
                ValidationGroup="UserDeleteForm" />
        </div>
        <div class="panel-body">
        <dl class="UserInfor">
            <dt>
                <asp:Literal ID="stringPasswordInput" runat="server">
                    비밀번호 입력</asp:Literal>: 
            </dt>
            <dd>
                <asp:TextBox ID="txtDeletePassword" runat="server"
                    CssClass="form-control input-sm"
                    TextMode="Password"
                    Style="display: inline;width:250px;"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valDeletePassword"
                    runat="server"
                    ControlToValidate="txtDeletePassword"
                    ErrorMessage=
                        "삭제를 위한 비밀번호를 한번 더 입력해 주세요."
                    Display="None" 
                    ValidationGroup="UserDeleteForm">
                </asp:RequiredFieldValidator>
            </dd>
            <dt style="clear: left;"></dt>
            <dd>
                <asp:Button ID="btnDelete" runat="server" 
                    Text="탈퇴"                     
                    ValidationGroup="UserDeleteForm" 
                    CssClass="btn btn-primary btn-sm" 
                    OnClientClick="return checkDeleteUser();"
                    OnClick="btnDelete_Click" />
                <script>
                    function checkDeleteUser() {

                        var valReturn =
                            confirm("회원에서 탈퇴하시겠습니까?");

                        if (valReturn == true) {
                            return confirm(
                                "현재 작업은 해당 사용자의 정보와 그와 관계된 "
                                + "모든 권한 및 소속 정보를 삭제합니다.\n"
                                + "정말 삭제하시겠습니까?");
                        } else {
                            return false;
                        }// end if

                    } // end function
                </script>
            </dd>
        </dl>
        </div>
    </div>
    <!-- 회원 탈퇴 -->

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
