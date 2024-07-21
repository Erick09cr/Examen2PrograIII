<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CandidatoGuardado.aspx.cs" Inherits="Examen.CandidatoGuardado" MasterPageFile="~/Site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Candidato Guardado</title>
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
            <h2>Candidato Guardado Exitosamente</h2>
            <p>El candidato ha sido registrado correctamente.</p>
        </div>
        <div class="imagen-registro">
             <img src="imagen/Candidato.png"/>
        </div>
    </div>
</asp:Content>