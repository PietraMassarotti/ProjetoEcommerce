<%@ Page Title="" Language="C#" MasterPageFile="~/views/cabecalhos/MasterPage.master" AutoEventWireup="true" CodeFile="cadastroProduto.aspx.cs" Inherits="paginasProdutos_cadastroProduto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Adicionar Produto</h1>

    <p>Nome:</p>
    <asp:TextBox ID="txtNomeProduto" runat="server"></asp:TextBox>

    <p>Preço unitário:</p>
    <asp:TextBox ID="txtPrecoProduto" runat="server"></asp:TextBox>

    <p>Descrição:</p>
    <asp:TextBox ID="txtDescricaoProduto" runat="server"></asp:TextBox>

    <p>Validade:</p>
    <asp:TextBox ID="txtvalidadeProduto" runat="server"></asp:TextBox>

    <br />
    <br />

    <br />

    <p>Quantidade Disponivel:</p>
    <asp:TextBox ID="txtQtdDisponivelProduto" runat="server"></asp:TextBox>

    <br />
    <br />

    <asp:Button ID="btnCadastroCliente" runat="server" Text="Adicionar" />
</asp:Content>

