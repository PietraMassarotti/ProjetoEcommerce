<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="entradaUser_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Página de Entrada</title>
     <link rel="stylesheet" type="text/css" href="~/views/css/entradaUser.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="caixa">

            <h1>Seja bem vindo ao Tudo e Mais um Pouco!</h1>

            <h2>Quem é você?</h2>

            <br />

            <asp:Button ID="btnCliente" runat="server" Text="Cliente" OnClick="btnCliente_Click" />

            <br />
            <br />

            <asp:Button ID="btnAdmin" runat="server" Text="Administrador" OnClick="btnAdmin_Click" />

        </div>
    </form>
</body>
</html>
