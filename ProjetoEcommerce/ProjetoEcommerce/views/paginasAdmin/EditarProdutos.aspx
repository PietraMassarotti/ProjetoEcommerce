<%@ Page Language="C#" AutoEventWireup="true"
    CodeFile="EditarProdutos.aspx.cs"
    Inherits="paginasProdutos_editarProduto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <meta http-equiv="Content-Type"
        content="text/html; charset=utf-8"/>

    <title>Editar Produto</title>

</head>

<body>

    <form id="form1" runat="server">

        <h1>Editar Produto</h1>

        <p>Nome:</p>

        <asp:TextBox ID="txtNomeProduto" runat="server">
        </asp:TextBox>

        <p>Preço:</p>

        <asp:TextBox ID="txtPrecoProduto" runat="server"></asp:TextBox>

        <p>Descrição:</p>

        <asp:TextBox ID="txtDescricaoProduto" runat="server"></asp:TextBox>

        <p>Validade:</p>

        <asp:TextBox ID="txtValidadeProduto" runat="server" TextMode="Date"></asp:TextBox>

        <p>Quantidade disponível:</p>

        <asp:TextBox ID="txtQtdDisponivelProduto" runat="server"></asp:TextBox>

        <br />
        <br />

        <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>

        <br />
        <br />

        <asp:Button ID="btnSalvar" runat="server" Text="Salvar alterações" OnClick="btnSalvar_Click" />

        <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />

    </form>

</body>

</html>