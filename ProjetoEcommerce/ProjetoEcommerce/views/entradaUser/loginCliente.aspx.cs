using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class entradaUser_loginCliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnVoltar01_Click(object sender, EventArgs e)
    {
        Response.Redirect("index.aspx");
    }

    protected void btnCadastroCliente_Click(object sender, EventArgs e)
    {
        Response.Redirect("cadastroCliente.aspx");
    }
}