<%@ Page Title="Home" Language="C#" MasterPageFile="~/Html/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Html_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id="defaultPage">
        <br />
        <h1>Welcome to your movie library!</h1>
        <br />
        <br />
        <h3>How to</h3>
        <ul>
            <li>1. You must login in order to do anything</li>
            <li>2. Click the Library link to check your library</li>
            <li>3. Add Titles to your library by clicking Add Movie<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; put in the information or searching for it with the title</li>
            <li>click the add button (all fields must be filled in)</li>
            <li>you may add another movie or check your library</li>
        </ul>
    </div>
</asp:Content>

