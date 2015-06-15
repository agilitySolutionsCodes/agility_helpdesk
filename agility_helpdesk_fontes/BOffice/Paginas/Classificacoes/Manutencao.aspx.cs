using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BO;
using BLL;

namespace BOffice.Classificacoes
{
    public partial class Manutencao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if (Session["IdUsuario"] != null)
                {
                    Usuario usuario = null;
                    usuario = (Usuario)Session["objetoUsuario"];

                    CarregaClassificacoes(usuario);
                }

                else
                {
                    Session.RemoveAll();
                    Response.Redirect("~/Conta");
                }
            }
        }

        #region Eventos

        protected void GrdClassificacoes_RowCommand(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GrdClassificacoes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GrdClassificacoes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dt = new DataTable();

            Usuario usuario = null;
            usuario = (Usuario)Session["objetoUsuario"];

            ClassificacaoBLL classificacaoBLL = new ClassificacaoBLL();
            dt = classificacaoBLL.GetClassificacoes(usuario);

            GrdClassificacoes.DataSource = dt;
            GrdClassificacoes.PageIndex = e.NewPageIndex;
            GrdClassificacoes.DataBind();
        }

        protected void GrdClassificacoes_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
        {

        }

        protected void BtnDeletar_Click(object sender, EventArgs e)
        {
            int indice = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            GridViewRow gvr = GrdClassificacoes.Rows[indice];
            RemoverItem(gvr);
        }

        protected void BtnEditar_Click(object sender, EventArgs e)
        {
            int indice = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            GridViewRow gvr = GrdClassificacoes.Rows[indice];
            AtualizarItem(gvr);
        }

        #endregion

        #region Métodos

        protected void CarregaClassificacoes(Usuario usuario)
        {
            DataTable dt = new DataTable();
            ClassificacaoBLL classificacaoBLL = new ClassificacaoBLL();
            dt = classificacaoBLL.GetClassificacoes(usuario);

            if (dt.Rows.Count > 0)
            {
                GrdClassificacoes.DataSource = dt;
                GrdClassificacoes.DataBind();
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
            string IdObj = ((Label)row.FindControl("lblIdClassificacao")).Text;

            Usuario usuario = null;
            usuario = (Usuario)Session["objetoUsuario"];
            
            if (!string.IsNullOrEmpty(IdObj))
            {
                ClassificacaoBLL classificacaoBLL = new ClassificacaoBLL();
                classificacaoBLL.DeletaClassificacaoPorId(Convert.ToInt32(IdObj));
                CarregaClassificacoes(usuario);
            }
        }

        protected void AtualizarItem(GridViewRow row)
        {
            string IdClassificacao = ((Label)row.FindControl("lblIdClassificacao")).Text;

            if (!string.IsNullOrEmpty(IdClassificacao))
            {
                Session.Add("IdClassificacaoUpdate", IdClassificacao);
                Response.Redirect("~/Classificacoes-Cadastro");
            }
        }

        #endregion
    }
}