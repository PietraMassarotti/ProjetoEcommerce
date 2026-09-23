<%@ Page Title="" Language="C#" MasterPageFile="~/cabecalhos/MasterPage.master" AutoEventWireup="true" CodeFile="catalogo.aspx.cs" Inherits="paginasProdutos_catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br>
    <p>Catálogo de Produtos</p>
    <asp:TextBox ID="txtBuscarNome" runat="server"></asp:TextBox>

    <asp:DropDownList ID="ddlCores" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCores_SelectedIndexChanged">
        <asp:ListItem Text="Selecione..." Value="" />
        <asp:ListItem Text="Vermelho" Value="1" />
        <asp:ListItem Text="Azul" Value="2" />
        <asp:ListItem Text="Verde" Value="3" />
    </asp:DropDownList>

    <asp:ListView runat="server" DataSourceID="SqlDataSource1" GroupItemCount="3">
        <AlternatingItemTemplate>
            <td runat="server" style="">nome:
                <asp:Label ID="nomeLabel" runat="server" Text='<%# Eval("nome") %>' />
                <br />preco_unitario:
                <asp:Label ID="preco_unitarioLabel" runat="server" Text='<%# Eval("preco_unitario") %>' />
                <br />qtd_disponivel:
                <asp:Label ID="qtd_disponivelLabel" runat="server" Text='<%# Eval("qtd_disponivel") %>' />
                <br />cod_categoria:
                <asp:Label ID="cod_categoriaLabel" runat="server" Text='<%# Eval("cod_categoria") %>' />
                <br /></td>
        </AlternatingItemTemplate>
        <EditItemTemplate>
            <td runat="server" style="">nome:
                <asp:TextBox ID="nomeTextBox" runat="server" Text='<%# Bind("nome") %>' />
                <br />preco_unitario:
                <asp:TextBox ID="preco_unitarioTextBox" runat="server" Text='<%# Bind("preco_unitario") %>' />
                <br />qtd_disponivel:
                <asp:TextBox ID="qtd_disponivelTextBox" runat="server" Text='<%# Bind("qtd_disponivel") %>' />
                <br />cod_categoria:
                <asp:TextBox ID="cod_categoriaTextBox" runat="server" Text='<%# Bind("cod_categoria") %>' />
                <br />
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Atualizar" />
                <br />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancelar" />
                <br /></td>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <table runat="server" style="">
                <tr>
                    <td>Nenhum dado foi retornado.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <EmptyItemTemplate>
<td runat="server" />
        </EmptyItemTemplate>
        <GroupTemplate>
            <tr id="itemPlaceholderContainer" runat="server">
                <td id="itemPlaceholder" runat="server"></td>
            </tr>
        </GroupTemplate>
        <InsertItemTemplate>
            <td runat="server" style="">nome:
                <asp:TextBox ID="nomeTextBox" runat="server" Text='<%# Bind("nome") %>' />
                <br />preco_unitario:
                <asp:TextBox ID="preco_unitarioTextBox" runat="server" Text='<%# Bind("preco_unitario") %>' />
                <br />qtd_disponivel:
                <asp:TextBox ID="qtd_disponivelTextBox" runat="server" Text='<%# Bind("qtd_disponivel") %>' />
                <br />cod_categoria:
                <asp:TextBox ID="cod_categoriaTextBox" runat="server" Text='<%# Bind("cod_categoria") %>' />
                <br />
                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Inserir" />
                <br />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Limpar" />
                <br /></td>
        </InsertItemTemplate>
        <ItemTemplate>
            <td runat="server" style="">nome:
                <asp:Label ID="nomeLabel" runat="server" Text='<%# Eval("nome") %>' />
                <br />preco_unitario:
                <asp:Label ID="preco_unitarioLabel" runat="server" Text='<%# Eval("preco_unitario") %>' />
                <br />qtd_disponivel:
                <asp:Label ID="qtd_disponivelLabel" runat="server" Text='<%# Eval("qtd_disponivel") %>' />
                <br />cod_categoria:
                <asp:Label ID="cod_categoriaLabel" runat="server" Text='<%# Eval("cod_categoria") %>' />
                <br /></td>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table id="groupPlaceholderContainer" runat="server" border="0" style="">
                            <tr id="groupPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style="">
                        <asp:DataPager ID="DataPager1" runat="server" PageSize="12">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <td runat="server" style="">nome:
                <asp:Label ID="nomeLabel" runat="server" Text='<%# Eval("nome") %>' />
                <br />preco_unitario:
                <asp:Label ID="preco_unitarioLabel" runat="server" Text='<%# Eval("preco_unitario") %>' />
                <br />qtd_disponivel:
                <asp:Label ID="qtd_disponivelLabel" runat="server" Text='<%# Eval("qtd_disponivel") %>' />
                <br />cod_categoria:
                <asp:Label ID="cod_categoriaLabel" runat="server" Text='<%# Eval("cod_categoria") %>' />
                <br /></td>
        </SelectedItemTemplate>
    </asp:ListView>

<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT [nome], [preco_unitario], [qtd_disponivel], [cod_categoria] FROM [tbl_produtos]"></asp:SqlDataSource>
</asp:Content>

