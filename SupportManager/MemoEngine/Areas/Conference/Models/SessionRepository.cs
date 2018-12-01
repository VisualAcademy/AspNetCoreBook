using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MemoEngine.Models
{
    public class SessionRepository
    {
        /// <summary>
        /// 컨트롤러에서
        /// Sessions.All.XXX로 접근할 수 있도록...
        /// </summary>
        public static IList<Session> All { get; set; }

        /// <summary>
        /// 정적 생성자
        /// </summary>
        static SessionRepository()
        {
            // XML 파일 읽어오기
            var xmlData = HttpContext.Current.Server.MapPath("~/App_Data/Sessions/SessionsData.xml");
            var xml = XDocument.Load(xmlData); // 메모리로 로드

            // XML 데이터를 IEnumerable<Session>로 읽어오기
            var sessions =
                from s in xml.Root.Elements("Session")
                select new Session
                {
                    Title = s.Element("Title").Value,
                    // 하나 이상의 Speaker를 Speakers 리스트에 담기 : LINQ to XML
                    Speakers = s.Elements("Speaker").Select(x => x.Value),
                    Room = s.Element("Room").Value,
                    Description = s.Element("Description").Value,
                    Code = s.Element("Code").Value,
                    Community = s.Element("Community").Value,
                    Tags = s.Elements("Tag").Select(x => x.Value),
                    StartDate = ConvertToDateTime(s.Element("Date").Value),
                    DateText = s.Element("Date").Value
                };

            // 취합된 세션 정보를 List 형태로 반환
            All = sessions.ToList();
        }

        private static DateTime ConvertToDateTime(string strDate)
        {
            // 2011년 12월 06일 화요일 오후 03시 30분 => 실제 날짜형(DateTime)
            //var year = strDate.Substring(0, 4); // 2011

            IFormatProvider culture = new System.Globalization.CultureInfo("ko-KR", true);

            return DateTime.Parse(strDate, culture, System.Globalization.DateTimeStyles.AssumeLocal);
        }
    }
}