using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using BO;
using BLL;

namespace BOffice.Categorias
{
    public partial class Manutencao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["IdUsuario"] != null)
                {
                    CarregaCategorias();
                }

                else
                {
                    Session.RemoveAll();
                    Response.Redirect("~/Conta");
                }
            }
        }

        #region Eventos

        protected void GrdCategorias_RowCommand(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GrdCategorias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GrdCategorias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dt = new DataTable();
            CategoriaBLL categoriaBLL = new CategoriaBLL();

            Usuario usuario = null;
            if (Session["objetoUsuario"] != null)
            {
                usuario = (Usuario)Session["objetoUsuario"];
            }

            dt = categoriaBLL.GetCategorias(usuario);

            GrdCategorias.DataSource = dt;
            GrdCategorias.PageIndex = e.NewPageIndex;
            GrdCategorias.DataBind();
        }

        protected void GrdCategorias_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
        {
            DataTable dt = new DataTable();
            CategoriaBLL categoriaBLL = new CategoriaBLL();

            Usuario usuario = null;
            if (Session["objetoUsuario"] != null)
            {
                usuario = (Usuario)Session["objetoUsuario"];
            }

            dt = categoriaBLL.GetCategorias(usuario);

            GrdCategorias.DataSource = dt;
            GrdCategorias.PageIndex = e.NewPageIndex;
            GrdCategorias.DataBind();
        }

        protected void BtnDeletar_Click(object sender, EventArgs e)
        {
            int indice = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            GridViewRow gvr = GrdCategorias.Rows[indice];
            RemoverItem(gvr);
        }

        protected void BtnEditar_Click(object sender, EventArgs e)
        {
            int indice = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            GridViewRow gvr = GrdCategorias.Rows[indice];
            AtualizarItem(gvr);
        }

        #endregion

        #region Métodos

        protected void CarregaCategorias()
        {
            DataTable dt = new DataTable();
            CategoriaBLL categoriaBLL = new CategoriaBLL();

            Usuario usuario = null;

            if (Session["objetoUsuario"] != null)
            {
                usuario = (Usuario)Session["objetoUsuario"];
            }
            dt = categoriaBLL.GetCategorias(usuario);

            if (dt.Rows.Count > 0)
            {
                GrdCategorias.DataSource = dt;
                GrdCategorias.DataBind();
            }

            else
            {
                //Exibe mensagem com número de resultados encontrados
                LblMsgmChamados.Text = "Não existem cadastros no momento";
                //Exibe mensagem
                LblMsgmChamados.Visible = true;
            }
        }

        protected void RemoverItem(GridViewRow row)
        {
            string IdObj = ((Label)row.FindControl("lblIdCategoria")).Text;

            if (!string.IsNullOrEmpty(IdObj))
            {
                CategoriaBLL categoriaBLL = new CategoriaBLL();
                categoriaBLL.DeletaCategoriaPorId(Convert.ToInt32(IdObj));
                CarregaCategorias();
            }
        }

        protected void AtualizarItem(GridViewRow row)
        {
            string IdCategoria = ((Label)row.FindControl("lblIdCategoria")).Text;

            if (!string.IsNullOrEmpty(IdCategoria))
            {
                Session.Add("IdCategoriaUpdate", IdCategoria);
                Response.Redirect("~/Categorias-Cadastro");
            }
        }

        #endregion
    }
}