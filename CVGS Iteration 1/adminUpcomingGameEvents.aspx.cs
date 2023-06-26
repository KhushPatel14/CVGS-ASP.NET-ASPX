using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace CVGS_Iteration_1
{
    public partial class adminGameEvents : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkIfGameEventExists())
            {
/*                Response.Write("<script>alert('Game Event Id is already exist. Add with different Event ID.');</script>");
*/                validation.Text += "Game Event Id is already exist. Add with different Event ID" + "\r\n";

            }
            else
            {
                validation.Text = "";
                if (EventID.Text == "" || EventDate.Text == "" || EventName.Text == "" || EventDescription.Text == "")
                {
                    //Response.Write("<script>alert('Please, ADD all fields to add an event!');</script>");
                    if (EventID.Text == "")
                    {
                        validation.Text += "Please, enter the Event ID." + "\r\n";
                    }
                    else
                    {
                        validation.Text += "";
                    }
                    if (EventDate.Text == "")
                    {
                        validation.Text += "Please, enter the Event Date." + "\r\n";
                    }
                    else
                    {
                        validation.Text += "";
                    }
                    if (EventName.Text == "")
                    {
                        validation.Text += "Please, enter the Event Name." + "\r\n";
                    }
                    else
                    {
                        validation.Text += "";
                    }
                    if (EventDescription.Text == "")
                    {
                        validation.Text += "Please, enter the Event Description." + "\r\n";
                    }
                    else
                    {
                        validation.Text += "";
                    }
                }
                else
                {
                    addNewEvent();
                    validation.Text = "";

                }
            }
        }

        bool checkIfGameEventExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from upcoming_events where " +
                    "event_id='" + EventID.Text.Trim() + "';", con);
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
/*                Response.Write("<script>alert('" + ex.Message + "');</script>");
*/                validation.Text += ex.Message;
                return false;
            }
        }

        void addNewEvent()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO upcoming_events(event_id, event_name,event_date,event_description) " +
                       "values(@event_id, @event_name, @event_date, @event_description)", con);
                cmd.Parameters.AddWithValue("@event_id", EventID.Text.Trim());
                cmd.Parameters.AddWithValue("@event_name", EventName.Text.Trim());
                cmd.Parameters.AddWithValue("@event_date", EventDate.Text.Trim());
                cmd.Parameters.AddWithValue("@event_description", EventDescription.Text.Trim());


                cmd.ExecuteNonQuery();
                con.Close();
                validation.Text += "Game Event added successfully.";
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                validation.Text += ex.Message;
            }
        }

        void clearForm()
        {
            EventID.Text = "";
            EventName.Text = "";
            EventDate.Text = "";
            EventDescription.Text = "";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfGameEventExists())
            {
                deleteGameEvent();

            }
            else
            {
                validation.Text += "Game event is deleted";

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            getEventByID();
        }


        void deleteGameEvent()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM upcoming_events WHERE event_id='" + EventID.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                validation.Text += "Event deleted successfully";
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                validation.Text += ex.Message;
            }
        }

        void getEventByID()
        {

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from upcoming_events where " +
                    "event_id='" + EventID.Text.Trim() + "';", con);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count >= 1)
                {
                    EventName.Text = dataTable.Rows[0][1].ToString();
                    EventDate.Text = dataTable.Rows[0][2].ToString();
                    EventDescription.Text = dataTable.Rows[0][3].ToString().Substring(0, 10);
                    validation.Text = "";
                }
                else
                {
                    validation.Text = "";
                    validation.Text += "Invalid id!";

                }
            }
            catch (Exception ex)
            {
                validation.Text += ex.Message;

            }
        }
    }
}