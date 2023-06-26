<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminReviewPage.aspx.cs" Inherits="CVGS_Iteration_1.adminReviewPage" %>
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
                                <h3>Admin Feedback Page List</h3>
                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <hr>
                        </div>
                    </div>

                    <div class="row">
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=cvgsDB;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [game_ratings_tbl]"></asp:SqlDataSource>

                        <div class="col">
                            <asp:GridView ID="GridView1" class="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowCommand="GridView1_RowCommand">
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                                    <asp:BoundField DataField="ratings" HeaderText="Ratings" SortExpression="ratings" />
                                    <asp:BoundField DataField="feedback" HeaderText="Feedback" SortExpression="feedback" />
                                    
                                    <asp:TemplateField HeaderText="Feedback Status">
                                        <ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <asp:RadioButton ID="approve" GroupName="feedbackStatus" Checked="true" CommandName="approve" Text="Approve" runat="server"></asp:RadioButton>
                                            <asp:RadioButton ID="decline" GroupName="feedbackStatus" Text="Decline" runat="server"></asp:RadioButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                </Columns>

                            </asp:GridView>
                            <center>
                            <asp:Button ID="Button1" Class="btn btn-primary" runat="server" Text="Update Status" OnClick="Button1_Click" />
                            </center>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>

</asp:Content>