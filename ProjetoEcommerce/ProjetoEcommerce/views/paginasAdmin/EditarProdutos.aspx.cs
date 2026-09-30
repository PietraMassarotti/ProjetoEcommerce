using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;

public partial class paginasProdutos_editarProduto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Verifica se existe um usuário logado
        if (Session["cod_usuario"] == null ||
            Session["tipo_user"] == null ||
            Session["tipo_user"].ToString() != "A")
        {
            // Se não for administrador, volta para o login
            Response.Redirect("~/entradaUser/loginAdmin.aspx");
            return;
        }

        // Carrega o produto somente na primeira vez que a página abre
        if (!IsPostBack)
        {
            CarregarProduto();
        }
    }


    // Procura o produto no banco de dados e coloca os dados nos campos
    private void CarregarProduto()
    {
        // Pega o ID do produto que veio pela URL
        string idProduto = Request.QueryString["id"];

        // Verifica se o ID existe na URL
        if (string.IsNullOrEmpty(idProduto))
        {
            lblMsg.Text = "Produto não encontrado.";
            lblMsg.Visible = true;
            return;
        }

        // Tenta transformar o ID em número
        int id;

        if (!int.TryParse(idProduto, out id))
        {
            lblMsg.Text = "ID do produto inválido.";
            lblMsg.Visible = true;
            return;
        }

        // Pega o código do administrador que está logado
        int codAdmin = Convert.ToInt32(Session["cod_usuario"]);

        // Pega a conexão configurada no Web.config
        string conexao = ConfigurationManager
            .ConnectionStrings["ConnectionString"]
            .ConnectionString;

        // Abre a conexão com o banco
        using (SqlConnection conn = new SqlConnection(conexao))
        {
            // Procura somente o produto pertencente ao administrador logado
            string sql = @"SELECT nome,
                      preco_unitario,
                      descricao,
                      validade,
                      qtd_disponivel
               FROM tbl_produtos
               WHERE cod_produto = @id
               AND cod_admin = @cod_admin";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                // Envia o ID como parâmetro
                cmd.Parameters.AddWithValue("@id", id);

                // Envia o código do administrador como parâmetro
                cmd.Parameters.AddWithValue("@cod_admin", codAdmin);

                // Abre a conexão
                conn.Open();

                // Executa a consulta
                SqlDataReader reader = cmd.ExecuteReader();

                // Verifica se encontrou o produto
                if (reader.Read())
                {
                    // Coloca os dados do banco nos campos da página
                    txtNomeProduto.Text = reader["nome"].ToString();

                    txtPrecoProduto.Text = reader["preco_unitario"].ToString();

                    txtDescricaoProduto.Text =
                        reader["descricao"].ToString();

                    // Verifica se existe uma data de validade
                    if (reader["validade"] != DBNull.Value)
                    {
                        DateTime validade =
                            Convert.ToDateTime(reader["validade"]);

                        // Coloca a data no formato usado pelo campo Date
                        txtValidadeProduto.Text =
                            validade.ToString("yyyy-MM-dd");
                    }

                    txtQtdDisponivelProduto.Text =
                        reader["qtd_disponivel"].ToString();
                }
                else
                {
                    // Caso o produto não seja encontrado
                    lblMsg.Text = "Produto não encontrado.";
                    lblMsg.Visible = true;
                }

                // Fecha o leitor
                reader.Close();
            }
        }
    }


    // Executado quando o botão "Salvar alterações" é clicado
    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        // Verifica novamente se o administrador está logado
        if (Session["cod_usuario"] == null ||
            Session["tipo_user"] == null ||
            Session["tipo_user"].ToString() != "A")
        {
            Response.Redirect("~/entradaUser/loginAdmin.aspx");
            return;
        }

        // Pega o ID do produto pela URL
        string idProduto = Request.QueryString["id"];

        // Verifica se existe um ID
        if (string.IsNullOrEmpty(idProduto))
        {
            lblMsg.Text = "Produto não encontrado.";
            lblMsg.Visible = true;
            return;
        }

        // Converte o ID para número
        int id;

        if (!int.TryParse(idProduto, out id))
        {
            lblMsg.Text = "ID do produto inválido.";
            lblMsg.Visible = true;
            return;
        }

        // Verifica se o nome foi preenchido
        if (string.IsNullOrWhiteSpace(txtNomeProduto.Text))
        {
            lblMsg.Text = "Nome do produto é obrigatório.";
            lblMsg.Visible = true;
            return;
        }

        // Verifica se o preço é um número válido
        decimal preco;

        if (!decimal.TryParse(txtPrecoProduto.Text, out preco))
        {
            lblMsg.Text = "Digite um preço válido.";
            lblMsg.Visible = true;
            return;
        }

        // Verifica se a quantidade é um número inteiro
        int quantidade;

        if (!int.TryParse(txtQtdDisponivelProduto.Text, out quantidade))
        {
            lblMsg.Text = "Digite uma quantidade válida.";
            lblMsg.Visible = true;
            return;
        }

        // Verifica se a validade é uma data válida
        DateTime validade;

        if (!DateTime.TryParse(txtValidadeProduto.Text, out validade))
        {
            lblMsg.Text = "Digite uma validade válida.";
            lblMsg.Visible = true;
            return;
        }

        // Pega o código do administrador logado
        int codAdmin = Convert.ToInt32(Session["cod_usuario"]);

        // Pega a conexão do Web.config
        string conexao = ConfigurationManager
            .ConnectionStrings["ConnectionString"]
            .ConnectionString;

        try
        {
            // Abre a conexão com o banco
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                // Atualiza os dados do produto


                string sql = @"UPDATE tbl_produtos
               SET nome = @nome,
                   preco_unitario = @preco,
                   descricao = @descricao,
                   validade = @validade,
                   qtd_disponivel = @qtd
               WHERE cod_produto = @id
               AND cod_admin = @cod_admin";


                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    // Passa os valores para os parâmetros
                    cmd.Parameters.AddWithValue(
                        "@nome", txtNomeProduto.Text);

                    cmd.Parameters.AddWithValue(
                        "@preco", preco);

                    cmd.Parameters.AddWithValue(
                        "@descricao", txtDescricaoProduto.Text);

                    cmd.Parameters.AddWithValue(
                        "@validade", validade);

                    cmd.Parameters.AddWithValue(
                        "@qtd", quantidade);

                    cmd.Parameters.AddWithValue(
                        "@id", id);

                    cmd.Parameters.AddWithValue(
                        "@cod_admin", codAdmin);

                    // Abre a conexão
                    conn.Open();

                    // Executa o UPDATE
                    int linhasAlteradas = cmd.ExecuteNonQuery();

                    // Verifica se algum produto foi alterado
                    if (linhasAlteradas > 0)
                    {
                        lblMsg.Text = "Produto alterado com sucesso.";
                        lblMsg.Visible = true;
                    }
                    else
                    {
                        lblMsg.Text = "Não foi possível alterar o produto.";
                        lblMsg.ForeColor = Color.IndianRed;
                        lblMsg.Visible = true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Mostra o erro caso aconteça algum problema
            lblMsg.Text = "Erro: " + ex.Message;
            lblMsg.Visible = true;
        }
    }


    // Executado quando o botão "Voltar" é clicado
    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        // Volta para a página que mostra os produtos
        Response.Redirect("verMeusProdutos.aspx");
    }
}