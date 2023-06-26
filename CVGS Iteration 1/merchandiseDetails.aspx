<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="merchandiseDetails.aspx.cs" Inherits="CVGS_Iteration_1.merchandiseDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">

    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css">

    <div align="center">
        <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1">
            <ItemTemplate>
                <div class="container">
                    <div class="row">
                        <div class="col-12-lg mt-2">
                            <div class="card" style="width:28rem;">
                                <asp:Image CssClass="card-img-top" Height="300px" Width="447px" ID="Image1" runat="server" ImageUrl='<%# Eval("product_img") %>'
                                    AlternateText="Game Image"/>
                                <div class="card-body bg-dark">
                                    <h5 class="card-title text-white" style="font-style: italic";><%# Eval("product_name") %></h5>
                                    <h6 class="card-title text-white">Price: $<%# Eval("product_cost") %></h6>
                                    <h6 class="card-title text-white">Related Game: <%# Eval("related_game") %></h6>
                                    <h6 class="card-title text-white">Publish Date: <%# Eval("publish_date") %></h6>
                                    <p class="card-text text-white">Description: <br /> <%# Eval("product_description") %></p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
        <asp:Button class="btn btn-primary"  ID="Button1" runat="server" Text="Back To Items" OnClick="Button1_Click"/>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=cvgsDB;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [product_id], [related_game], [publish_date], [product_name], [product_cost], [product_description], [product_img] FROM [admin_merchandise] WHERE ([product_id] = @product_id)">
            <SelectParameters>
                <asp:QueryStringParameter Name="product_id" QueryStringField="id" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>

</asp:Content>
