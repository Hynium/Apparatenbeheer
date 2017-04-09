<%@ Page Title="" Language="C#" MasterPageFile="~/WerknemerSite.master" AutoEventWireup="true" CodeBehind="Aanvragen.aspx.cs" Inherits="ApparatenbeheerWeb.Werknemer.Aanvragen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder2" runat="server">

    <asp:GridView ID="AanvragenGrid" runat="server" AutoGenerateColumns="False" DataKeyNames="Id,Type,Status" OnSelectedIndexChanged="AanvragenGrid_SelectedIndexChanged">
        <Columns>
            <asp:CommandField HeaderText="Select" ShowSelectButton="True">
                <ItemStyle CssClass="col-xs-1" />
            </asp:CommandField>
            <asp:BoundField DataField="Id" HeaderText="Id">
                <ItemStyle CssClass="col-xs-2" />
            </asp:BoundField>
            <asp:BoundField DataField="Type" HeaderText="Aangevraagd Type">
                <ItemStyle CssClass="col-xs-3" />
            </asp:BoundField>
            <asp:BoundField DataField="Status" HeaderText="Status">
                <ItemStyle CssClass="col-xs-4" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>

    <br />
    <br />

    <asp:GridView ID="SelectedApparaatGrid" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Aanvrager" HeaderText="Aangevraagd door">
                <ItemStyle CssClass="col-xs-1" />
            </asp:BoundField>
            <asp:BoundField DataField="Ontvanger" HeaderText="Aangevraagd voor">
                <ItemStyle CssClass="col-xs-2" />
            </asp:BoundField>
            <asp:BoundField DataField="ICTVerantwoordelijke" HeaderText="Verantwoordelijke">
                <ItemStyle CssClass="col-xs-3" />
            </asp:BoundField>
            <asp:BoundField DataField="Status" HeaderText="Status">
            <ItemStyle CssClass="col-xs-4" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>

    <div id="commentaar" class="form-control" runat="server">
        <label for="tbCommentaar" class="control-label col-sm-2">Commentaar: </label>
        <asp:TextBox ID="tbCommentaar" runat="server" ReadOnly="True" CssClass="col-sm-4"></asp:TextBox>
    </div>
</asp:Content>
