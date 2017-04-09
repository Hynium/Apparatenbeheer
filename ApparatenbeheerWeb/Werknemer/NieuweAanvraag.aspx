<%@ Page Title="" Language="C#" MasterPageFile="~/WerknemerSite.master" AutoEventWireup="true" CodeBehind="NieuweAanvraag.aspx.cs" Inherits="ApparatenbeheerWeb.Werknemer.NieuweAanvraag" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder2" runat="server">

    <div class="form-horizontal">
        <fieldset>

            <legend class="col-sm-offset-2">Nieuwe aanvraag</legend>

            <div class="form-group">
                <label for="verantwoordelijke" class="control-label col-sm-2">Gebruikersnaam verantwoordelijke:</label>
                <div class="col-sm-6">
                    <input class="form-control" type="text"
                        placeholder="Verantwoordelijke" id="verantwoordelijke" runat="server" />
                </div>
            </div>

            <div class="form-group">
                <label for="ontvanger" class="control-label col-sm-2">Gebruikersnaam ontvanger:</label>
                <div class="col-sm-6">
                    <input class="form-control" type="text" required="required"
                        placeholder="Ontvanger" id="ontvanger" runat="server" />
                </div>
            </div>

            <div class="form-group">
                <label class="control-label col-sm-2">Type: </label>
                <div class="col-sm-6">
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetApparaatTypes" TypeName="Apparatenbeheer.Business.Controller"></asp:ObjectDataSource>
                    <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server" DataSourceID="ObjectDataSource1" DataTextField="Omschrijving" DataValueField="Omschrijving"></asp:DropDownList>
                </div>
            </div>

            <div class="form-group" style="margin-top: 25px">
                <asp:Label ID="foutboodschap" EnableViewState="true" runat="server"
                    CssClass="alert alert-danger col-sm-offset-2"></asp:Label>
            </div>
            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-4">
                    <asp:Button ID="btnAanvragen" Text="Aanvragen"
                        PostBackUrl="~/Werknemer/NieuweAanvraag.aspx" CssClass="btn btn-primary" runat="server" OnClick="btnAanvragen_Click" />
                </div>
            </div>

        </fieldset>
    </div>

</asp:Content>
