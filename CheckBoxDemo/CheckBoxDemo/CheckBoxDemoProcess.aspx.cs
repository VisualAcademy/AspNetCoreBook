using System;

namespace CheckBoxDemo
{
    public partial class CheckBoxDemoProcess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(Request["Name"]);
            Response.Write("<hr />");
            Response.Write(Request["IsWedding"]);
            Response.Write("<hr />");
            Response.Write(Request["IsCar"]);
            Response.Write("<hr />");
            Response.Write(Request["Hobby"]);
            Response.Write("<hr />");

            string[] hobby = Request.Form.GetValues("Hobby");
            for (int i = 0; i < hobby.Length; i++)
            {
                Response.Write($"{i + 1} : {hobby[i]}<br />");
            }
        }
    }
}
