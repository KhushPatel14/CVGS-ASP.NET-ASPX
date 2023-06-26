using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml.Linq;
//using System.Web.DynamicData;
//using System.Security.Cryptography.X509Certificates;

namespace CVGS_Iteration_1
{
    public partial class AddtoCart : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["buyitems"] == null)
                {
                    Button1.Enabled = false;
                }
                else
                {
                    Button1.Enabled = true;
                }

                // Adding Games to gridview
                Session["addgame"] = "false";
                DataTable dt = new DataTable();
                DataRow dr;

                dt.Columns.Add("sno");
                dt.Columns.Add("gId");
                dt.Columns.Add("gImage");
                dt.Columns.Add("gName");
                dt.Columns.Add("gPrice");

                if (Request.QueryString["id"] != null)
                {
                    if (Session["buyitems"] == null)
                    {
                        dr = dt.NewRow();
                        SqlConnection con = new SqlConnection(strcon);

                        SqlCommand cmd = new SqlCommand("select * from game_inventory where game_id=" + Request.QueryString["id"], con);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        dr["sno"] = 1;
                        dr["gId"] = ds.Tables[0].Rows[0]["game_id"].ToString();
                        dr["gImage"] = ds.Tables[0].Rows[0]["game_img"].ToString();
                        dr["gName"] = ds.Tables[0].Rows[0]["game_name"].ToString();
                        dr["gPrice"] = ds.Tables[0].Rows[0]["game_cost"].ToString();

                        dt.Rows.Add(dr);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["buyitems"] = dt;
                        Button1.Enabled = true;

                        GridView1.FooterRow.Cells[3].Text = "Total Amount: ";
                        GridView1.FooterRow.Cells[4].Text = grandtotal().ToString();
                        Response.Redirect("addToCart.aspx");
                    }
                    else
                    {
                        dt = (DataTable)Session["buyitems"];
                        int sr;
                        sr = dt.Rows.Count;

                        dr = dt.NewRow();
                        SqlConnection scon = new SqlConnection(strcon);


                        SqlDataAdapter da = new SqlDataAdapter("select * from game_inventory where game_id=" + Request.QueryString["id"], scon);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        dr["sno"] = sr + 1;
                        dr["gId"] = ds.Tables[0].Rows[0]["game_id"].ToString();
                        dr["gImage"] = ds.Tables[0].Rows[0]["game_img"].ToString();
                        dr["gName"] = ds.Tables[0].Rows[0]["game_name"].ToString();
                        dr["gPrice"] = ds.Tables[0].Rows[0]["game_cost"].ToString();

                        dt.Rows.Add(dr);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["buyitems"] = dt;
                        Button1.Enabled = true;

                        GridView1.FooterRow.Cells[3].Text = "Total Amount: ";
                        GridView1.FooterRow.Cells[4].Text = grandtotal().ToString();
                        Response.Redirect("addToCart.aspx");
                    }
                }
                else
                {
                    dt = (DataTable)Session["buyitems"];
                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                    if (GridView1.Rows.Count > 0)
                    {
                        GridView1.FooterRow.Cells[3].Text = "Total Amount: ";
                        GridView1.FooterRow.Cells[4].Text = grandtotal().ToString();
                    }
                }
            }
            string OrderDate = DateTime.Now.ToShortDateString();
            Session["Orderdate"] = OrderDate;
            orderid();
        }

        public int grandtotal()
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["buyitems"];
            int nrow = dt.Rows.Count;
            int i = 0;
            int totalprice = 0;
            while (i < nrow)
            {
                totalprice = totalprice + Convert.ToInt32(dt.Rows[i]["gPrice"].ToString());

                i = i + 1;
            }
            return totalprice;
        }

        public void orderid()
        {
            string alpha = "abCdefghIjklmNopqrStuvwXyz123456789";
            Random r = new Random();
            char[] myArray = new char[5];
            for (int i = 0; i < 5; i++)
            {
                myArray[i] = alpha[(int)(35 * r.NextDouble())];
            }
            string orderid;
            orderid = "Order_Id: " + DateTime.Now.Hour.ToString() + DateTime.Now.Second.ToString() +
                DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() +
                new string(myArray)
                + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();

            Session["Orderid"] = orderid;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["buyitems"];


            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                int sr;
                int sr1;
                string qdata;
                string dtdata;
                sr = Convert.ToInt32(dt.Rows[i]["sno"].ToString());
                TableCell cell = GridView1.Rows[e.RowIndex].Cells[0];
                qdata = cell.Text;
                dtdata = sr.ToString();
                sr1 = Convert.ToInt32(qdata);
                if (sr == sr1)
                {
                    dt.Rows[i].Delete();
                    dt.AcceptChanges();
                    //Item Has Been Deleted From Shopping Cart
                    break;
                }
            }

            for (int i = 0; i <= dt.Rows.Count; i++)
            {
                if (i >= 1)
                {
                    dt.Rows[i - 1]["sno"] = i.ToString();
                    dt.AcceptChanges();
                }

            }


            Session["buyitems"] = dt;
            Response.Redirect("addToCart.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt;
            dt = (DataTable)Session["buyitems"];
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                var order1 = Session["Orderid"];
                var sno1 = dt.Rows[i]["sno"];
                var gid1 = dt.Rows[i]["gId"];
                var gname1 = dt.Rows[i]["gName"];
                var price1 = dt.Rows[i]["gPrice"];
                var orderdate1 = Session["Orderdate"];

                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                string query = $"insert into game_cart_details_tbl(orderid, sno, game_id, game_name, game_cost, order_date) values('{order1}', '{sno1}', '{gid1}', '{gname1}', '{price1}', '{orderdate1}')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            if (GridView1.Rows.Count.ToString() == "0")
            {
                Response.Write("<script>alert('Your Cart is Empty. You cannot place an Order');</script>");
            }
            else
            {
                Response.Redirect("PlaceOrder.aspx");
            }
        }

        public void ClearCart()
        {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete from game_cart_details_tbl", con);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("addToCart.aspx");
        }

        protected void Clear_Button_Cart(object sender, EventArgs e)
        {
            Session["buyitems"] = null;
            ClearCart();

        }
    }
}