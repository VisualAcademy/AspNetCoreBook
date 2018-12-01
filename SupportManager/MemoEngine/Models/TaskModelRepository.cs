using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace MemoEngine.Models
{
    public class TaskModelRepository
    {
        private SqlConnection db;

        public TaskModelRepository()
        {
            db = new SqlConnection(
                ConfigurationManager.ConnectionStrings[
                    "ConnectionString"].ConnectionString);
        }

        /// <summary>
        /// 할일 저장
        /// </summary>
        public void AddTask(TaskModel model)
        {
            this.db.Execute(
                @"
                    Insert Into Tasks (Title, IsCompleted) 
                    Values (@Title, Cast('false' As Bit))
                ", model);
        }

        /// <summary>
        /// 할일 리스트
        /// </summary>
        public List<TaskModel> GetTasks()
        {
            return this.db.Query<TaskModel>(
                "Select * From Tasks Order By Id Desc").ToList();
        }

        /// <summary>
        /// 할일 완료 처리 또는 되돌리기
        /// </summary>
        public void CompleteTask(int id)
        {
            db.Execute(@"Update Tasks Set IsCompleted = ~IsCompleted 
                Where Id = @Id", new { id });
        }
    }
}