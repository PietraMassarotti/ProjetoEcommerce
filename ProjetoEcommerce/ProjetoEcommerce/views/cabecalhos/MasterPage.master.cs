using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cabecalhos_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["cod_usuario"] != null)
        {
            string codUsuario = Session["cod_usuario"].ToString();
            string tipo = Session["tipo_user"].ToString();

            if (tipo == "C")
            {
                btnCarrinho.Visible = true;
                btnCatalogo.Visible = true;
            }
            if (tipo == "A")
            {
                btnVendas.Visible = true;
                btnClientes.Visible = true;
                btnMeusProdutos.Visible = true;
            }
        }
        else { 
            btnSair_Click(sender, e);
        }

    }

    protected void btnSair_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Response.Redirect("~/views/entradaUser/index.aspx");
    }

    protected void btnSobre_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/views/cabecalhos/sobre.aspx");
    }

    protected void btnVendas_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/views/paginasAdmin/vendas.aspx");
    }

    protected void btnClientes_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/views/paginasAdmin/verClientes.aspx");
    }

    protected void btnMeusProdutos_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/views/paginasAdmin/verMeusProdutos.aspx");
    }

    protected void btnCatalogo_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/views/paginasCliente/catalogo.aspx");
    }

    protected void btnPlanos_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/views/cabecalhos/planos.aspx");
    }

    protected void btnContato_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/views/cabecalhos/contato.aspx");
    }

    protected void btnPedidos_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/views/paginasCliente/pedidos.aspx");
    }
}
