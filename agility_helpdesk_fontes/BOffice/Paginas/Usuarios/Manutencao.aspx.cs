using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using BO;
using BLL;

namespace BOffice.Usuarios
{
    public partial class Manutencao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["IdUsuario"] != null)
                {
                    Usuario usuario = new Usuario();
                    usuario.Empresa = Convert.ToInt32(Session["EmpresaUsuario"].ToString());
                    usuario.IdUsuario = Convert.ToInt32(Session["IdUsuario"].ToString());

                    CarregaUsuarios(usuario.Empresa, usuario.IdUsuario);
                }

                else
                {
                    Session.RemoveAll();
                    Response.Redirect("~/Conta");
                }
            }
        }

        #region Eventos

        protected void GrdUsuarios_RowCommand(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GrdUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GrdUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dt = new DataTable();

            Usuario usuario = new Usuario();
            usuario.Empresa = Convert.ToInt32(Session["EmpresaUsuario"].ToString());
            usuario.IdUsuario = Convert.ToInt32(Session["IdUsuario"].ToString());

            UsuarioBLL usuarioBLL = new UsuarioBLL();
            dt = usuarioBLL.GetUsuarios(usuario.Empresa, usuario.IdUsuario);

            GrdUsuarios.DataSource = dt;
            GrdUsuarios.PageIndex = e.NewPageIndex;
            GrdUsuarios.DataBind();
        }

        protected void GrdUsuarios_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
        {

        }

        protected void BtnDeletar_Click(object sender, EventArgs e)
        {
            int indice = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            GridViewRow gvr = GrdUsuarios.Rows[indice];
            RemoverItem(gvr);
        }

        protected void BtnEditar_Click(object sender, EventArgs e)
        {
            int nIndice = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            GridViewRow gvr = GrdUsuarios.Rows[nIndice];
            AtualizarItem(gvr);
        }

        #endregion

        #region Métodos

        public void CarregaUsuarios(int idEmpresa, int idUsuario)
        {
            UsuarioBLL usuarioBLL = new UsuarioBLL();
            DataTable dt = new DataTable();

            Usuario usuario = new Usuario();
            usuario.Empresa = Convert.ToInt32(Session["EmpresaUsuario"].ToString());
            usuario.IdUsuario = Convert.ToInt32(Session["IdUsuario"].ToString());

            dt = usuarioBLL.GetUsuarios(usuario.Empresa, usuario.IdUsuario);
            if (dt.Rows.Count > 0)
            {
                GrdUsuarios.DataSource = dt;
                GrdUsuarios.DataBind();
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
            string IdObj = ((Label)row.FindControl("lblIdUsuario")).Text;

            if (!string.IsNullOrEmpty(IdObj))
            {
                UsuarioBLL usuarioBLL = new UsuarioBLL();
                usuarioBLL.DeleteUserById(Convert.ToInt32(IdObj));
                Usuario usuario = (Usuario)Session["objetoUsuario"];

                CarregaUsuarios(usuario.Empresa, usuario.IdUsuario);
            }
        }

        protected void AtualizarItem(GridViewRow oRow)
        {
            string idUsuario = ((Label)oRow.FindControl("lblIdUsuario")).Text;

            if (!string.IsNullOrEmpty(idUsuario))
            {
                Session.Add("IdUsuarioUpdate", idUsuario);
                Response.Redirect("~/Usuarios-Cadastro");
            }
        }

        #endregion
    }
}