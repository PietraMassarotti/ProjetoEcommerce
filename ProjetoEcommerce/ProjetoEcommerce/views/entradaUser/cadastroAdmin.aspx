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
            <asp:TextBox ID="txtSenhaAdmin" runat="server" type="password"></asp:TextBox>

            <br />
            <br />

            <asp:Button ID="btnCadastroAdmin" runat="server" Text="Cadastrar" OnClick="btnCadastrarAdmin_Click"/>

            <br />
            <br />
                 <asp:Label ID="lblMsg" runat="server" Text="Label" Visible="false"></asp:Label>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="cod_admin" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="cod_admin" HeaderText="cod_admin" InsertVisible="False" ReadOnly="True" SortExpression="cod_admin" />
                    <asp:BoundField DataField="nome" HeaderText="nome" SortExpression="nome" />
                    <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                    <asp:BoundField DataField="senha" HeaderText="senha" SortExpression="senha" />
                    <asp:BoundField DataField="tipo_user" HeaderText="tipo_user" SortExpression="tipo_user" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [tbl_administradores]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
