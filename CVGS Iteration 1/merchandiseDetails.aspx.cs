using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CVGS_Iteration_1
{
    public partial class merchandiseDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] == null)
                {
                    Response.Redirect("viewMerchandise.aspx");
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewMerchandise.aspx");
        }
    }
}