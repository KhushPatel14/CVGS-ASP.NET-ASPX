<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminReport.aspx.cs" Inherits="CVGS_Iteration_1.adminReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
    <div class="row">
        <div class="col">
            <center>
                <asp:Button ID="Button1" runat="server" Text="Download All Games" OnClick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="Download Game Details" OnClick="Button2_Click" />
                <asp:Button ID="Button3" runat="server" Text="Download Member Names" OnClick="Button3_Click" />
                <asp:Button ID="Button4" runat="server" Text="Download Member Details" OnClick="Button4_Click" />
            </center>
        </div>
    </div>
</asp:Content>
