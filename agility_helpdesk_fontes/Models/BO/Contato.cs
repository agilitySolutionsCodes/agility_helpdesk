using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Contato
    {
        #region Propriedades

        private int idContato;
        private string nome;
        private string email;
        private string assunto;
        private string mensagem;
        private DateTime dataContato;

        #endregion

        #region Get&Set

        public int IdContato { get { return idContato; } set { idContato = value; } }
        public string Nome { get { return nome; } set { nome = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Assunto { get { return assunto; } set { assunto = value; } }
        public string Mensagem { get { return mensagem; } set { mensagem = value; } }
        public DateTime DataContato { get { return dataContato; } set { dataContato = value; } }

        #endregion 
    }
}
