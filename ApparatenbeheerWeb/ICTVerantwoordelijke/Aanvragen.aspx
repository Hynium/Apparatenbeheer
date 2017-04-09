<%@ Page Title="" Language="C#" MasterPageFile="~/ICTVerantwoordelijkeSite.master" AutoEventWireup="true" CodeBehind="Aanvragen.aspx.cs" Inherits="ApparatenbeheerWeb.ICTVerantwoordelijke.Aanvragen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder4" runat="server">

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

    <br />

    <div id="commentaarForm" runat="server">

        <div class="form-group">
            <label for="commentaar" class="control-label col-sm-2">Commentaar:</label><br />
            <div class="col-sm-2">
                <input class="form-control" type="text" required="required"
                    placeholder="Commentaar" id="commentaar" runat="server" />
            </div>
        </div>
        <br />
        <div class="form-group">
            <div class="col-xs-1">
                <asp:Button ID="btnAccepteren" Text="Accepteren"
                    PostBackUrl="~/ICTVerantwoordelijke/Aanvragen.aspx" CssClass="btn btn-success" runat="server" OnClick="btnAccepteren_Click" />
            </div>
            <div class="col-xs-2">
                <asp:Button ID="btnWeigeren" Text="Weigeren"
                    PostBackUrl="~/ICTVerantwoordelijke/Aanvragen.aspx" CssClass="btn btn-danger" runat="server" OnClick="btnWeigeren_Click" />
            </div>
        </div>

    </div>

</asp:Content>
