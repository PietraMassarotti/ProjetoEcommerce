<%@ Page Title="" Language="C#" MasterPageFile="~/views/cabecalhos/MasterPage.master" AutoEventWireup="true" CodeFile="cadastroProduto.aspx.cs" Inherits="paginasProdutos_cadastroProduto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="produto">

        <h1>Adicionar Produto</h1>
        <br />
        <p>Nome:</p>
        <asp:TextBox ID="txtNomeProduto" CssClass="qtdDispo" runat="server"></asp:TextBox>
        <br />
        <br />
        <p>Preço unitário:</p>
        <asp:TextBox ID="txtPrecoProduto" CssClass="qtdDispo" runat="server"></asp:TextBox>
        <br />
        <br />
        <p>Descrição:</p>
        <asp:TextBox ID="txtDescricaoProduto" CssClass="qtdDispo" runat="server"></asp:TextBox>
        <br />
        <br />
        <p>Validade:</p>
        <asp:TextBox ID="txtvalidadeProduto" runat="server" CssClass="qtdDispo" TextMode="Date"></asp:TextBox>
        <br />
        <br />
        <p>Quantidade Disponível:</p>
        <asp:TextBox ID="txtQtdDisponivelProduto" runat="server" CssClass="qtdDispo"></asp:TextBox>

        <br />

        <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>

        <br />

        <asp:Button ID="btnCadastrarProduto"
            runat="server"
            CssClass="botao"
            Text="Adicionar"
            OnClick="btnCadastrarProduto_Click" />
        <br />
        <br />
        <asp:Button ID="btnVoltar" runat="server" CssClass="botao" Text="Voltar" OnClick="btnVoltar_Click" />

    </div>

</asp:Content>