using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CVGS_Iteration_1
{
    public partial class upcomingEvents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (Session["role"] != null)
            {
                if (e.CommandName == "register")
                {
                    Response.Redirect("ThanksPageUpcomingEvents.aspx");
                }
            }
            else
            {
                Response.Redirect("userLogin.aspx");
            }
        }
    }
}