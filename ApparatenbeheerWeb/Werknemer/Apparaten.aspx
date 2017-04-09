<%@ Page Title="" Language="C#" MasterPageFile="~/WerknemerSite.master" AutoEventWireup="true" CodeBehind="Apparaten.aspx.cs" Inherits="ApparatenbeheerWeb.Werknemer.Apparaten" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder2" runat="server">
    
    <asp:GridView ID="ApparatenGrid" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id">
            <ItemStyle CssClass="col-xs-1" />
            </asp:BoundField>
            <asp:BoundField DataField="Type" HeaderText="Type">
            <ItemStyle CssClass="col-xs-2" />
            </asp:BoundField>
            <asp:BoundField DataField="Code" HeaderText="Code">
            <ItemStyle CssClass="col-xs-3" />
            </asp:BoundField>
            <asp:BoundField DataField="Omschrijving" HeaderText="Omschrijving">
            <ItemStyle CssClass="col-xs-4" />
            </asp:BoundField>
            <asp:BoundField DataField="Prijs" DataFormatString="{0:C2}" HeaderText="Prijs">
            <ItemStyle CssClass="col-xs-5" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
    
</asp:Content>
