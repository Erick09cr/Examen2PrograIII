<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Votaciones.aspx.cs" Inherits="Examen.Votaciones" MasterPageFile="~/Site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Votaciones</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Votaciones</h2>
        <div class="form-group">
            <label for="txtCedulaVotante">Cédula del Votante:</label>
            <asp:TextBox ID="txtCedulaVotante" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="ddlCandidatos">Seleccionar Candidato:</label>
            <asp:DropDownList ID="ddlCandidatos" runat="server" CssClass="form-control">
                <asp:ListItem Text="-- Seleccione un Candidato --" Value=""></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Button ID="ButtonVotar" runat="server" Text="Votar" CssClass="btn btn-primary" OnClick="ButtonVotar_Click" />
        </div>
        <div>
            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger"></asp:Label>
        </div>
    </div>
</asp:Content>