using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;

namespace BLL
{
    public class ContatoBLL
    {
        #region Objetos

        ContatoDAL contatoDAL = new ContatoDAL();

        #endregion

        #region Métodos

        public void InsereContato(string nomeContato, string emailContato, string assuntoContato, string mensagemContato, DateTime dataContato)
        {
            contatoDAL.InsereNovoContato(nomeContato, emailContato, assuntoContato, mensagemContato, dataContato);
        }

        #endregion
    }
}
