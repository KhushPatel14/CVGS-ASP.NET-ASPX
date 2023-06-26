<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminGameManagement.aspx.cs" Inherits="CVGS_Iteration_1.adminGameManagement" %>
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
                                    <h3>Game Community</h3>
                                </center>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="120px" src="images/adminManagement.png" />
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
                            <div class="col-md-4">
                                <label>Game Community ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="GameCommunityID"
                                            runat="server" placeholder="ID"></asp:TextBox>
                                        <asp:Button class="btn btn-primary" ID="Button1" runat="server"
                                            Text="Find" OnClick="Button1_Click" />
                                    </div>
                                </div>

                            </div>


                            <div class="col-md-8">
                                <label>Game Community Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="CommunityName"
                                        runat="server" placeholder="Game Community Name"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-4">
                                <asp:Button class="btn btn-success btn-block btn-lg" ID="Button2" runat="server"
                                    Text="Add" OnClick="Button2_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button3" runat="server"
                                    Text="Update" OnClick="Button3_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button class="btn btn-danger btn-block btn-lg" ID="Button4" runat="server"
                                    Text="delete" OnClick="Button4_Click" />
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
                                        <h3>Game Community List</h3>
                                    </center>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <hr>
                                </div>
                            </div>

                            <div class="row">
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=cvgsDB;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [game_management_tbl]"></asp:SqlDataSource>

                                <div class="col">
                                    <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                                        <Columns>
                                            <asp:BoundField DataField="gameCommunityID" HeaderText="gameCommunityID" SortExpression="gameCommunityID" />
                                            <asp:BoundField DataField="communityName" HeaderText="communityName" SortExpression="communityName" />
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
