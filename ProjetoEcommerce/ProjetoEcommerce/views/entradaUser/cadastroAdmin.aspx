<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cadastroAdmin.aspx.cs" Inherits="entradaUser_cadastroAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Cadastro - Admin</title>
     <link rel="stylesheet" type="text/css" href="~/views/css/entradaUser.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class ="caixa">

            <h1>Cadastro Administrador</h1>

            <p>Digite seu nome:</p>
            <asp:TextBox ID="txtNomeAdmin" runat="server"></asp:TextBox>

            <p>Digite seu e-mail:</p>
            <asp:TextBox ID="txtEmailAdmin" runat="server"></asp:TextBox>

            <p>Digite sua senha:</p>
            <asp:TextBox ID="txtSenhaAdmin" runat="server" type="password"></asp:TextBox>

            <br />
            <br />

            <asp:Button ID="btnCadastroAdmin" runat="server" Text="Cadastrar" OnClick="btnCadastrarAdmin_Click"/>

            <br />
            <br />
                 <asp:Label ID="lblMsg" runat="server" Text="Label" Visible="false"></asp:Label>
            <br />
                 <asp:Button ID="btnLogin" runat="server" Text="Ir para login" Visible="false" OnClick="btnLogin_Click"/>
            <br />
            <br />

            <asp:Button ID="btnVoltar" runat="server" Text="Voltar para Tela inicial" OnClick="btnVoltar_Click" />

        </div>
    </form>
</body>
</html>
