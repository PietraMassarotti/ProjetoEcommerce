using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Activities;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class views_paginasCliente_detalheProduto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //evita que a página recarrega os dados do banco toda vez que a página sofre post-back, resumindo toda vez que um botão da página é clicado. Evita sobreescrever dados
        if (!IsPostBack)
        {
            int codProduto;
            // valida: existe e é um número? Como o cod de produto é passado na url, ele pode ser alterado por qualquer usuário, int.TryParse converte o valor da url e verfifica se é um número evitando que a página quebre
            if (!int.TryParse(Request.QueryString["id"], out codProduto))
            {
                //se não é válido retorna para o catalogo
                Response.Redirect("~/views/paginasProdutos/catalogo.aspx");
                //para o código aqui sem continuar, igual o break
                return;
            }

            //se é válido carrega os detalhes do produto
            CarregarProduto(codProduto);
        }
    }

    protected void CarregarProduto(int codProduto)
    {
        string strConexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = strConexao.ToString();
        conn.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        //  cmd.ExecuteNonQuery(); // ISSO aqui usa para oque não faz select, por exemplo INSERT, DELETE UPDATE
        //  cmd.ExecuteReader(); ou  cmd.ExecuteScalar(); // isso para query
        cmd.CommandText = "SELECT nome, descricao, preco_unitario, qtd_disponivel FROM tbl_produtos WHERE cod_produto = @cod";
        //Evita SQL injection, o nome é Binding SQL;
        cmd.Parameters.AddWithValue("@cod", codProduto);
        SqlDataReader reader = cmd.ExecuteReader();
        //Usa if porque o retorno é sempre um único administrador nao vários
        if (reader.Read())
        {
            // cada linha retornado é um items do if
            lblNome.Text = reader["nome"].ToString();
            lblDescricao.Text = reader["descricao"].ToString();
            //.ToString("C"), transforma em uma string do tipo moeda, com a formatação bonitinha
            lblPreco.Text = Convert.ToDecimal(reader["preco_unitario"]).ToString("C");
            lblQtd.Text = reader["qtd_disponivel"].ToString();
        }
        else
        {
            // id não existe no banco
            Response.Redirect("~/views/paginasCliente/catalogo.aspx");
        }

        conn.Close();
        
    }
}