using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemoEngine.Entities
{
    /// <summary>
    /// UserProfiles 테이블과 일대일 매핑
    /// </summary>
    public class Profile
    {
        public int Id { get; set; }

        // 기본 속성들
        public int UID { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime LastLoginDate { get; set; }
        public string LastLoginIP { get; set; }
        public int VisitedCount { get; set; }
        public bool Blocked { get; set; }

        // 추가 속성들 : 옵션
        public string PhoneNumber { get; set; }     // 전화번호(휴대폰)
        public string Address { get; set; }         // 주소
        public string Gender { get; set; }          // 성별
        public string BirthDate { get; set; }       // 생년월일
        public string Country { get; set; }         // 국가

        // 부모 클래스 지정
        public Member Member { get; set; }
    }
}
