using Dapper;
using MemoEngine.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MemoEngine.Repositories
{
    /// <summary>
    /// Object Relationships 3가지
    /// DivisionRepository uses a Division : Collaboration("uses a")
    /// BoardDivision has a Division : Composition("has a")
    /// Cat is a Animal : Inheritance("is a")
    /// </summary>
    public class DivisionRepository
    {
        // Database 개체 생성
        private IDbConnection db = new SqlConnection(ConfigurationManager
            .ConnectionStrings["ConnectionString"].ConnectionString);

        // 데이터 출력
        public List<Division> GetDivisions()
        {
            string sql = @"
                Select DivisionId, DivisionName, DivisionNameEng 
                From Divisions Order By DivisionName Asc";
            return this.db.Query<Division>(sql).ToList(); 
        }
    }
}