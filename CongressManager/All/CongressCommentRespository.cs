using Dapper;
using Hawaso.Standard;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace All
{
    public class CongressCommentRespository : ICongressCommentRespository
    {
        private SqlConnection db; 

        public CongressCommentRespository()
        {
            db = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        }

        /// <summary>
        /// 특정 게시물에 댓글 추가
        /// </summary>
        public void AddComment(ArticleCommentBase model)
        {
            // 파라미터 추가
            var parameters = new DynamicParameters();
            parameters.Add(
                "@ArticleId", value: model.ArticleId, dbType: DbType.Int32);
            parameters.Add(
                "@Name", value: model.Name, dbType: DbType.String);
            parameters.Add(
                "@Opinion", value: model.Opinion, dbType: DbType.String);
            parameters.Add(
                "@Password", value: model.Password, dbType: DbType.String);

            string sql = @"
                Insert Into CongressesComments (ArticleId, Name, Opinion, Password)
                Values(@ArticleId, @Name, @Opinion, @Password);

                Update Congresses Set CommentCount = CommentCount + 1 
                Where Id = @ArticleId
            ";

            db.Execute(sql, parameters, commandType: CommandType.Text);
        }
        
        /// <summary>
        /// 특정 게시물에 해당하는 댓글 리스트
        /// </summary>
        public List<ArticleCommentBase> GetComments(int articleId)
        {
            return db.Query<ArticleCommentBase>(
                "Select * From CongressesComments Where ArticleId = @ArticleId"
                , new { ArticleId = articleId }
                , commandType: CommandType.Text).ToList();
        }

        /// <summary>
        /// 특정 게시물의 특정 Id에 해당하는 댓글 카운트
        /// </summary>
        public int GetCountBy(int articleId, int id, string password)
        {
            return db.Query<int>(@"Select Count(*) From CongressesComments 
                Where ArticleId = @ArticleId And Id = @Id And Password = @Password"
                , new { ArticleId = articleId, Id = id, Password = password }
                , commandType: CommandType.Text).SingleOrDefault();
        }

        /// <summary>
        /// 댓글 삭제  
        /// </summary>
        public int DeleteComment(int articleId, int id, string password)
        {
            return db.Execute(@"Delete CongressesComments 
                Where ArticleId = @ArticleId And Id = @Id And Password = @Password; 
                
                Update Congresses Set CommentCount = CommentCount - 1 
                Where Id = @ArticleId"
                , new { ArticleId = articleId, Id = id, Password = password }
                , commandType: CommandType.Text);
        }

        /// <summary>
        /// 최근 댓글 리스트 전체
        /// </summary>
        public List<ArticleCommentBase> GetRecentComments()
        {
            string sql = @"SELECT TOP 5 Id, ArticleId, Opinion, PostDate 
                FROM CongressesComments Order By Id Desc";
            return db.Query<ArticleCommentBase>(sql).ToList();
        }
    }
}
