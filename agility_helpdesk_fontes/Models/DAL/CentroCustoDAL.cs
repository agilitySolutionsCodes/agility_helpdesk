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
    public class CentroCustoDAL
    {
        #region Propriedades

        HelpDeskConexao conexao = new HelpDeskConexao();

        #endregion

        #region Métodos

        public void InsereCentroCusto(CentroCusto centroCustoDAL)
        {
            SqlCommand sqlCmd;
            SqlConnection sqlCon = new SqlConnection();
            sqlCon = conexao.GetConexao();

            sqlCmd = new SqlCommand("STP_Incluir_CentroCusto", sqlCon);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add(new SqlParameter("@P_Descricao", centroCustoDAL.Descricao));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Classe", centroCustoDAL.Classe));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Ativo", centroCustoDAL.Ativo));
            sqlCmd.Parameters.Add(new SqlParameter("@P_IdEmpresa", centroCustoDAL.Empresa));

            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public void AtualizaCentroCustoPorId(CentroCusto centroCustoDAL)
        {
            SqlCommand sqlCmd;
            SqlConnection sqlCon = new SqlConnection();
            sqlCon = conexao.GetConexao();

            sqlCmd = new SqlCommand("STP_Atualizar_CentroCusto", sqlCon);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add(new SqlParameter("@P_IdCentroCusto", centroCustoDAL.IdCentroCusto ));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Classe", centroCustoDAL.Classe));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Ativo", centroCustoDAL.Ativo));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Descricao", centroCustoDAL.Descricao));

            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public DataTable GetCentrosCusto(Usuario usuarioDAL)
        {
            DataTable dt = new DataTable();

            SqlCommand sqlCmd;
            SqlConnection sqlCon = conexao.GetConexao();
            sqlCmd = new SqlCommand("STP_Lista_CentroCusto", sqlCon);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add(new SqlParameter("@P_IdUsuario", usuarioDAL.IdUsuario));

            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            da.Fill(dt);

            return dt;
        }

        public void DeletaCentroCustoPorId(int idCentroCustoDAL)
        {
            SqlCommand sqlCmd;
            SqlConnection sqlCon = conexao.GetConexao();
            sqlCmd = new SqlCommand("STP_Deleta_CentroCusto", sqlCon);

            SqlParameter sqlPm = new SqlParameter("@P_IdCentroCusto", SqlDbType.Int);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add(new SqlParameter("@P_IdCentroCusto", idCentroCustoDAL));
            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

            sqlCon.Close();
        }

        public DataTable GetCentrosCustoPorId(int idCentrosCustoDAL)
        {
            DataTable dt = new DataTable();
            SqlCommand sqlCmd;
            SqlConnection sqlCon = conexao.GetConexao();
            sqlCmd = new SqlCommand("STP_Lista_CentroCusto_Por_Id", sqlCon);

            SqlParameter sqlPm = new SqlParameter("@P_IdCentroCusto", SqlDbType.Int);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add(new SqlParameter("@P_IdCentroCusto", idCentrosCustoDAL));
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            da.Fill(dt);

            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

            return dt;
        }

        #endregion
    }
}
