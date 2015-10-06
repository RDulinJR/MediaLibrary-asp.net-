<%@ Page Title="Login" Language="C#" MasterPageFile="~/Html/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Html_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Login</h1>
    <p>&nbsp;</p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Username:"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Required Field" Font-Bold="True" ForeColor="#FF3300"></asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Required Field" Font-Bold="True" ForeColor="#FF3300"></asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:CheckBox ID="CheckBox1" runat="server" Text="Remember Me" />
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" />
        <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
    </p>

</asp:Content>

