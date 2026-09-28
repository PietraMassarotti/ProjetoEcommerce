<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cadastroCliente.aspx.cs" Inherits="entradaUser_cadastroCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <h1>Cadastro Cliente</h1>

            <p>Digite seu nome:</p>
            <asp:TextBox ID="txtNomeCliente" runat="server"></asp:TextBox>

            <p>Digite seu e-mail:</p>
            <asp:TextBox ID="txtEmailCliente" runat="server"></asp:TextBox>

            <p>Digite sua senha:</p>
            <asp:TextBox ID="txtSenhaCliente" runat="server"></asp:TextBox>

            <p>Digite seu CPF:</p>
            <asp:TextBox ID="txtCpfCliente" runat="server"></asp:TextBox>

            <br />
            <br />

            <asp:Button ID="btnCadastroCliente" runat="server" Text="Cadastrar" OnClick="btnCadastroCliente_Click" />

            <br />
            <br />

            <asp:Label ID="lblMsg" runat="server" Text="Label" Visible ="false"></asp:Label>

            <br />
            <br />

            <asp:Button ID="btnVoltar" runat="server" Text="Voltar para tela inicial" OnClick="btnVoltar_Click"/>

            <br />
            <br />

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="cod_cliente" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="cod_cliente" HeaderText="cod_cliente" InsertVisible="False" ReadOnly="True" SortExpression="cod_cliente" />
                    <asp:BoundField DataField="nome" HeaderText="nome" SortExpression="nome" />
                    <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                    <asp:BoundField DataField="senha" HeaderText="senha" SortExpression="senha" />
                    <asp:BoundField DataField="cpf" HeaderText="cpf" SortExpression="cpf" />
                    <asp:BoundField DataField="tipo_user" HeaderText="tipo_user" SortExpression="tipo_user" />
                </Columns>
            </asp:GridView>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [tbl_clientes]"></asp:SqlDataSource>

        </div>
    </form>
</body>
</html>
