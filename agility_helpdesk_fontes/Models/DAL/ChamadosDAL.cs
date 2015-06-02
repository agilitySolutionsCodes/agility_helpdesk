using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;

using BO;

namespace DAL
{
    public class ChamadosDAL
    {
        #region Propriedades

        HelpDeskConexao conexao = new HelpDeskConexao();

        #endregion

        #region Métodos

        public DataTable GetNumeroChamadosFinalizados(int idEmpresaDAL, string statusFiltro)
        {
            DataTable dt = new DataTable();

            SqlCommand sqlCmd;
            SqlConnection sqlCon = conexao.GetConexao();
            sqlCmd = new SqlCommand("STP_Lista_Numero_Chamados_Relatorio", sqlCon);

            sqlCmd.Parameters.Add(new SqlParameter("@P_IdEmpresa", idEmpresaDAL));
            sqlCmd.Parameters.Add(new SqlParameter("@P_StatusFiltro", statusFiltro));

            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            da.Fill(dt);

            return dt;
        }

        public DataTable BuscaChamadoPorPalavraChave(string palavraChave)
        {
            DataTable dt = new DataTable();
            SqlCommand sqlCmd;
            SqlConnection sqlCon = conexao.GetConexao();
            sqlCmd = new SqlCommand("STP_Busca", sqlCon);

            SqlParameter sqlPm = new SqlParameter("@P_PalavraChave", SqlDbType.VarChar);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add(new SqlParameter("@P_PalavraChave", palavraChave));
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            da.Fill(dt);

            return dt;
        }

        public DataTable ListaChamadosPorId(int idUsuario)
        {
            DataTable dt = new DataTable();
            SqlCommand sqlCmd;
            SqlConnection sqlCon = conexao.GetConexao();
            sqlCmd = new SqlCommand("STP_Lista_Chamados_Por_Id", sqlCon);

            SqlParameter sqlPm = new SqlParameter("@P_IdChamado", SqlDbType.Int);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add(new SqlParameter("@P_IdUsuario", idUsuario));
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            da.Fill(dt);

            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

            return dt;
        }

        public DataTable ListaChamados(Usuario usuarioDAL)
        {
            DataTable dt = new DataTable();

            SqlCommand sqlCmd;
            SqlConnection sqlCon = conexao.GetConexao();
            sqlCmd = new SqlCommand("STP_Lista_Chamados", sqlCon);

            SqlParameter sqlPm = new SqlParameter("@P_IdUsuario", SqlDbType.Int);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add(new SqlParameter("@P_IdUsuario", usuarioDAL.IdUsuario));

            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            da.Fill(dt);

            return dt;
        }

        public DataTable ListaDetalheChamado(int idChamado)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlCon = conexao.GetConexao();
            SqlCommand sqlCmd = new SqlCommand("STP_Lista_Detalhe_Chamado", sqlCon);

            SqlParameter sqlPm = new SqlParameter("@P_IdChamado", SqlDbType.Int);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add(new SqlParameter("@P_IdChamado", idChamado));
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            da.Fill(dt);

            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

            return dt;
        }

        public DataTable ListaHistoricoComentario(int idChamado)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlCon = conexao.GetConexao();
            SqlCommand sqlCmd = new SqlCommand("STP_Lista_Detalhe_Chamado_Historico", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;

            sqlCmd.Parameters.Add(new SqlParameter("@P_IdChamado", idChamado));
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            da.Fill(dt);

            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
            return dt;
        }

