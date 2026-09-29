using System;
using System.Activities.Expressions;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class views_paginasCliente_pedidos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int cod_user;

        // valida: existe e é um número? Como o cod de produto é passado na url, ele pode ser alterado por qualquer usuário, int.TryParse converte o valor da url e verfifica se é um número evitando que a página quebre
        if (Session["cod_usuario"] == null || !int.TryParse(Session["cod_usuario"].ToString(), out cod_user))
        {
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

            cmd.CommandText = "SELECT P.cod_pedido, STRING_AGG(PR.nome, ', ') AS produtos, P.data_pedido, P.data_entrega FROM tbl_pedidos P JOIN tbl_itens_pedido IP ON IP.cod_pedido = P.cod_pedido JOIN tbl_produtos PR ON PR.cod_produto = IP.cod_produto WHERE P.cod_cliente = @cod_user GROUP BY P.cod_pedido, P.data_pedido, P.data_entrega";

            cmd.Parameters.AddWithValue("@cod_user", cod_user);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable tabela = new DataTable();
            tabela.Load(reader);

            conn.Close();

            // Liga a tabela ao Repeater e desenha um item vazio para cada linha
            rptProdutos.DataSource = tabela;
            rptProdutos.DataBind();

            // Agora percorre os itens ja criados e preenche cada um
            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                DataRow linha = tabela.Rows[i];
                RepeaterItem item = rptProdutos.Items[i];

                Label lblCod = (Label)item.FindControl("lblCod");
                Label lblProd = (Label)item.FindControl("lblProd");
                Label lblData = (Label)item.FindControl("lblData");
                Label lblEntrega = (Label)item.FindControl("lblEntrega");

                lblCod.Text = linha["cod_pedido"].ToString();
                lblProd.Text = linha["produtos"].ToString();
                lblData.Text = linha["data_pedido"].ToString();
                lblEntrega.Text = linha["data_entrega"].ToString();
            }

        }
    }
}