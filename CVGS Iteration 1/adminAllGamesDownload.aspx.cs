using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Web.WebSockets;
using System.Configuration;

namespace CVGS_Iteration_1
{
    public partial class adminAllGamesDownload : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string Orderid = Session["role"].ToString();
            Label1.Text = Orderid;
            //findorderdate(Label2.Text);
            //string Name = Session["Name"].ToString();
            //Label3.Text = Name;
            showgrid(Label1.Text);
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }

        [Obsolete]
        protected void Button1_Click(object sender, EventArgs e)
        {
            exportpdf();
        }

        [Obsolete]
        private void exportpdf()
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=AllGame.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            Panel1.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }

        //private void findorderdate(String Orderid)
        //{
        //    SqlConnection con = new SqlConnection(strcon);
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("select * from game_inventory where role='" + Label1.Text + "'");
        //    cmd.Connection = con;
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    da.SelectCommand = cmd;
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    //if (ds.Tables[0].Rows.Count > 0)
        //    //{
        //    //    Label2.Text = ds.Tables[0].Rows[0]["Orderdate"].ToString();
        //    //}
        //    con.Close();
        //}

        private void showgrid(String orderid)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("product_Name");

            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM game_inventory where role='" + Label1.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);


            int totalRows = ds.Tables[0].Rows.Count;
            int i = 0;
            int grandTotal = 0;

            while (i < totalRows)
            {
                dr = dt.NewRow();
                dr["product_Name"] = ds.Tables[0].Rows[i]["game_name"].ToString();

                int price = Convert.ToInt32(ds.Tables[0].Rows[i]["game_cost"].ToString());
                grandTotal += price;
                dt.Rows.Add(dr);
                i = i + 1;
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();


        }
    }
}