<%@ Page Title="" Language="C#" MasterPageFile="~/views/cabecalhos/MasterPage.master" AutoEventWireup="true" CodeFile="contato.aspx.cs" Inherits="views_cabecalhos_contato" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="paginaGeral paginaEstreita">
    <h1>Fale Conosco</h1>

    <p>Seu Nome:</p>
    <asp:TextBox ID="txtNome" runat="server" CssClass="campo"></asp:TextBox>

    <p>Seu E-mail:</p>
    <asp:TextBox ID="txtEmail" runat="server" CssClass="campo"></asp:TextBox>

    <p>Assunto:</p>
    <asp:TextBox ID="txtAssunto" runat="server" CssClass="campo"></asp:TextBox>

    <p>Mensagem:</p>
    <asp:TextBox ID="txtMensagem" runat="server" TextMode="MultiLine" Rows="5" CssClass="campo"></asp:TextBox>

    <br /><br />
    <asp:Button ID="btnEnviar" runat="server" Text="Enviar Mensagem" CssClass="enviar" OnClick="btnEnviar_Click" />

    <br /><br />
    <asp:Label ID="lblMsg" runat="server" Visible="false" CssClass="msg"></asp:Label>
</div>

</asp:Content>

