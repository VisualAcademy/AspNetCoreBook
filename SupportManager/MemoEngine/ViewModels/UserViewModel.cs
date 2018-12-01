using MemoEngine.Core;
using MemoEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace MemoEngine.ViewModels
{
    /// <summary>
    /// Users 뷰(View)에 대해서 일대일
    /// </summary>
    public class UserViewModel : ILoggable
    {
        public UserViewModel()
        {
            // Empty
        }

        public UserViewModel(int UID)
        {
            this.UID = UID; 
        }
        
        // 기본 속성들 : 필수

        public int UID { get; set; }            // Auto Implemented Properties
        public string DomainID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime LastLoginDate { get; set; }
        public string LastLoginIP { get; set; }
        public int VisitedCount { get; set; }
        public string Description { get; set; }
        public bool Blocked { get; set; }
        public string DomainType { get; set; } // SQL: Type 필드, C#: DomainType 속성


        // 추가 속성들 : 옵션

        public string PhoneNumber { get; set; }     // 전화번호(휴대폰)
        public string Address { get; set; }         // 주소
        public string Gender { get; set; }          // 성별
        public string BirthDate { get; set; }       // 생년월일
        public string Country { get; set; }         // 국가


        // 확장 속성들

        // DisplayName = DomainID + ( + Name + ) = RedPlus(박용준)
        public string DisplayName
        {
            get
            {
                return String.Format("{0}({1})", DomainID, Name);
            }
        }

        [Obsolete("구현하지 않은 메서드임: 사용하지 말 것")]
        public bool Validate()
        {
            return true;
        }

        /// <summary>
        /// UserID에 대한 유효성 검사: 잘못된 문자열 입력 방지
        /// </summary>
        /// <param name="strUserID">유효한 아이디인지 확인할 문자열</param>
        /// <returns>사용 가능(true), 사용 불가(false)</returns>
        public static bool ValidUserID(string strUserID)
        {
            string[] arrChar = { @"\", @"/", ":", "?", "*", "" + (char)34, "<", ">", "|", " ", "'", "%", "&", "+" };
            bool blnTemp = true;
            foreach (string s in arrChar)
            {
                if (strUserID.IndexOf(s) != -1)
                {
                    blnTemp = false;
                }
            }
            return blnTemp;
        }


        /// <summary>
        /// [1] 이메일에 대한 유효성 검사 확인
        /// </summary>
        /// <returns></returns>
        public Boolean ValidateEmail()
        {
            var valid = true;


            if (String.IsNullOrWhiteSpace(this.Email))
            {
                valid = false;
            }

            // 여기에 이메일에 대한 유효성 검사를 진행하는 코드 구현
            // 정규표현식 사용하면 됨.
            Regex regex = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
            valid = regex.IsMatch(this.Email); // 패턴이 맞으면 True


            var isRealDomain = true;
            // 여기에 실제 사용 가능한 도메인인지 확인하는 코드가 들어옴... 예를 들어, naver.com, daum.net, live.com 식으로 도메인 제한을 두고자한다면...

            if (!isRealDomain)
            {
                valid = false;
            }


            return valid;
        }


        /// <summary>
        /// [2] Tuple of T를 사용하여 다중 값 반환하는 이메일 확인 메서드
        /// </summary>
        /// <returns></returns>
        public Tuple<bool, string> ValidateEmailWithMessage()
        {
            Tuple<bool, string> result = Tuple.Create(true, "");

            if (String.IsNullOrWhiteSpace(this.Email))
            {
                result = Tuple.Create(false, "이메일이 NULL입니다.");
            }

            if (result.Item1 == true)
            {
                var isValidFormat = true;
                // 여기에 이메일에 대한 유효성 검사를 진행하는 코드 구현
                // 정규표현식 사용하면 됨.

                if (!isValidFormat)
                {
                    result = Tuple.Create(false, "이메일이 형식에 맞지 않습니다.");
                }
            }

            if (result.Item1 == true)
            {
                var isRealDomain = true;
                // 여기에 실제 사용 가능한 도메인인지 확인하는 코드가 들어옴... 예를 들어, naver.com, daum.net, live.com 식으로 도메인 제한을 두고자한다면...

                if (!isRealDomain)
                {
                    result = Tuple.Create(false, "지정한 도메인에 해당하는 이메일이 아닙니다.");
                }
            }

            return result;
        }


        /// <summary>
        /// [3] OperationResult를 사용하여 다중 값 반환하는 이메일 확인 메서드
        /// </summary>
        /// <returns></returns>
        public OperationResult ValidateEmailWithObject()
        {
            var op = new OperationResult();

            if (String.IsNullOrWhiteSpace(this.Email))
            {
                op.Success = false;
                op.AddMessage("이메일이 NULL입니다.");
            }

            if (op.Success)
            {
                var isValidFormat = true;
                // 여기에 이메일에 대한 유효성 검사를 진행하는 코드 구현
                // 정규표현식 사용하면 됨.

                if (!isValidFormat)
                {
                    op.Success = false;
                    op.AddMessage("이메일이 형식에 맞지 않습니다.");
                }
            }

            if (op.Success)
            {
                var isRealDomain = true;
                // 여기에 실제 사용 가능한 도메인인지 확인하는 코드가 들어옴... 예를 들어, naver.com, daum.net, live.com 식으로 도메인 제한을 두고자한다면...

                if (!isRealDomain)
                {
                    op.Success = false;
                    op.AddMessage("지정한 도메인에 해당하는 이메일이 아닙니다.");
                }
            }

            return op;
        }



        public override string ToString()
        {
            return DomainID;
        }




        public string Log()
        {
            var logString = this.DomainID + "(" + this.DomainType + ")" + ": " + this.Name;
            return logString;
        }


    }
}