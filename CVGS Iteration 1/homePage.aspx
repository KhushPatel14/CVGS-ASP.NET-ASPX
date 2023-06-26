<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="homePage.aspx.cs" Inherits="CVGS_Iteration_1.homepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
    <section>
        <img src="images/home.jpg" class="img-fluid" style="height: 400px; width: 1550px; margin-top: 10px" />
    </section>

    <section>
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <center>
                        <h2>Our Features</h2>
                    </center>
                </div>
            </div>

            <div class="row">
                <div class="col-md-6">
                    <center>
                        <%--<img src="images/search.jpeg" class="img-fluid" />--%>
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="120px" ImageUrl="~/images/search.jpeg" Width="140px" OnClick="ImageButton1_Click"/>
                        <h4>Search Games</h4>
                        <p style="margin-left:8em" class="text-justify">Click the image above to search games!</p>
                    </center>
                </div>

                <div class="col-md-6">
                    <center>
                        <asp:ImageButton ID="ImageButton2" runat="server" Height="120px" ImageUrl="~/images/event.jpeg" Width="140px" OnClick="ImageButton2_Click"/>
                        <h4>Upcoming events</h4>
                        <p style="margin-left:5em" class="text-justify">Click the image above to see upcoming events!</p>
                    </center>
                </div>

                
            </div>

        </div>
    </section>
</asp:Content>


