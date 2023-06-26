﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="gameDetails.aspx.cs" Inherits="CVGS_Iteration_1.gameDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
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
                                <asp:Image CssClass="card-img-top" Height="300px" Width="447px" ID="Image1" runat="server" ImageUrl='<%# Eval("game_img") %>'
                                    AlternateText="Game Image"/>
                                <div class="card-body bg-dark">
                                    <h5 class="card-title text-white" style="font-style: italic";><%# Eval("game_name") %></h5>
                                    <h6 class="card-title text-white">Price: $<%# Eval("game_cost") %></h6>
                                    <h6 class="card-title text-white">Community Name: <%# Eval("community_name") %></h6>
                                    <h6 class="card-title text-white">Publish Date: <%# Eval("publish_date") %></h6>
                                    <h6 class="card-title text-white">Genre: <%# Eval("genre") %></h6>
                                    <p class="card-text text-white">Description: <br /> <%# Eval("game_des") %></p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>

        <div class="card-body bg-dark" style="width:28rem;">

        <asp:Button class="btn btn-primary"  ID="Button1" runat="server" Text="Back To Games" OnClick="Button1_Click"/>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=cvgsDB;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [game_id], [game_name], [publish_date], [community_name], [genre], [game_des], [game_cost], [game_img] FROM [game_inventory] WHERE ([game_id] = @game_id)">
            <SelectParameters>
                <asp:QueryStringParameter Name="game_id" QueryStringField="id" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>

</asp:Content>