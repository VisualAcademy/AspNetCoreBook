using System;
using System.Data;
using System.Data.SqlClient;
using Reply.Entity;

namespace Reply.Dsl
{
    public class ReplyDac
    {
        private string _ConnectionString; // 필드 : DB연결문자열 저장
        public ReplyDac()
        {
            _ConnectionString =
                System.Configuration.ConfigurationManager.ConnectionStrings[
                    "ConnectionString"].ConnectionString;
        }

        #region Public Methods

        #region 입력 : InsertReply()
        public int InsertReply(ReplyEntity re)
        {
            SqlConnection con = new SqlConnection(_ConnectionString);

            SqlCommand cmd = new SqlCommand("WriteReply", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", re.Name);
            cmd.Parameters.AddWithValue("@Email", re.Email);
            cmd.Parameters.AddWithValue("@Title", re.Title);
            cmd.Parameters.AddWithValue("@PostIp", re.PostIP);
            cmd.Parameters.AddWithValue("@Content", re.Content);
            cmd.Parameters.AddWithValue("@Password", re.Password);
            cmd.Parameters.AddWithValue("@Encoding", re.Encoding);
            cmd.Parameters.AddWithValue("@Homepage", re.Homepage);

            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();

            return result;
        }
        #endregion

        #region 출력 : SelectReply()
        public DataSet SelectReply()
        {
            SqlConnection conn = new SqlConnection(_ConnectionString);

            SqlCommand cmd = new SqlCommand("ListReply", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();

            da.Fill(ds, "Reply");

            return ds;
        }
        #endregion

        #region 상세
        public IDataReader SelectReplyByNum(int num)
        {
            SqlConnection conn = new SqlConnection(_ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("ViewReply", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Num", num);

            return cmd.ExecuteReader(); // Close() -> uisng () {} 사용해서 Close() 처리 필요
        }
        #endregion

        #region 수정
        public int UpdateReply(ReplyEntity entity)
        {
            SqlConnection con = new SqlConnection(_ConnectionString);

            SqlCommand cmd = new SqlCommand("ModifyReply", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", entity.Name);
            cmd.Parameters.AddWithValue("@Email", entity.Email);
            cmd.Parameters.AddWithValue("@Title", entity.Title);
            cmd.Parameters.AddWithValue("@ModifyIp", entity.ModifyIP);
            cmd.Parameters.AddWithValue("@Content", entity.Content);
            cmd.Parameters.AddWithValue("@Encoding", entity.Encoding);
            cmd.Parameters.AddWithValue("@Homepage", entity.Homepage);
            cmd.Parameters.AddWithValue("@Password", entity.Password);
            cmd.Parameters.AddWithValue("@Num", entity.Num);

            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();

            return result;
        }
        #endregion

        #region 삭제
        public int DeleteReply(int num, string password)
        {
            SqlConnection con = new SqlConnection(_ConnectionString);
            SqlCommand cmd = new SqlCommand("DeleteReply", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddWithValue("@Num", num);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        #endregion

        #region 검색
        public DataTable SelectReplyByWord(string searchField, string searchQuery)
        {
            SqlConnection conn = new SqlConnection(_ConnectionString);

            SqlCommand cmd = new SqlCommand("SearchReply", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SearchField", searchField);
            cmd.Parameters.AddWithValue("@SearchQuery", searchQuery);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            
            DataSet ds = new DataSet(); 

            da.Fill(ds, "Reply");

            return ds.Tables[0]; // DataTable로 반환
        } 
        #endregion

        #region 답변 : InsertReply()
        public int InsertReply(ReplyEntity re, int num)
        {
            SqlConnection con = new SqlConnection(_ConnectionString);

            SqlCommand cmd = new SqlCommand("ReplyReply", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", re.Name);
            cmd.Parameters.AddWithValue("@Email", re.Email);
            cmd.Parameters.AddWithValue("@Title", re.Title);
            cmd.Parameters.AddWithValue("@PostIp", re.PostIP);
            cmd.Parameters.AddWithValue("@Content", re.Content);
            cmd.Parameters.AddWithValue("@Password", re.Password);
            cmd.Parameters.AddWithValue("@Encoding", re.Encoding);
            cmd.Parameters.AddWithValue("@Homepage", re.Homepage);
            cmd.Parameters.AddWithValue("@ParentNum", num);

            con.Open();
            int result = cmd.ExecuteNonQuery(); 
            con.Close();

            return result;
        }
        #endregion

        #endregion
    }
}
