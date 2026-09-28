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

            <asp:Button ID="btnLoginAdmin" runat="server" Text="Entrar" OnClick="btnLoginAdmin_Click" />

            <br />
            <br />

            <asp:Label ID="lblMsg" runat="server" Text="Label" Visible="false"></asp:Label>

            <asp:Button ID="btnVoltar02" runat="server" Text="Voltar" OnClick="btnVoltar02_Click" />

        </div>
    </form>
    
</body>
</html>
