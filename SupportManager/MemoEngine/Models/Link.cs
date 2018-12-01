using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace MemoEngine.Models
{
    public class LinkModel
    {
        public int      Id { get; set; }
        public int      PortalId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string   Title { get; set; }
        public string   Url { get; set; }
        public int      ViewOrder { get; set; }
        public string   Description { get; set; }
    }

    public class LinkRepository
    {
        /// <summary>
        /// 전체 링크 리스트 반환
        /// </summary>
        /// <returns></returns>
        public List<LinkModel> GetLinks()
        {
            DataTable dt = 
                (new DatabaseProviderFactory()).Create("ConnectionString")
                    .ExecuteDataSet(CommandType.Text, "Select * From Links Order By Id Asc").Tables[0];

            List<LinkModel> lst = new List<LinkModel>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lst.Add(new LinkModel { 
                    Id = Convert.ToInt32(dt.Rows[i][0]), 
                    PortalId = Convert.ToInt32(dt.Rows[i][1]), 
                    CreatedDate = Convert.ToDateTime(dt.Rows[i][2]),
                    Title = dt.Rows[i][3].ToString(), 
                    Url = dt.Rows[i]["Url"].ToString(), 
                    ViewOrder = Convert.ToInt32(dt.Rows[i]["ViewOrder"]),
                    Description = dt.Rows[i]["Description"].ToString()
                });
            }

            return lst;
        }

        /// <summary>
        /// AddLink : 링크 저장, EL를 사용한 저장(Insert) 패턴
        /// </summary>
        public int AddLink(LinkModel link)
        { 
            // SQL 구문
            string sql = "Insert Into Links(Title, Url, ViewOrder, Description) Values(@Title, @Url, @ViewOrder, @Description)";
            // 커넥션
            Database db = (new DatabaseProviderFactory()).Create("ConnectionString");
            // 커멘드
            DbCommand cmd = db.GetSqlStringCommand(sql);
            // 파라미터 추가
            db.AddInParameter(cmd, "@Title", DbType.String, link.Title);
            db.AddInParameter(cmd, "@Url", DbType.String, link.Url);
            db.AddInParameter(cmd, "@ViewOrder", DbType.Int32, link.ViewOrder);
            db.AddInParameter(cmd, "@Description", DbType.String, link.Description);
            // 실행
            int result = db.ExecuteNonQuery(cmd);
            // 결과값 반환
            return result; 
        }


        /// <summary>
        /// 단일 링크에 대한 정보를 반환
        /// </summary>
        /// <param name="id">LinkId</param>
        /// <returns>LinkModel 타입</returns>
        public LinkModel GetLink(int id)
        {
            LinkModel link = new LinkModel();

            // SQL 구문
            string sql = "Select * From Links Where Id = @Id";

            // Database 클래스의 인스턴스 생성
            Database db = (new DatabaseProviderFactory()).Create("ConnectionString");

            // DbCommand 생성
            DbCommand cmd = db.GetSqlStringCommand(sql);

            // 파라미터 추가
            db.AddInParameter(cmd, "@Id", DbType.Int32, id);

            // 실행 후 결과값 받기
            bool isnull = true;
            using (IDataReader objReader = db.ExecuteReader(cmd))
            {
                while (objReader.Read())
                {
                    isnull = false;
                    link.Id = objReader["Id"] != DBNull.Value ? Convert.ToInt32(objReader["Id"]) : 0;
                    link.PortalId = objReader["PortalId"] != DBNull.Value ? Convert.ToInt32(objReader["PortalId"]) : 0;
                    link.CreatedDate = objReader["CreatedDate"] != DBNull.Value ? Convert.ToDateTime(objReader["CreatedDate"]) : DateTime.MinValue;
                    link.Title = objReader["Title"] != DBNull.Value ? Convert.ToString(objReader["Title"]) : null;
                    link.Url = objReader["Url"] != DBNull.Value ? Convert.ToString(objReader["Url"]) : null;
                    link.ViewOrder = objReader["ViewOrder"] != DBNull.Value ? Convert.ToInt32(objReader["ViewOrder"]) : 0;
                    link.Description = objReader["Description"] != DBNull.Value ? Convert.ToString(objReader["Description"]) : null;
                }    
            }

            if (isnull)
            {
                return null;
            }

            return link; 
        }

        /// <summary>
        /// 링크 정보 업데이트
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public LinkModel UpdateLink(LinkModel link)
        {
            // SQL 구문
            string sql = "Update Links Set Title = @Title, Url = @Url, ViewOrder = @ViewOrder, Description = @Description Where Id = @Id";
            // 커넥션
            Database db = (new DatabaseProviderFactory()).Create("ConnectionString");
            // 커멘드
            DbCommand cmd = db.GetSqlStringCommand(sql);
            // 파라미터 추가
            db.AddInParameter(cmd, "@Title", DbType.String, link.Title);
            db.AddInParameter(cmd, "@Url", DbType.String, link.Url);
            db.AddInParameter(cmd, "@ViewOrder", DbType.Int32, link.ViewOrder);
            db.AddInParameter(cmd, "@Description", DbType.String, link.Description);

            db.AddInParameter(cmd, "@Id", DbType.Int32, link.Id);

            // 실행
            db.ExecuteNonQuery(cmd);

            return link;
        }

        /// <summary>
        /// 링크 삭제
        /// </summary>
        public int DeleteLink(int id)
        {
            // SQL 구문
            string sql = "Delete Links Where Id = @Id";
            // 커넥션
            Database db = (new DatabaseProviderFactory()).Create("ConnectionString");
            // 커멘드
            DbCommand cmd = db.GetSqlStringCommand(sql);
            // 파라미터 추가
            db.AddInParameter(cmd, "@Id", DbType.Int32, id);
            // 실행
            int result = db.ExecuteNonQuery(cmd);

            return result;
        }

    }
}