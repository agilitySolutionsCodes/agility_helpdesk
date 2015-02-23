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
    public class UsuarioDAL
    {
        #region Propriedades

        HelpDeskConexao conexao = new HelpDeskConexao();

        #endregion

        #region Métodos

        public Usuario AutenticaUsuarioAdminPorSenha(string email, string senha)
        {
            SqlCommand sqlCmd;
            SqlConnection sqlCon = new SqlConnection();
            sqlCon = conexao.GetConexao();

            sqlCmd = new SqlCommand("STP_Autenticar_Usuario", sqlCon);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            Usuario usuario = new Usuario();
            usuario.Email = email;
            usuario.Senha = senha;

            sqlCmd.Parameters.Add(new SqlParameter("@P_Email", usuario.Email));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Senha", usuario.Senha));

            sqlCmd.Parameters.Add("@Ok", SqlDbType.Bit).Direction = ParameterDirection.Output;
            sqlCmd.Parameters.Add("@CodUsuario", SqlDbType.Int).Direction = ParameterDirection.Output;
            sqlCmd.Parameters.Add("@NomeUsuario", SqlDbType.VarChar, 80).Direction = ParameterDirection.Output;
            sqlCmd.Parameters.Add("@ImagemUsuario", SqlDbType.VarChar, 80).Direction = ParameterDirection.Output;
            sqlCmd.Parameters.Add("@Ativo", SqlDbType.Bit, 80).Direction = ParameterDirection.Output;
            sqlCmd.Parameters.Add("@PerfilSistema", SqlDbType.Char, 80).Direction = ParameterDirection.Output;
            sqlCmd.Parameters.Add("@PerfilUsuario", SqlDbType.Bit, 80).Direction = ParameterDirection.Output;
            sqlCmd.Parameters.Add("@EmpresaUsuario", SqlDbType.Int, 80).Direction = ParameterDirection.Output;

            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

            usuario.Online = Convert.ToBoolean(sqlCmd.Parameters["@Ok"].Value);
            usuario.IdUsuario = Convert.ToInt32(sqlCmd.Parameters["@CodUsuario"].Value);
            usuario.Nome = Convert.ToString(sqlCmd.Parameters["@NomeUsuario"].Value);
            usuario.Imagem = Convert.ToString(sqlCmd.Parameters["@ImagemUsuario"].Value);
            usuario.Ativo = Convert.ToBoolean(sqlCmd.Parameters["@Ativo"].Value);
            usuario.Perfil = Convert.ToString(sqlCmd.Parameters["@PerfilSistema"].Value);

            if (Convert.ToBoolean(sqlCmd.Parameters["@PerfilUsuario"].Value != DBNull.Value))
            {
                usuario.Administrador = Convert.ToBoolean(sqlCmd.Parameters["@PerfilUsuario"].Value);
            }

            if (Convert.ToBoolean(sqlCmd.Parameters["@EmpresaUsuario"].Value != DBNull.Value))
            {
                usuario.Empresa = Convert.ToInt32(sqlCmd.Parameters["@EmpresaUsuario"].Value);
            }

            return usuario;

        }

        public Usuario AutenticarUsuarioPorSenha(string email, string senha)
        {
            SqlCommand sqlCmd;
            SqlConnection sqlCon = new SqlConnection();
            sqlCon = conexao.GetConexao();

            sqlCmd = new SqlCommand("STP_Autenticar_Usuario", sqlCon);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            Usuario usuario = new Usuario();
            usuario.Email = email;
            usuario.Senha = senha;

            sqlCmd.Parameters.Add(new SqlParameter("@P_Email", usuario.Email));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Senha", usuario.Senha));

            sqlCmd.Parameters.Add("@Ok", SqlDbType.Bit).Direction = ParameterDirection.Output;
            sqlCmd.Parameters.Add("@CodUsuario", SqlDbType.Int).Direction = ParameterDirection.Output;
            sqlCmd.Parameters.Add("@NomeUsuario", SqlDbType.VarChar, 80).Direction = ParameterDirection.Output;
            sqlCmd.Parameters.Add("@ImagemUsuario", SqlDbType.VarChar, 80).Direction = ParameterDirection.Output;
            sqlCmd.Parameters.Add("@Ativo", SqlDbType.Bit, 80).Direction = ParameterDirection.Output;
            sqlCmd.Parameters.Add("@PerfilSistema", SqlDbType.Char, 80).Direction = ParameterDirection.Output;
            sqlCmd.Parameters.Add("@PerfilUsuario", SqlDbType.Bit, 80).Direction = ParameterDirection.Output;
            sqlCmd.Parameters.Add("@EmpresaUsuario", SqlDbType.Int, 80).Direction = ParameterDirection.Output;

            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

            usuario.Online = Convert.ToBoolean(sqlCmd.Parameters["@Ok"].Value);
            usuario.IdUsuario = Convert.ToInt32(sqlCmd.Parameters["@CodUsuario"].Value);
            usuario.Nome = Convert.ToString(sqlCmd.Parameters["@NomeUsuario"].Value);
            usuario.Imagem = Convert.ToString(sqlCmd.Parameters["@ImagemUsuario"].Value);
            usuario.Ativo = Convert.ToBoolean(sqlCmd.Parameters["@Ativo"].Value);
            usuario.Perfil = Convert.ToString(sqlCmd.Parameters["@PerfilSistema"].Value);

            if (Convert.ToBoolean(sqlCmd.Parameters["@PerfilUsuario"].Value != DBNull.Value))
            {
                usuario.Administrador = Convert.ToBoolean(sqlCmd.Parameters["@PerfilUsuario"].Value);
            }

            if (Convert.ToBoolean(sqlCmd.Parameters["@EmpresaUsuario"].Value != DBNull.Value))
            {
                usuario.Empresa = Convert.ToInt32(sqlCmd.Parameters["@EmpresaUsuario"].Value);    
            }
            
            return usuario;
        }

        public Usuario RecuperaSenhaPorEmail(string email)
        {
            SqlCommand sqlCmd;
            SqlConnection sqlCon = new SqlConnection();
            sqlCon = conexao.GetConexao();

            sqlCmd = new SqlCommand("STP_Recupera_Senha_Usuario", sqlCon);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            Usuario usuario = new Usuario();

            sqlCmd.Parameters.Add(new SqlParameter("@P_Email", email));

            sqlCmd.Parameters.Add("@Ok", SqlDbType.Bit).Direction = ParameterDirection.Output;
            sqlCmd.Parameters.Add("@CodUsuario", SqlDbType.Int).Direction = ParameterDirection.Output;
            sqlCmd.Parameters.Add("@NomeUsuario", SqlDbType.VarChar, 80).Direction = ParameterDirection.Output;
            sqlCmd.Parameters.Add("@ImagemUsuario", SqlDbType.VarChar, 80).Direction = ParameterDirection.Output;
            sqlCmd.Parameters.Add("@Ativo", SqlDbType.Bit, 80).Direction = ParameterDirection.Output;
            sqlCmd.Parameters.Add("@PerfilUsuario", SqlDbType.Bit, 80).Direction = ParameterDirection.Output;
            sqlCmd.Parameters.Add("@EmailExistente", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;

            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

            usuario.Online = Convert.ToBoolean(sqlCmd.Parameters["@Ok"].Value);
            usuario.IdUsuario = Convert.ToInt32(sqlCmd.Parameters["@CodUsuario"].Value);
            usuario.Nome = Convert.ToString(sqlCmd.Parameters["@NomeUsuario"].Value);
            usuario.Imagem = Convert.ToString(sqlCmd.Parameters["@ImagemUsuario"].Value);
            usuario.Ativo = Convert.ToBoolean(sqlCmd.Parameters["@Ativo"].Value);

            if (Convert.ToBoolean(sqlCmd.Parameters["@PerfilUsuario"].Value != DBNull.Value))
            {
                usuario.Administrador = Convert.ToBoolean(sqlCmd.Parameters["@PerfilUsuario"].Value);
            }

            usuario.Email = Convert.ToString(sqlCmd.Parameters["@EmailExistente"].Value);

            //Método chamado para fechar conexão existente
            sqlCon.Close();

            return usuario;
        }

        public Usuario GetUsuarioEmail(string email)
        {
            SqlConnection sqlCon = new SqlConnection();
            sqlCon = conexao.GetConexao();
            SqlCommand sqlCmd = new SqlCommand("", sqlCon);

            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;


            Usuario usuario = new Usuario();
            return usuario;
        }

        public Usuario InsereNovoUsuario(Usuario usuarioDAL)
        {
            SqlCommand sqlCmd;
            SqlConnection sqlCon = new SqlConnection();
            sqlCon = conexao.GetConexao();

            sqlCmd = new SqlCommand("STP_Incluir_Usuario", sqlCon);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            Usuario usuario = new Usuario();

            // Prenche objeto usuário criado com objeto recebido como parametro
            usuario = usuarioDAL;

            sqlCmd.Parameters.Add(new SqlParameter("@P_Nome", usuario.Nome));            
            sqlCmd.Parameters.Add(new SqlParameter("@P_Email", usuario.Email));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Senha", usuario.Senha));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Departamento", usuario.Departamento));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Cargo", usuario.Cargo));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Telefone", usuario.Telefone));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Ramal", usuario.Ramal));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Empresa", usuario.Empresa));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Ativo", usuario.Ativo));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Administrador", usuario.Administrador));
            sqlCmd.Parameters.Add(new SqlParameter("@P_PerfilUsuario", usuario.Perfil));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Imagem", usuario.Imagem));

            sqlCmd.Parameters.Add("@CodUsuario", SqlDbType.Int).Direction = ParameterDirection.Output;

            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

            usuario.IdUsuario = Convert.ToInt32(sqlCmd.Parameters["@CodUsuario"].Value);

            return usuario;
        }

        public DataTable GetUsuarios(int idEmpresaDAL, int idUsuarioDAL)
        {
            DataTable dt = new DataTable();

            SqlCommand sqlCmd;
            SqlConnection sqlCon = new SqlConnection();
            sqlCon = conexao.GetConexao();
            sqlCmd = new SqlCommand("STP_Lista_Usuarios", sqlCon);

            sqlCmd.Parameters.Add(new SqlParameter("@P_IdEmpresa", idEmpresaDAL));
            sqlCmd.Parameters.Add(new SqlParameter("@P_IdUsuario", idUsuarioDAL));

            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            da.Fill(dt);

            return dt;
        }

        public void AtualizaUsuarioPorId(Usuario usuarioDAL)
        {
            SqlCommand sqlCmd;
            SqlConnection sqlCon = new SqlConnection();
            sqlCon = conexao.GetConexao();

            sqlCmd = new SqlCommand("STP_Atualizar_Usuario", sqlCon);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            Usuario usuario = new Usuario();
            usuario = usuarioDAL;

            sqlCmd.Parameters.Add(new SqlParameter("@P_IdUsuario", usuario.IdUsuario));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Nome", usuario.Nome));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Email", usuario.Email));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Departamento", usuario.Departamento));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Cargo", usuario.Cargo));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Telefone", usuario.Telefone));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Ramal", usuario.Ramal));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Empresa", usuario.Empresa));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Ativo", usuario.Ativo));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Administrador", usuario.Administrador));
            sqlCmd.Parameters.Add(new SqlParameter("@P_PerfilUsuario", usuario.Perfil));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Imagem", usuario.Imagem));

            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public void AtualizaSenhaUsuario(int idUsuario, string novaSenha)
        {
            SqlCommand sqlCmd = new SqlCommand();
            SqlConnection sqlCon = new SqlConnection();
            sqlCon = conexao.GetConexao();

            sqlCmd = new SqlCommand("STP_Insere_Nova_Senha", sqlCon);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            Usuario usuario = new Usuario();
            usuario.IdUsuario = idUsuario;

            sqlCmd.Parameters.Add(new SqlParameter("@P_IdUsuario", usuario.IdUsuario));
            sqlCmd.Parameters.Add(new SqlParameter("@P_NovaSenha", novaSenha));

            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public void DeletaUsuarioPorId(int IdUsuario)
        {
            SqlCommand sqlCmd;
            SqlConnection sqlCon = conexao.GetConexao();
            sqlCmd = new SqlCommand("STP_Deleta_Usuario", sqlCon);

            SqlParameter sqlPm = new SqlParameter("@P_IdUsuario", SqlDbType.Int);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add(new SqlParameter("@P_IdUsuario", IdUsuario));
            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

            sqlCon.Close();
        }

        public Boolean ValidaEmail(string email)
        {
            SqlCommand sqlCmd;
            SqlConnection sqlCon = new SqlConnection();
            sqlCon = conexao.GetConexao();
            sqlCmd = new SqlCommand("STP_Valida_Email", sqlCon);

            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            Boolean Ok = false;
            sqlCmd.Parameters.Add(new SqlParameter("@P_EMAIL", email));

            sqlCmd.Parameters.Add("@Ok", SqlDbType.Bit).Direction = ParameterDirection.Output;
            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

            Ok = Convert.ToBoolean(sqlCmd.Parameters["@Ok"].Value);
            return Ok;
        }

        public DataTable GetUsuarioPorId(int idUsuario)
        {
            DataTable dt = new DataTable();
            SqlCommand sqlCmd;
            SqlConnection sqlCon = conexao.GetConexao();

            sqlCmd = new SqlCommand("STP_Lista_Usuarios_Por_Id", sqlCon);

            SqlParameter sqlPm = new SqlParameter("@P_IdUsuario", SqlDbType.Int);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add(new SqlParameter("@P_IdUsuario", idUsuario));
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            da.Fill(dt);

            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

            return dt;
        }

        #endregion
    }
}
