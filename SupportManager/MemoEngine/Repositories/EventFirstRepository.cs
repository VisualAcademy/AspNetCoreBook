using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MemoEngine.Repositories
{
    public class EventFirstRepository
    {
        public void AddEvent(string uid)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con.Open();

            SqlCommand cmd = new SqlCommand("Insert Events_First (UID) Values(" + uid + ")", con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            con.Close();
        }

        public int GetEventById(string uid)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con.Open();

            SqlCommand cmd = new SqlCommand("Select Id From Events_First Where UID = " + uid + " Order By Id Asc", con);
            cmd.CommandType = CommandType.Text;

            int result = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                result = dr.GetInt32(0);
            }
            con.Close();

            return result;
        }

        public IDataReader GetEventList()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con.Open();

            SqlCommand cmd = new SqlCommand("Select Top 100 e.Id, u.UID, u.DomainID, u.Name, u.Email From Events_First e Join Users u on e.UID = u.UID Order By e.Id Asc", con);
            cmd.CommandType = CommandType.Text;

            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}
