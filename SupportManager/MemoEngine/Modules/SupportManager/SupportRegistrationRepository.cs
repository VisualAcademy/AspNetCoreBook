using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MemoEngine
{
    public class SupportRegistrationRepository
    {
        private IDbConnection db;
        public SupportRegistrationRepository()
        {
            db = new SqlConnection(
                ConfigurationManager.ConnectionStrings[
                    "ConnectionString"].ConnectionString);
        }

        /// <summary>
        /// 입력
        /// </summary>
        public SupportRegistration Add(SupportRegistration model)
        {
            var sql =
                @"
                    INSERT INTO [dbo].[SupportRegistrations]
                           ([SupportSettingId]
                           ,[BoardName]
                           ,[BoardNum]
                           ,[BoardTitle]
                           ,[CreationDate]
                           ,[UserId]
                           ,[Username]
                           ,[NickName]
                           ,[Name]
                           ,[Mobile]
                           ,[Company]
                           ,[Homepage]
                           ,[SupportDate]
                           ,[Recipient]
                           ,[Product])
                     VALUES
                           (@SupportSettingId
                           ,@BoardName
                           ,@BoardNum
                           ,@BoardTitle
                           ,@CreationDate
                           ,@UserId
                           ,@Username
                           ,@NickName
                           ,@Name
                           ,@Mobile
                           ,@Company
                           ,@Homepage
                           ,@SupportDate
                           ,@Recipient
                           ,@Product); 
                "
                +
                "Select Cast(SCOPE_IDENTITY() As Int);";
            var id = db.Query<int>(sql, model).Single();
            model.Id = id;
            return model; 
        }


        public bool IsRegisteredUser(
            string boardName, int boardNum, string username)
        {
            var sqlCount = @"
                Select Count(*) From SupportRegistrations 
                Where 
                    BoardName = @BoardName 
                    And BoardNum = @BoardNum 
                    And Username = @Username";
            var count = db.Query<int>(sqlCount, new {
                BoardName = boardName, BoardNum = boardNum, Username = username
            }).Single();

            if (count > 0)
            {
                return true; // 이미 등록한(신청한) 사용자임
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 서포트 등록 취소
        /// </summary>
        public void RemoveSupportRegistration(
            string boardName, int boardNum, string username)
        {
            var sqlDelete = @"
                Delete SupportRegistrations 
                Where 
                    BoardName = @BoardName 
                    And 
                    BoardNum = @BoardNum 
                    And 
                    Username = @Username";
            var count = db.Execute(sqlDelete, new {
                    BoardName = boardName,
                    BoardNum = boardNum,
                    Username = username
                });
        }

        public bool IsFinishedSupportRegistration(string boardName, int boardNum)
        {
            var sqlCount1 = @"
                Select MaxCount From SupportSettings 
                Where 
                    BoardName = @BoardName And BoardNum = @BoardNum";
            var count1 = db.Query<int>(sqlCount1, new {
                    BoardName = boardName, BoardNum = boardNum
                }).SingleOrDefault(); // SingleOrDefault 사용한 것 주의

            var sqlCount2 = @"
                Select Count(*) From SupportRegistrations 
                Where 
                    BoardName = @BoardName And BoardNum = @BoardNum";
            var count2 = db.Query<int>(sqlCount2, new {
                    BoardName = boardName, BoardNum = boardNum
                }).Single();

            // 이벤트에 등록된 숫자가 같거나, 더 많으면 마감된 이벤트로 봄
            if (count1 != 0 && count1 <= count2)
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// 특정 게시판에 해당하는 서포트 등록자 리스트 
        /// </summary>
        public List<SupportRegistration> GetAll(string boardName, int boardNum)
        {
            string sql = @"
                Select * From SupportRegistrations 
                Where 
                    BoardName = @BoardName 
                    And 
                    BoardNum = @BoardNum 
                Order By Id Desc";
            return db.Query<SupportRegistration>(
                sql, new {
                    BoardName = boardName, BoardNum = boardNum }).ToList();
        }


        /// <summary>
        /// 출력
        /// </summary>
        public List<SupportRegistration> GetAll()
        {
            string sql = "Select * From SupportRegistrations Order By Id Desc";
            return db.Query<SupportRegistration>(sql).ToList();
        }

        /// <summary>
        /// 상세
        /// </summary>
        public SupportRegistration GetById(
            string boardName, int boardNum, string username)
        {
            string sql = @"
                Select Top 1 * 
                From SupportRegistrations 
                Where 
                    BoardName = @BoardName 
                    And 
                    BoardNum = @BoardNum 
                    And 
                    Username = @Username 
                Order By Id Desc";
            return db.Query<SupportRegistration>(
                sql, new {
                    BoardName = boardName,
                    BoardNum = boardNum,
                    Username = username }).SingleOrDefault();
        }

        /// <summary>
        /// 수정
        /// </summary>
        public SupportRegistration Update(SupportRegistration model)
        {
            var sql = @"
                    Update SupportRegistrations                  
                    SET 
                        [SupportSettingId] = @SupportSettingId
                        ,[BoardName] = @BoardName
                        ,[BoardNum] = @BoardNum
                        ,[BoardTitle] = @BoardTitle
                        ,[CreationDate] = @CreationDate
                        ,[UserId] = @UserId
                        ,[Username] = @Username
                        ,[NickName] = @NickName
                        ,[Name] = @Name
                        ,[Mobile] = @Mobile
                        ,[Company] = @Company
                        ,[Homepage] = @Homepage
                        ,[SupportDate] = @SupportDate
                        ,[Recipient] = @Recipient
                        ,[Product] = @Product
                    Where 
                        BoardName = @BoardName
                        And
                        BoardNum = @BoardNum
                        And
                        Username = @Username";
            db.Execute(sql, model);
            return model;
        }

        /// <summary>
        /// 삭제
        /// </summary>
        public void Remove(string boardName, int boardNum, string username)
        {
            string sql = @"
                Delete SupportRegistrations 
                Where 
                    BoardName = @BoardName 
                    And 
                    BoardNum = @BoardNum 
                    And 
                    Username = @Username";
            db.Execute(sql, new
            {
                BoardName = boardName,
                BoardNum = boardNum,
                Username = username
            });
        }
    }
}
