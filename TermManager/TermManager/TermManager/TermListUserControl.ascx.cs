using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TermManager.TermManager
{
    public partial class TermListUserControl : System.Web.UI.UserControl
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
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con.Open();

            SqlCommand cmd = new SqlCommand(
                "Select Id, Upper(Title) As Title, Description From TermViews Order By Id Desc", con);
            cmd.CommandType = System.Data.CommandType.Text;

            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd; 
            da.Fill(ds);

            this.ctlTermList.DataSource = ds; // 채우기 
            this.ctlTermList.DataBind(); // 실행

            con.Close(); 
        }
    }
}
