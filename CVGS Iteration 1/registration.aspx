<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="registration.aspx.cs" Inherits="CVGS_Iteration_1.signUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="120px" src="images/employeeImage.png" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>User Registration</h3>
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
                            <div class="col-md-6">
                                <label>Full Name</label>
                                <div class="form-group">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="FullName" ErrorMessage="Please enter valid name" ForeColor="Red">Please enter valid name</asp:RequiredFieldValidator>
                                    <br />
                                    <asp:TextBox CssClass="form-control" ID="FullName"
                                        runat="server" placeholder="Full Name"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label>Email Address</label>
                                <div class="form-group">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="EmailID" ErrorMessage="Please enter valid email id" ForeColor="Red">Please enter valid email id</asp:RequiredFieldValidator>
                                    <br />
                                    <asp:TextBox CssClass="form-control" ID="EmailID"
                                        runat="server" placeholder="Email Address" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-12">
                                <label>User Name</label>
                                <div class="form-group">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="EmployeeID" ErrorMessage="Please enter user name" ForeColor="Red">Please enter user name</asp:RequiredFieldValidator>
                                    <asp:TextBox CssClass="form-control" ID="EmployeeID"
                                        runat="server" placeholder="User Name"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>User Password</label>
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="EmployeePassword" ErrorMessage="Please enter Password" ForeColor="Red">Please enter Password</asp:RequiredFieldValidator>
                                    <%--<br />--%>
                                    <asp:TextBox CssClass="form-control" ID="EmployeePassword"
                                        runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="EmployeePassword" ErrorMessage="Must be a strong password" ForeColor="Red" ValidationExpression="^(?=.*[A-Z].*[A-Z])(?=.*[!@#$&amp;*])(?=.*[0-9].*[0-9])(?=.*[a-z].*[a-z].*[a-z]).{8,20}$">Must have minimum 8 charaters and maximum 20: include two uppercase letter, one special charater, two digits, three lowercase letters</asp:RegularExpressionValidator>

                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server"
                                        Text="Sign Up" OnClick="Button1_Click" />
                                </div>
                                <%--                                <div>
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                                </div>--%>
                            </div>
                        </div>

                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
