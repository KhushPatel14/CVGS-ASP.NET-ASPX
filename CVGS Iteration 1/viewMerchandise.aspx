<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="viewMerchandise.aspx.cs" Inherits="CVGS_Iteration_1.viewMerchandise" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">

    <div style="text-align: right">
        <asp:Label ID="Label6" runat="server" Text="Search Game"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Height="31px" Width="174px"></asp:TextBox>
        <asp:ImageButton ID="ImageButton2" runat="server" Height="33px" Width="35px" ImageUrl="~/images/search.png" OnClick="ImageButton2_Click"/>
    </div>
    <%--        </tr>
    </table>--%>
    <div class="col-sm-12">
        <center>
            <h3>Merchandise List
            </h3>
        </center>
    </div>
    <center>
        <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" Height="293px" Width="310px" RepeatColumns="5" RepeatDirection="Horizontal" OnItemCommand="DataList1_ItemCommand">
            <ItemTemplate>
                <table>
                    <tr>
                        <td style="text-align: center; background-color: #5f98f3">
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("product_name") %>' Font-Bold="True" Font-Names="Open Sans Extrabold" ForeColor="White"></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td style="text-align: center">
                            <asp:ImageButton ID="Image1" runat="server" BorderColor="#5F98F3" BorderWidth="1px" Height="279px" Width="278px" ImageUrl='<%# Eval("product_img") %>' CommandArgument='<%#Eval("product_id") %>' CommandName="Description"/>
                        </td>
                    </tr>

                    <tr>
                        <td style="text-align: center; background-color: #5f98f3">
                            <asp:Label ID="Label2" runat="server" Text="Price: $" Font-Bold="True" Font-Names="Arial" ForeColor="White" Style="text-align: center"></asp:Label>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("product_cost") %>' Font-Bold="True" Font-Names="Arial" ForeColor="White" Style="text-align: center"></asp:Label>

                        </td>
                    </tr>

                    <tr>
                        <td style="text-align: center; background-color: #5f98f3">
                            <asp:Label ID="Label4" runat="server" Text="Related Game :" Font-Bold="True" Font-Names="Arial" ForeColor="White" Style="text-align: center"></asp:Label>
                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("related_game")%>' Font-Bold="True" Font-Names="Arial" ForeColor="White" Style="text-align: center"></asp:Label>

                        </td>
                    </tr>

                    <tr>
                        <td style="text-align: center">
                            <asp:ImageButton ID="ImageButtonWishlist" runat="server" ImageUrl="~/images/wishList1.jpeg"
                                Width="50px" Height="50px" CommandArgument='<%# Eval("product_id") %>' CommandName="AddToWishList" />
                            <asp:ImageButton ID="ImageButton1" runat="server" Height="40px" ImageUrl="~/images/cart.jpg" Width="160px" CommandArgument='<%# Eval("product_id") %>' CommandName="AddToCart" />
                        </td>
                    </tr>

                </table>
                <br />
                <br />
            </ItemTemplate>
        </asp:DataList>
    </center>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server"
        ConnectionString="Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=cvgsDB;Integrated Security=True" ProviderName="System.Data.SqlClient"
        SelectCommand="SELECT [product_name], [product_img], [product_cost], [related_game], [product_id] FROM [admin_merchandise]"></asp:SqlDataSource>

</asp:Content>
