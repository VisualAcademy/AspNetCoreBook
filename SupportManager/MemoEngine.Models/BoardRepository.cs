using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace MemoEngine.Models
{
    /// <summary>
    /// Board 클래스(Boards 테이블)에 대한 리파지터리 클래스
    /// </summary>
    public class BoardRepository
    {
        // DB 개체: Context 개체
        private readonly SqlConnection ctx;
        
        public BoardRepository()
        {
            ctx = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        }

        /// <summary>
        /// 특정 그룹별(커뮤니티별) 게시판 주요 정보 리스트: BoardAlias와 Title만 출력, 게시판 이동 드롭다운리스트/ 커뮤니티별 게시판 리스트 메뉴 등에서 사용
        /// </summary>
        /// <param name="groupName">그룹명(커뮤니티명)</param>
        /// <returns>게시판 별칭과 제목 리스트</returns>
        public List<BoardEntity> GetBoardEntitiesByGroupName(string groupName)
        {
            return ctx.Query<BoardEntity>(
                "SELECT BoardAlias, Title FROM Boards WHERE GroupName = @GroupName And ShowList = 1 ORDER BY GroupOrder ASC", new { groupName }).ToList();
        }


        /// <summary>
        /// 특정 사용자(UID)가 시삽으로 있는 게시판 리스트 정보 얻기: 
        ///     특정 사용자의 정보 변경시 Application 변수 모두 업데이트
        ///     특정 사용자가 삭제 또는 탈퇴될 때 특정 게시판의 시삽으로 있으면 삭제 금지
        ///     Human Test 완료
        /// </summary>
        /// <param name="uid">Session["UID"].ToString()</param>
        /// <returns>게시판 별칭과 제목 리스트</returns>
        public List<BoardEntity> GetBoardAliasAndTitleListByUserUID(string uid)
        {
            return ctx.Query<BoardEntity>("SELECT BoardAlias, Title FROM Boards WHERE SysopUID = @UID", new { uid }).ToList();
        }
    }
}
