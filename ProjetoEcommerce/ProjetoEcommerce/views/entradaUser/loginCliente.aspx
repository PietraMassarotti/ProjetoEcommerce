<%@ Page Language="C#" AutoEventWireup="true" CodeFile="loginCliente.aspx.cs" Inherits="entradaUser_loginCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <h1>Login Cliente</h1>

            <p>Digite seu e-mail:</p>
            <asp:TextBox ID="txtEmailCliente" runat="server"></asp:TextBox>

            <p>Digite sua senha:</p>
            <asp:TextBox ID="txtSenhaCliente" runat="server"></asp:TextBox>

            <br />
            <br />

            <asp:Button ID="btnLoginCliente" runat="server" Text="Entrar" />

            <br />
            <br />

            <p>Ainda não possui uma conta? Clique abaixo!</p>
            <asp:Button ID="btnCadastroCliente" runat="server" Text="Cadastre-se" OnClick="btnCadastroCliente_Click" />

            <br />
            <br />

            <asp:Button ID="btnVoltar01" runat="server" Text="Voltar" OnClick="btnVoltar01_Click" />

        </div>
    </form>
</body>
</html>
