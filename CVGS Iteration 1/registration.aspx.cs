using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CVGS_Iteration_1
{
    public partial class signUp : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (checkEmployeeExists())
            {

                Response.Write("<script>alert('Employee already Exist with this Employee ID, try with other ID');</script>");
            }
            else
            {
                signUpEmployee();
            }
        }

        bool checkEmployeeExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from employee_table where " +
                    "employee_id='" + EmployeeID.Text.Trim() + "';", con);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        void signUpEmployee()
        {

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO employee_table(full_name,email,employee_id,password) " +
                       "values(@full_name,@email,@employee_id,@password)", con);
                cmd.Parameters.AddWithValue("@full_name", FullName.Text.Trim());
                cmd.Parameters.AddWithValue("@email", EmailID.Text.Trim());
                cmd.Parameters.AddWithValue("@password", EmployeePassword.Text.Trim());
                cmd.Parameters.AddWithValue("@employee_id", EmployeeID.Text.Trim());


                cmd.ExecuteNonQuery();
                con.Close();
                
                Response.Write("<script>alert('Employee Sign Up Successful. Go to Employee Login to Login');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }

}