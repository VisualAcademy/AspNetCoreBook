using MemoEngine.Repositories;
using MemoEngine.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace MemoEngine
{
    public partial class UserInfor : System.Web.UI.Page
    {
        private UserRepository _userRepo;

        public string UserId { get; set; }

        public UserInfor()
        {
            _userRepo = new UserRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                UserId = Session["UserID"].ToString();
                // 익명사용자면 로그인 페이지로 이동
                if (UserId == "Anonymous")
                {
                    Response.Redirect("~/Login.aspx"); // 로그인으로 강제 이동
                }
            }
            // 로그인 되었는지 안되었는지 확인
            if (UserId != null) // 로그인 되었으면 참
            {
                if (!Page.IsPostBack) // 수정 기능이 있을 때에는 반드시 처음로드
                {
                    DisplayYear();
                    DisplayMonth();
                    DisplayDay(31);
                    GetCountryList();

                    DisplayData(); // 출력 전담 메서드
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        /// <summary>
        /// 특정 드롭다운리스트에 국가리스트(국가명, 코드) 바인딩하기
        /// </summary>
        private void GetCountryList()
        {
            // 딕셔너리 개체 생성
            Dictionary<string, string> objDic =
                new Dictionary<string, string>();

            // CultureInfo 개체를 사용하여 모든 국가리스트 가져오기
            foreach (CultureInfo objCultureInfo in
                CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                // RegionInfo로 각각의 표시이름, 코드 등 가져오기
                RegionInfo objRegionInfo =
                    new RegionInfo(objCultureInfo.Name);
                if (!objDic.ContainsKey(String.Format("{0}({1})"
                    , objRegionInfo.DisplayName, objRegionInfo.EnglishName)))
                {
                    objDic.Add(String.Format("{0}({1})",
                        objRegionInfo.DisplayName, objRegionInfo.EnglishName)
                        , objRegionInfo.TwoLetterISORegionName);
                }
            }

            // 키값에 따른 오름차순 정렬
            var obj = objDic.OrderBy(p => p.Key);

            // 드롭다운리스트의 Text/Value에 바인딩
            foreach (KeyValuePair<string, string> val in obj)
            {
                lstCountry.Items.Add(new ListItem(val.Key, val.Value));
            }

            // 대한민국(Korea)을 기본값으로 선택(selected)
            lstCountry.Items.FindByValue("KR").Selected = true;
        }


        private void DisplayDay(int maxDay)
        {
            this.lstDay.Items.Clear();
            for (int i = 1; i <= maxDay; i++)
            {
                this.lstDay.Items.Add(new ListItem(i.ToString()));
            }
            this.lstDay.Items.Insert(0, new ListItem("일", "0"));
        }

        private void DisplayMonth()
        {
            for (int i = 1; i <= 12; i++)
            {
                lstMonth.Items.Add(
                    new ListItem(i.ToString(), i.ToString()));
            }
        }

        private void DisplayYear()
        {
            // 현재 년도부터 100년간의 날짜를 바인딩: 6세 이상부터 회원 가입
            for (int i = DateTime.Now.Year - 6; i > 1900; i--)
            {
                lstYear.Items.Add(new ListItem(i.ToString()));
            }
        }

        private void DisplayData()
        {
            var user = _userRepo.GetUser(UserId);
            if (user != null)
            {
                lblUserId.Text      = UserId;
                lblUserName.Text    = user.Name;
                lblDomainId.Text    = UserId;
                lblName.Text        = user.Name;
                txtEmail.Text       = user.Email;
                txtDescription.Text = user.Description;

                txtPhoneNumber.Text = user.PhoneNumber;
                txtAddress.Text     = user.Address;
                if (user.Gender == "남자")
                {
                    optGenderMan.Checked = true;
                }
                else
                {
                    optGenderWomen.Checked = true;
                }

                // 생년월일
                if (user.BirthDate != null)
                {
                    string[] dates = user.BirthDate.Split('-');
                    if (dates.Length == 3)
                    {
                        lstYear.SelectedValue = dates[0];
                        lstMonth.SelectedValue = 
                            Convert.ToInt32(dates[1]).ToString(); // 09->9
                        lstDay.SelectedValue = 
                            Convert.ToInt32(dates[2]).ToString(); ; // 05->5
                    }
                }
                // 국가
                lstCountry.SelectedValue = user.Country; // KR
            }
        }

        /// <summary>
        /// 비밀번호 변경
        /// </summary>
        protected void btnChangePassword_Click(
            object sender, EventArgs e)
        {
            // Productivity Power Tool: <Ctrl+Alt+]>
            string password    = txtPassword.Text;
            string passwordNew = txtPasswordNew.Text;
            string userId      = UserId;

            int result = _userRepo.ChangePasswordByDomainId(
                password, passwordNew, userId);

            if (result > 0)
            {
                lblDisplay.Text = "암호가 성공적으로 수정되었습니다.";
            }
            else
            {
                lblDisplay.Text = "현재 암호가 틀립니다.";
            }
        }

        protected void btnChangeProfile_Click(object sender, EventArgs e)
        {
            var model = new UserViewModel();
            model.DomainID    = UserId; 
            model.Email       = txtEmail.Text;
            model.Description = txtDescription.Text;
            model.PhoneNumber = txtPhoneNumber.Text;
            model.Address     = txtAddress.Text;
            model.Gender      = optGenderMan.Checked ? "남자" : "여자";
            model.BirthDate   =
                String.Format("{0}-{1:00}-{2:00}"
                    , lstYear.SelectedValue
                    , Convert.ToInt32(lstMonth.SelectedValue)
                    , Convert.ToInt32(lstDay.SelectedValue));
            model.Country     = lstCountry.SelectedValue;

            if (_userRepo.UpdateUserProcess(model) > 0)
            {
                //"Your personal profile has been successfully changed."
                lblDisplay.Text = 
                    "사용자 프로필이 성공적으로 수정되었습니다.";
            }
            else
            {
                //"There was a problem with your request."
                lblDisplay.Text = 
                    "프로필 정보가 업데이트되지 못했습니다.";
            }
        }

        /// <summary>
        /// 회원 탈퇴
        /// </summary>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (_userRepo.IsCorrectPasswordByUID(
                Convert.ToInt32(Session["UID"]), txtDeletePassword.Text))
            {
                if (UserId == "Administrator" || UserId == "Anonymous"
            || UserId == "Guest")
                {
                    lblDisplay.Text =
                        "해당 사용자는 필수 구성원이기 때문에 삭제할 수 없습니다.";
                }
                else
                {
                    DeleteProcess(UserId);
                } 
            }
            else
            {
                lblDisplay.Text =
                    "암호가 틀립니다. The password is incorrect.";
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(),
                    "GoMain",
                    "<script>alert('암호가 틀립니다."
                    + " The password is incorrect.');</script>");

                return;
            }
        }

        private void DeleteProcess(string userId)
        {
            _userRepo.DeleteUser(userId); // 회원 정보 삭제

            FormsAuthentication.SignOut(); // 현재 접속자 자동 로그아웃
            Application["UserInf@" + UserId] = null;
            Session.Abandon();

            string js = @"
<script>
alert('회원탈퇴 처리되었습니다.');
location.href='/';
</script>
";
            Page.ClientScript.RegisterClientScriptBlock(
                this.GetType(), "GoMain", js);
        }
    }
}
