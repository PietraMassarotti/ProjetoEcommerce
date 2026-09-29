<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cadastroCliente.aspx.cs" Inherits="entradaUser_cadastroCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Cadastro - Cliente</title>
     <link rel="stylesheet" type="text/css" href="~/views/css/entradaUser.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class ="caixa">

            <h1>Cadastro Cliente</h1>

            <p>Digite seu nome:</p>
            <asp:TextBox ID="txtNomeCliente" runat="server"></asp:TextBox>

            <p>Digite seu e-mail:</p>
            <asp:TextBox ID="txtEmailCliente" runat="server"></asp:TextBox>

            <p>Digite sua senha:</p>
            <!-- TextMode="Password" oculta a senha digitada -->
            <asp:TextBox ID="txtSenhaCliente" runat="server" TextMode="Password"></asp:TextBox>

            <p>Digite seu CPF:</p>
            <asp:TextBox ID="txtCpfCliente" runat="server"></asp:TextBox>

            <br />
            <br />

            <asp:Button ID="btnCadastroCliente" runat="server" Text="Cadastrar" OnClick="btnCadastroCliente_Click" />

            <br />
            <br />

            <asp:Label ID="lblMsg" runat="server" Text="Label" Visible="false"></asp:Label>
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Ir para login" Visible="false" OnClick="btnLogin_Click"/>

            <br />
            <br />

            <asp:Button ID="btnVoltar" runat="server" Text="Voltar para tela inicial" OnClick="btnVoltar_Click"/>

        </div>
    </form>
</body>
</html>