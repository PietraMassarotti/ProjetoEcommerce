<%@ Page Language="C#" AutoEventWireup="true" CodeFile="loginAdmin.aspx.cs" Inherits="entradaUser_loginAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <h1>Login Administrador</h1>

            <p>Digite seu e-mail:</p>
            <asp:TextBox ID="txtEmailAdmin" runat="server"></asp:TextBox>

            <p>Digite sua senha:</p>
            <asp:TextBox ID="txtSenhaAdmin" runat="server"></asp:TextBox>

            <br />
            <br />

            <asp:Button ID="btnLoginAdmin" runat="server" Text="Entrar" />

            <br />
            <br />

            <p>Ainda não possui uma conta? Clique abaixo!</p>
            <asp:Button ID="btnCadastroAdmin" runat="server" Text="Cadastre-se" />

        </div>
    </form>
</body>
</html>
