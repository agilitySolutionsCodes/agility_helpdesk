using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BO;
using BLL;

namespace BOffice.Empresas
{
    public partial class Manutencao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["IdUsuario"] != null)
                {
                    Usuario usuario = (Usuario)Session["objetoUsuario"];
                    CarregaEmpresas(usuario);
                }

                else
                {
                    Session.RemoveAll();
                    Response.Redirect("~/Conta");
                }
            }
        }

        #region Eventos

        protected void GrdEmpresas_RowCommand(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GrdEmpresas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GrdEmpresas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dt = new DataTable();
            EmpresaBLL empresaBLL = new EmpresaBLL();
            Usuario usuario = (Usuario)Session["objetoUsuario"];
            dt = empresaBLL.GetEmpresas(usuario);

            GrdEmpresas.DataSource = dt;
            GrdEmpresas.PageIndex = e.NewPageIndex;
            GrdEmpresas.DataBind();
        }

        protected void GrdEmpresas_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
        {

        }

        protected void BtnDeletar_Click(object sender, EventArgs e)
        {
            int indice = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            GridViewRow gvr = GrdEmpresas.Rows[indice];
            RemoverItem(gvr);
        }

        protected void BtnEditar_Click(object sender, EventArgs e)
        {
            int indice = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            GridViewRow gvr = GrdEmpresas.Rows[indice];
            AtualizarItem(gvr);
        }

        #endregion

        #region Métodos

        public void CarregaEmpresas(Usuario usuario)
        {
            DataTable dt = new DataTable();
            EmpresaBLL empresaBLL = new EmpresaBLL();

            dt = empresaBLL.GetEmpresas(usuario);

            if (dt.Rows.Count > 0)
            {
                GrdEmpresas.DataSource = dt;
                GrdEmpresas.DataBind();
            }

            else
            {
                //Exibe mensagem com número de resultados encontrados
                LblMsgmChamados.Text = "Não existem cadastros no momento";
                //Exibe mensagem
                LblMsgmChamados.Visible = true;
            }
        }

        public void RemoverItem(GridViewRow row)
        {
            string IdObj = ((Label)row.FindControl("LblIdEmpresa")).Text;

            if (!string.IsNullOrEmpty(IdObj))
            {
                EmpresaBLL empresaBLL = new EmpresaBLL();
                empresaBLL.DeletaEmpresaPorId(Convert.ToInt32(IdObj));
                Usuario usuario = (Usuario)Session["objetoUsuario"];

                CarregaEmpresas(usuario);
            }
        }

        public void AtualizarItem(GridViewRow row)
        {
            string IdEmpresa = ((Label)row.FindControl("LblIdEmpresa")).Text;

            if (!string.IsNullOrEmpty(IdEmpresa))
            {
                Session.Add("IdEmpresaUpdate", IdEmpresa);
                Response.Redirect("~/Empresas-Cadastro");
            }
        }

        #endregion
    }
}