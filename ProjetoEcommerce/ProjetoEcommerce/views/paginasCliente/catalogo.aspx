<%@ Page Title="" Language="C#" MasterPageFile="~/views/cabecalhos/MasterPage.master" AutoEventWireup="true" CodeFile="catalogo.aspx.cs" Inherits="views_paginasCliente_catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="catalogo">
        <h1>Catálogo de Produtos</h1>

        <%-- Usa repeater porque dessa maneira tem mais controle sobre o design(CSS) dos elementos HTML, ele repete tudo que está dentro da tag ItemTemplate --%>
        <asp:Repeater ID="rptProdutos" runat="server">
            <HeaderTemplate>
                <div class="catalogoGrid">
            </HeaderTemplate>

            <ItemTemplate>
                <div class="cardProduto">
                    <asp:HyperLink ID="lnkProduto" runat="server">
                        <asp:Label ID="lblNome" runat="server" CssClass="cardProdutoNome"></asp:Label>
                    </asp:HyperLink>

                    <p class="cardProdutoInfo">Categoria: <asp:Label ID="lblCategoria" runat="server"></asp:Label></p>
                    <p class="cardProdutoPreco">R$ <asp:Label ID="lblPreco" runat="server"></asp:Label></p>
                </div>
            </ItemTemplate>

            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
