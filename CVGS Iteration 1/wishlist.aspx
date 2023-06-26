<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="wishlist.aspx.cs" Inherits="CVGS_Iteration_1.wishlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
<!DOCTYPE html>

<html xmlns ="http://www.w3.org/1999/xhtml">
<head runrat="server">
    <title></title>
</head>

<body>
    <form id="form1" runrat="server">
        <div align="center" style="margin: 0 auto;">
            <h2 style="text-decoration: blink; color: #5f98f3">You have following games in your Wish List</h2>
            <br />
            <br />

            <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Size="Large" NavigateUrl="~/viewGame.aspx">Continue Shopping</asp:HyperLink>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" Font-Size="Large" OnClick="LinkButton1_Click"> Clear WishList</asp:LinkButton>
            <br />
            <br />


            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderColor="#333333" BorderWidth="5px" EmptyDataText="No Game available in your wishlist" Font-Bold="True" Height="257px" ShowFooter="True" Width="1100px" OnRowDeleting="GridView1_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="sno" HeaderText="Sr No">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:ImageField DataImageUrlField="gImage" HeaderText="Product Image">
                        <ControlStyle Height="300px" Width="340px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:ImageField>
                    <asp:BoundField DataField="gName" HeaderText="Product Name">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="gPrice" HeaderText="Price">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    
                    <asp:CommandField DeleteText="Remove" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource runat="server" ID="SqlDataSource1"></asp:SqlDataSource>
    </form>
</body>
</html>

</asp:Content>