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
        if (!IsPostBack)
        {
            int codProduto;
            // valida: existe e é um número?
            if (!int.TryParse(Request.QueryString["id"], out codProduto))
            {
                Response.Redirect("~/views/paginasProdutos/catalogo.aspx");
                return;
            }
            CarregarProduto(codProduto);
        }
    }

    private void CarregarProduto(int codProduto)
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