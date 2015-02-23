using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BLL;

namespace Site.Paginas.Institucional
{
    public partial class Contato : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["IdUsuario"] != null)
                {
                    //Oculta filtro de chamados
                    Label lblOrdenar = (Label)Master.FindControl("LblOrdenar");
                    lblOrdenar.Visible = false;

                    DropDownList drpFiltro = (DropDownList)Master.FindControl("drpPrioridade");
                    drpFiltro.Visible = false;
                }

                else
                {
                    Session.RemoveAll();
                    Response.Redirect("~/Conta");
                    
                }
            }
        }

        #region Eventos

        protected void BtnCadastrar_ServerClick(object sender, EventArgs e)
        {
            if (ValidaCampos() != false)
            {
                //Grava contato
                GravarContato(TxtNome.Value, TxtEmail.Value, TxtAssunto.Value, TxtMensagem.Value);
                
                //Exibe mensagem de cadastro realizado com sucesso
                ScriptManager.RegisterClientScriptBlock(BtnCadastrar, BtnCadastrar.GetType(), "msgSucesso", "alert('Formulário enviado com sucesso.');", true);

                //Limpa campos após cadastro ser realizado
                LimparCampos();
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
                //ValidadorMensagem.ErrorMessage = "Por favor digite uma mensagem";
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