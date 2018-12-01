using System;

namespace MemoEngine.Libraries
{

    public partial class StringLibraryTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string u = "a😎b😎c😎d😎e😎f😎a😎b😎c😎d😎e😎f😎";

            Response.Write(u + "<br />");

            Response.Write(Dul.StringLibrary.CutString(u, 6) + "<br />");

            Response.Write(Dul.StringLibrary.CutStringUnicode(u, 3) + "<br />");

            Response.Write(u.CutStringUnicode(7) + "<br />");

        }
    }
}