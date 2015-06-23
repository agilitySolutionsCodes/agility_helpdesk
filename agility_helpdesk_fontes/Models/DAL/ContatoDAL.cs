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
    public class ContatoDAL
    {
        #region Objetos

        HelpDeskConexao conexao;
        
        #endregion

        #region Métodos

        public void InsereNovoContato(string nome, string email, string assunto, string mensagem, DateTime data)
        {
            conexao = new HelpDeskConexao();

            SqlCommand sqlCmd;
            SqlConnection sqlCon = new SqlConnection();
            sqlCon = conexao.GetConexao();

            sqlCmd = new SqlCommand("STP_Incluir_Contato", sqlCon);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            Contato contato = new Contato();
            contato.Nome = nome;
            contato.Email = email;
            contato.Assunto = assunto;
            contato.Mensagem = mensagem;
            contato.DataContato = data;

            sqlCmd.Parameters.Add(new SqlParameter("@P_Nome", contato.Nome));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Email", contato.Email));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Assunto", contato.Assunto));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Mensagem", contato.Mensagem));
            sqlCmd.Parameters.Add(new SqlParameter("@P_DataContato", contato.DataContato));

            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

        }

        #endregion
    }
}
