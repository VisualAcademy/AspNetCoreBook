using MemoEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MemoEngine.Modules.Link
{
    public partial class LinkModuleUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<LinkModel> lst = (new LinkRepository()).GetLinks();

            for (int i = 0; i < lst.Count; i++)
            {
                ctlFavorites.Items.Add(new ListItem(lst[i].Title, lst[i].Url));
            }

        }
    }
}