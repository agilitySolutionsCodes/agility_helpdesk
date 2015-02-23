using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BO;

namespace DAL
{
    public class CategoriaDAL
    {
        #region Propriedades

        HelpDeskConexao conexao = new HelpDeskConexao();
        
        #endregion

        #region Métodos

        public DataTable GetCategorias(Usuario usuario)
        {
            DataTable dt = new DataTable();

            SqlCommand sqlCmd;
            SqlConnection sqlCon = conexao.GetConexao();
            sqlCmd = new SqlCommand("STP_Lista_Categorias", sqlCon);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add(new SqlParameter("@P_IdUsuario", usuario.IdUsuario));

            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            da.Fill(dt);

            return dt;
        }

        public void InsereNovaCategoria(Categoria categoriaDAL)
        {
            SqlCommand sqlCmd;
            SqlConnection sqlCon = new SqlConnection();
            sqlCon = conexao.GetConexao();

            sqlCmd = new SqlCommand("STP_Incluir_Categoria", sqlCon);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add(new SqlParameter("@P_IdEmpresa", categoriaDAL.Empresa));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Nome", categoriaDAL.Nome));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Descricao", categoriaDAL.Descricao));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Ativo", categoriaDAL.Ativo));


            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public void AtualizaCategoriaPorId(Categoria categoriaDAL)
        {
            SqlCommand sqlCmd;
            SqlConnection sqlCon = new SqlConnection();
            sqlCon = conexao.GetConexao();

            sqlCmd = new SqlCommand("STP_Atualizar_Categoria", sqlCon);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add(new SqlParameter("@P_IdCategoria", categoriaDAL.IdCategoria));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Nome", categoriaDAL.Nome));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Descricao", categoriaDAL.Descricao));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Ativo", categoriaDAL.Ativo));

            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

        }

        public void DeletaCategoriaPorId(int idCategoria)
        {
            SqlCommand sqlCmd;
            SqlConnection sqlCon = conexao.GetConexao();
            sqlCmd = new SqlCommand("STP_Deleta_Categoria", sqlCon);

            SqlParameter sqlPm = new SqlParameter("@P_IdCategoria", SqlDbType.Int);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add(new SqlParameter("@P_IdCategoria", idCategoria));
            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

            sqlCon.Close();
        }

        public DataTable GetCategoriaPorId(int idCategoria)
        {
            DataTable dt = new DataTable();
            SqlCommand sqlCmd;
            SqlConnection sqlCon = conexao.GetConexao();
            sqlCmd = new SqlCommand("STP_Lista_Categorias_Por_Id", sqlCon);

            SqlParameter sqlPm = new SqlParameter("@P_IdCategoria", SqlDbType.Int);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add(new SqlParameter("@P_IdCategoria", idCategoria));
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            da.Fill(dt);
            
            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

            return dt;
        }

        #endregion
    }
}
