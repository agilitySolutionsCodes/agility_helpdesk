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

        ClassificacaoDAL classificacaoDAL;

        #endregion

        #region Métodos

        public DataTable GetClassificacoes(Usuario usuarioBLL)
        {
            DataTable dt = new DataTable();
            classificacaoDAL = new ClassificacaoDAL();

            dt = classificacaoDAL.GetClassificacoes(usuarioBLL);
            return dt;
        }

        public void InsereClassificacao(Classificacao classificacaoBLL)
        {
            if (classificacaoBLL != null)
            {
                classificacaoDAL = new ClassificacaoDAL();
                classificacaoDAL.InsereNovaClassificacao(classificacaoBLL);    
            }
        }

        public void AtualizaClassificacao(Classificacao classificacaoBLL)
        {
            if (classificacaoBLL != null)
            {
                classificacaoDAL = new ClassificacaoDAL();
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
                classificacaoDAL = new ClassificacaoDAL();
                dt = classificacaoDAL.GetClassificacaoPorId(idCategoria);
            }

            return dt;
        }

        #endregion
    }
}
