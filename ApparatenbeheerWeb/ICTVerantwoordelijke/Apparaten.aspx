<%@ Page Title="" Language="C#" MasterPageFile="~/ICTVerantwoordelijkeSite.master" AutoEventWireup="true" CodeBehind="Apparaten.aspx.cs" Inherits="ApparatenbeheerWeb.ICTVerantwoordelijke.Apparaten" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder4" runat="server">
    <asp:GridView ID="ApparatenGrid" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id">
            <ItemStyle CssClass="col-xs-2" />
            </asp:BoundField>
            <asp:BoundField DataField="Type" HeaderText="Type">
            <ItemStyle CssClass="col-xs-3" />
            </asp:BoundField>
            <asp:BoundField DataField="Code" HeaderText="Code">
            <ItemStyle CssClass="col-xs-4" />
            </asp:BoundField>
            <asp:BoundField DataField="Omschrijving" HeaderText="Omschrijving">
            <ItemStyle CssClass="col-xs-5" />
            </asp:BoundField>
            <asp:BoundField DataField="Prijs" HeaderText="Prijs">
            <ItemStyle CssClass="col-xs-6" />
            </asp:BoundField>
            <asp:BoundField DataField="Gebruiker" HeaderText="Gebruiker">
            <ItemStyle CssClass="col-xs-7" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>

</asp:Content>
