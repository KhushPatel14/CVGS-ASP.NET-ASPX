<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="merchandisePlaceOrder.aspx.cs" Inherits="CVGS_Iteration_1.merchandisePlaceOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">

    <table align="center" style="margin-top: 50px; width: 531px; height: 563px" bgcolor="LightBlue">
        <tr>
            <td colspan="2" align="center" style="vertical-align: top">
                <asp:Label ID="Label1" runat="server" Text="Card Details" Font-Bold="True" Font-Size="X-Large" ForeColor="White"></asp:Label>
            </td>
        </tr>

        <tr>
            <td align="center" style="vertical-align: top">
                <asp:TextBox ID="TextBox1" runat="server" placeholder="First Name" BorderColor="Black" BorderWidth="2px" Font-Bold="True" Font-Size="Medium" Height="44px" Width="188px"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="First Name required" ControlToValidate="TextBox1" ForeColor="Red">First Name required</asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please enter a valid name" ControlToValidate="TextBox1" ForeColor="Red" ValidationExpression="^[A-Za-z]*$">Please enter a valid name</asp:RegularExpressionValidator>
            </td>

            <td align="center" style="vertical-align: top">
                <asp:TextBox ID="TextBox2" runat="server" placeholder="Last Name" BorderColor="Black" BorderWidth="2px" Font-Bold="True" Font-Size="Medium" Height="44px" Width="188px"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Last Name required" ControlToValidate="TextBox2" ForeColor="Red">Last Name required</asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Please enter a valid last name" ControlToValidate="TextBox2" ForeColor="Red" ValidationExpression="^[A-Za-z]*$">Please enter a valid Last name</asp:RegularExpressionValidator>
            </td>
        </tr>

        <tr>
            <td colspan="2" align="center">
                <asp:Image ID="Image1" runat="server" BorderColor="Black" BorderWidth="2px" ImageUrl="~/images/visa.png" Width="438px" />
            </td>
        </tr>

        <tr>
            <td colspan="2" align="center">
                <asp:Label ID="Label2" runat="server" Text="Card Number" Font-Bold="True" Font-Size="Large" ForeColor="White"></asp:Label>
            </td>
        </tr>

        <tr>
            <td colspan="2" align="center" style="vertical-align: top">
                <asp:TextBox ID="TextBox3" runat="server" placeholder="16 Digits" BorderColor="Black" BorderWidth="2px" Font-Bold="True" Font-Size="Medium" Height="44px" Width="442px"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="card number required" ControlToValidate="TextBox3" ForeColor="Red">card number required</asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Card number must be 16 charater" ControlToValidate="TextBox3" ForeColor="Red" ValidationExpression="[0-9]{16}">Card number must be 16 charater</asp:RegularExpressionValidator>
            </td>
        </tr>

        <tr>
            <td align="center">
                <asp:Label ID="Label3" runat="server" Text="Expiry Date" Font-Bold="True" Font-Size="Large" ForeColor="White"></asp:Label>
            </td>

            <td align="center">
                <asp:Label ID="Label4" runat="server" Text="CVV" Font-Bold="True" Font-Size="Large" ForeColor="White"></asp:Label>
            </td>
        </tr>

        <tr>
            <td align="center" style="vertical-align: top">
                <asp:TextBox ID="TextBox4" runat="server" placeholder="MMYY" BorderColor="Black" BorderWidth="2px" Font-Bold="True" Font-Size="Medium" Height="44px" Width="188px"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Expiry date required" ControlToValidate="TextBox4" ForeColor="Red">Expiry date required</asp:RequiredFieldValidator>
            </td>

            <td align="center" style="vertical-align: top">
                <asp:TextBox ID="TextBox5" runat="server" placeholder="3 Digits" BorderColor="Black" BorderWidth="2px" Font-Bold="True" Font-Size="Medium" Height="44px" Width="188px"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="CVV number required" ControlToValidate="TextBox5" ForeColor="Red">CVV number required</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="CVV number must be 3 charater" ControlToValidate="TextBox5" ForeColor="Red" ValidationExpression="[0-9]{3}">CVV number must be 3 charater</asp:RegularExpressionValidator>
            </td>
        </tr>

        <%--<tr>
            <td align="center" style="vertical-align: top" colspan="2">
                <asp:TextBox ID="TextBox6" runat="server" placeholder="Billing Address" BorderColor="Black" BorderWidth="2px" Font-Bold="True" Font-Size="Large" Height="50px" Width="188px" TextMode="MultiLine"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Billing Address required" ControlToValidate="TextBox6" ForeColor="Red">Billing Address required</asp:RequiredFieldValidator>
            </td>
        </tr>--%>

        <tr>
            <td align="center" colspan="2">
                <asp:Button ID="Button1" runat="server" Text="Submit" BackColor="Black" BorderColor="White" BorderWidth="2px" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="44px" Width="188px" OnClick="Button1_Click" />
            </td>
        </tr>

        <tr>
            <td colspan="2">
                <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" NavigateUrl="~/merchandiseAddToCart.aspx">Previous Page</asp:HyperLink>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:HyperLink ID="HyperLink2" runat="server" Font-Bold="True" NavigateUrl="~/viewMerchandise.aspx">View Merchandise</asp:HyperLink>
            </td>
        </tr>
    </table>

</asp:Content>
