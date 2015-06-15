using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BO;
using BLL;

namespace BOffice.CentroCustos
{
    public partial class Manutencao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["IdUsuario"] != null)
                {
                    CarregaCentroCusto();
                }

                else
                {
                    Session.RemoveAll();
                    Response.Redirect("~/Conta");
                }
            }
        }

        #region Eventos

        protected void GrdCentroCusto_RowCommand(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GrdCentroCusto_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GrdCentroCusto_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dt = new DataTable();
            CentroCustosBLL centroCustoBLL = new CentroCustosBLL();

            Usuario usuario = null;
            if (Session["objetoUsuario"] != null)
            {
                usuario = (Usuario)Session["objetoUsuario"];
            }

            dt = centroCustoBLL.GetCentrosCusto(usuario);

            GrdCentroCusto.DataSource = dt;
            GrdCentroCusto.PageIndex = e.NewPageIndex;
            GrdCentroCusto.DataBind();
        }

        protected void GrdCentroCusto_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
        {
            DataTable dt = new DataTable();
            CentroCustosBLL centroCustoBLL = new CentroCustosBLL();

            Usuario usuario = null;
            if (Session["objetoUsuario"] != null)
            {
                usuario = (Usuario)Session["objetoUsuario"];
            }

            dt = centroCustoBLL.GetCentrosCusto(usuario);

            GrdCentroCusto.DataSource = dt;
            GrdCentroCusto.PageIndex = e.NewPageIndex;
            GrdCentroCusto.DataBind();
        }

        protected void BtnDeletar_Click(object sender, EventArgs e)
        {
            int indice = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            GridViewRow gvr = GrdCentroCusto.Rows[indice];
            RemoverItem(gvr);
        }

        protected void BtnEditar_Click(object sender, EventArgs e)
        {
            int indice = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            GridViewRow gvr = GrdCentroCusto.Rows[indice];
            AtualizarItem(gvr);
        }

        #endregion

        #region Métodos

        protected void CarregaCentroCusto()
        {
            DataTable dt = new DataTable();
            CentroCustosBLL centroCustoBLL = new CentroCustosBLL();

            Usuario usuario = null;

            if (Session["objetoUsuario"] != null)
            {
                usuario = (Usuario)Session["objetoUsuario"];
            }

            dt = centroCustoBLL.GetCentrosCusto(usuario);

            //Exibição Status Chamado
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["Classe"].ToString() == "A ")
                {
                    dt.Rows[i]["Classe"] = "Analítica";
                }

                if (dt.Rows[i]["Classe"].ToString() == "S ")
                {
                    dt.Rows[i]["Classe"] = "Sintética";
                }
            }

            if (dt.Rows.Count > 0)
            {
                GrdCentroCusto.DataSource = dt;
                GrdCentroCusto.DataBind();
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
            string IdObj = ((Label)row.FindControl("lblIdCentroCusto")).Text;

            if (!string.IsNullOrEmpty(IdObj))
            {
                CentroCustosBLL centroCustoBLL = new CentroCustosBLL();
                centroCustoBLL.DeletaCentroCustoPorId(Convert.ToInt32(IdObj));
                CarregaCentroCusto();
            }
        }

        protected void AtualizarItem(GridViewRow row)
        {
            string IdCategoria = ((Label)row.FindControl("lblIdCentroCusto")).Text;

            if (!string.IsNullOrEmpty(IdCategoria))
            {
                Session.Add("IdCentroCustoUpdate", IdCategoria);
                Response.Redirect("~/Centro-Custo-Cadastro");
            }
        }

        #endregion
    }
}