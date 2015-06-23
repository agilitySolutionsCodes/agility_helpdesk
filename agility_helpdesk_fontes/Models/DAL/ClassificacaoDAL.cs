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
    public class ClassificacaoDAL
    {
        #region Objetos

        HelpDeskConexao conexao;

        #endregion

        #region Métodos

        public DataTable GetClassificacoes(Usuario usuarioDAL)
        {
            DataTable dt = new DataTable();

            conexao = new HelpDeskConexao();

            SqlCommand sqlCmd;
            SqlConnection sqlCon = conexao.GetConexao();

            sqlCmd = new SqlCommand("STP_Lista_Classificacoes", sqlCon);
            SqlParameter sqlPm = new SqlParameter("@P_IdUsuario", SqlDbType.Int);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add(new SqlParameter("@P_IdUsuario", usuarioDAL.IdUsuario));

            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            da.Fill(dt);

            return dt;
        }

        public void InsereNovaClassificacao(Classificacao classificacaoDAL)
        {
            conexao = new HelpDeskConexao();

            SqlCommand sqlCmd;
            SqlConnection sqlCon = new SqlConnection();
            sqlCon = conexao.GetConexao();

            sqlCmd = new SqlCommand("STP_Incluir_Classificacao", sqlCon);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add(new SqlParameter("@P_IdEmpresa", classificacaoDAL.Empresa));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Nome", classificacaoDAL.Nome));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Descricao", classificacaoDAL.Descricao));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Ativo", classificacaoDAL.Ativo));

            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public void AtualizaClassificacaoPorId(Classificacao classificacaoDAL)
        {
            conexao = new HelpDeskConexao();

            SqlCommand sqlCmd;
            SqlConnection sqlCon = new SqlConnection();
            sqlCon = conexao.GetConexao();

            sqlCmd = new SqlCommand("STP_Atualizar_Classificacao", sqlCon);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add(new SqlParameter("@P_IdClassificacao", classificacaoDAL.IdClassificacao));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Nome", classificacaoDAL.Nome));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Descricao", classificacaoDAL.Descricao));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Ativo", classificacaoDAL.Ativo));

            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public void DeletaClassificacaoPorId(int idClassificacao)
        {
            conexao = new HelpDeskConexao();

            SqlCommand sqlCmd;
            SqlConnection sqlCon = conexao.GetConexao();
            sqlCmd = new SqlCommand("STP_Deleta_Classificacao", sqlCon);

            SqlParameter sqlPm = new SqlParameter("@P_IdClassificacao", SqlDbType.Int);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add(new SqlParameter("@P_IdClassificacao", idClassificacao));

            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
            sqlCon.Close();
        }

        public DataTable GetClassificacaoPorId(int idClassificacao)
        {
            conexao = new HelpDeskConexao();

            DataTable dt = new DataTable();
            SqlCommand sqlCmd;
            SqlConnection sqlCon = conexao.GetConexao();
            sqlCmd = new SqlCommand("STP_Lista_Classificacoes_Por_Id", sqlCon);

            SqlParameter sqlPm = new SqlParameter("@P_IdClassificacao", SqlDbType.Int);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add(new SqlParameter("@P_IdClassificacao", idClassificacao));
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            da.Fill(dt);

            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

            return dt;
        }

        #endregion
    }
}
