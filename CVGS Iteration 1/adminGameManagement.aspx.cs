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
    public partial class adminGameManagement : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        //add button click
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkIfGameCommunityExists())
            {
                //Response.Write("<script>alert('Game Community Id is already exist. Add with different " +
                //    "Community ID.');</script>");
                validation.Text = "Game Community Id is already exist. Add with different Community ID.";

            }
            else
            {
                if (CommunityName.Text == "" || GameCommunityID.Text == "")
                {
                    //Response.Write("<script>alert('Please, fill out ALL fields to add Game Community.');</script>");
                    validation.Text = "Please, fill out ALL fields to add Game Community.";
                }
                else
                {
                    addNewCommunity();
                }
            }
        }

        //update button click
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfGameCommunityExists())
            {
                updateNewCommunity();

            }
            else
            {
                //Response.Write("<script>alert('Game Community Id doesn't exit.');</script>");
                validation.Text = "Game Community Id doesn't exit.";

            }
        }

        //delete button click
        protected void Button4_Click(object sender, EventArgs e)
        {

            if (checkIfGameCommunityExists())
            {
                deleteGameCommunity();

            }
            else
            {
                //Response.Write("<script>alert('Game Community is deleted.');</script>");
                validation.Text = "Game Community is deleted.";
            }
        }

        //GO button click
        protected void Button1_Click(object sender, EventArgs e)
        {
            getCommunityByID();
        }

        void getCommunityByID()
        {

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from game_management_tbl where " +
                    "gameCommunityID='" + GameCommunityID.Text.Trim() + "';", con);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count >= 1)
                {
                    CommunityName.Text = dataTable.Rows[0][1].ToString();
                    validation.Text = "";
                }
                else
                {
                    //Response.Write("<script>alert('Invalid comunnity ID.');</script>");
                    validation.Text = "Invalid comunnity ID.";

                }
            }
            catch (Exception ex)
            {
                //Response.Write("<script>alert('" + ex.Message + "');</script>");
                validation.Text = "' " + ex.Message + " '";

            }
        }


        void deleteGameCommunity()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM game_management_tbl WHERE GameCommunityID='" + GameCommunityID.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                //Response.Write("<script>alert('Game Community updated successfully.');</script>");
                validation.Text = "Game Community deleted successfully."; clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                //Response.Write("<script>alert('" + ex.Message + "');</script>");
                validation.Text = "' " + ex.Message + " '";
            }
        }

        void updateNewCommunity()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE game_management_tbl SET CommunityName=@CommunityName WHERE " +
                    "GameCommunityID='" + GameCommunityID.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@CommunityName", CommunityName.Text.Trim());


                cmd.ExecuteNonQuery();
                con.Close();
                //Response.Write("<script>alert('Game Community updated successfully.');</script>");
                validation.Text = "Game Community updated successfully."; clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                //Response.Write("<script>alert('" + ex.Message + "');</script>");
                validation.Text = "' " + ex.Message + " '";
            }
        }

        void addNewCommunity()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO game_management_tbl(gameCommunityID, communityName) " +
                       "values(@gameCommunityID, @communityName)", con);
                cmd.Parameters.AddWithValue("@gameCommunityID", GameCommunityID.Text.Trim());
                cmd.Parameters.AddWithValue("@communityName", CommunityName.Text.Trim());


                cmd.ExecuteNonQuery();
                con.Close();
                //Response.Write("<script>alert('Game Community added successfully.');</script>");
                validation.Text = "Game Community added successfully.";
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                //Response.Write("<script>alert('" + ex.Message + "');</script>");
                validation.Text = "' " + ex.Message + " '";
            }
        }

        

        bool checkIfGameCommunityExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from game_management_tbl where " +
                    "gameCommunityID='" + GameCommunityID.Text.Trim() + "';", con);
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
                //Response.Write("<script>alert('" + ex.Message + "');</script>");
                validation.Text = "' " + ex.Message + " '";
                return false;
            }
        }

        void clearForm()
        {
            CommunityName.Text = "";
            GameCommunityID.Text = "";
        }
    }
}