<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Votante.aspx.cs" Inherits="Examen.Votante" MasterPageFile="~/Site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Registro de Votante</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Registro de Votante</h2>
        <div class="form-group">
            <label for="txtCedula">Cédula:</label>
            <asp:TextBox ID="txtCedula" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtNombre">Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtEdad">Edad:</label>
            <asp:TextBox ID="txtEdad" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar Votante" CssClass="btn btn-primary" OnClick="btnRegistrar_Click" />
        </div>
        <div>
            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger"></asp:Label>
        </div>
    </div>
</asp:Content>
