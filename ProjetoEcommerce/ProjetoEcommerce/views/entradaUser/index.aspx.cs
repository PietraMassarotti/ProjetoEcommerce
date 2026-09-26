using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class entradaUser_Default : System.Web.UI.Page
{
    protected void btnCliente_Click(object sender, EventArgs e)
    {
        Response.Redirect("loginCliente.aspx");
    }

    protected void btnAdmin_Click(object sender, EventArgs e)
    {
        Response.Redirect("loginAdmin.aspx");
    }
}