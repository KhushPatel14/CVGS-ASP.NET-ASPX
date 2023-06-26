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
    public partial class adminReviewPage : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                string ID = row.Cells[0].Text;
                RadioButton radioButton1 = (row.Cells[2].FindControl("approve") as RadioButton);
                RadioButton radioButton2 = (row.Cells[2].FindControl("decline") as RadioButton);
                string status;


                if (radioButton1.Checked)
                {
                    status = radioButton1.Text;
                }
                else
                {
                    status = radioButton2.Text;
                }

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE game_ratings_tbl SET feedback_status = @feedback_status WHERE ID = @ID", con);
                cmd.Parameters.AddWithValue("@feedback_status", status);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            Response.Write("<script>alert('Status updated successfully.')</script>");
        }
    }
}