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
    public partial class merchandiseWishList : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Adding Games to gridview

                //Session["addgame"] = "false";\

                DataTable dt = new DataTable();
                DataRow dr;

                dt.Columns.Add("sno");
                dt.Columns.Add("pId");
                dt.Columns.Add("pImage");
                dt.Columns.Add("pName");
                dt.Columns.Add("pPrice");

                if (Request.QueryString["id"] != null)
                {
                    if (Session["merchandiseWishListItems"] == null)
                    {
                        dr = dt.NewRow();
                        SqlConnection con = new SqlConnection(strcon);

                        SqlCommand cmd = new SqlCommand("select * from admin_merchandise where product_id=" + Request.QueryString["id"], con);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        dr["sno"] = 1;
                        dr["pId"] = ds.Tables[0].Rows[0]["product_id"].ToString();
                        dr["pImage"] = ds.Tables[0].Rows[0]["product_img"].ToString();
                        dr["pName"] = ds.Tables[0].Rows[0]["product_name"].ToString();
                        dr["pPrice"] = ds.Tables[0].Rows[0]["product_cost"].ToString();

                        dt.Rows.Add(dr);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["merchandiseWishListItems"] = dt;

                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            var order1 = Session["Orderid"];
                            var sno1 = dt.Rows[i]["sno"];
                            var gid1 = dt.Rows[i]["pId"];
                            var gname1 = dt.Rows[i]["pName"];
                            var price1 = dt.Rows[i]["pPrice"];
                            var orderdate1 = Session["Orderdate"];

                            con.Open();
                            string query = $"insert into wishListDetailsMerchandise(orderid, sno, product_id, product_name, product_cost, order_date) values('{order1}', '{sno1}', '{gid1}', '{gname1}', '{price1}', '{orderdate1}')";
                            SqlCommand cmd1 = new SqlCommand(query, con);
                            cmd1.ExecuteNonQuery();
                            con.Close();
                        }

                        Response.Redirect("merchandiseWishList.aspx");
                    }
                    else
                    {
                        dt = (DataTable)Session["merchandiseWishListItems"];
                        int sr;
                        sr = dt.Rows.Count;

                        dr = dt.NewRow();
                        SqlConnection scon = new SqlConnection(strcon);


                        SqlDataAdapter da = new SqlDataAdapter("select * from admin_merchandise where product_id=" + Request.QueryString["id"], scon);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        dr["sno"] = sr + 1;
                        dr["pId"] = ds.Tables[0].Rows[0]["product_id"].ToString();
                        dr["pImage"] = ds.Tables[0].Rows[0]["product_img"].ToString();
                        dr["pName"] = ds.Tables[0].Rows[0]["product_name"].ToString();
                        dr["pPrice"] = ds.Tables[0].Rows[0]["product_cost"].ToString();

                        dt.Rows.Add(dr);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["merchandiseWishListItems"] = dt;

                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            var order1 = Session["Orderid"];
                            var sno1 = dt.Rows[i]["sno"];
                            var gid1 = dt.Rows[i]["pId"];
                            var gname1 = dt.Rows[i]["pName"];
                            var price1 = dt.Rows[i]["pPrice"];
                            var orderdate1 = Session["Orderdate"];

                            scon.Open();
                            string query = $"insert into wishListDetailsMerchandise(orderid, sno, product_id, product_name, product_cost, order_date) values('{order1}', '{sno1}', '{gid1}', '{gname1}', '{price1}', '{orderdate1}')";
                            SqlCommand cmd1 = new SqlCommand(query, scon);
                            cmd1.ExecuteNonQuery();
                            scon.Close();
                        }

                        Response.Redirect("merchandiseWishList.aspx");
                    }
                }
                else
                {
                    dt = (DataTable)Session["merchandiseWishListItems"];
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }


        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["merchandiseWishListItems"];

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
                    //Item Has Been Deleted From wishlist
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
            Session["merchandiseWishListItems"] = dt;
            Response.Redirect("merchandiseWishList.aspx");
        }

        public void ClearWishList()
        {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete from wishListDetailsMerchandise", con);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("merchandiseWishList.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["merchandiseWishListItems"] = null;
            ClearWishList();

        }
    }
}