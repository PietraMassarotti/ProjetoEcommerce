<%@ Page Language="C#" AutoEventWireup="true" CodeFile="menu.aspx.cs" Inherits="views_menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
<div style="background-color: #2c3e50; padding: 15px; font-family: Arial, sans-serif;">
            <asp:HyperLink ID="hlCatalogo" runat="server" NavigateUrl="~/views/paginasCliente/catalogo.aspx" ForeColor="White" Font-Bold="true" Style="margin-right: 20px; text-decoration: none;">Catálogo</asp:HyperLink>
            <asp:HyperLink ID="hlCompras" runat="server" NavigateUrl="~/views/paginasCliente/historicoCompras.aspx" ForeColor="White" Font-Bold="true" Style="margin-right: 20px; text-decoration: none;">Ver Compras</asp:HyperLink>
            <asp:HyperLink ID="hlSobre" runat="server" NavigateUrl="~/views/entradaUser/sobre.aspx" ForeColor="White" Font-Bold="true" Style="margin-right: 20px; text-decoration: none;">Sobre Nós</asp:HyperLink>
            <asp:HyperLink ID="hlPlanos" runat="server" NavigateUrl="~/views/entradaUser/planos.aspx" ForeColor="White" Font-Bold="true" Style="margin-right: 20px; text-decoration: none;">Planos</asp:HyperLink>
            <asp:HyperLink ID="hlContato" runat="server" NavigateUrl="~/views/entradaUser/contato.aspx" ForeColor="White" Font-Bold="true" Style="margin-right: 20px; text-decoration: none;">Fale Conosco</asp:HyperLink>
            
            <asp:HyperLink ID="hlSair" runat="server" NavigateUrl="~/views/entradaUser/loginCliente.aspx" ForeColor="#E74C3C" Font-Bold="true" Style="float: right; text-decoration: none;">Sair</asp:HyperLink>
        </div>
    </form>
</body>
</html>
