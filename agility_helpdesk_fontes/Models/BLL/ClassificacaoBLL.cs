using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;

using BO;
using DAL;

namespace BLL
{
    public class ClassificacaoBLL
    {
        #region Objetos

        ClassificacaoDAL classificacaoDAL = new ClassificacaoDAL();

        #endregion

        #region Métodos

        public DataTable GetClassificacoes(Usuario usuarioBLL)
        {
            DataTable dt = new DataTable();
            dt = classificacaoDAL.GetClassificacoes(usuarioBLL);
            return dt;
        }

        public void InsereClassificacao(Classificacao classificacaoBLL)
        {
            if (classificacaoBLL != null)
            {
                classificacaoDAL.InsereNovaClassificacao(classificacaoBLL);    
            }
        }

        public void AtualizaClassificacao(Classificacao classificacaoBLL)
        {
            if (classificacaoBLL != null)
            {
                classificacaoDAL.AtualizaClassificacaoPorId(classificacaoBLL);
            }
        }

        public void DeletaClassificacaoPorId(int idCategoria)
        {
            if (idCategoria != 0)
            {
                classificacaoDAL = new ClassificacaoDAL();
                classificacaoDAL.DeletaClassificacaoPorId(idCategoria);
            }
        }

        public DataTable ListaClassificacaoPorId(int idCategoria)
        {
            DataTable dt = new DataTable();

            if (idCategoria != 0)
            {
                dt = classificacaoDAL.GetClassificacaoPorId(idCategoria);
            }

            return dt;
        }

        #endregion
    }
}
