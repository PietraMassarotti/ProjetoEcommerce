using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class views_paginasAdmin_visualizarMeusProdutos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Verifica se o usuário está logado
        if (Session["cod_usuario"] == null ||
            Session["tipo_user"] == null ||
            Session["tipo_user"].ToString() != "A")
        {
            Response.Redirect("~/views/entradaUser/loginAdmin.aspx");
            return;
        }

        // Só carrega os produtos quando a página abre
        if (!IsPostBack)
        {
            CarregarProdutos();
        }
    }


    // Busca os produtos cadastrados pelo administrador
    private void CarregarProdutos()
    {
        // Pega o código do administrador logado
        int codAdmin = Convert.ToInt32(Session["cod_usuario"]);

        // Pega a conexão do Web.config
        string conexao = ConfigurationManager
            .ConnectionStrings["ConnectionString"]
            .ConnectionString;

        // Cria a conexão
        using (SqlConnection conn = new SqlConnection(conexao))
        {
            // Busca os produtos desse administrador
            string sql = @"SELECT cod_produto,
                                  nome,
                                  preco_unitario,
                                  qtd_disponivel,
                                  validade,
                                  descricao
                           FROM tbl_produtos
                           WHERE cod_admin = @cod_admin";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                // Envia o código do administrador
                cmd.Parameters.AddWithValue("@cod_admin", codAdmin);

                // Cria um adaptador para pegar os dados
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                // Cria uma tabela temporária
                DataTable tabela = new DataTable();

                // Preenche a tabela
                adapter.Fill(tabela);

                // Coloca os produtos no GridView
                GridView1.DataSource = tabela;
                GridView1.DataBind();
            }
        }
    }

    protected void btnNovosProdutos_Click(object sender, EventArgs e)
    {
        Response.Redirect("cadastroProduto.aspx");
    }

}