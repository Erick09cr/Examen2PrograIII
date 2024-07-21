<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="IngresarCandidatos.aspx.cs" Inherits="Examen.IngresarCandidatos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   
    <div class="container">
        <h2>Ingresar Candidatos</h2>
        <div class="form-group">
            <label for="txtCedula">Cédula:</label>
            <asp:TextBox ID="txtCedula" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtNombre">Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtPartidoPolitico">Partido Político:</label>
            <asp:TextBox ID="txtPartidoPolitico" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Button ID="ButtonGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="ButtonGuardar_Click" />
        </div>
    </div>
</asp:Content>