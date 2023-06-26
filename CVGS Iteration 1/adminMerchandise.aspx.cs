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
    public partial class adminMerchandise : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string global_filepath;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillGameValues();
            }
            GridView1.DataBind();
        }

        void fillGameValues()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT game_name from game_inventory;", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataValueField = "game_name";
                DropDownList2.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        // Add
        protected void Button1_Click(object sender, EventArgs e)
        {
            validation.Text = "";
            if (TextBox1.Text == "" || TextBox2.Text == "" || TextBox3.Text == "" || TextBox4.Text == "" )
            {
                if (TextBox4.Text == "")
                {
                    validation.Text += "Please, enter product's name." + "\r\n";

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
                //Response.Write("<script>alert('Please, add image and fill out ALL fields to add game');</script>");
                if (TextBox1.Text == "")
                {
                    validation.Text += "Please, enter Product cost." + "\r\n";
                }
                else
                {
                    validation.Text += "";
                }
                if (TextBox2.Text == "")
                {
                    validation.Text += "Please, enter product's description." + "\r\n";
                }
                else
                {
                    validation.Text += "";
                }
                
                
                
                
            }
            else
            {
                addNewMerchandise();
                validation.Text = "";
            }

        }

        // Update
        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        // Delete
        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        void addNewMerchandise()
        {
            try
            {
                string filepath = "~/game_merchandise/Merchandise.png";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("game_merchandise/" + filename));
                filepath = "~/game_merchandise/" + filename;



                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO admin_merchandise" +
                    "(related_game,publish_date,product_name,product_cost,product_description,product_img) values" +
                    "(@related_game,@publish_date,@product_name,@product_cost,@product_description,@product_img)", con);

                cmd.Parameters.AddWithValue("@related_game", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publish_date", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@product_name", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@product_cost", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@product_description", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@product_img", filepath);

                cmd.ExecuteNonQuery();
                con.Close();
                //Response.Write("<script>alert('Item added successfully.');</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('Good job!','Item added successfully!','success')", true);
                //clearform();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {

            }
        }
    }
}