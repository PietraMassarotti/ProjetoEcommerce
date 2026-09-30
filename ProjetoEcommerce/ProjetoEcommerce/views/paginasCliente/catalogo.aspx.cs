using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class views_paginasCliente_catalogo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Conecta ao banco de dados e busca os produtos
        string strConexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = strConexao.ToString();
        conn.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        cmd.CommandText = "SELECT P.cod_produto, P.nome AS nome_produto, P.preco_unitario, C.nome AS nome_categoria FROM tbl_produtos AS P INNER JOIN tbl_categorias AS C ON C.cod_categoria = P.cod_categoria;";
        //resultado do select dentro de reader
        //objeto responsável por ler, linha por linha, o resultado de uma consulta SQL feita ao banco de dados.
        SqlDataReader reader = cmd.ExecuteReader();

        //uma estrutura de dados que representa uma tabela na memória (linhas e colunas), parecida com uma planilha.
        DataTable tabela = new DataTable();

        //percorre o reader inteiro automaticamente e guarda tudo dentro da tabela
        tabela.Load(reader);

        conn.Close();

        // Liga a tabela ao Repeater e desenha um item vazio para cada linha
        //diz ao Repeater "essa é a fonte de dados que você vai usar".
        rptProdutos.DataSource = tabela;
        rptProdutos.DataBind();

        // Agora percorre os itens ja criados e preenche cada um
        for (int i = 0; i < tabela.Rows.Count; i++)
        {
            //Pega a linha i da tabela, ou seja, os dados de um pedido específico (todas as colunas daquela linha).
            DataRow linha = tabela.Rows[i];
            RepeaterItem item = rptProdutos.Items[i];

            Label lblNome = (Label)item.FindControl("lblNome");
            Label lblPreco = (Label)item.FindControl("lblPreco");
            Label lblCategoria = (Label)item.FindControl("lblCategoria");
            HyperLink lnkProduto = (HyperLink)item.FindControl("lnkProduto");

            int codProduto = Convert.ToInt32(linha["cod_produto"]);

            //Preenche cada label com o valor correspondente daquela linha:
            lblNome.Text = linha["nome_produto"].ToString();
            lblPreco.Text = linha["preco_unitario"].ToString();
            lblCategoria.Text = linha["nome_categoria"].ToString();
            lnkProduto.NavigateUrl = "~/views/paginasCliente/detalheProduto.aspx?id=" + codProduto;
        }
    }

}