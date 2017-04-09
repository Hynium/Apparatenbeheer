<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ApparatenbeheerWeb.Account.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="EigenRolMenu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentPlaceHolder1" runat="server">
    <asp:Login ID="LoginForm" DestinationPageUrl="~/default.aspx" runat="server" OnAuthenticate="LoginForm_Authenticate" RememberMeText="Remember me">
    </asp:Login>
</asp:Content>