        public void InsereChamado(Chamado chamado)
        {
            SqlCommand sqlCmd;
            SqlConnection sqlCon = new SqlConnection();
            sqlCon = conexao.GetConexao();

            sqlCmd = new SqlCommand("STP_Incluir_Chamado", sqlCon);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add(new SqlParameter("@P_Empresa", Convert.ToInt32(chamado.Empresa)));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Assunto", chamado.Assunto));
            sqlCmd.Parameters.Add(new SqlParameter("@P_CodCategoria", chamado.Categoria));
            sqlCmd.Parameters.Add(new SqlParameter("@P_CodClassificacao", chamado.Classificacao));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Descricao", chamado.Descricao));
            sqlCmd.Parameters.Add(new SqlParameter("@P_DataAbertura", chamado.DataAbertura));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Solicitante", chamado.Solicitante));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Anexo", chamado.Anexo));
            sqlCmd.Parameters.Add(new SqlParameter("@P_StatusChamado", chamado.Status));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Observacao", chamado.Observacao));
            sqlCmd.Parameters.Add(new SqlParameter("@P_DataFinalizacao", chamado.DataFinalizacao));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Prioridade", chamado.Prioridade));

            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public Chamado InsereNovoChamado(Chamado chamadoDAL)
        {
            SqlCommand sqlCmd;
            SqlConnection sqlCon = new SqlConnection();
            sqlCon = conexao.GetConexao();

            sqlCmd = new SqlCommand("STP_Incluir_Chamado", sqlCon);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            Chamado chamado = new Chamado();

            // Prenche objeto chamado criado com objeto recebido como parametro
            chamado = chamadoDAL;

            sqlCmd.Parameters.Add(new SqlParameter("@P_Empresa", chamado.Empresa));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Assunto", chamado.Assunto));
            sqlCmd.Parameters.Add(new SqlParameter("@P_CodCategoria", chamado.Categoria));
            sqlCmd.Parameters.Add(new SqlParameter("@P_CodClassificacao", chamado.Classificacao));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Descricao", chamado.Descricao));
            sqlCmd.Parameters.Add(new SqlParameter("@P_DataAbertura", chamado.DataAbertura));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Solicitante", chamado.Solicitante));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Anexo", chamado.Anexo));
            sqlCmd.Parameters.Add(new SqlParameter("@P_StatusChamado", chamado.Status));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Observacao", chamado.Observacao));
            sqlCmd.Parameters.Add(new SqlParameter("@P_DataFinalizacao", chamado.DataFinalizacao));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Prioridade", chamado.Prioridade));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Atendente", chamado.Atendente));

            sqlCmd.Parameters.Add("@CodChamado", SqlDbType.Int).Direction = ParameterDirection.Output;

            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

            chamado.IdChamado = Convert.ToInt32(sqlCmd.Parameters["@CodChamado"].Value);

            return chamado;
        }

        public void AtulizaChamadoPorId(Chamado chamadoDAL)
        {
            SqlCommand sqlCmd;
            SqlConnection sqlCon = new SqlConnection();
            sqlCon = conexao.GetConexao();

            sqlCmd = new SqlCommand("STP_Incluir_Chamado", sqlCon);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            Chamado chamado = new Chamado();
            chamado = chamadoDAL;

            sqlCmd.Parameters.Add(new SqlParameter("@P_IdChamado", chamado.IdChamado));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Empresa", chamado.Empresa));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Assunto", chamado.Assunto));
            sqlCmd.Parameters.Add(new SqlParameter("@P_CodCategoria", chamado.Categoria));
            sqlCmd.Parameters.Add(new SqlParameter("@P_CodClassificacao", chamado.Classificacao));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Descricao", chamado.Descricao));
            sqlCmd.Parameters.Add(new SqlParameter("@P_DataAbertura", chamado.DataAbertura));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Solicitante", chamado.Solicitante));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Anexo", chamado.Anexo));
            sqlCmd.Parameters.Add(new SqlParameter("@P_StatusChamado", chamado.Status));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Observacao", chamado.Observacao));
            sqlCmd.Parameters.Add(new SqlParameter("@P_DataFinalizacao", chamado.DataFinalizacao));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Prioridade", chamado.Prioridade));

            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public Chamado AtenderChamado(int IdUsuario, int IdChamado)
        {
            SqlCommand sqlCmd;
            SqlConnection sqlCon = new SqlConnection();
            sqlCon = conexao.GetConexao();

            Chamado chamado = new Chamado();
            chamado.IdChamado = IdChamado;
            chamado.Solicitante = IdUsuario;

            sqlCmd = new SqlCommand("STP_Atender_Chamado", sqlCon);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add(new SqlParameter("@P_IdChamado", IdChamado));
            sqlCmd.Parameters.Add(new SqlParameter("@P_IdUsuario", IdUsuario));
            sqlCmd.Parameters.Add("@Ok", SqlDbType.Bit).Direction = ParameterDirection.Output;

            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

            if (Convert.ToBoolean(sqlCmd.Parameters["@Ok"].Value != DBNull.Value))
            {
                chamado.Ok = Convert.ToBoolean(sqlCmd.Parameters["@Ok"].Value);
            }

            return chamado;
        }

        public Chamado FinalizarChamadoAprovacao(int idUsuario, int idChamado, string observacao)
        {
            SqlCommand sqlCmd;
            SqlConnection sqlCon = new SqlConnection();
            sqlCon = conexao.GetConexao();

            Chamado chamado = new Chamado();
            chamado.IdChamado = idChamado;
            chamado.Observacao = observacao;

            sqlCmd = new SqlCommand("STP_Finalizar_Chamado_Aprovacao", sqlCon);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;


            sqlCmd.Parameters.Add(new SqlParameter("@P_IdUsuario", idUsuario));
            sqlCmd.Parameters.Add(new SqlParameter("@P_IdChamado", idChamado));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Observacao", observacao));
            sqlCmd.Parameters.Add("@Ok", SqlDbType.Bit).Direction = ParameterDirection.Output;

            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

            if (Convert.ToBoolean(sqlCmd.Parameters["@Ok"].Value != DBNull.Value))
            {
                chamado.Ok = Convert.ToBoolean(sqlCmd.Parameters["@Ok"].Value);
            }

            return chamado;
        }

        public Chamado FinalizarChamado(int idUsuario, int idChamado)
        {
            SqlCommand sqlCmd;
            SqlConnection sqlCon = new SqlConnection();
            sqlCon = conexao.GetConexao();

            Chamado chamado = new Chamado();
            chamado.IdChamado = idChamado;

            sqlCmd = new SqlCommand("STP_Finalizar_Chamado", sqlCon);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add(new SqlParameter("@P_IdUsuario", idUsuario));
            sqlCmd.Parameters.Add(new SqlParameter("@P_IdChamado", chamado.IdChamado));
            sqlCmd.Parameters.Add("@Ok", SqlDbType.Bit).Direction = ParameterDirection.Output;

            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

            if (Convert.ToBoolean(sqlCmd.Parameters["@Ok"].Value != DBNull.Value))
            {
                chamado.Ok = Convert.ToBoolean(sqlCmd.Parameters["@Ok"].Value);
            }

            return chamado;
        }

        #endregion
    }
}
