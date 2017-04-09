<%@ Page Title="" Language="C#" MasterPageFile="~/ICTVerantwoordelijkeSite.master" AutoEventWireup="true" CodeBehind="Gebruikers.aspx.cs" Inherits="ApparatenbeheerWeb.ICTVerantwoordelijke.Gebruikers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder4" runat="server">
    <asp:GridView ID="GebruikerGrid" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id">
            <ItemStyle CssClass="col-xs-1" />
            </asp:BoundField>
            <asp:BoundField DataField="Gebruikersnaam" HeaderText="Gebruikersnaam">
            <ItemStyle CssClass="col-xs-2" />
            </asp:BoundField>
            <asp:BoundField DataField="Naam" HeaderText="Naam">
            <ItemStyle CssClass="col-xs-3" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
</asp:Content>
