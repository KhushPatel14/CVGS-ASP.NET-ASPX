<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="upcomingEvents.aspx.cs" Inherits="CVGS_Iteration_1.upcomingEvents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
            //$('.table1').DataTable();
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">

    <div class="col-md-12">
        <div class="col-md-14">
            <div class="card">
                <div class="card-body">

                    <div class="row">
                        <div class="col">
                            <center>
                                <h3>Upcoming Events List</h3>
                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <hr>
                        </div>
                    </div>

                    <div class="row">
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=cvgsDB;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [upcoming_events]"></asp:SqlDataSource>

                        <div class="col">
                            <asp:GridView ID="GridView1" class="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowCommand="GridView1_RowCommand">
                                <Columns>
                                    <asp:BoundField DataField="event_name" HeaderText="Event Name" SortExpression="event_name" />
                                    <asp:BoundField DataField="event_date" HeaderText="Event date" SortExpression="event_date" />
                                    <asp:BoundField DataField="event_description" HeaderText="Description" SortExpression="event_description" />
                                    <asp:ButtonField Text="Register" CommandName="register" />
                                </Columns>

                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
