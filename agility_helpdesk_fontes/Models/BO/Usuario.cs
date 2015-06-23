using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Usuario
    {
        #region Propriedades 

        private int idUsuario;
        private string nome;
        private string email;
        private string senha;
        private string imagem;
        private int departamento;
        private string cargo;
        private string telefone;
        private string ramal;
        private int empresa;
        private Boolean ativo;
        public Boolean online;
        private Boolean administrador;
        private string perfil;

        //Propriedade criada para validação de cadastro
        public Boolean ok;

        #endregion

        #region Get&Set

        public int IdUsuario { get { return idUsuario; } set { idUsuario = value; } }
        public string Nome { get { return nome; } set { nome = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Senha { get { return senha; } set { senha = value; } }
        public string Imagem { get { return imagem; } set { imagem = value; } }
        public int Departamento { get { return departamento; } set { departamento = value; } }
        public string Cargo { get { return cargo; } set { cargo = value; } }
        public string Telefone { get { return telefone; } set { telefone = value; } }
        public string Ramal { get { return ramal; } set { ramal = value; } }
        public int Empresa { get { return empresa; } set { empresa = value; } }
        public Boolean Ativo { get { return ativo; } set { ativo = value; } }
        public Boolean Online { get { return online; } set { online = value; } }
        public Boolean Administrador { get { return administrador; } set { administrador = value; } }
        public Boolean Ok { get { return ok; } set { ok = value; } }
        public string Perfil { get { return perfil; } set { perfil = value; } }

        #endregion
    }
}
