using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class entradaUser_loginAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnVoltar02_Click(object sender, EventArgs e)
    {
        Response.Redirect("index.aspx");
    }

    protected void btnLoginAdmin_Click(object sender, EventArgs e)
    {
        //Para teste:
        //email: teste@email.com
        //senha: Teste123

        string msg = "";
        int contaErro = 0;
        string email = txtEmailAdmin.Text;
        string senha = txtSenhaAdmin.Text;

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

        //Se os campos estão vazios não tem sentido procura-los no banco
        if (contaErro > 0)
        {
            lblMsg.Text = msg;
            lblMsg.ForeColor = Color.IndianRed;
            lblMsg.Visible = true;
        }
        else {
            String codAdmin = null;
            String senhaAtual = null;

            string strConexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = strConexao.ToString();
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            //  cmd.ExecuteNonQuery(); // ISSO aqui usa para oque não faz select, por exemplo INSERT, DELETE UPDATE
            //  cmd.ExecuteReader(); ou  cmd.ExecuteScalar(); // isso para query
            cmd.CommandText = "SELECT cod_admin, senha FROM tbl_administradores WHERE email = @email";
            //Evita SQL injection, o nome é Binding SQL;
            cmd.Parameters.AddWithValue("@email", email);
            SqlDataReader reader = cmd.ExecuteReader();
            //Usa if porque o retorno é sempre um único administrador nao vários
            if (reader.Read())
            {
                // cada linha retornado é um items do if

                //pega e guarda o codAdmin correspondente ao email;
                codAdmin = Convert.ToString(reader["cod_admin"]);
                //pega e guarda a senha correspondente ao email;
                senhaAtual = Convert.ToString(reader["senha"]);
            }

            conn.Close();

            //se admin ainda for null, então o email não existe no banco;
            if (codAdmin == null)
            {
                contaErro++;
                msg += "E-mail não encontrado. <br>";
            }
            else {
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
                //se tudo der certo inicia sessão com id do admin
                Session["token"] = codAdmin;
                Response.Redirect("~/views/paginasProdutos/catalogo.aspx");
            }

        }
    }
}