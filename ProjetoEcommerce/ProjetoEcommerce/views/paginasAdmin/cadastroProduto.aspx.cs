
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI;

public partial class paginasProdutos_cadastroProduto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnCadastrarProduto_Click(object sender, EventArgs e)
    {
        string strConexao = ConfigurationManager
            .ConnectionStrings["ConnectionString"].ConnectionString;

        if (Session["cod_usuario"] == null ||
            Session["tipo_user"] == null ||
            Session["tipo_user"].ToString() != "A")
        {
            Response.Redirect("~/entradaUser/loginAdmin.aspx");
            return;
        }

        int codAdmin = Convert.ToInt32(Session["cod_usuario"]);

        int contaErro = 0;
        string msgErro = "";

        lblMsg.Visible = false;

        if (txtNomeProduto.Text.Trim() == "")
        {
            contaErro++;
            msgErro += "Campo 'Nome' deve ser preenchido!<br>";
        }

        if (txtPrecoProduto.Text.Trim() == "")
        {
            contaErro++;
            msgErro += "Campo 'Preço' deve ser preenchido!<br>";
        }

        if (txtDescricaoProduto.Text.Trim() == "")
        {
            contaErro++;
            msgErro += "Campo 'Descrição' deve ser preenchido!<br>";
        }

        if (txtvalidadeProduto.Text == "")
        {
            contaErro++;
            msgErro += "Campo 'Validade' deve ser preenchido!<br>";
        }

        if (txtQtdDisponivelProduto.Text.Trim() == "")
        {
            contaErro++;
            msgErro += "Campo 'Quantidade Disponível' deve ser preenchido!<br>";
        }

        if (contaErro > 0)
        {
            lblMsg.Text = msgErro;
            lblMsg.ForeColor = Color.IndianRed;
            lblMsg.Visible = true;
            return;
        }

        decimal preco;
        int quantidade;
        DateTime validade;

        if (!decimal.TryParse(txtPrecoProduto.Text, out preco))
        {
            lblMsg.Text = "Digite um preço válido!";
            lblMsg.ForeColor = Color.IndianRed;
            lblMsg.Visible = true;
            return;
        }

        if (!int.TryParse(txtQtdDisponivelProduto.Text, out quantidade))
        {
            lblMsg.Text = "Digite uma quantidade válida!";
            lblMsg.ForeColor = Color.IndianRed;
            lblMsg.Visible = true;
            return;
        }

        if (!DateTime.TryParse(txtvalidadeProduto.Text, out validade))
        {
            lblMsg.Text = "Digite uma validade válida!";
            lblMsg.ForeColor = Color.IndianRed;
            lblMsg.Visible = true;
            return;
        }

        using (SqlConnection conn = new SqlConnection(strConexao))
        {
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "INSERT INTO tbl_produtos " +
                    "(nome, preco_unitario, descricao, validade, qtd_disponivel, cod_admin) VALUES " +
                    "(@nome, @preco, @descricao, @validade, @qtd_disponivel, @cod_admin)";

                cmd.Parameters.AddWithValue("@nome", txtNomeProduto.Text);
                cmd.Parameters.AddWithValue("@preco", preco);
                cmd.Parameters.AddWithValue("@descricao", txtDescricaoProduto.Text);
                cmd.Parameters.AddWithValue("@validade", validade);
                cmd.Parameters.AddWithValue("@qtd_disponivel", quantidade);
                cmd.Parameters.AddWithValue("@cod_admin", codAdmin);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Erro ao cadastrar produto: " + ex.Message;
                lblMsg.ForeColor = Color.IndianRed;
                lblMsg.Visible = true;
                return;
            }
        }

        txtNomeProduto.Text = "";
        txtPrecoProduto.Text = "";
        txtDescricaoProduto.Text = "";
        txtvalidadeProduto.Text = "";
        txtQtdDisponivelProduto.Text = "";

        lblMsg.Text = "Cadastro realizado com sucesso! :)";
        lblMsg.ForeColor = Color.DarkOliveGreen;
        lblMsg.Visible = true;
    }

    
}