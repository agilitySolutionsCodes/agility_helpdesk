using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using BO;
using DAL;

namespace BLL
{
    public class CentroCustosBLL
    {
        #region Objetos

        #endregion

        #region Métodos

        public void InsereCentroCusto(CentroCusto centroCustoBLL)
        {
            if (centroCustoBLL != null)
            {
                CentroCustoDAL centroCustoDAL = new CentroCustoDAL();
                centroCustoDAL.InsereCentroCusto(centroCustoBLL);
            }
        }

        public void AtualizaCentroCustoPorId(CentroCusto centroCustoBLL)
        {
            if (centroCustoBLL != null)
            {
                CentroCustoDAL centroCustoDAL = new CentroCustoDAL();
                centroCustoDAL.AtualizaCentroCustoPorId(centroCustoBLL);
            }
        }

        public DataTable GetCentrosCusto(Usuario usuarioBLL)
        {
            DataTable dt = new DataTable();
            CentroCustoDAL centroCustoDAL = new CentroCustoDAL();
            dt = centroCustoDAL.GetCentrosCusto(usuarioBLL);
            
            return dt;
        }

        public void DeletaCentroCustoPorId(int idCentroCustoBLL)
        {
            if (idCentroCustoBLL != 0)
            {
                CentroCustoDAL centroCustoDAL = new CentroCustoDAL();
                centroCustoDAL.DeletaCentroCustoPorId(idCentroCustoBLL);
            }
        }

        public DataTable ListaCentroCustoPorId(int idCentroCustoBLL)
        {
            DataTable dt = new DataTable();

            if (idCentroCustoBLL != 0)
            {
                CentroCustoDAL centroCustoDAL =  new CentroCustoDAL();
                dt = centroCustoDAL.GetCentrosCustoPorId(idCentroCustoBLL);
            }

            return dt;
        }

        #endregion
    }
}
