using System;
using System.Collections.Generic;

namespace MemoEngine.Models
{
    public class Session
    {
        /// <summary>
        /// 세션 제목
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 발표자(들)
        /// </summary>
        public IEnumerable<string> Speakers { get; set; }
        /// <summary>
        /// 장소
        /// </summary>
        public string Room { get; set; }
        /// <summary>
        /// 세미나 세션 설명
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 일련번호 : 세션코드
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 소속 커뮤니티
        /// </summary>
        public string Community { get; set; }
        /// <summary>
        /// 태그s
        /// </summary>
        public IEnumerable<string> Tags { get; set; }
        /// <summary>
        /// 세미나 시작 날짜
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 2014-09-24 수요일 오후 03시 30분
        /// </summary>
        public string DateText { get; set; }
    }
}