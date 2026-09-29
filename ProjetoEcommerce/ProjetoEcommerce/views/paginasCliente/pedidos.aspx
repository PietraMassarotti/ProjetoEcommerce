<%@ Page Title="" Language="C#" MasterPageFile="~/views/cabecalhos/MasterPage.master" AutoEventWireup="true" CodeFile="pedidos.aspx.cs" Inherits="views_paginasCliente_pedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="catalogo">
        <h1>Pedidos</h1>

        <%-- Usa repeater porque dessa maneira tem mais controle sobre o design(CSS) dos elementos HTML, ele repete tudo que está dentro da tag ItemTemplate --%>
        <asp:Repeater ID="rptProdutos" runat="server">
            <HeaderTemplate>
                <div class="catalogoGrid">
            </HeaderTemplate>

            <ItemTemplate>
                <div class="cardProduto">
                    <p class="cardProdutoNome">Código: <asp:Label ID="lblCod" runat="server"></asp:Label></p>
                    <p class="cardProdutoInfo">Produtos: <asp:Label ID="lblProd" runat="server"></asp:Label></p>
                    <p class="cardProdutoInfo">Data que pedido foi realizado: <asp:Label ID="lblData" runat="server"></asp:Label></p>
                    <p class="cardProdutoPreco">Data Entrega: <asp:Label ID="lblEntrega" runat="server"></asp:Label></p>
                </div>
            </ItemTemplate>

            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>
    </div>


</asp:Content>

