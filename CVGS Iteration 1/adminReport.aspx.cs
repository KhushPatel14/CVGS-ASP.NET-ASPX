using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CVGS_Iteration_1
{
    public partial class adminReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminAllGamesDownload.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminAllGameDetailsDownload.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminMemberListDownload.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminMemberDetailListDownload.aspx");
        }
    }
}