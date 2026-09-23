<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cadastroAdmin.aspx.cs" Inherits="entradaUser_cadastroAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <h1>Cadastro Administrador</h1>

            <p>Digite seu nome:</p>
            <asp:TextBox ID="txtNomeAdmin" runat="server"></asp:TextBox>

            <p>Digite seu e-mail:</p>
            <asp:TextBox ID="txtEmailAdmin" runat="server"></asp:TextBox>

            <p>Digite sua senha:</p>
            <asp:TextBox ID="txtSenhaAdmin" runat="server"></asp:TextBox>

            <br />
            <br />

            <asp:Button ID="btnCadastroAdmin" runat="server" Text="Cadastrar" />

        </div>
    </form>
</body>
</html>
