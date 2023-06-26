using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CVGS_Iteration_1
{
    public partial class userProfile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"].ToString() == "" || Session["username"] == null)
                {
                    Response.Write("<script>alert('Session Expired Login Again.');</script>");
                    Response.Redirect("userLogin.aspx");
                }
                else
                {
                    if (!Page.IsPostBack)
                    {
                        getUserProfileDetails();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Session Expired Login Again.');</script>");
                Response.Redirect("userLogin.aspx");

            }

            //if (sameCheckBox.Checked)
            //{
            //    ShippingAddress.Enabled = false;
            //    ShippingAddress.Visible = false;
            //}
            //else
            //{
            //    ShippingAddress.Enabled = true;
            //    ShippingAddress.Visible = true;
            //}
        }


        //Update Button 
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Session["username"].ToString() == "" || Session["username"] == null)
            {
                Response.Write("<script>alert('Session Expired Login Again.');</script>");
                Response.Redirect("userLogin.aspx");
            }
            else
            {
               updateUserProfileDetails();
                getUserProfileDetails();

            }
        }

        

        //User defined
        void updateUserProfileDetails()
        {
            string password = "";
            if (EmployeeNewPassword.Text.Trim() == "")
            {
                password = EmployeePassword.Text.Trim();
            }
            else
            {
                password = EmployeeNewPassword.Text.Trim();
            }
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("update employee_table set full_name=@full_name, email=@email," +
                    "employee_id=@employee_id, password=@password, gender=@gender, birthday=@birthday, preferences=@preferences," +
                    "game_category=@game_category, mailing_address=@mailing_address, shipping_address=@shipping_address, city=@city," +
                    "province=@province, postal_code=@postal_code, same_checkbox=@same_checkbox WHERE employee_id='" + Session["username"].ToString().Trim() + "'", con);

                cmd.Parameters.AddWithValue("@full_name", FullName.Text.Trim());
                cmd.Parameters.AddWithValue("@email", EmailID.Text.Trim());
                cmd.Parameters.AddWithValue("@employee_id", EmployeeID.Text.Trim());
                cmd.Parameters.AddWithValue("@password", password.ToString());
                cmd.Parameters.AddWithValue("@gender", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@birthday", Date.Text.Trim());
                cmd.Parameters.AddWithValue("@preferences", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@game_category", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@mailing_address", MailingAddress.Text.Trim());
                if (sameCheckBox.Checked)
                {
                    cmd.Parameters.AddWithValue("@shipping_address", MailingAddress.Text.Trim());
                }
                else
                {
                    cmd.Parameters.AddWithValue("@shipping_address", ShippingAddress.Text.Trim());
                }
                cmd.Parameters.AddWithValue("@city", City.Text.Trim());
                cmd.Parameters.AddWithValue("@province", Province.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@postal_code", Postal.Text.Trim());
                cmd.Parameters.AddWithValue("@same_checkbox", sameCheckBox.Checked);

                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {
                    validation.Text = "";
                    validation.Text += "Your Details Updated Successfully." + "\r\n";
                    validation.Focus();
                    getUserProfileDetails();
                }
                else
                {
                    validation.Text += "Invalid entry." + "\r\n";
                }
            }
            catch(Exception ex)
            {
                validation.Text += ex.Message + "\r\n";
            }
        }



        void getUserProfileDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from employee_table where " +
                    "employee_id='" + Session["username"].ToString() + "';", con);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                FullName.Text = dataTable.Rows[0]["full_name"].ToString();
                EmailID.Text = dataTable.Rows[0]["email"].ToString();
                EmployeeID.Text = dataTable.Rows[0]["employee_id"].ToString();
                EmployeePassword.Text = dataTable.Rows[0]["password"].ToString();
                DropDownList1.SelectedValue = dataTable.Rows[0]["gender"].ToString();
                Date.Text = dataTable.Rows[0]["birthday"].ToString().Substring(0, 10);
                DropDownList2.SelectedValue = dataTable.Rows[0]["preferences"].ToString();
                DropDownList3.SelectedValue = dataTable.Rows[0]["game_category"].ToString();
                MailingAddress.Text = dataTable.Rows[0]["mailing_address"].ToString();

                if (sameCheckBox.Checked)
                {
                    ShippingAddress.Text = dataTable.Rows[0]["mailing_address"].ToString();
                }
                else
                {
                    ShippingAddress.Text = dataTable.Rows[0]["shipping_address"].ToString();
                }
                City.Text = dataTable.Rows[0]["city"].ToString();
                Province.SelectedValue = dataTable.Rows[0]["province"].ToString();
                Postal.Text = dataTable.Rows[0]["postal_code"].ToString();
                Boolean sameCheckBox1 = Convert.ToBoolean( dataTable.Rows[0]["same_checkbox"]);
                sameCheckBox.Checked = Convert.ToBoolean(sameCheckBox1);

                /*if (sameCheckBox.c)
                {
                    ShippingAddress.Enabled = false;
                    ShippingAddress.Visible = false;
                }
                else
                {
                    ShippingAddress.Enabled = true;
                    ShippingAddress.Visible = true;
                }*/
            }
            catch (Exception ex)
            {
                validation.Text += ex.Message + "\r\n";
            }
        }

        /*protected void sameCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            getUserProfileDetails();
        }*/
    }
}