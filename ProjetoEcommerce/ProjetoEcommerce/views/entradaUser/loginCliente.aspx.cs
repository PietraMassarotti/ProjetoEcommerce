using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
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

    protected void btnLoginCliente_Click(object sender, EventArgs e)
    {
        string msg = "";
        int contaErro = 0;
        string email = txtEmailCliente.Text;
        string senha = txtSenhaCliente.Text;

        if (email == "")
        {
            contaErro++;
            msg += "Campo e-mail não pode estar vazio! <br>";
        }

        if (senha == "")
        {
            contaErro++;
            msg += "Campo senha não pode estar vazia! <br>";
        }

        // Se os campos estão vazios não tem sentido procurá-los no banco
        if (contaErro > 0)
        {
            lblMsg.Text = msg;
            lblMsg.ForeColor = Color.IndianRed;
            lblMsg.Visible = true;
        }
        else
        {
            String codCliente = null;
            String senhaAtual = null;

            string strConexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = strConexao.ToString();
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "SELECT cod_cliente, senha FROM tbl_clientes WHERE email = @email AND tipo_user = 'C'";
            // Evita SQL injection, o nome é Binding SQL;
            cmd.Parameters.AddWithValue("@email", email);
            SqlDataReader reader = cmd.ExecuteReader();

            // Usa if porque o retorno é sempre um único cliente não vários
            if (reader.Read())
            {
                // Pega e guarda o codCliente correspondente ao e-mail
                codCliente = Convert.ToString(reader["cod_cliente"]);
                // Pega e guarda a senha correspondente ao e-mail
                senhaAtual = Convert.ToString(reader["senha"]);
            }

            conn.Close();

            // Se cliente ainda for null, então o e-mail não existe no banco
            if (codCliente == null)
            {
                contaErro++;
                msg += "E-mail não encontrado. <br>";
            }
            else
            {
                if (senha != senhaAtual)
                {
                    contaErro++;
                    msg += "Senha incorreta. <br>";
                }
            }

            if (contaErro > 0)
            {
                lblMsg.Text = msg;
                lblMsg.ForeColor = Color.IndianRed;
                lblMsg.Visible = true;
            }
            else
            {
                // Se tudo der certo inicia sessão com o código do cliente
                Session["cod_usuario"] = codCliente;
                Session["tipo_user"] = 'C';
                Response.Redirect("~/views/paginasCliente/catalogo.aspx");
            }
        }
    }

    protected void btnCadastroCliente_Click(object sender, EventArgs e)
    {
        Response.Redirect("cadastroCliente.aspx");
    }
}