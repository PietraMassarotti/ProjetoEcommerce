<%@ Page Language="C#" AutoEventWireup="true"
    CodeFile="verMeusProdutos.aspx.cs"
    Inherits="views_paginasAdmin_visualizarMeusProdutos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <meta http-equiv="Content-Type"
        content="text/html; charset=utf-8"/>

    <title>Meus Produtos - Admin</title>

    <link rel="stylesheet"
        type="text/css"
        href="~/views/css/entradaUser.css" />

</head>

<body>

    <form id="form1" runat="server">

        <div class="caixa">

            <h1>Meus Produtos</h1>

            <p>Bem-vindo à área do administrador!</p>

            <asp:Button
                ID="btnNovosProdutos"
                runat="server"
                Text="Cadastrar Novos Produtos"
                OnClick="btnNovosProdutos_Click" />

            <br />
            <br />

            <asp:Button
                ID="BtnEditarProdutos"
                runat="server"
                Text="Editar Produtos"
                OnClick="BtnEditarProdutos_Click" />

            <br />
            <br />

            <asp:GridView
                ID="GridView1"
                runat="server"
                AutoGenerateColumns="False">

                <Columns>

                    <asp:BoundField
                        DataField="nome"
                        HeaderText="Nome" />

                    <asp:BoundField
                        DataField="preco_unitario"
                        HeaderText="Preço" />

                    <asp:BoundField
                        DataField="descricao"
                        HeaderText="Descrição" />

                    <asp:BoundField
                        DataField="validade"
                        HeaderText="Validade" />

                    <asp:HyperLinkField
                        Text="Editar"
                        HeaderText="Ação"
                        DataNavigateUrlFields="cod_produto"
                        DataNavigateUrlFormatString="EditarProdutos.aspx?id={0}" />

                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>