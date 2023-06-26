<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminLogin.aspx.cs" Inherits="CVGS_Iteration_1.adminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="120px" src="images/adminImage.png" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Admin Login</h3>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <hr>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <label>Admin ID</label>
                                    <asp:TextBox CssClass="form-control" ID="AdminID"
                                        runat="server" placeholder="Admin ID"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <label>Password</label>
                                    <asp:TextBox CssClass="form-control" ID="AdminPassword"
                                        runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <asp:Button class="btn btn-primary btn-block btn-lg" ID="Login" runat="server" Text="Login" OnClick="Login_Click" />
                                </div>

                            </div>
                        </div>

                        <div class="row">
                            <div class="col-4">
                                <br />
                                <asp:TextBox CssClass="form-control" ID="validation"
                                        runat="server" ReadOnly="true" style="width:500px; height:50px; color:red;"></asp:TextBox>
                            </div>
                        </div>

                    </div>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
