<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="digitalGamePdf.aspx.cs" Inherits="CVGS_Iteration_1.paymentPdf" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">

    <div align="center">
        <asp:Button ID="Button1" runat="server" Text="Download Digital Game" BackColor="Silver" Font-Bold="True" Font-Size="Large" Height="49px" OnClick="Button1_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Size="Large" NavigateUrl="~/homePage.aspx">Go to Home Page</asp:HyperLink>

        <asp:Panel ID="Panel1" runat="server">
            <table border="1">
                <tr>
                    <td style="text-align: center">
                        <h2 style="text-align: center">Digital Game</h2>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                        <br />
                        <br />
                      
                        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>

                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="1000px">
                            <Columns>
                                <asp:BoundField DataField="sno" HeaderText="SNo">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="product_ID" HeaderText="Game ID">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="product_Name" HeaderText="Game Name">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                            </Columns>

                        </asp:GridView>
                    </td>
                </tr>
               
                <tr>
                    <td align="Center">This is not a real game!</td>
                </tr>
                <tr>
                    <td></td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
