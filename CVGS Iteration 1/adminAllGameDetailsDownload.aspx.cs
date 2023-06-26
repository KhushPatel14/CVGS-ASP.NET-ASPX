using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace CVGS_Iteration_1
{
    public partial class adminAllGameDetailsDownload : System.Web.UI.Page
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
            Response.AddHeader("content-disposition", "attachment;filename=AllGameDetails.pdf");
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

        private void showgrid(String orderid)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("product_Name");
            dt.Columns.Add("product_Date");
            dt.Columns.Add("product_Genre");
            dt.Columns.Add("product_Cost");
            dt.Columns.Add("product_Des");

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
                dr["product_Date"] = ds.Tables[0].Rows[i]["publish_date"].ToString();
                dr["product_Genre"] = ds.Tables[0].Rows[i]["genre"].ToString();
                dr["product_Cost"] = ds.Tables[0].Rows[i]["game_cost"].ToString();
                dr["product_Des"] = ds.Tables[0].Rows[i]["game_des"].ToString();

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