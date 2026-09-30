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
        //inicializa o contador de erros e a mensagem de erro
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

        //Validação básica de dados, se o tamanho do input for maior que o aceito pelo banco impede o cadastro
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
        //se algum campo estiver vazio alertará o usuário, caso contrário insere os dados no banco
        if (contaErro > 0)
        {
            lblMsg.Text = msgErro;
            lblMsg.ForeColor = Color.IndianRed;
            lblMsg.Visible = true;
        } 
        else
        {
            using (SqlConnection conn = new SqlConnection(strConexao))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                //tenta inserir os dados do administrador no banco de dados
                try
                { 
                // Insere os dados do administrador no banco de dados
                cmd.CommandText = "INSERT INTO tbl_administradores " +
                    "(nome, email, senha, tipo_user) VALUES " +
                    "(@nome, @email, @senha, 'A')";
                // Adiciona os parâmetros para evitar SQL Injection
                cmd.Parameters.AddWithValue("@nome", txtNomeAdmin.Text);
                cmd.Parameters.AddWithValue("@email", txtEmailAdmin.Text);
                cmd.Parameters.AddWithValue("@senha", txtSenhaAdmin.Text);

                cmd.ExecuteNonQuery();
                    }
                catch (Exception ex){ //caso ocorra algum erro ao inserir os dados no banco de dados, exibe o que causou o erro
                    lblMsg.Text = "Erro ao cadastrar administrador: " + ex.Message;
                    lblMsg.ForeColor = Color.IndianRed;
                    lblMsg.Visible = true;
                    return;
                }
            }

                // Limpa os campos do formulário e exibe a mensagem de sucesso
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