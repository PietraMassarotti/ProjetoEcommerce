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
       int codProduto;
       // valida: existe e é um número? Como o cod de produto é passado na url, ele pode ser alterado por qualquer usuário, int.TryParse converte o valor da url e verfifica se é um número evitando que a página quebre
       if (!int.TryParse(Request.QueryString["id"], out codProduto)){
          //se não é válido retorna para o catalogo
          Response.Redirect("~/views/paginasProdutos/catalogo.aspx");
          //para o código aqui sem continuar, igual o break
          return;
        }
        else
        {
            string strConexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = strConexao.ToString();
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            //  cmd.ExecuteNonQuery(); // ISSO aqui usa para oque não faz select, por exemplo INSERT, DELETE UPDATE
            //  cmd.ExecuteReader(); ou  cmd.ExecuteScalar(); // isso para query
            cmd.CommandText = "SELECT P.cod_produto, P.nome AS nome_produto, P.descricao, P.preco_unitario, P.qtd_disponivel, C.nome AS nome_categoria, A.nome AS nome_admin FROM tbl_produtos AS P INNER JOIN tbl_categorias AS C ON C.cod_categoria = P.cod_categoria INNER JOIN tbl_administradores AS A ON A.cod_admin = P.cod_admin WHERE P.cod_produto = @cod";

            //Evita SQL injection, o nome é Binding SQL;
            cmd.Parameters.AddWithValue("@cod", codProduto);
            SqlDataReader reader = cmd.ExecuteReader();
            //Usa if porque o retorno é sempre um único administrador nao vários
            if (reader.Read())
            {
                // cada linha retornado é um items do if
                lblNome.Text = reader["nome_produto"].ToString();
                lblDescricao.Text = reader["descricao"].ToString();
                lblCategoria.Text = reader["nome_categoria"].ToString();
                lblVendedor.Text = reader["nome_admin"].ToString();
                lblPreco.Text = reader["preco_unitario"].ToString();
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

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/views/paginasCliente/catalogo.aspx");
    }

    protected void btnAdicionar_Click(object sender, EventArgs e)
    {
        int contaErro = 0;
        string msgErro = "";

        lblMsg.Visible = false;

        int quantidade;

        if (!int.TryParse(txtQuantidade.Text, out quantidade) || quantidade <= 0)
        {
            contaErro++;
            msgErro += "Campo 'Quantidade' deve ser um número maior que zero!<br>";
        }
        
        if (contaErro > 0)
        {
            lblMsg.Text = msgErro;
            lblMsg.ForeColor = Color.IndianRed;
            lblMsg.Visible = true;
        }
        else
        {
            lblMsg.Text = "Produto adicionado ao carrinho com sucesso!";
            lblMsg.ForeColor = Color.DarkOliveGreen;
            lblMsg.Visible = true;
        }
    }
}