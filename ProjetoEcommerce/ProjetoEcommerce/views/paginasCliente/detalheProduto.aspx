<%@ Page Title="" Language="C#" MasterPageFile="~/views/cabecalhos/MasterPage.master" AutoEventWireup="true" CodeFile="detalheProduto.aspx.cs" Inherits="views_paginasCliente_detalheProduto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<div class="produto">

    <%--Labels vazias, sao preenchidas no code behind--%>
    <h2 class="produtoNome"><asp:Label ID="lblNome" runat="server" /></h2>
    <p class="produtoDescricao"><asp:Label ID="lblDescricao" runat="server" /></p>

    <div class="produtoInfo">
        <p><strong>Categoria: </strong><asp:Label ID="lblCategoria" runat="server" /></p>
        <p><strong>Vendedor: </strong><asp:Label ID="lblVendedor" runat="server" /></p>
        <p><strong>Quantidade Disponível: </strong><asp:Label ID="lblQtd" runat="server" /></p>
    </div>

    <p class="produtoPreco">
        Preço: <asp:Label ID="lblPreco" runat="server" />
    </p>

    <div class="produtoBotoes">
        <p>Escolha a quantidade de itens desejados:</p>
        <asp:TextBox ID="txtQuantidade" runat="server" CssClass="qtdDispo" TextMode="Number" Text="1" />
        <asp:Button ID="btnAdicionar" runat="server" CssClass="botao" Text="Adicionar ao carrinho" OnClick="btnAdicionar_Click" />
    </div>

    <asp:Label ID="lblMsg" runat="server" Visible="false" />

    <br />

    <asp:Button ID="btnVoltar" runat="server" CssClass="botao" Text="Voltar para catálogo" OnClick="btnVoltar_Click" />

</div>

</asp:Content>

