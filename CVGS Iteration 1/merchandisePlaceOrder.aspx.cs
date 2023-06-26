using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CVGS_Iteration_1
{
    public partial class merchandisePlaceOrder : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into card_details" + "(first_name,last_name,card_number,expiry_date,cvv) values (@first_name,@last_name,@card_number,@expiry_date,@cvv)", con);
            cmd.Parameters.AddWithValue("@first_name", TextBox1.Text);
            cmd.Parameters.AddWithValue("@last_name", TextBox2.Text);
            cmd.Parameters.AddWithValue("@card_number", TextBox3.Text);
            cmd.Parameters.AddWithValue("@expiry_date", TextBox4.Text);
            cmd.Parameters.AddWithValue("@cvv", TextBox5.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            //Response.Write("<script>alert('Payment successful');</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('Thank you!','Payment successful!','success')", true);
            //Session["address"] = TextBox6.Text;
            //Response.Redirect("thankyouMerchandise.aspx");
        }
    }
}