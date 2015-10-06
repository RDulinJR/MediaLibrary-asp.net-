<%@ Page Title="" Language="C#" MasterPageFile="~/Html/MasterPage.master" AutoEventWireup="true" CodeFile="MovieDetails.aspx.cs" Inherits="Html_MovieDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Movie Details</h1>
    <asp:FormView ID="FormView1" runat="server" Width="100%" margin="20px">
        <ItemTemplate>
            <div>
                <h2><%#Eval("Title") %></h2>
            </div>
            <br />
            <table>
                <tr>
                    <td>
                        <img src ="<%#Eval("Poster") %>" />
                    </td>
                    <td>
                        <p>Title: <%#Eval("Title") %></p>
                        <br />
                        <p>Year: <%#Eval("Year") %></p>
                        <br />
                        <p>Runtime: <%#Eval("Runtime") %></p>
                        <br />
                        <p>Genre: <%#Eval("Genre") %></p>
                        <br />
                        <p>Actors: <%#Eval("Actors") %></p>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>


