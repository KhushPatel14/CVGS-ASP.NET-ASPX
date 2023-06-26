using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CVGS_Iteration_1
{
    public partial class viewGame : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["addgame"] = "false";
            Session["addgamewish"] = "false";
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            Session["addgamewish"] = "true";
            Session["addgame"] = "true";

            if (Session["role"] != null)
            {
                if (e.CommandName == "AddToWishList")
                {
                    Response.Redirect("wishlist.aspx?id=" + e.CommandArgument.ToString());
                }
                else if (e.CommandName == "Description")
                {
                    Response.Redirect("gameDetails.aspx?id=" + e.CommandArgument.ToString());
                }
                else if (e.CommandName == "AddToCart")
                {
                    Response.Redirect("addToCart.aspx?id=" + e.CommandArgument.ToString());
                }
            }
            else
            {
                if (e.CommandName == "Description")
                {
                    Response.Redirect("gameDetails.aspx?id=" + e.CommandArgument.ToString());
                }
                else
                {
                    Response.Redirect("userLogin.aspx");
                }
            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter sda = new SqlDataAdapter("select * from game_inventory where (game_name like '%" + TextBox1.Text+ "%') or (genre like '%"+TextBox1.Text+"%')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataList1.DataSourceID = null;
            DataList1.DataSource = dt;
            DataList1.DataBind();

        }
    }
}