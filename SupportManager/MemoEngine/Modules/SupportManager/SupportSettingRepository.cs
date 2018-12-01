using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MemoEngine
{
    public class SupportSettingRepository
    {
        private IDbConnection db;
        public SupportSettingRepository()
        {
            db = new SqlConnection(
                ConfigurationManager.ConnectionStrings[
                    "ConnectionString"].ConnectionString);
        }

        public void AddOrUpdateSupportSetting(SupportSetting model)
        {
            //[1] 특정 게시판의 번호에 해당하는 설정 정보가 있는지 확인
            //[2] 이미 설정 정보가 있으면 설정 정보 업데이트
            //[3] 저장된 설정 정보가 없으면 처음으로 저장 
            string sql = @"
                Declare @CountItems Int 
                Select @CountItems = Count(*) From SupportSettings Where BoardName = @BoardName And BoardNum = @BoardNum

                If @CountItems > 0
                Begin
                    -- 업데이트
                    SET NOCOUNT OFF;
                    UPDATE [SupportSettings] SET [Remarks] = @Remarks, [CreationDate] = @CreationDate, [BoardName] = @BoardName, [BoardNum] = @BoardNum, [BoardTitle] = @BoardTitle, [BoardContent] = @BoardContent, [StartDate] = @StartDate, [EventDate] = @EventDate, [EndDate] = @EndDate, [MaxCount] = @MaxCount, [IsClosed] = @IsClosed WHERE BoardName = @BoardName And BoardNum = @BoardNum;
                    SELECT Id, Remarks, CreationDate, BoardName, BoardNum, BoardTitle, BoardContent, StartDate, EventDate, EndDate, MaxCount, IsClosed FROM SupportSettings WHERE BoardName = @BoardName And BoardNum = @BoardNum;
                End
                Else
                Begin
                    -- 인서트 
                    INSERT INTO [SupportSettings] ([Remarks], [CreationDate], [BoardName], [BoardNum], [BoardTitle], [BoardContent], [StartDate], [EventDate], [EndDate], [MaxCount], [IsClosed]) VALUES (@Remarks, @CreationDate, @BoardName, @BoardNum, @BoardTitle, @BoardContent, @StartDate, @EventDate, @EndDate, @MaxCount, @IsClosed);
                    SELECT Id, Remarks, CreationDate, BoardName, BoardNum, BoardTitle, BoardContent, StartDate, EventDate, EndDate, MaxCount, IsClosed FROM SupportSettings WHERE (Id = SCOPE_IDENTITY());
                End
            ";
            db.Execute(sql, model); 
        }

        /// <summary>
        /// 상세보기
        /// </summary>
        public SupportSetting GetById(string boardName, int boardNum)
        {
            string sql = @"
                Select Top 1 * 
                From SupportSettings 
                Where 
                    BoardName = @BoardName 
                    And 
                    BoardNum = @BoardNum 
                Order By Id Desc";
            return db.Query<SupportSetting>(
                sql, new
                {
                    BoardName = boardName,
                    BoardNum = boardNum
                }).SingleOrDefault(); 
        }

        /// <summary>
        /// 출력
        /// </summary>
        public List<SupportSetting> GetAll()
        {
            string sql = "Select * From SupportSettings Order By Id Desc";
            return db.Query<SupportSetting>(sql).ToList();
        }

        /// <summary>
        /// 이벤트 등록 시간이 지났는지 확인: 즉, 등록이 가능한지 확인
        /// </summary>
        public bool IsEventTime(string boardName, int boardNum)
        {
            string sql = @"
                Select DateDiff(second, EventDate, GetDate()) 
                From SupportSettings 
                    Where BoardName = @BoardName And BoardNum = @BoardNum 
            ";
            int count = db.Query<int>(sql, new {BoardName = boardName
                , BoardNum = boardNum }).SingleOrDefault();
            if (count > 0)
            {
                return true; 
            }
            else
            {
                return false;
            }
        }
    }
}
