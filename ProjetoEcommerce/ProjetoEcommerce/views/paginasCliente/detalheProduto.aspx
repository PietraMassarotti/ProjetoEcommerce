<%@ Page Title="" Language="C#" MasterPageFile="~/views/cabecalhos/MasterPage.master" AutoEventWireup="true" CodeFile="detalheProduto.aspx.cs" Inherits="views_paginasCliente_detalheProduto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <%--Labels vazias, sao preenchidas no code behind--%>
    <h2><asp:Label ID="lblNome" runat="server" /></h2>
    <p><asp:Label ID="lblDescricao" runat="server" /></p>
    <p>Preço: <asp:Label ID="lblPreco" runat="server" /></p>
    <p>Quantidade Disponivel: <asp:Label ID="lblQtd" runat="server" /></p>

    <p>Quantidade:</p>
    <asp:TextBox ID="txtQuantidade" runat="server" TextMode="Number" Text="1" Width="60px" />
    <asp:Button ID="btnAdicionar" runat="server" Text="Adicionar ao carrinho"/>
    <asp:Label ID="lblMsg" runat="server" Visible="false"/>

</asp:Content>

