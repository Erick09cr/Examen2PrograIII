<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VotoRegistrado.aspx.cs" Inherits="Examen.VotoRegistrado" MasterPageFile="~/Site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Voto Registrado</title>
    <link rel="stylesheet" href="css/styles.css" />
    <style>
        .container {
            margin-top: 50px;
            text-align: center;
        }
        .message {
            margin-bottom: 30px;
        }

    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="message">
            <h2>Voto Registrado</h2>
            <p>Gracias por participar en nuestras elecciones.</p>
        </div>
        <div class="imagen-registro">
             <img src="imagen/votoexitoso.png"/>
        </div>
    </div>
</asp:Content>
