<%@ Page Title="" Language="C#" MasterPageFile="~/views/cabecalhos/MasterPage.master" AutoEventWireup="true" CodeFile="catalogo.aspx.cs" Inherits="views_paginasCliente_catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h1>Catálogo de Produtos</h1>

    <asp:Repeater runat="server" DataSourceID="SqlDataSource1">
        <ItemTemplate>
        <div class="card-produto">
            <asp:HyperLink runat="server"
                NavigateUrl='<%# Eval("cod_produto", "~/views/paginasCliente/detalheProduto.aspx?id={0}") %>'>
                <h3><%# Eval("nome") %></h3>
            </asp:HyperLink>
            <p><%# Eval("preco_unitario", "{0:C}") %></p>
        </div>
    </ItemTemplate>
    </asp:Repeater>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT cod_produto, nome, preco_unitario FROM tbl_produtos"></asp:SqlDataSource>

</asp:Content>

