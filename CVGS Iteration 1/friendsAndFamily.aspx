<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="friendsAndFamily.aspx.cs" Inherits="CVGS_Iteration_1.friendsAndFamily" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <script type="text/javascript">
      $(document).ready(function () {
          $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
          //$('.table1').DataTable();
      });
      </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
     <div class="container">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Friends And Family</h3>
                                </center>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="120px" src="images/friends&family.jpeg"/>
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
                            <div class="col-md-8">
                                <label>Name</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="nameFriendsFamily"
                                            runat="server" placeholder="Name"></asp:TextBox> 
                                        &nbsp;&nbsp;&nbsp;&nbsp; 
                                        <asp:Button class="btn btn-primary" ID="Button1" runat="server"
                                            Text="Find" OnClick="Button1_Click" />
                                    </div>
                                </div>

                            </div>


                            <div class="col-md-8">
                                <label>Email</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" Name="emailFriendsFamily" ID="emailFriendsFamily"
                                        runat="server" placeholder="Email"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-4">
                                <asp:Button class="btn btn-success btn-block btn-lg" ID="Button2" runat="server"
                                    Text="Add" OnClick="Button2_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button class="btn btn-danger btn-block btn-lg" ID="Button3" runat="server"
                                    Text="delete" OnClick="Button3_Click"/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-7">
                <div class="col-md-14">
                    <div class="card">
                        <div class="card-body">

                            <div class="row">
                                <div class="col">
                                    <center>
                                        <h3>Friends & Family List</h3>
                                    </center>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <hr>
                                </div>
                            </div>

                            <div class="row">
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=cvgsDB;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [friends_family_tbl]"></asp:SqlDataSource>

                                <div class="col">
                                    <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                                        <Columns>
                                            <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                                            <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-4">
                                    <br />
                                    <asp:TextBox CssClass="form-control" ID="validation"
                                            runat="server" ReadOnly="true" style="width:590px; height:50px; color:red;"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>