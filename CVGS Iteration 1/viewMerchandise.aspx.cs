using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CVGS_Iteration_1
{
    public partial class viewMerchandise : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["addmerchandise"] = "false";
            Session["addmerchandisewish"] = "false";
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter sda = new SqlDataAdapter("select * from admin_merchandise where (product_name like '%" + TextBox1.Text + "%') or (related_game like '%" + TextBox1.Text + "%')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataList1.DataSourceID = null;
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            Session["addmerchandise"] = "true";
            Session["addmerchandisewish"] = "true";
            //if (Session["role"] != null)
            //{
            if (e.CommandName == "AddToWishList")
            {
                Response.Redirect("merchandiseWishList.aspx?id=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "Description")
            {
                Response.Redirect("merchandiseDetails.aspx?id=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "AddToCart")
            {
                Response.Redirect("merchandiseAddToCart.aspx?id=" + e.CommandArgument.ToString());
            }           
        }
    }
}