using Dapper;
using MemoEngine.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MemoEngine.Repositories
{
    public class BadWordRepository
    {
        /// <summary>
        /// Dapper dot net의 DB/Context 개체 생성
        /// </summary>
        private IDbConnection con = new SqlConnection(ConfigurationManager
            .ConnectionStrings["ConnectionString"].ConnectionString);

        /// <summary>
        /// 입력
        /// </summary>
        /// <param name="word"></param>
        public void AddBadWord(BadWordModel model)
        {
            string sql = "Insert Into BadWords (Word) Values (@Word);";
            this.con.Execute(sql, model);
        }

        /// <summary>
        /// 입력 후 관련 Identity 값 반환
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public BadWordModel AddBadWordUpgrade(BadWordModel word)
        {
            string sql = @"
                Insert Into BadWords (Word) Values (@Word);
                Select Cast(SCOPE_IDENTITY() As Int);
            ";
            var id = this.con.Query<int>(sql, word).Single();
            word.Id = id;
            return word; 
        }

        /// <summary>
        /// BulkInsert 벌크 인서트: 다중 입력
        /// </summary>
        /// <param name="word"></param>
        public void BulkInsertBadWord(List<BadWordModel> words)
        {
            // 데이터베이스가 연결되었는지 확인
            if (this.con.State != ConnectionState.Open)
            {
                this.con.Open();
            }

            string sql = "Insert Into BadWords (Word) Values (@Word);";
            this.con.Execute(sql, words);
        }



        /// <summary>
        /// 출력
        /// </summary>
        /// <returns></returns>
        public List<BadWordModel> GetBadWords()
        {
            string sql = "Select * From BadWords Order By Word Asc, Id Asc";
            return this.con.Query<BadWordModel>(sql).ToList(); 
        }

        /// <summary>
        /// 상세
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BadWordModel Find(int id)
        {
            string sql = "Select * From BadWords Where Id = @Id";
            return this.con.Query<BadWordModel>(
                sql, new { Id = id }).SingleOrDefault();
        }

        /// <summary>
        /// 수정
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BadWordModel Update(BadWordModel model)
        {
            string sql = "Update BadWords Set Word = @Word Where Id = @Id";
            this.con.Execute(sql, model);
            return model; 
        }

        /// <summary>
        /// 삭제
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            string sql = "Delete BadWords Where Id = @Id";
            this.con.Execute(sql, new { id });
        }


        /// <summary>
        /// 넘겨온 문자열에 비속어가 포함되어 있는지 아닌지 확인
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        public bool IsExists(string strInput)
        {
            bool r = false;

            List<BadWordModel> words = (new BadWordRepository()).GetBadWords();
            foreach (var word in words)
            {
                if (strInput.Contains(word.Word))
                {
                    return true;
                }
            }

            return r;
        }

    }
}