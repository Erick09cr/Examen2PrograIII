<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Examen.Inicio" MasterPageFile="~/Site.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Inicio - Sistema de Votaciones</title>
    <link rel="stylesheet" href="css/styles.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container">
        <div class="imagen-inicio">
            <img src="Imagen/voto-image.PNG" />
        </div>
        <div >
            <h2>Bienvenido al Sistema de Votaciones</h2>
            <p>Sistema electrónico para registrar candidatos,usuario, votaciones y mostrar resultados.</p>
        </div>
    </div>
</asp:Content>