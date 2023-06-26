<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminMemberDetailListDownload.aspx.cs" Inherits="CVGS_Iteration_1.adminMemberDetailListDownload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">

    <div align="center">
        <asp:Button ID="Button1" runat="server" Text="Download All Member Details" BackColor="Silver" Font-Bold="True" Font-Size="Large" Height="49px" OnClick="Button1_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Size="Large" NavigateUrl="~/homePage.aspx">Go to Home Page</asp:HyperLink>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:HyperLink ID="HyperLink2" runat="server" Font-Bold="True" Font-Size="Large" NavigateUrl="~/adminReport.aspx">Go to Previous Page</asp:HyperLink>

        <asp:Panel ID="Panel1" runat="server">
            <table border="1">
                <tr>
                    <td style="text-align: center">
                        <h2 style="text-align: center">All Member Details</h2>
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

                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="1450px">
                            <Columns>
                                <asp:BoundField DataField="product_ID" HeaderText="User Name">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="product_Name" HeaderText="Member Name">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="member_Email" HeaderText="Member Email">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="member_gender" HeaderText="Member Gender">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="member_birthday" HeaderText="Member Birthday">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="member_prefrence" HeaderText="Prefrence">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="member_address" HeaderText="Address">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="member_city" HeaderText="City">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="member_province" HeaderText="Province">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="member_code" HeaderText="Postal Code">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                            </Columns>

                        </asp:GridView>
                    </td>
                </tr>
               
                <tr>
                    <td align="Center">All Member Details!</td>
                </tr>
                <tr>
                    <td></td>
                </tr>
            </table>
        </asp:Panel>
    </div>

</asp:Content>
