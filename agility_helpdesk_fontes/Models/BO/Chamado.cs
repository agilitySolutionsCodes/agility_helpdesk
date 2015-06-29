using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Chamado
    {
        #region Propriedades

        private int idChamado;
        private string empresa;
        private int codEmpresa;
        private string assunto;
        private int categoria;
        private int classificacao;
        private string prioridade;
        private string descricao;
        private DateTime dataAbertura;
        private int solicitante;
        private int atendente;
        private string anexo;
        private string status;
        private string observacao;
        private DateTime dataFinalizacao;
        private DateTime dataModificacao;
        private Boolean ok;

        #endregion

        #region Get&Set

        public int IdChamado { get { return idChamado; } set { idChamado = value; } }
        public string Empresa { get { return empresa; } set { empresa = value; } }
        public int CodEmpresa { get { return codEmpresa; } set { codEmpresa = value; } }
        public string Assunto { get { return assunto; } set { assunto = value; } }
        public int Categoria { get { return categoria; } set { categoria = value; } }
        public int Classificacao { get { return classificacao; } set { classificacao = value; } }
        public string Prioridade { get { return prioridade; } set { prioridade = value; } }
        public string Descricao { get { return descricao; } set { descricao = value; } }
        public DateTime DataAbertura { get { return dataAbertura; } set { dataAbertura = value; } }
        public int Solicitante { get { return solicitante; } set { solicitante = value; } }
        public int Atendente { get { return atendente; } set { atendente = value; } }
        public string Anexo { get { return anexo; } set { anexo = value; } }
        public string Status { get { return status; } set { status = value; } }
        public string Observacao { get { return observacao; } set { observacao = value; } }
        public DateTime DataFinalizacao { get { return dataFinalizacao; } set { dataFinalizacao = value; } }
        public DateTime DataModificacao { get { return dataModificacao; } set { dataModificacao = value; } }
        public Boolean Ok { get { return ok; } set { ok = value; } }

        #endregion
    }
}
