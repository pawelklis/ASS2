using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASS2WEB
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void btnWork_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }

        protected void btnsortprogrems_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/sortprograms.aspx");
        }

        protected void btndirections_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/directions.aspx");
        }

        protected void btnstats_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/stats.aspx");
        }
    }
}