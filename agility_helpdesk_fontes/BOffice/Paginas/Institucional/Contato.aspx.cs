using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BLL;

namespace BOffice.Contato
{
    public partial class Enviar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!Page.IsPostBack)
                {
                    if (Session["IdUsuario"] != null)
                    {
                        //Do something
                    }

                    else
                    {
                        Session.RemoveAll();
                        Response.Redirect("~/Conta");
                    }
                }
            }
        }

        #region Eventos

        protected void BtnCadastrar_ServerClick(object sender, EventArgs e)
        {
            if (ValidaCampos() != false)
            {
                GravarContato(TxtNome.Value, TxtEmail.Value, TxtAssunto.Value, TxtMensagem.Value);
            }
        }

        protected void BtnLimpar_ServerClick(object sender, EventArgs e)
        {
            LimparCampos();
        }

        #endregion

        #region Métodos

        protected void GravarContato(string nomeContato, string emailContato, string assuntoContato, string msgmContato)
        {
            ContatoBLL contatoBLL = new ContatoBLL();
            contatoBLL.InsereContato(nomeContato, emailContato, assuntoContato, msgmContato, DateTime.Now);
        }

        protected Boolean ValidaCampos()
        {
            Boolean varValidado = true;

            if (string.IsNullOrEmpty(TxtMensagem.Value))
            {
                ValidadorMensagem.ErrorMessage = "Por favor digite uma mensagem";
                varValidado = false;
            }

            return varValidado;
        }

        protected void LimparCampos()
        {
            TxtNome.Value = string.Empty;
            TxtEmail.Value = string.Empty;
            TxtAssunto.Value = string.Empty;
            TxtMensagem.Value = string.Empty;
        }

        #endregion
    }
}