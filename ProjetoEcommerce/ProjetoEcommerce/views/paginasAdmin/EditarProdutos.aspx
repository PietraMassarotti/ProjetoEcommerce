<%@ Page Title="" Language="C#" MasterPageFile="~/views/cabecalhos/MasterPage.master"
    AutoEventWireup="true"
    CodeFile="EditarProdutos.aspx.cs"
    Inherits="paginasProdutos_editarProduto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="produto">

        <h1>Editar Produto</h1>
        <br />
        <p>Nome:</p>
        <asp:TextBox ID="txtNomeProduto" runat="server" CssClass="qtdDispo"></asp:TextBox>
        <br />
        <br />
        <p>Preço:</p>
        <asp:TextBox ID="txtPrecoProduto" runat="server" CssClass="qtdDispo"></asp:TextBox>
        <br />
        <br />
        <p>Descrição:</p>
        <asp:TextBox ID="txtDescricaoProduto" runat="server" CssClass="qtdDispo"></asp:TextBox>
        <br />
        <br />
        <p>Validade:</p>
        <asp:TextBox ID="txtValidadeProduto" runat="server" CssClass="qtdDispo" TextMode="Date"></asp:TextBox>
        <br />
        <br />
        <p>Quantidade disponível:</p>
        <asp:TextBox ID="txtQtdDisponivelProduto" runat="server" CssClass="qtdDispo"></asp:TextBox>

        <br />

        <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>

        <br />

        <asp:Button ID="btnSalvar" runat="server" CssClass="botao" Text="Salvar alterações" OnClick="btnSalvar_Click" />
        <br />
        <br />
        <asp:Button ID="btnVoltar" runat="server" CssClass="botao" Text="Voltar" OnClick="btnVoltar_Click" />

    </div>

</asp:Content>