using System;

namespace MemoEngine.Models
{
    /// <summary>
    /// 분류(게시판 키워드 카테고리)
    /// </summary>
    public class Division
    {
        public int DivisionId { get; set; }
        public string DivisionName { get; set; }
        public string DivisionNameEng { get; set; }

        /// <summary>
        /// 한글과 영문에 대한 JSON 데이터 반환
        /// </summary>
        public string JsonData
        {
            get
            {
                // return "{kor:'사진',eng:'PHOTO'}"; // 원하는 데이터
                // return String.Format("{kor:'{0}',eng:'{1}'}", DivisionName, DivisionNameEng); // 테스트 실패
                return "{" + String.Format("kor:'{0}',eng:'{1}'", DivisionName, DivisionNameEng) + "}"; // 테스트 성공
            }
        }
    }
}
