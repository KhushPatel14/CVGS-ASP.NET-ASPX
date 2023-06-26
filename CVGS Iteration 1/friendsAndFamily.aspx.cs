using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CVGS_Iteration_1
{
    public partial class friendsAndFamily : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            getNameByID();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkIfNameExists())
            {
                validation.Text = "This Name is already exist. Add with different Email.";
            }
            else
            {
                if (nameFriendsFamily.Text == "" || emailFriendsFamily.Text == "")
                {
                    validation.Text = "Please, fill out ALL fields to add Name or Email in friends and family list.";
                }
                else
                {
                    addNewFriendsAndFamilyList();
                    EmailSender();

                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfNameExists())
            {
                deleteFriendsAndFamilyList();

            }
            else
            {
                validation.Text = "Email Address doesn't exit.";
            }
        }

        void getNameByID()
        {

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from friends_family_tbl where " +
                    "name='" + nameFriendsFamily.Text.Trim() + "';", con);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count >= 1)
                {
                    emailFriendsFamily.Text = dataTable.Rows[0][2].ToString();
                    validation.Text = "";
                }
                else
                {
                    validation.Text = "Invalid name.";
                }
            }
            catch (Exception ex)
            {
                validation.Text = "' " + ex.Message + " '";

            }
        }

        bool checkIfNameExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from friends_family_tbl where " +
                    "name='" + nameFriendsFamily.Text.Trim() + "';", con);
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
                validation.Text = "' " + ex.Message + " '";
                return false;
            }
        }


        void addNewFriendsAndFamilyList()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO friends_family_tbl(name, email) " +
                       "values(@name, @email)", con);
                cmd.Parameters.AddWithValue("@name", nameFriendsFamily.Text.Trim());
                cmd.Parameters.AddWithValue("@email", emailFriendsFamily.Text.Trim());


                cmd.ExecuteNonQuery();
                con.Close();
                validation.Text = "Name added successfully in friends and family list.";
                //clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                validation.Text = "' " + ex.Message + " '";
            }
        }

        void deleteFriendsAndFamilyList()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM friends_family_tbl WHERE name='" + nameFriendsFamily.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                validation.Text = "Name deleted successfully."; clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                validation.Text = "' " + ex.Message + " '";
            }
        }

        void clearForm()
        {
            nameFriendsFamily.Text = "";
            emailFriendsFamily.Text = "";
        }

        private void EmailSender()
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("neerajgadhavi8@gmail.com");
            mail.To.Add(new MailAddress(emailFriendsFamily.Text.ToString().Trim()));
            mail.Subject = "Friends & Family Email Confirmation";
            mail.Body = "<h4>" + "Friends & Family Email Confirmation " + " " + nameFriendsFamily.Text + "</h2>" + "<br><br>" + "Email: " + emailFriendsFamily.Text.Trim() + "<br>" + "Thank You";
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtp.Timeout = 600000;
            smtp.Host = "smtp.gmail.com";
            NetworkCredential SMTPUserInfo = new NetworkCredential("neerajgadhavi8@gmail.com", "vohghwlpknbntbpq");
            smtp.Credentials = SMTPUserInfo;
            smtp.Send(mail);

        }


    }
}