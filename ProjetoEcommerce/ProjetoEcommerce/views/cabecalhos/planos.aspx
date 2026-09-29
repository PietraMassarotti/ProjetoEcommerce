<%@ Page Title="" Language="C#" MasterPageFile="~/views/cabecalhos/MasterPage.master" AutoEventWireup="true" CodeFile="planos.aspx.cs" Inherits="views_cabecalhos_planos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="paginaGeral">
    <h1>Planos de Vantagens</h1>

    <div class="lista">
        <div class="card">
            <h3>Plano Bronze</h3>
            <p>• Desconto de 5% em todas as compras</p>
            <p>• Atendimento prioritário</p>
            <p class="preco">R$ 14,90 / mês</p>
        </div>

        <div class="card destaque">
            <h3>Plano Ouro</h3>
            <p>• Frete Grátis ilimitado</p>
            <p>• Desconto de 15% em todas as compras</p>
            <p class="preco">R$ 29,90 / mês</p>
        </div>
    </div>
</div>

</asp:Content>

