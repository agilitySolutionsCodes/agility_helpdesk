using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Categoria
    {
        #region Propriedades

        private int idCategoria;
        private string nome;
        private string descricao;
        private Boolean ativo;
        private int empresa;

        #endregion

        #region Get&Set

        public int IdCategoria { get { return idCategoria; } set { idCategoria = value; } }
        public string Nome { get { return nome; } set { nome = value; } }
        public string Descricao { get { return descricao; } set { descricao = value; } }
        public Boolean Ativo { get { return ativo; } set { ativo = value; } }
        public int Empresa { get { return empresa; } set { empresa = value; } }

        #endregion

        #region Construtor

        public Categoria()
        {
            //Construtor inicializa as propriedades com valores 0 ou null
            this.idCategoria = 0;
            this.nome = string.Empty;
            this.descricao = string.Empty;
            this.ativo = false;
            this.empresa = 0;
        }

        #endregion
    }
}
