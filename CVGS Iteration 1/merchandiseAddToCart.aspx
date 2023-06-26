<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="merchandiseAddToCart.aspx.cs" Inherits="CVGS_Iteration_1.merchandiseAddToCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">

    <div align="center" style="margin: 0 auto;">
        <h2 style="text-decoration: blink; color: #5f98f3">You have following Product in your Cart</h2>
        <br />
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Size="Large" NavigateUrl="~/viewMerchandise.aspx">Continue Shopping</asp:HyperLink>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Clear_Button_Cart"> Clear Cart</asp:LinkButton>
        <br />
        <br />

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderColor="#333333" BorderWidth="5px" EmptyDataText="No Game available in shopping cart" Font-Bold="True" Height="257px" ShowFooter="True" Width="1100px" OnRowDeleting="GridView1_RowDeleting">
            <Columns>
                <asp:BoundField DataField="sno" HeaderText="Sr No">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:ImageField DataImageUrlField="pImage" HeaderText="Product Image">
                    <ControlStyle Height="300px" Width="340px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:ImageField>
                <asp:BoundField DataField="pName" HeaderText="Product Name">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <%--                <asp:BoundField DataField="gQuantity" HeaderText="Quantity">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>--%>
                <asp:BoundField DataField="pPrice" HeaderText="Price">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <%--<asp:BoundField DataField="gTotal" HeaderText="Total Price">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>--%>
                <asp:CommandField DeleteText="Remove" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Check Out" Font-Bold="True" Height="46px" Width="135px" OnClick="Button1_Click" />
    </div>

</asp:Content>
