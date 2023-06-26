using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using com.itextpdf.text.pdf;
using System.IO;

namespace CVGS_Iteration_1
{
    public partial class gameDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] == null)
                {
                    Response.Redirect("viewGame.aspx");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewGame.aspx");
        }
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Button2_Click(object sender, EventArgs e)
        {
            addNewRating();
            ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Rating or feedback added successfully!','success')", true);
        }

        void addNewRating()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO game_ratings_tbl(ratings, feedback) values(@ratings, @feedback)", con);
                cmd.Parameters.AddWithValue("@ratings", RatingList.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@feedback", Feedback.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();
                

            }
            catch (Exception ex)
            {

            }
        }

    }
}