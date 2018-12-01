using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MemoEngine.Repositories
{
    public class BoardDivisionRepository
    {
        // Database 개체 생성
        private IDbConnection db = new SqlConnection(ConfigurationManager
            .ConnectionStrings["ConnectionString"].ConnectionString);

        // Boards_Divisions 입력후 Id 값 반환
        public int AddBoardDivision(int tid, int divisionId)
        {
            var sql = "Insert Into BoardDivisions (TID, DivisionId) " 
                + " Values(@TID, @DivisionId); " 
                + " Select Cast(SCOPE_IDENTITY() As Int);";
            var id = this.db.Query<int>(
                sql, new { TID = tid, DivisionId = divisionId }).Single();
            return id; 
        }
    }
}
