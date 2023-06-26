<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminUpcomingGameEvents.aspx.cs" Inherits="CVGS_Iteration_1.adminGameEvents" %>

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
                                    <h3>Upcoming Events</h3>
                                </center>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="120px" src="images/upcoming.jpg" />
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
                                <label>Event ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="EventID"
                                            runat="server" placeholder="ID"></asp:TextBox>
                                        <asp:Button class="btn btn-primary" ID="Button1" runat="server"
                                            Text="Find" OnClick="Button1_Click" />
                                    </div>
                                </div>

                            </div>


                            <div class="col-md-8">
                                <label>Event Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="EventName"
                                        runat="server" placeholder="EventName"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Event Date</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="EventDate"
                                        runat="server" placeholder="EventName" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label>Event Description</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="EventDescription" runat="server" placeholder="Game Description" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-4">
                                <asp:Button class="btn btn-success btn-block btn-lg" ID="Button2" runat="server"
                                    Text="Add" OnClick="Button2_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button class="btn btn-danger btn-block btn-lg" ID="Button4" runat="server"
                                    Text="Delete" OnClick="Button4_Click" />
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
                                        <h3>Events List</h3>
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
                                    <asp:GridView ID="GridView1" class="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                                        <Columns>
                                            <asp:BoundField DataField="event_id" HeaderText="event_id" SortExpression="event_id" />
                                            <asp:BoundField DataField="event_name" HeaderText="event_name" SortExpression="event_name" />
                                            <asp:BoundField DataField="event_date" HeaderText="event_date" SortExpression="event_date" />
                                            <asp:BoundField DataField="event_description" HeaderText="event_description" SortExpression="event_description" />
                                        </Columns>

                                    </asp:GridView>
                                </div>
                            </div>


                            <div class="row">
                                <br />
                                <div class="col-12">
                                    <asp:TextBox CssClass="form-control" ID="validation"
                                            runat="server" TextMode="MultiLine" ReadOnly="true" style="width:600px; height:100px; color:red;"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
