<%@ Page Title="" Language="C#" MasterPageFile="~/views/cabecalhos/MasterPage.master" AutoEventWireup="true" CodeFile="catalogo.aspx.cs" Inherits="views_paginasCliente_catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h1>Catálogo de Produtos</h1>

    <%-- Usa repeater porque dessa maneira tem mais controle sobre o design(CSS) dos elementos HTML, ele repete tudo que está dentro da tag ItemTemplate --%>
    <asp:Repeater runat="server" DataSourceID="SqlDataSource1"><%-- A ligaçao com o banco é feita direta no repeater --%>
        <ItemTemplate>
        <div>
             <%-- É um Link que envia o id específico do produto(que o usuário quer acessar) para a página detalheProduto --%>
            <asp:HyperLink runat="server"
                <%-- Eval() pega o valor de uma coluna do banco de dados para o item atual. A sintaxe <%# %> é uma data-binding expression (um trecho de código usado em aplicações para conectar uma propriedade de um elemento visual diretamente a uma fonte de dados) --%>
                <%-- O segundo parâmetro serve para montar uma url com o código especifico do produto--%>
                NavigateUrl='<%# Eval("cod_produto", "~/views/paginasCliente/detalheProduto.aspx?id={0}") %>'>
                <h3><%# Eval("nome") %></h3>
            </asp:HyperLink>
             <%-- Mostra o preço do produto. O segundo parametro serve para formatação de string do tipo moeda. EX:Transforma 10.99 em R$10,99 (dependendo da configuraçao de local/país)--%>
            <p><%# Eval("preco_unitario", "{0:C}") %></p>
        </div>
    </ItemTemplate>
    </asp:Repeater>

    <%--Retorna a tabela inteira/todos os produtos cadastrados--%>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"SelectCommand="SELECT cod_produto, nome, preco_unitario FROM tbl_produtos"></asp:SqlDataSource>

</asp:Content>

