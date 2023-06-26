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

namespace CVGS_Iteration_1
{
    public partial class merchandiseAddToCart : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["buymerchandises"] == null)
                {
                    Button1.Enabled = false;
                }
                else
                {
                    Button1.Enabled = true;
                }

                // Adding to gridview
                Session["addmerchandise"] = "false";
                DataTable dt = new DataTable();
                DataRow dr;

                dt.Columns.Add("sno");
                dt.Columns.Add("pImage");
                dt.Columns.Add("pName");
                dt.Columns.Add("pPrice");

                if (Request.QueryString["id"] != null)
                {
                    if (Session["buymerchandises"] == null)
                    {
                        dr = dt.NewRow();
                        SqlConnection con = new SqlConnection(strcon);

                        SqlCommand cmd = new SqlCommand("select * from admin_merchandise where product_id=" + Request.QueryString["id"], con);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        dr["sno"] = 1;
                        dr["pImage"] = ds.Tables[0].Rows[0]["product_img"].ToString();
                        dr["pName"] = ds.Tables[0].Rows[0]["product_name"].ToString();
                        dr["pPrice"] = ds.Tables[0].Rows[0]["product_cost"].ToString();

                        dt.Rows.Add(dr);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["buymerchandises"] = dt;
                        Button1.Enabled = true;

                        GridView1.FooterRow.Cells[3].Text = "Total Amount: ";
                        GridView1.FooterRow.Cells[4].Text = grandtotal().ToString();
                        Response.Redirect("merchandiseAddToCart.aspx");
                    }
                    else
                    {
                        dt = (DataTable)Session["buymerchandises"];
                        int sr;
                        sr = dt.Rows.Count;

                        dr = dt.NewRow();
                        SqlConnection scon = new SqlConnection(strcon);


                        SqlDataAdapter da = new SqlDataAdapter("select * from admin_merchandise where product_id=" + Request.QueryString["id"], scon);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        dr["sno"] = sr + 1;
                        dr["pImage"] = ds.Tables[0].Rows[0]["product_img"].ToString();
                        dr["pName"] = ds.Tables[0].Rows[0]["product_name"].ToString();
                        dr["pPrice"] = ds.Tables[0].Rows[0]["product_cost"].ToString();

                        dt.Rows.Add(dr);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["buymerchandises"] = dt;
                        Button1.Enabled = true;

                        GridView1.FooterRow.Cells[3].Text = "Total Amount: ";
                        GridView1.FooterRow.Cells[4].Text = grandtotal().ToString();
                        Response.Redirect("merchandiseAddToCart.aspx");
                    }
                }
                else
                {
                    dt = (DataTable)Session["buymerchandises"];
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
            dt = (DataTable)Session["buymerchandises"];
            int nrow = dt.Rows.Count;
            int i = 0;
            int totalprice = 0;
            while (i < nrow)
            {
                totalprice = totalprice + Convert.ToInt32(dt.Rows[i]["pPrice"].ToString());

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

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt;
            dt = (DataTable)Session["buymerchandises"];
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                var order1 = Session["Orderid"];
                var sno1 = dt.Rows[i]["sno"];
                var pname1 = dt.Rows[i]["pName"];
                var price1 = dt.Rows[i]["pPrice"];
                var orderdate1 = Session["Orderdate"];

                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                string query = $"insert into merchandise_cart_details_tbl(orderid,sno, product_name, product_cost, order_date) values('{order1}', '{sno1}', '{pname1}', '{price1}', '{orderdate1}')";
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
                Response.Redirect("merchandisePlaceOrder.aspx");
            }
        }

        protected void Clear_Button_Cart(object sender, EventArgs e)
        {
            Session["buymerchandises"] = null;
            ClearCart();
        }

        public void ClearCart()
        {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete from merchandise_cart_details_tbl", con);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("merchandiseAddToCart.aspx");
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["buymerchandises"];


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


            Session["buymerchandises"] = dt;
            Response.Redirect("merchandiseAddToCart.aspx");
        }
    }
}