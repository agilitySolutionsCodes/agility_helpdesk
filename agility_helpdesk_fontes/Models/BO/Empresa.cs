using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Empresa
    {
        #region Propriedades

        private int idEmpresa;
        private string cnpj;
        private string razaoSocial;
        private string nomeFantasia;
        private string endereco;
        private string uf;
        private string cidade;
        private string cep;
        private string telefone;
        private string email;
        private string empresaPertencente;
        private Boolean ativo;
        //Propriedade criada para validação de cadastro
        public Boolean ok;
        private Boolean matriz;
        private int? codigoMatriz;

        #endregion

        #region Get&Set

        public int IdEmpresa { get { return idEmpresa; } set { idEmpresa = value; } }
        public string Cnpj { get { return cnpj; } set { cnpj = value; } }
        public string RazaoSocial { get { return razaoSocial; } set { razaoSocial = value; } }
        public string NomeFantasia { get { return nomeFantasia; } set { nomeFantasia = value; } }
        public string Endereco { get { return endereco; } set { endereco = value; } }
        public string Uf { get { return uf; } set { uf = value; } }
        public string Cidade { get { return cidade; } set { cidade = value; } }
        public string Cep { get { return cep; } set { cep = value; } }
        public string Telefone { get { return telefone; } set { telefone = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string EmpresaPertencente { get { return empresaPertencente; } set { empresaPertencente = value; } }
        public Boolean Ativo { get { return ativo; } set { ativo = value; } }
        //Propriedade criada para validação de cadastro
        public Boolean Ok { get { return ok; } set { ok = value; } }
        public Boolean Matriz { get { return matriz; } set { matriz = value; } }
        public int? CodigoMatriz { get { return codigoMatriz; } set { codigoMatriz = value; } }

        #endregion
    }
}
