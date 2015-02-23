using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DAL
{
    public class HelpDeskConexao 
    {
        #region Variáveis

        private SqlConnection conexao;

        #endregion

        #region Métodos

        public HelpDeskConexao()
        {
            AppSettingsReader app = new AppSettingsReader();
            string ambiente = app.GetValue("Ambiente", typeof(String)).ToString();
            conexao = new SqlConnection(ConfigurationManager.ConnectionStrings[ambiente].ConnectionString);

        }

        public SqlConnection GetConexao()
        {
            try
            {
                if (conexao.State == ConnectionState.Closed || conexao.State == ConnectionState.Broken)
                {
                    conexao.Open();
                }

                else
                {
                    conexao.Close();
                }
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return conexao;
        }

        #endregion
    }
}
