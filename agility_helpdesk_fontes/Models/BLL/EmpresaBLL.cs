using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BO;
using DAL;

namespace BLL
{
    public class EmpresaBLL
    {
        #region Objetos

        #endregion

        #region Métodos

        public DataTable GetEmpresas(Usuario UsuarioBLL)
        {
            DataTable dt = new DataTable();

            if (UsuarioBLL != null)
            {
                EmpresaDAL empresaDAL = new EmpresaDAL();
                dt = empresaDAL.GetEmpresas(UsuarioBLL.IdUsuario);    
            }

            return dt;
        }

        public DataTable GetCentroCusto(Usuario usuarioBLL)
        {
            DataTable dt = new DataTable();
            EmpresaDAL empresaDAL = new EmpresaDAL();

            dt = empresaDAL.GetCentroCusto(usuarioBLL);
            
            return dt;
        }

        public void InsereEmpresa(Empresa empresaBLL)
            {
                if (empresaBLL != null)
                {
                    EmpresaDAL empresaDAL = new EmpresaDAL();
                    empresaDAL.InsereNovaEmpresa(empresaBLL);   
                }
            }

        public void AtualizaEmpresaPorId(Empresa empresaBLL)
        {
            if (empresaBLL.IdEmpresa != 0)
            {
                EmpresaDAL empresaDAL = new EmpresaDAL();
                empresaDAL.AtualizaEmpresaPorId(empresaBLL);    
            }
        }

        public void DeletaEmpresaPorId(int idEmpresa)
        {
            if (idEmpresa != 0)
	        {
                EmpresaDAL empresaDAL = new EmpresaDAL();
                empresaDAL.DeletaEmpresaPorId(idEmpresa);
	        }        
        }

        public Boolean ValidaCNPJ(string cnpj)
        {
            Empresa empresa = new Empresa();
            EmpresaDAL empresaDAL = new EmpresaDAL();
            empresa.Ok = empresaDAL.ValidaCNPJ(cnpj);

            return empresa.Ok;
        }

        public DataTable ListaEmpresaPorId(int idEmpresa)
        {
            DataTable dt = new DataTable();
            
            if (idEmpresa != 0)
            {
                EmpresaDAL empresaDAL = new EmpresaDAL();
                dt = empresaDAL.GetEmpresaPorId(idEmpresa);
            }

            return dt;
        }

        #endregion
    }
}
