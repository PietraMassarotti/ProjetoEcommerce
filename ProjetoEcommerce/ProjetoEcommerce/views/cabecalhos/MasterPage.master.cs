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
        //Verifica se a sessao existe
        if (Session["cod_usuario"] != null)
        {
            string codUsuario = Session["cod_usuario"].ToString();
            string tipo = Session["tipo_user"].ToString();

            //Se tipo_usuario igual a C exibe páginas de cliente
            if (tipo == "C")
            {
                btnPedidos.Visible = true;
                btnCatalogo.Visible = true;
            }
            //Se tipo_usuario igual a A exibe páginas de admin
            if (tipo == "A")
            {
                btnClientes.Visible = true;
                btnMeusProdutos.Visible = true;
            }
        }
        //se não existe sai
        else { 
            btnSair_Click(sender, e);
        }

    }

    protected void btnSair_Click(object sender, EventArgs e)
    {
        //abandona e sai da sessão
        Session.Abandon();
        Session.Clear();
        Response.Redirect("~/views/entradaUser/index.aspx");
    }

    //Navegação de páginas no menu
    protected void btnSobre_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/views/cabecalhos/sobre.aspx");
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
