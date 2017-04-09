<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registratie.aspx.cs" Inherits="ApparatenbeheerWeb.Account.Registratie" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="EigenRolMenu" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="contentPlaceHolder1" runat="server">

    <div class="form-horizontal">
        <fieldset>

            <legend class="col-sm-offset-2">Nieuwe gebruiker</legend>

            <div class="form-group">
                <label for="gebruikersnaam" class="control-label col-sm-2">Gebruikersnaam:</label>
                <div class="col-sm-4">
                    <input class="form-control" type="text" required="required" 
                        placeholder="Gebruikersnaam" id="gebruikersnaam" runat="server" />
                </div>
            </div>

            <div class="form-group">
                <label for="paswoord" class="control-label col-sm-2">Wachtwoord:</label>
                <div class="col-sm-4">
                    <input class="form-control" type="password" required="required" 
                        placeholder="Wachtwoord" id="paswoord" runat="server" />
                </div>
            </div>

            <div class="form-group">
                <label for="paswoordHerhaling" class="control-label col-sm-2">Herhaal wachtwoord:</label>
                <div class="col-sm-4">
                    <input class="form-control" type="password" required="required" 
                        placeholder="Wachtwoord" id="paswoordHerhaling" runat="server" />
                </div>
            </div>

            <div class="form-group">
                <label for="voornaam" class="control-label col-sm-2">Voornaam:</label>
                <div class="col-sm-4">
                    <input class="form-control" type="text" required="required" 
                        placeholder="Voornaam" id="voornaam" runat="server" />
                </div>
            </div>

            <div class="form-group">
                <label for="achternaam" class="control-label col-sm-2">Achternaam:</label>
                <div class="col-sm-4">
                    <input class="form-control" type="text" required="required" 
                        placeholder="Achternaam" id="achternaam" runat="server" />
                </div>
            </div>

            <div class="form-group" style="margin-top: 25px">
                <asp:Label ID="foutboodschap" EnableViewState="true" runat="server" 
                    CssClass="alert alert-danger col-sm-offset-2"></asp:Label>
            </div>
            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-4">
                    <asp:Button ID="btnRegistreren" Text="Registreren" OnClick="btnRegistreren_Click" 
                        PostBackUrl="~/Account/Registratie.aspx" CssClass="btn btn-primary" runat="server" />
                </div>
            </div>

        </fieldset>
    </div>

</asp:Content>
