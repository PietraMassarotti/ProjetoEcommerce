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

            <asp:Button ID="btnCadastroCliente" runat="server" Text="Cadastrar" />

        </div>
    </form>
</body>
</html>
