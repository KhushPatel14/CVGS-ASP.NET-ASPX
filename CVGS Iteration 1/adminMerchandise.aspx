<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminMerchandise.aspx.cs" Inherits="CVGS_Iteration_1.adminMerchandise" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });

        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#imgview').attr('src', e.target.result);
                };

                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Merchandise</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img id="imgview" width="100px" src="images/Merchandise.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:FileUpload onchange="readURL(this);" class="form-control" ID="FileUpload1" runat="server" />
                            </div>
                        </div>
                        <asp:Label ID="Label7" runat="server" ForeColor="#00CC99" Text="Label">Please, choose image first from above!
                        </asp:Label>
                        <div class="row">

                            <div class="col-md-6">
                                <label>Product Name</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Product Name"></asp:TextBox>
                                        <asp:Button class="btn btn-primary" ID="Button4" runat="server" Text="Find" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Publish Date</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Date" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label>Related game</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">
                                        <asp:ListItem Text="P1" Value="P1" />
                                        <asp:ListItem Text="P2" Value="P2" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label>Product Cost(per unit)</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Product Cost(per unit)"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-8">
                                <label>Product Description</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Product Description" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-4">
                                <asp:Button ID="Button1" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="Button1_Click" />
                            </div>
                            <%--<div class="col-4">
                                <asp:Button ID="Button3" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="Button3_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button2" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="Button2_Click" />
                            </div>--%>
                        </div>
                    </div>
                </div>
                <a href="homePage.aspx"><< Back to Home</a><br>
                <br>
            </div>
            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=cvgsDB;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [admin_merchandise]"></asp:SqlDataSource>
                                        Merchandise List</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                                    <Columns>

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col-lg-10">
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("product_name") %>' Font-Bold="True" Font-Size="Large"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-12">

                                                                    <span>Community Name -
                                                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("related_game") %>' Font-Italic="True"></asp:Label>
                                                                    </span>

                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Publish Date -
                                                                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("publish_date") %>'></asp:Label>
                                                                    &nbsp;| Cost - $
                                                                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("product_cost") %>'></asp:Label>

                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Description -
                                                                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Italic="True" Text='<%# Eval("product_description") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <asp:Image class="img-fluid" ID="Image1" runat="server" ImageUrl='<%# Eval("product_img") %>' />
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
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
        </div>
    </div>

</asp:Content>
