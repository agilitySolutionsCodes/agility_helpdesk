using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

using BO;

namespace DAL
{
    public class EmpresaDAL
    {
        #region Propriedades

        HelpDeskConexao conexao;

        #endregion

        #region Métodos

        public DataTable GetEmpresas(int IdUsuarioDAL)
        {
            DataTable dt = new DataTable();

            conexao = new HelpDeskConexao();

            SqlCommand sqlCmd;
            SqlConnection sqlCon = new SqlConnection();
            sqlCon = conexao.GetConexao();
            sqlCmd = new SqlCommand("STP_Lista_Empresas", sqlCon);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add(new SqlParameter("@P_IdUsuario ", IdUsuarioDAL));

            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            da.Fill(dt);

            return dt;
        }

        public DataTable GetCentroCusto(Usuario usuarioDAL)
        {
            DataTable dt = new DataTable();

            conexao = new HelpDeskConexao();

            SqlCommand sqlCmd;
            SqlConnection sqlCon = new SqlConnection();
            sqlCon = conexao.GetConexao();
            sqlCmd = new SqlCommand("STP_Lista_CentroCusto", sqlCon);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add(new SqlParameter("@P_IdUsuario ", usuarioDAL.IdUsuario));

            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            da.Fill(dt);

            return dt;
        }

        public void InsereNovaEmpresa(Empresa empresaDAL)
        {
            conexao = new HelpDeskConexao();

            SqlCommand sqlCmd;
            SqlConnection sqlCon = new SqlConnection();
            sqlCon = conexao.GetConexao();

            sqlCmd = new SqlCommand("STP_Incluir_Empresa", sqlCon);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add(new SqlParameter("@P_CNPJ ", empresaDAL.Cnpj));
            sqlCmd.Parameters.Add(new SqlParameter("@P_RazaoSocial", empresaDAL.RazaoSocial));
            sqlCmd.Parameters.Add(new SqlParameter("@P_NomeFantasia", empresaDAL.NomeFantasia));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Endereco", empresaDAL.Endereco));
            sqlCmd.Parameters.Add(new SqlParameter("@P_UF", empresaDAL.Uf));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Cidade", empresaDAL.Cidade));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Cep", empresaDAL.Cep));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Telefone", empresaDAL.Telefone));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Email", empresaDAL.Email));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Ativo", empresaDAL.Ativo));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Matriz", empresaDAL.Matriz));

            if (empresaDAL.CodigoMatriz == 0)
            {
                sqlCmd.Parameters.Add(new SqlParameter("@P_CodMatriz", null));
            }

            else
            {
                sqlCmd.Parameters.Add(new SqlParameter("@P_CodMatriz", empresaDAL.CodigoMatriz));
            }

            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public void AtualizaEmpresaPorId(Empresa empresaDAL)
        {
            conexao = new HelpDeskConexao();

            SqlCommand sqlCmd;
            SqlConnection sqlCon = new SqlConnection();
            sqlCon = conexao.GetConexao();

            sqlCmd = new SqlCommand("STP_Atualizar_Empresa", sqlCon);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add(new SqlParameter("@P_IdEmpresa", empresaDAL.IdEmpresa));
            sqlCmd.Parameters.Add(new SqlParameter("@P_CNPJ ", empresaDAL.Cnpj));
            sqlCmd.Parameters.Add(new SqlParameter("@P_RazaoSocial", empresaDAL.RazaoSocial));
            sqlCmd.Parameters.Add(new SqlParameter("@P_NomeFantasia", empresaDAL.NomeFantasia));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Endereco", empresaDAL.Endereco));
            sqlCmd.Parameters.Add(new SqlParameter("@P_UF", empresaDAL.Uf));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Cidade", empresaDAL.Cidade));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Cep", empresaDAL.Cep));
            //sqlCmd.Parameters.Add(new SqlParameter("@P_Telefone", empresaDAL.Telefone));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Email", empresaDAL.Email));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Ativo", empresaDAL.Ativo));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Matriz", empresaDAL.Matriz));

            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public void DeletaEmpresaPorId(int idEmpresa)
        {
            conexao = new HelpDeskConexao();

            SqlCommand sqlCmd;
            SqlConnection sqlCon = conexao.GetConexao();
            sqlCmd = new SqlCommand("STP_Deleta_Empresa", sqlCon);

            SqlParameter sqlPm = new SqlParameter("@P_IdEmpresa", SqlDbType.Int);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add(new SqlParameter("@P_IdEmpresa", idEmpresa));
            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

            sqlCon.Close();
        }

        public Boolean ValidaCNPJ(string cnpj)
        {
            conexao = new HelpDeskConexao();

            SqlCommand sqlCmd;
            SqlConnection sqlCon = new SqlConnection();
            sqlCon = conexao.GetConexao();

            sqlCmd = new SqlCommand("STP_Valida_CNPJ", sqlCon);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            Empresa empresa = new Empresa();
            empresa.Cnpj = cnpj;

            sqlCmd.Parameters.Add(new SqlParameter("@P_CNPJ", empresa.Cnpj));

            sqlCmd.Parameters.Add("@Ok", SqlDbType.Bit).Direction = ParameterDirection.Output;
            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

            empresa.Ok = Convert.ToBoolean(sqlCmd.Parameters["@Ok"].Value);

            return empresa.Ok;
        }

        public DataTable GetEmpresaPorId(int idEmpresa)
        {
            conexao = new HelpDeskConexao();

            DataTable dt = new DataTable();
            SqlCommand sqlCmd;
            SqlConnection sqlCon = conexao.GetConexao();
            sqlCmd = new SqlCommand("STP_Lista_Empresas_Por_Id", sqlCon);

            SqlParameter sqlPm = new SqlParameter("@P_IdEmpresa", SqlDbType.Int);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add(new SqlParameter("@P_IdEmpresa", idEmpresa));
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            da.Fill(dt);

            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

            return dt;
        }

        #endregion
    }
}
