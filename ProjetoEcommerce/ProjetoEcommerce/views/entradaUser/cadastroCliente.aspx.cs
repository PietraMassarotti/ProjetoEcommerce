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
        string strConexao = ConfigurationManager
            .ConnectionStrings["ConnectionString"].ConnectionString;
        //inicializa o contador de erros e a mensagem de erro
        int contaErro = 0;
        string msgErro = "";

        lblMsg.Visible = false;

        if (txtNomeCliente.Text.Trim() == "")
        {
            contaErro++;
            msgErro += "Nome - Obrigatório!<br>";
        }

        if (txtEmailCliente.Text.Trim() == "")
        {
            contaErro++;
            msgErro += "Email - Obrigatório!<br>";
        }

        if (txtSenhaCliente.Text == "")
        {
            contaErro++;
            msgErro += "Senha - Obrigatória!<br>";
        }

        if (txtCpfCliente.Text == "")
        {
            contaErro++;
            msgErro += "Senha - Obrigatória!<br>";
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
                    cmd.CommandText = "INSERT INTO tbl_clientes " +
                        "(nome, email, senha, cpf, tipo_user) VALUES " +
                        "(@nome, @email, @senha, @cpf, 'C')";
                    // Adiciona os parâmetros para evitar SQL Injection
                    cmd.Parameters.AddWithValue("@nome", txtNomeCliente.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmailCliente.Text);
                    cmd.Parameters.AddWithValue("@senha", txtSenhaCliente.Text);
                    cmd.Parameters.AddWithValue("@cpf", txtCpfCliente.Text);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                { //caso ocorra algum erro ao inserir os dados no banco de dados, exibe o que causou o erro
                    lblMsg.Text = "Erro ao cadastrar cliente: " + ex.Message;
                    lblMsg.ForeColor = Color.IndianRed;
                    lblMsg.Visible = true;
                    return;
                }
            }
            // Limpa os campos do formulário e exibe a mensagem de sucesso
            txtNomeCliente.Text = string.Empty;
            txtEmailCliente.Text = string.Empty;
            txtSenhaCliente.Text = string.Empty;
            txtCpfCliente.Text = string.Empty;

            lblMsg.Text = "Cadastro realizado com sucesso! :)";
            lblMsg.ForeColor = Color.DarkOliveGreen;
            lblMsg.Visible = true;

            GridView1.DataBind();
        }
    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("index.aspx");
    }
}