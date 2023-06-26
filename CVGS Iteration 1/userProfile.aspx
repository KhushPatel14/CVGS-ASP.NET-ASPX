<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userProfile.aspx.cs" Inherits="CVGS_Iteration_1.userProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-6 mx-auto">
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
                                    <h3>Your Profile</h3>
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
                                    <asp:TextBox CssClass="form-control" ID="FullName"
                                        runat="server" placeholder="Full Name"></asp:TextBox>
                                </div>
                            </div>


                            <div class="col-md-6">
                                <label>Email Address</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="EmailID"
                                        runat="server" placeholder="Email Address" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label>Gender</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList1"
                                        runat="server">
                                        <asp:ListItem Text="Male" Value="Male" />
                                        <asp:ListItem Text="Female" Value="Female" />
                                        <asp:ListItem Text="Other" Value="Other" />
                                    </asp:DropDownList>

                                </div>
                            </div>


                            <div class="col-md-6">
                                <label>Birthdate(dd-mm-yyyy)</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="Date"
                                        runat="server" placeholder="Birthdate" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label>Preferences</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList2"
                                        runat="server">
                                        <asp:ListItem Text="PlayStation" Value="PlayStation" />
                                        <asp:ListItem Text="Xbox" Value="Xbox" />
                                        <asp:ListItem Text="PC" Value="PC" />
                                    </asp:DropDownList>

                                </div>
                            </div>

                            <div class="col-md-6">
                                <label>Game Category</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList3"
                                        runat="server">
                                        <asp:ListItem Text="Action" Value="Action" />
                                        <asp:ListItem Text="Adventure" Value="Adventure" />
                                        <asp:ListItem Text="Racing" Value="Racing" />
                                        <asp:ListItem Text="Puzzle" Value="Puzzle" />
                                    </asp:DropDownList>

                                </div>
                            </div>

                            <div class="col-md-12">
                                <label id="checkboxLable">Are your billing and shipping address same?</label>
                                <asp:CheckBox ID="sameCheckBox" runat="server" Text="" ></asp:CheckBox>
                           </div>

                            <div class="col-md-12">
                                <label>Mailing Address</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="MailingAddress"
                                        runat="server" placeholder="Mailing Address"  rows="7" cols="50"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-12">
                                <label id="shippingID">Shipping Address</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="ShippingAddress"
                                        runat="server" placeholder="Shipping Address"  rows="7" cols="50" Enabled="True" Visible="True"></asp:TextBox>
                                </div>
                            </div>
<%--                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Mailing and Shipping should be same." Text="Mailing and Shipping should be same." ControlToCompare="MailingAddress" ControlToValidate="ShippingAddress" ForeColor="Red"></asp:CompareValidator>--%>

                            <div class="col-md-4">
                                <label>City</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="City"
                                        runat="server" placeholder="City"></asp:TextBox>
                                </div>
                            </div>

                            <%--<div class="col-md-4">
                                <label>Province</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="Province"
                                        runat="server" placeholder="Province"></asp:TextBox>
                                </div>
                            </div>--%>

                            <div class="col-md-4">
                                <label>Province</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="Province"
                                        runat="server">
                                        <asp:ListItem Text="Alberta" Value="Alberta" />
                                        <asp:ListItem Text="British Columbia" Value="British_Columbia" />
                                        <asp:ListItem Text="Manitoba" Value="Manitoba" />
                                        <asp:ListItem Text="New Brunswick" Value="New_Brunswick" />
                                        <asp:ListItem Text="Newfoundland and Labrador" Value="Newfoundland_and_Labrador" />
                                        <asp:ListItem Text="Northwest Territories" Value="Northwest_Territories" />
                                        <asp:ListItem Text="Nova Scotia" Value="Nova_Scotia" />
                                        <asp:ListItem Text="Nunavut" Value="Nunavut" />
                                        <asp:ListItem Text="Ontario" Value="Ontario" />
                                        <asp:ListItem Text="Prince Edward Island" Value="Prince_Edward_Island" />
                                        <asp:ListItem Text="Quebec" Value="Quebec" />
                                        <asp:ListItem Text="Saskatchewan" Value="Saskatchewan" />
                                        <asp:ListItem Text="Yukon" Value="Yukon" />
                                    </asp:DropDownList>

                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Postal Code</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="Postal"
                                        runat="server" placeholder="Postal Code"></asp:TextBox>
                                </div>
                            </div>

                            <div style="margin-left: auto; margin-right:auto;">
                                <div class="col-50">
                                    <center>
                                        <span class="badge badge-pill badge-info">Login Credentials
                                        </span>
                                    </center>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4">
                                    <label>User ID</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="EmployeeID"
                                            runat="server" placeholder="User ID" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Old Password</label>
                                        <asp:TextBox CssClass="form-control" ID="EmployeePassword"
                                            runat="server" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>New Password</label>
                                        <asp:TextBox CssClass="form-control" ID="EmployeeNewPassword"
                                            runat="server" placeholder="New Password" TextMode="Password"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-8 mx-auto">
                                <center>
                                    <div class="form-group">
                                        <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button2" runat="server"
                                            Text="Update" OnClick="Button2_Click" />
                                    </div>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-4">
                                <br />
                                <asp:TextBox CssClass="form-control" ID="validation"
                                    runat="server" TextMode="MultiLine" ReadOnly="true" Style="width: 800px; height: 200px; color: red;"></asp:TextBox>
                            </div>
                        </div>

                    </div>
                </div>

            </div>

            <div class="col-md-7">
            </div>
        </div>
    </div>

</asp:Content>
