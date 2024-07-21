<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Resultados.aspx.cs" Inherits="Examen.Resultados" MasterPageFile="~/Site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Resultados de la Elección</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Resultados de la Elección</h2>

    <asp:Label ID="lblGanador" runat="server" CssClass="font-weight-bold text-success"></asp:Label>

    <asp:GridView ID="GridViewResultados" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Candidato" HeaderText="Candidato" />
            <asp:BoundField DataField="VotosObtenidos" HeaderText="Votos Obtenidos" />
            <asp:BoundField DataField="PorcentajeVotos" HeaderText="Porcentaje de Votos" />
        </Columns>
    </asp:GridView>

    <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger"></asp:Label>
</asp:Content>