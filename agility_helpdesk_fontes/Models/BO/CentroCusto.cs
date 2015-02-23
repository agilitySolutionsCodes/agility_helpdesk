using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class CentroCusto
    {
        #region Propriedades

        private int idCentroCusto;
        private string classe;
        private string descricao;
        private bool ativo;
        private int empresa;

        #endregion

        #region Get&Set

        public int IdCentroCusto { get { return idCentroCusto; } set { idCentroCusto = value; } }
        public string Classe { get { return classe; } set { classe = value; } }
        public string Descricao { get { return descricao; } set { descricao = value; } }
        public bool Ativo { get { return ativo; } set { ativo = value; } }
        public int Empresa { get { return empresa; } set { empresa = value; } }
        
        #endregion

        #region Construtor

        public CentroCusto()
        {
            //Construtor inicializa as propriedades com valores 0 ou null

            this.idCentroCusto = 0;
            this.classe = string.Empty;
            this.descricao = string.Empty;
            this.ativo = false;
        }

        #endregion
    }
}
