using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace CVGS_Iteration_1
{
    public partial class adminGameInventory : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string global_filepath;



        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                fillGameCommunityValues();
            }
            GridView1.DataBind();

        }

        //Go button
        protected void Button4_Click(object sender, EventArgs e)
        {
            getGamebyID();
        }


        //Add button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkIfGameExists())
            {
                Response.Write("<script>alert('Game already exists, try new Game ID');</script>");
            }
            else
            {
                validation.Text = "";
                if (TextBox1.Text == "" || TextBox2.Text == "" || TextBox3.Text == "" || ListBox1.SelectedValue == ""
                    || TextBox10.Text == "" || TextBox6.Text == "")
                {
                    //Response.Write("<script>alert('Please, add image and fill out ALL fields to add game');</script>");
                    if (TextBox1.Text == "")
                    {
                        validation.Text += "Please, enter the game id." + "\r\n";
                    }
                    else
                    {
                        validation.Text += "";
                    }
                    if (TextBox2.Text == "")
                    {
                        validation.Text += "Please, enter the Game Name." + "\r\n";
                    }
                    else
                    {
                        validation.Text += "";
                    }
                    if (TextBox3.Text == "")
                    {
                        validation.Text += "Please, enter the Publish Date." + "\r\n";
                    }
                    else
                    {
                        validation.Text += "";
                    }
                    if (ListBox1.SelectedValue == "")
                    {
                        validation.Text += "Please, select the Genre." + "\r\n";
                    }
                    else
                    {
                        validation.Text += "";
                    }
                    if (TextBox10.Text == "")
                    {
                        validation.Text += "Please, enter the Game Cost." + "\r\n";

                    }
                    else
                    {
                        validation.Text += "";
                    }
                    if (TextBox6.Text == "")
                    {
                        validation.Text += "Please, enter the Game Description.";

                    }
                    else
                    {
                        validation.Text += "";
                    }
                }
                else
                {
                    addNewGame();
                    validation.Text = "";
                }
            }
        }

        //Update button
        protected void Button3_Click(object sender, EventArgs e)
        {
            updateGamebyID();
        }


        //Delete btn
        protected void Button2_Click(object sender, EventArgs e)
        {
            deleteGameByID();
        }


        void deleteGameByID()
        {
            if (checkIfGameExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("DELETE FROM game_inventory WHERE game_id='" + TextBox1.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Game deleted successfully.');</script>");
                    clearform();
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Invalid Member ID.');</script>");
            }
        }



        //Update Game
        void updateGamebyID()
        {
            if (checkIfGameExists())
            {
                try
                {
                    string genres = "";
                    foreach (int i in ListBox1.GetSelectedIndices())
                    {
                        genres = genres + ListBox1.Items[i] + ",";
                    }
                    genres = genres.Remove(genres.Length - 1);

                    string filepath = "~/game_inventory/game";
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);

                    if (filename == "" || filename == null)
                    {
                        filepath = global_filepath;

                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                        filepath = "~/book_inventory/" + filename;
                    }


                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();

                    }
                    SqlCommand command = new SqlCommand("UPDATE game_inventory SET " +
                        "game_name=@game_name, community_name=@community_name, publish_date=@publish_date, " +
                        "genre=@genre, game_cost=@game_cost, game_des=@game_des, game_img=@game_img where game_id = '" + TextBox1.Text.Trim() + "'", con);

                    command.Parameters.AddWithValue("@game_name", TextBox2.Text.Trim());
                    command.Parameters.AddWithValue("@community_name", DropDownList2.SelectedItem.Value);
                    command.Parameters.AddWithValue("@publish_date", TextBox3.Text.Trim().Substring(0, 10));
                    command.Parameters.AddWithValue("@genre", genres);
                    command.Parameters.AddWithValue("@game_cost", TextBox10.Text.Trim());
                    command.Parameters.AddWithValue("@game_des", TextBox6.Text.Trim());
                    command.Parameters.AddWithValue("@game_img", filepath);

                    command.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    validation.Text += "";
                    validation.Text += "Game updated.";
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");

                }
            }
            else
            {
                Response.Write("<script>alert('Invalid game ID.');</script>");
            }
        }

        void getGamebyID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from game_inventory WHERE game_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0]["game_name"].ToString();
                    DropDownList2.SelectedValue = dt.Rows[0]["community_name"].ToString().Trim();
                    TextBox3.Text = dt.Rows[0]["publish_date"].ToString().Substring(0, 10);
                    TextBox10.Text = dt.Rows[0]["game_cost"].ToString();
                    TextBox6.Text = dt.Rows[0]["game_des"].ToString();


                    ListBox1.ClearSelection();
                    string[] genre = dt.Rows[0]["genre"].ToString().Trim().Split(',');
                    for (int i = 0; i < genre.Length; i++)
                    {
                        for (int j = 0; j < ListBox1.Items.Count; j++)
                        {
                            if (ListBox1.Items[j].ToString() == genre[i])
                            {
                                ListBox1.Items[j].Selected = true;
                            }
                        }
                    }

                    global_filepath = dt.Rows[0]["game_img"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Game ID');</script>");
                }
            }
            catch (Exception ex)
            {

            }
        }

        void fillGameCommunityValues()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT communityName from game_management_tbl;", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataValueField = "communityName";
                DropDownList2.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        bool checkIfGameExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from game_inventory where " +
                    "game_id='" + TextBox1.Text.Trim() + "'OR game_name='" + TextBox2.Text.Trim() + "';", con);
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

        void addNewGame()
        {
            try
            {
                string genres = "";
                foreach (int i in ListBox1.GetSelectedIndices())
                {
                    genres = genres + ListBox1.Items[i] + ",";
                }
                genres = genres.Remove(genres.Length - 1);


                string filepath = "~/game_inventory/game1.png";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("game_inventory/" + filename));
                filepath = "~/game_inventory/" + filename;



                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO game_inventory" +
                    "(game_id,game_name,community_name,publish_date,genre,game_cost,game_des,game_img) values" +
                    "(@game_id,@game_name,@community_name,@publish_date,@genre,@game_cost,@game_des,@game_img)", con);

                cmd.Parameters.AddWithValue("@game_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@game_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@community_name", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publish_date", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genres);
                cmd.Parameters.AddWithValue("@game_cost", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@game_des", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@game_img", filepath);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Game added successfully.');</script>");
                clearform();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        void clearform()
        {
            TextBox2.Text = "";
            TextBox10.Text = "";
            TextBox1.Text = "";
            TextBox3.Text = "";
            TextBox6.Text = "";
        }
    }
}