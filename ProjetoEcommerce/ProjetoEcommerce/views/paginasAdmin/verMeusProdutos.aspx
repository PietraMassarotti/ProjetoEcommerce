<%@ Page Title="" Language="C#" MasterPageFile="~/views/cabecalhos/MasterPage.master"
    AutoEventWireup="true"
    CodeFile="verMeusProdutos.aspx.cs"
    Inherits="views_paginasAdmin_visualizarMeusProdutos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="produto">

        <h1>Meus Produtos</h1>
        <br />

        <p>Bem-vindo à área do administrador!</p>

        <br />

        <asp:Button
            ID="btnNovosProdutos"
            runat="server"
            CssClass="botao"
            Text="Cadastrar Novos Produtos"
            OnClick="btnNovosProdutos_Click" />

        <br />
        <br />

        <asp:GridView
            ID="GridView1"
            runat="server"
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="475px">

            <AlternatingRowStyle BackColor="White" />

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

                //gridview para ver os produtos cadastrados pelo administrador, com opção de editar cada produto
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
    </div>

</asp:Content>