<%@ Page Title="" Language="C#" MasterPageFile="~/ICTVerantwoordelijkeSite.master" AutoEventWireup="true" CodeBehind="NieuwApparaat.aspx.cs" Inherits="ApparatenbeheerWeb.ICTVerantwoordelijke.NieuwApparaat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder4" runat="server">

    <div class="form-horizontal">
        <fieldset>

            <legend class="col-sm-offset-2">Nieuw apparaat</legend>

            <div class="form-group">
                <label class="control-label col-sm-2">Type: </label>
                <div class="col-sm-6">
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetApparaatTypes" TypeName="Apparatenbeheer.Business.Controller"></asp:ObjectDataSource>
                    <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server" DataSourceID="ObjectDataSource1" DataTextField="Omschrijving" DataValueField="Omschrijving"></asp:DropDownList>
                </div>
            </div>

            <div class="form-group">
                <label for="code" class="control-label col-sm-2">Code:</label>
                <div class="col-sm-6">
                    <input class="form-control" type="text"
                        placeholder="Code" id="code" runat="server" />
                </div>
            </div>

            <div class="form-group">
                <label for="omschrijving" class="control-label col-sm-2">Omschrijving:</label>
                <div class="col-sm-6">
                    <input class="form-control" type="text" required="required"
                        placeholder="Omschrijving" id="omschrijving" runat="server" />
                </div>
            </div>

            <div class="form-group">
                <label for="prijs" class="control-label col-sm-2">Prijs:</label>
                <div class="col-sm-6">
                    <input class="form-control" type="number" required="required"
                        placeholder="Prijs" id="prijs" runat="server" />
                </div>
            </div>

            <div class="form-group" style="margin-top: 25px">
                <asp:Label ID="foutboodschap" EnableViewState="true" runat="server"
                    CssClass="alert alert-danger col-sm-offset-2"></asp:Label>
            </div>
            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-4">
                    <asp:Button ID="btnToevoegen" Text="Toevoegen"
                        PostBackUrl="~/ICTVerantwoordelijke/NieuwApparaat.aspx" CssClass="btn btn-primary" runat="server" OnClick="btnToevoegen_Click" />
                </div>
            </div>

        </fieldset>
    </div>

</asp:Content>
