using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class views_cabecalhos_contato : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        if (txtNome.Text.Trim() == "" || txtEmail.Text.Trim() == "" || txtMensagem.Text.Trim() == "")
        {
            lblMsg.Text = "Por favor, preencha todos os campos obrigatórios!";
            lblMsg.ForeColor = Color.IndianRed;
            lblMsg.Visible = true;
            return;
        }

        txtNome.Text = string.Empty;
        txtEmail.Text = string.Empty;
        txtAssunto.Text = string.Empty;
        txtMensagem.Text = string.Empty;

        lblMsg.Text = "Sua mensagem foi enviada com sucesso! Entraremos em contato em breve.";
        lblMsg.ForeColor = Color.DarkOliveGreen;
        lblMsg.Visible = true;

    }
}