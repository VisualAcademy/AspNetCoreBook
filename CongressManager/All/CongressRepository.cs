using Dapper;
using Hawaso.Standard;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace All
{
    public class CongressRepository : ICongressRepository
    {
        private SqlConnection db; 

        public CongressRepository()
        {
            db = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString); 
        }

        /// <summary>
        /// 데이터 저장, 수정, 답변 공통 메서드
        /// </summary>
        public int SaveOrUpdate(ArticleBase n, BoardWriteFormType formType)
        {
            int r = 0;

            // 파라미터 추가
            var p = new DynamicParameters();

            //[a] 공통
            p.Add("@Name", value: n.Name, dbType: DbType.String);
            p.Add("@Email", value: n.Email, dbType: DbType.String);
            p.Add("@Title", value: n.Title, dbType: DbType.String);
            p.Add("@Content", value: n.Content, dbType: DbType.String);
            p.Add("@Password", value: n.Password, dbType: DbType.String);
            p.Add("@Encoding", value: n.Encoding, dbType: DbType.String);
            p.Add("@Homepage", value: n.Homepage, dbType: DbType.String);
            p.Add("@FileName", value: n.FileName, dbType: DbType.String);
            p.Add("@FileSize", value: n.FileSize, dbType: DbType.Int32);

            p.Add("@Category", value: n.Category, dbType: DbType.String); // 추가

            switch (formType)
            {
                case BoardWriteFormType.Write:
                    //[b] 글쓰기 전용
                    p.Add("@PostIp", value: n.PostIp, dbType: DbType.String);

                    r = db.Execute("CongressesWrite", p, commandType: CommandType.StoredProcedure);
                    break;
                case BoardWriteFormType.Modify:
                    //[b] 수정하기 전용
                    p.Add("@ModifyIp", value: n.ModifyIp, dbType: DbType.String);
                    p.Add("@Id", value: n.Id, dbType: DbType.Int32);

                    r = db.Execute("CongressesModify", p, commandType: CommandType.StoredProcedure);
                    break;
                case BoardWriteFormType.Reply:
                    //[b] 답변쓰기 전용
                    p.Add("@PostIp", value: n.PostIp, dbType: DbType.String);
                    p.Add("@ParentNum", value: n.ParentNum, dbType: DbType.Int32);

                    r = db.Execute("CongressesReply", p, commandType: CommandType.StoredProcedure);
                    break;
            }

            return r;
        }

        /// <summary>
        /// 게시판 글쓰기
        /// </summary>
        public void Add(ArticleBase vm)
        {
            try
            {
                SaveOrUpdate(vm, BoardWriteFormType.Write);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message); // 로깅 처리 권장 영역
            }
        }

        /// <summary>
        /// 수정하기
        /// </summary>
        public int UpdateNote(ArticleBase vm)
        {
            int r = 0;
            try
            {
                r = SaveOrUpdate(vm, BoardWriteFormType.Modify);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return r;
        }

        /// <summary>
        /// 답변 글쓰기
        /// </summary>
        public void ReplyNote(ArticleBase vm)
        {
            try
            {
                SaveOrUpdate(vm, BoardWriteFormType.Reply);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }

        #region CongressesList 페이지
        /// <summary>
        /// 게시판 리스트 
        /// GetAll(), FindAll() 형태를 주로 사용
        /// 또는 GetCongresses(), GetComments() 형태도 많이 사용
        /// </summary>
        /// <param name="pageIndex">페이지 번호</param>
        public List<ArticleBase> GetAll(int pageIndex)
        {
            try
            {
                var parameters = new DynamicParameters(new { PageNumber = pageIndex + 1, PageSize = 10 });
                return db.Query<ArticleBase>("CongressesList", parameters,
                    commandType: CommandType.StoredProcedure).ToList();
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }
        public List<ArticleBase> GetAll(int pageIndex, int pageSize = 10)
        {
            try
            {
                var parameters = new DynamicParameters(new { PageNumber = pageIndex + 1, PageSize = pageSize });
                return db.Query<ArticleBase>("CongressesList", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }

        /// <summary>
        /// 검색 카운트
        /// </summary>
        public int GetCountBySearch(string searchField, string searchQuery)
        {
            try
            {
                return db.Query<int>("CongressesSearchCount", new
                {
                    SearchField = searchField,
                    SearchQuery = searchQuery
                },
                    commandType: CommandType.StoredProcedure)
                    .SingleOrDefault();

            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }

        /// <summary>
        /// Congresses 테이블의 모든 레코드 수
        /// </summary>
        public int GetCountAll()
        {
            try
            {
                return db.Query<int>(
                    "Select Count(*) From Congresses").SingleOrDefault();
            }
            catch (System.Exception)
            {
                return -1;
            }
        }
        
        /// <summary>
        /// 검색 결과 리스트
        /// </summary>
        public List<ArticleBase> GetSeachAll(
            int pageIndex, string searchField, string searchQuery)
        {
            var parameters = new DynamicParameters(new
            {
                Page = pageIndex,
                SearchField = searchField,
                SearchQuery = searchQuery
            });
            return db.Query<ArticleBase>("CongressesSearchList", parameters,
                commandType: CommandType.StoredProcedure).ToList();
        }
        #endregion

        /// <summary>
        /// Id에 해당하는 파일명 반환
        /// </summary>
        public string GetFileNameById(int id)
        {
            return
                db.Query<string>("Select FileName From Congresses Where Id = @Id",
                new { Id = id }).SingleOrDefault();
        }


        /// <summary>
        /// 다운 카운트 1 증가
        /// </summary>
        public void UpdateDownCount(string fileName)
        {
            db.Execute("Update Congresses Set DownCount = DownCount + 1 "
                + " Where FileName = @FileName", new { FileName = fileName });
        }
        public void UpdateDownCountById(int id)
        {
            var p = new DynamicParameters(new { Id = id });
            db.Execute("Update Congresses Set DownCount = DownCount + 1 "
                + " Where Id = @Id", p, commandType: CommandType.Text);
        }

        /// <summary>
        /// 상세 보기 
        /// </summary>
        public ArticleBase GetNoteById(int id)
        {
            var parameters = new DynamicParameters(new { Id = id });
            return db.Query<ArticleBase>("CongressesView", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
        }

        /// <summary>
        /// 삭제 
        /// </summary>
        public int DeleteNote(int id, string password)
        {
            return db.Execute("CongressesDelete", new { Id = id, Password = password }, commandType: CommandType.StoredProcedure);
        }

        /// <summary>
        /// 최근 올라온 사진 리스트 4개 출력
        /// </summary>
        public List<ArticleBase> GetNewPhotos()
        {
            string sql =
                "SELECT TOP 4 Id, Title, FileName, FileSize FROM Congresses "
                + " Where FileName Like '%.png' Or FileName Like '%.jpg' Or "
                + " FileName Like '%.jpeg' Or FileName Like '%.gif' "
                + " Order By Id Desc";
            return db.Query<ArticleBase>(sql).ToList();
        }

        /// <summary>
        /// 최근 글 리스트
        /// </summary>
        public List<ArticleBase> GetSummaryByCategory(string category)
        {
            string sql = "SELECT TOP 3 Id, Title, Name, PostDate, FileName, "
                + " FileSize, ReadCount, CommentCount, Step "
                + " FROM Congresses "
                + " Where Category = @Category Order By Id Desc";
            return db.Query<ArticleBase>(sql, new { Category = category }).ToList();
        }

        /// <summary>
        /// 최근 글 리스트 전체(최근 글 5개 리스트)
        /// </summary>
        public List<ArticleBase> GetRecentPosts()
        {
            string sql = "SELECT TOP 3 Id, Title, Name, PostDate FROM Congresses "
                + " Order By Id Desc";
            return db.Query<ArticleBase>(sql).ToList();
        }

        /// <summary>
        /// 최근 글 리스트 n개
        /// </summary>
        public List<ArticleBase> GetRecentPosts(int numberOfCongresses)
        {
            string sql =
                $"SELECT TOP {numberOfCongresses} Id, Title, Name, PostDate "
                + " FROM Congresses Order By Id Desc";
            return db.Query<ArticleBase>(sql).ToList();
        }

        /// <summary>
        /// 특정 게시물을 공지사항(NOTICE)으로 올리기
        /// </summary>
        public void Pinned(int id)
        {
            db.Execute(
                "Update Congresses Set Category = 'Notice' Where Id = @Id"
                , new { Id = id });
        }
    }
}
