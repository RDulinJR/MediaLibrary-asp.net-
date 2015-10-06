<%@ Page Title="" Language="C#" MasterPageFile="~/Html/MasterPage.master" AutoEventWireup="true" CodeFile="AddMovie.aspx.cs" Inherits="Html_AddMovie" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Add A Movie</h1>
    <p>&nbsp;</p>
    <p>
        <asp:Image ID="Image1" runat="server" Height="308px" Visible="False" Width="200px" />
    </p>
<p>&nbsp;</p>
<p>Title:
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
</p>
<p>Year:
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
</p>
<p>Runtime:
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
</p>
<p>Genre:
    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
</p>
<p>Actors:
    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
</p>
<p>&nbsp;</p>
<p>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Clear" />
&nbsp;
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Search" />
&nbsp;
    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Add" />
</p>

</asp:Content>

