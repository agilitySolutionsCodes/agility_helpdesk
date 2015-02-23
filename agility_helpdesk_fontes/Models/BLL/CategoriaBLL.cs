using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

using BO;
using DAL;

namespace BLL
{
    public class CategoriaBLL
    {
        #region Objetos

        CategoriaDAL categoriaDAL;

        #endregion

        #region Métodos

        public DataTable GetCategorias(Usuario usuarioBLL)
        {
            DataTable dt = new DataTable();
            categoriaDAL = new CategoriaDAL();
            dt = categoriaDAL.GetCategorias(usuarioBLL);
            return dt;
        }

        public void InsereCategoria(Categoria categoriaBLL)
        {
            if (categoriaBLL != null)
            {
                categoriaDAL = new CategoriaDAL();
                categoriaDAL.InsereNovaCategoria(categoriaBLL);
            }
        }

        public void AtualizaCategoriaPorId(Categoria categoriaBLL)
        {
            if (categoriaBLL != null)
            {
                categoriaDAL = new CategoriaDAL();
                categoriaDAL.AtualizaCategoriaPorId(categoriaBLL);
            }
        }

        public void DeletaCategoriaPorId(int idCategoriaBLL)
        {
            if (idCategoriaBLL != 0)
            {
                categoriaDAL = new CategoriaDAL();
                categoriaDAL.DeletaCategoriaPorId(idCategoriaBLL);
            }
        }

        public DataTable ListaCategoriaPorId(int idCategoriaBLL)
        {
            DataTable dt = new DataTable();

            if (idCategoriaBLL != 0)
            {
                categoriaDAL = new CategoriaDAL();
                dt = categoriaDAL.GetCategoriaPorId(idCategoriaBLL);    
            }

            return dt;
        }

        #endregion
    }
}
