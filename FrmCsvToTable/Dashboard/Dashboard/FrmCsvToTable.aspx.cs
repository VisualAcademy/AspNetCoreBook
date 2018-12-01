using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace Dashboard
{
    public partial class FrmCsvToTable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCsvToTable_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(Server.MapPath("/SampleFiles/") + "\\SampleData.csv", Encoding.Default);
            while (!sr.EndOfStream)
            {
                // 콤마로 구분해서 한줄씩 읽어오기 
                string[] arr = sr.ReadLine().Split(',');

                // SampleData.sql 테이블에 저장
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                con.Open();

                string sql = 
                    $"Insert Into SampleData (Name, Num, IntData, DoubleData, FloatData, StringData) " +
                    $"Values (N'{arr[1]}', {arr[2]}, {arr[3]}, {arr[4]}, {arr[5]}, N'{arr[6]}')";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery(); 

                con.Close();
            }
        }
    }
}
