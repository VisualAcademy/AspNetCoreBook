using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Basic.Models
{
    public class BasicRepository
    {
        private IDbConnection db;
        public BasicRepository()
        {
            db = new SqlConnection(
                ConfigurationManager.ConnectionStrings[
                    "ConnectionString"].ConnectionString);
        }

        /// <summary>
        /// 입력
        /// </summary>
        public Basic Add(Basic model)
        {
            var sql = @"
                Insert Into Basics (
                    [Name], 
                    [Email], 
                    [Title], 
                    [PostDate], 
                    [PostIp], 
                    [Content], 
                    [Password], 
                    [ReadCount], 
                    [Encoding], 
                    [Homepage]
                ) 
                Values (
                    @Name, 
                    @Email, 
                    @Title, 
                    GetDate(), 
                    @PostIp, 
                    @Content, 
                    @Password, 
                    0, 
                    @Encoding, 
                    @Homepage
                ); " +
                "Select Cast(SCOPE_IDENTITY() As Int);";

            var id = db.Query<int>(sql, model).Single();

            model.Id = id;
            return model;
        }

        /// <summary>
        /// 출력
        /// </summary>
        public List<Basic> GetAll()
        {
            string sql = "Select * From Basics Order By Id Desc";
            return db.Query<Basic>(sql).ToList();
        }
    }
}
