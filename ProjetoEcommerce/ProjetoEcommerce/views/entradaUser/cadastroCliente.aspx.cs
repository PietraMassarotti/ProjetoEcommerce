using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class entradaUser_cadastroCliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnCadastroCliente_Click(object sender, EventArgs e)
    {
        string strConexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        int contaErro = 0;
        string msgErro = "";

        lblMsg.Visible = false;

        // Validações de campos obrigatórios
        if (txtNomeCliente.Text.Trim() == "")
        {
            contaErro++;
            msgErro += "Campo 'Nome' deve ser preenchido!<br>";
        }

        if (txtEmailCliente.Text.Trim() == "")
        {
            contaErro++;
            msgErro += "Campo 'E-mail' deve ser preenchido!<br>";
        }

        if (txtSenhaCliente.Text == "")
        {
            contaErro++;
            msgErro += "Campo 'Senha' deve ser preenchido!<br>";
        }

        if (txtCpfCliente.Text.Trim() == "")
        {
            contaErro++;
            msgErro += "Campo 'CPF' deve ser preenchido!<br>";
        }

        //Validação básica de dados, se o tamanho do input for maior que o aceito pelo banco impede o cadastro
        if (txtNomeCliente.Text.Length > 150)
        {
            contaErro++;
            msgErro += "Campo 'Nome' deve ter no máximo 150 caracteres!<br>";
        }

        if (txtEmailCliente.Text.Length > 150)
        {
            contaErro++;
            msgErro += "Campo 'E-mail' deve ter no máximo 150 caracteres!<br>";
        }

        if (txtSenhaCliente.Text.Length > 30)
        {
            contaErro++;
            msgErro += "Campo 'Senha' deve ter no máximo 30 caracteres<br>";
        }

        if (txtCpfCliente.Text.Length > 16)
        {
            contaErro++;
            msgErro += "Campo 'CPF'deve ter no máximo 16 caracteres!<br>";
        }

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

                //Verifica se o e-mail já existe no banco de dados antes de inserir
                SqlCommand cmdVerifica = new SqlCommand("SELECT COUNT(*) FROM tbl_clientes WHERE email = @email", conn);
                cmdVerifica.Parameters.AddWithValue("@email", txtEmailCliente.Text.Trim());

                int emailExiste = Convert.ToInt32(cmdVerifica.ExecuteScalar());

                //Se o email já existe no banco, impede cadastro
                if (emailExiste > 0)
                {
                    lblMsg.Text = "Este e-mail já está cadastrado!";
                    lblMsg.ForeColor = Color.IndianRed;
                    lblMsg.Visible = true;
                    return;
                }

                //Tenta inserir o novo cliente
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    cmd.CommandText = "INSERT INTO tbl_clientes (nome, email, senha, cpf, tipo_user) " +
                                     "VALUES (@nome, @email, @senha, @cpf, 'C')";

                    cmd.Parameters.AddWithValue("@nome", txtNomeCliente.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", txtEmailCliente.Text.Trim());
                    cmd.Parameters.AddWithValue("@senha", txtSenhaCliente.Text);
                    cmd.Parameters.AddWithValue("@cpf", txtCpfCliente.Text.Trim());

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    lblMsg.Text = "Erro ao cadastrar cliente: " + ex.Message;
                    lblMsg.ForeColor = Color.IndianRed;
                    lblMsg.Visible = true;
                    return;
                }
            }

            // Limpa os campos do formulário após sucesso
            txtNomeCliente.Text = string.Empty;
            txtEmailCliente.Text = string.Empty;
            txtSenhaCliente.Text = string.Empty;
            txtCpfCliente.Text = string.Empty;

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
        Response.Redirect("loginCliente.aspx");
    }
}