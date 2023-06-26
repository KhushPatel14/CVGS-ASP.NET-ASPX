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
    public partial class userLogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        int loginAttempt;

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
                SqlCommand cmd = new SqlCommand("SELECT * FROM employee_table WHERE " +
                    "employee_id='" + EmployeeID.Text.Trim() + "' AND password ='" + EmployeePassword.Text.Trim() + "'", con);

                DataTable dataTable = new DataTable();
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Response.Write("<script>alert('" + dataReader.GetValue(2) + "');</script>");
                        Session["username"] = dataReader.GetValue(2).ToString();
                        Session["fullname"] = dataReader.GetValue(0).ToString();
                        Session["role"] = "user";
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
                validation.Text = "' " + ex.Message + " '";
            }
        }

        protected void SignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("registration.aspx");

        }
    }
}