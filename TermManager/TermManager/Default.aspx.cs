using System;
using System.Configuration;
using System.Data.SqlClient;

namespace TermManager
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DisplayData();
            }
        }

        private void DisplayData()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "server=(localdb)\\mssqllocaldb;database=TermManager;Integrated Security=true;";
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select Distinct Id, Title, Description From Terms Where 1 = 1 Order By Title Desc";
            cmd.CommandType = System.Data.CommandType.Text;

            SqlDataReader dr = cmd.ExecuteReader();

            this.ctlTermList.DataSource = dr; // 데이터 소스 지정
            this.ctlTermList.DataBind(); // 바인딩(출력)

            con.Close();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = 
                "Insert Into Terms (Title, Description) Values(N'" + txtTerm.Text + "', N'" + txtDescription.Text + "') ";
            cmd.CommandType = System.Data.CommandType.Text;

            // 실행
            cmd.ExecuteNonQuery();

            Response.Redirect(Request.RawUrl); // 현재 페이지 다시 로드
        }
    }
}
