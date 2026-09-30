using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class entradaUser_cadastroAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnCadastrarAdmin_Click(object sender, EventArgs e)
    {
        string strConexao = ConfigurationManager
            .ConnectionStrings["ConnectionString"].ConnectionString;

        // inicializa o contador de erros e a mensagem de erro
        int contaErro = 0;
        string msgErro = "";

        lblMsg.Visible = false;

        if (txtNomeAdmin.Text.Trim() == "")
        {
            contaErro++;
            msgErro += "Campo 'Nome' deve ser preenchido!<br>";
        }

        if (txtEmailAdmin.Text.Trim() == "")
        {
            contaErro++;
            msgErro += "Campo 'E-mail' deve ser preenchido!<br>";
        }

        if (txtSenhaAdmin.Text == "")
        {
            contaErro++;
            msgErro += "Campo 'Senha' deve ser preenchido!<br>";
        }

        if (txtNomeAdmin.Text.Length > 150)
        {
            contaErro++;
            msgErro += "Campo 'Nome' deve ter no máximo 150 caracteres!<br>";
        }

        if (txtEmailAdmin.Text.Length > 150)
        {
            contaErro++;
            msgErro += "Campo 'E-mail' deve ter no máximo 150 caracteres!<br>";
        }

        if (txtSenhaAdmin.Text.Length > 30)
        {
            contaErro++;
            msgErro += "Campo 'Senha' deve ter no máximo 30 caracteres!<br>";
        }

        // se algum campo estiver vazio alertará o usuário,
        // caso contrário insere os dados no banco
        if (contaErro > 0)
        {
            lblMsg.Text = msgErro;
            lblMsg.ForeColor = Color.IndianRed;
            lblMsg.Visible = true;
        }
        else
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConexao))
                {
                    // abre a conexão com o banco de dados
                    conn.Open();

                    // verifica se o e-mail já está cadastrado
                    SqlCommand cmdVerifica = new SqlCommand(
                        "SELECT COUNT(*) FROM tbl_administradores WHERE email = @email",
                        conn);

                    cmdVerifica.Parameters.AddWithValue(
                        "@email",
                        txtEmailAdmin.Text.Trim());

                    int emailExiste = Convert.ToInt32(
                        cmdVerifica.ExecuteScalar());

                    if (emailExiste > 0)
                    {
                        lblMsg.Text = "Este e-mail já está cadastrado!";
                        lblMsg.ForeColor = Color.IndianRed;
                        lblMsg.Visible = true;
                        return;
                    }

                    // cria o comando para inserir o administrador
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    // tenta inserir os dados do administrador no banco de dados
                    cmd.CommandText = "INSERT INTO tbl_administradores " +
                        "(nome, email, senha, tipo_user) VALUES " +
                        "(@nome, @email, @senha, 'A')";

                    // adiciona os parâmetros para evitar SQL Injection
                    cmd.Parameters.AddWithValue("@nome", txtNomeAdmin.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmailAdmin.Text);
                    cmd.Parameters.AddWithValue("@senha", txtSenhaAdmin.Text);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // caso ocorra algum erro ao inserir os dados no banco,
                // exibe o que causou o erro
                lblMsg.Text = "Erro ao cadastrar administrador: " + ex.Message;
                lblMsg.ForeColor = Color.IndianRed;
                lblMsg.Visible = true;
                return;
            }

            // limpa os campos do formulário e exibe a mensagem de sucesso
            txtNomeAdmin.Text = string.Empty;
            txtEmailAdmin.Text = string.Empty;
            txtSenhaAdmin.Text = string.Empty;

            lblMsg.Text = "Cadastro realizado com sucesso! :)";
            lblMsg.ForeColor = Color.DarkOliveGreen;
            lblMsg.Visible = true;
            btnLogin.Visible = true;
        }
    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("index.aspx");
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("loginAdmin.aspx");
    }
}