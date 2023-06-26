using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CVGS_Iteration_1
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"].Equals(""))
                {
                    LinkButton1.Visible = true;   //User Login
                    LinkButton2.Visible = true;   //Sign Up
                    LinkButton3.Visible = false;  //Logout
                    LinkButton4.Visible = false;   //View Games
                    LinkButton14.Visible = false;  // View Merchandise
                    LinkButton12.Visible = false;  //User Profile
                    LinkButton5.Visible = false;  //Hello User
                    LinkButton7.Visible = true;  //Admin login
                    LinkButton8.Visible = false; //Game Community
                    //LinkButton10.Visible = false;   // Game Inventory
                    LinkButton11.Visible = false;  // User management
                    LinkButton9.Visible = false;   // Event add Admin
                    LinkButton10.Visible = false;  // Merchandise
                    LinkButton16.Visible = false;  // Report
                    LinkButton6.Visible = false;   // Cart
                    LinkButton15.Visible = false;  // Merchandise Cart
                    LinkButton13.Visible = false;  //wishlist
                    LinkButton17.Visible = false;  // merchandise wishlist
                    LinkButton18.Visible = false;  //friends & Family List
                    LinkButton19.Visible = false;  


                }
                else if (Session["role"].Equals("user"))
                {
                    LinkButton1.Visible = false;  //User Login
                    LinkButton2.Visible = false;  //Sing up
                    LinkButton3.Visible = true;   //Logout
                    LinkButton12.Visible = true;  //User Profile
                    LinkButton4.Visible = true;   //View Games
                    LinkButton14.Visible = true;  // View Merchandise
                    LinkButton5.Visible = true;  //Hello User
                    LinkButton5.Text = "Hello " + Session["username"].ToString();
                    LinkButton18.Visible = true;  //friends & Family List

                    LinkButton7.Visible = false;  //Admin login
                    LinkButton8.Visible = false; //Game Inventory
                    //LinkButton10.Visible = false;   // User management
                    LinkButton11.Visible = false;  // Game Community
                    LinkButton9.Visible = false;   // Event add Admin
                    LinkButton10.Visible = false;  // Merchandise
                    LinkButton16.Visible = false;  // Report
                    LinkButton6.Visible = true;   // Cart
                    LinkButton15.Visible = true;  // Merchandise Cart
                    LinkButton13.Visible = true;  //wishlist
                    LinkButton17.Visible = true;  // merchandise wishlist
                    LinkButton19.Visible = false;  


                }
                else if (Session["role"].Equals("admin"))
                {
                    LinkButton1.Visible = false;  //User Login
                    LinkButton2.Visible = false;  //Sing up
                    LinkButton3.Visible = true;   //Logout
                    LinkButton12.Visible = false;  //User Profile
                    LinkButton4.Visible = false;   //View Games
                    LinkButton14.Visible = false;  // View Merchandise
                    LinkButton5.Visible = true;  //Hello User
                    LinkButton5.Text = "Hello Admin";
                    LinkButton18.Visible = false;  //friends & Family List

                    LinkButton7.Visible = false;  //Admin login
                    LinkButton8.Visible = true; //Game Inventory
                    //LinkButton10.Visible = true;   // User management
                    LinkButton11.Visible = true;  // Game Community
                    LinkButton9.Visible = true;   // Event add Admin
                    LinkButton10.Visible = true;  // Merchandise
                    LinkButton16.Visible = true;  // Report
                    LinkButton6.Visible = false;   // Cart
                    LinkButton15.Visible = false;  // Merchandise Cart
                    LinkButton13.Visible = false;  //wishlist
                    LinkButton17.Visible = false;  // merchandise wishlist
                    LinkButton19.Visible = true;  

                }
            }
            catch (Exception ex)
            {

            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("userLogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("registration.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {

            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";

            LinkButton1.Visible = true;
            LinkButton2.Visible = true;
            LinkButton3.Visible = true;
            LinkButton4.Visible = false;
            LinkButton5.Visible = false;


            Response.Redirect("homePage.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewGame.aspx");
        }

        protected void HomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("homePage.aspx");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("userProfile.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminLogin.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminGameManagement.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminGameInventory.aspx");
        }

        //protected void LinkButton10_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("adminUserManagement.aspx");
        //}

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("userProfile.aspx");
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("addToCart.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminUpcomingGameEvents.aspx");
        }
        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminMerchandise.aspx");
        }

        protected void LinkButton13_Click(object sender, EventArgs e)
        {
            if (Session["role"] != null)
            {
                Response.Redirect("wishlist.aspx");
            }
            else
            {
                Response.Redirect("userLogin.aspx");
            }

        }

        protected void LinkButton20_Click(object sender, EventArgs e)
        {
            Response.Redirect("friendsAndFamily.aspx");
        }
        protected void LinkButton19_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminReviewPage.aspx");

        }

    }
}