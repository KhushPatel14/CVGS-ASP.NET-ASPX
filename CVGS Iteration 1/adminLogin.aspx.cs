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
    public partial class adminLogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM admin_login_tbl WHERE " +
                    "username='" + AdminID.Text.Trim() + "' AND password ='" + AdminPassword.Text.Trim() + "'", con);

                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        //Response.Write("<script>alert('" + dataReader.GetValue(0) + "');</script>");
                        Session["username"] = dataReader.GetValue(0).ToString();
                        Session["role"] = "admin";
                    }
                    Response.Redirect("homepage.aspx");
                }
                else
                {
                    //Response.Write("<script>alert('Invalid credentials');</script>");
                    validation.Text = "Invalid credentials";
                }

            }
            catch (Exception ex)
            {
                //Response.Write("<script>alert('"+ ex.Message +"');</script>");
                validation.Text = "' " + ex.Message + " '";
            }
        }
    }
}