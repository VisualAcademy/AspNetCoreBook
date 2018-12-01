using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MemoEngine.Repositories
{
    public class BoardCounterRepository
    {
        /// <summary>
        /// Dapper dot net의 DB/Context 개체 생성
        /// </summary>
        private IDbConnection con = new SqlConnection(ConfigurationManager
            .ConnectionStrings["ConnectionString"].ConnectionString);

        /// <summary>
        /// 특정 테이블의 레코드 수 반환
        /// </summary>
        /// <param name="boardName">테이블 이름</param>
        /// <returns>레코드 수</returns>
        public int GetCountByBoardName(string boardName)
        {
            // string sql = "Select Count(*) From " + boardName;
            string sql = @"
                SELECT SUM (row_count) 
                FROM sys.dm_db_partition_stats 
                WHERE object_id=OBJECT_ID(@BoardName)    
                AND (index_id=0 or index_id=1); 
            ";
            return this.con.Query<int>(
                sql, new { BoardName = boardName }).Single();
        }
    }
}
