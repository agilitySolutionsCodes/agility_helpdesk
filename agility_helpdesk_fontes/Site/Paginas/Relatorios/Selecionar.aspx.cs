using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site.Paginas.Relatorios
{
    public partial class SelecionarTipoRelatorio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Oculta filtro de chamados
                Label lblOrdenar = (Label)Master.FindControl("LblOrdenar");
                lblOrdenar.Visible = false;

                DropDownList drpFiltro = (DropDownList)Master.FindControl("drpPrioridade");
                drpFiltro.Visible = false;

                if (Session["IdUsuario"] != null)
                {
                    
                }

                else
                {
                    Session.RemoveAll();
                    Response.Redirect("~/Conta");
                }
            }
        }

        #region Eventos

        protected void BtnChamadosFinalizados_ServerClick(object sender, EventArgs e)
        {
            Session.Add("StatusFiltro", "F ");
            Response.Redirect("~/Relatorios-Visualizar");
        }

        protected void BtnChamadosAbertos_ServerClick(object sender, EventArgs e)
        {
            Session.Add("StatusFiltro", "P ");
            Response.Redirect("~/Relatorios-Visualizar");
        }

        protected void BtnTodosChamados_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Relatorios-Visualizar");
        }

        #endregion
    }
}