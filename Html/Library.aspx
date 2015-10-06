<%@ Page Title="" Language="C#" MasterPageFile="~/Html/MasterPage.master" AutoEventWireup="true" CodeFile="Library.aspx.cs" Inherits="Html_About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <h1>Your Library</h1>
    <br />
    <br />
    <div class="library">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MediaLibraryConnectionString1 %>" SelectCommand="SELECT [MediaId], [Title], [Year], [Poster] FROM [Movies] WHERE ([U_Id] = @U_Id)">
            <SelectParameters>
                <asp:SessionParameter Name="U_Id" SessionField="uid" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1">
            <LayoutTemplate>
                <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="poster">
                    <div class="posterInner">
                        <a href="MovieDetails.aspx?mediaId=<%#Eval("MediaId") %>">
                            <img src="<%# Eval("Poster") %>" height="200" width="100" />
                        </a>
                        <div class="posterTitle">
                            <%# Eval("Title") %>
                            (<%# Eval("Year") %>)
                        </div>
                    </div>
                </div>
            </ItemTemplate>
            <EmptyDataTemplate>
                No data was returned
            </EmptyDataTemplate>
        </asp:ListView>
    </div>

</asp:Content>

