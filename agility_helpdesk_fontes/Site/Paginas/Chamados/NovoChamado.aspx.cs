using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BO;
using BLL;

namespace Site.Paginas.Chamados
{
    public partial class NovoChamado : System.Web.UI.Page
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

                    Usuario usuario = null;
                    usuario = (Usuario)Session["objetoUsuario"];

                    LoadCategorias(usuario);
                    LoadClassificacoes(usuario);
                    LoadUsersPorEmpresa(usuario);

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
            //Instância de chamadoBLL
            ChamadosBLL chamadoBLL = new ChamadosBLL();

            //Instância de novo chamado
            Chamado chamado = new Chamado();

            //Preenche objeto com dados da página
            chamado = Preencher();

            //Chama BLL e insere chamado
            chamado = chamadoBLL.InserirChamado(chamado);

            if (UploadImagem.HasFile)
            {
                UploadImagem.SaveAs(Server.MapPath("~/Uploads/") + chamado.Anexo);
            }

            //Exibe mensagem de cadastro realizado com sucesso
            ScriptManager.RegisterClientScriptBlock(BtnCadastrar, BtnCadastrar.GetType(), "msgSucesso", "alert('Chamado aberto com sucesso.');", true);

            Response.Redirect("~/Chamados-Fila");
        }

        protected void BtnLimpar_ServerClick(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        #endregion

        #region Métodos

        protected Boolean ValidaCampos(Chamado chamado)
        {
            //Variável de validação
            Boolean varValidado = true;

            //if (TxtSenha.Value != TxtConfirmacaoSenha.Value)
            //{
            //    ValidadorSenha.Enabled = true;
            //}

            return varValidado;
        }

        protected Chamado Preencher()
        {
            Chamado chamado = new Chamado();

            chamado.CodEmpresa = Convert.ToInt32(Session["EmpresaUsuario"]);
            chamado.Categoria = Convert.ToInt32(DrpCategoria.SelectedValue);
            chamado.Classificacao = Convert.ToInt32(DrpClassificacao.SelectedValue);
            chamado.Prioridade = DrpPrioridade.SelectedValue;
            chamado.Assunto = TxtAssunto.Value;
            chamado.Descricao = TxtDescricao.Value;
            chamado.DataAbertura = DateTime.Now;
            chamado.Solicitante = Convert.ToInt32(Session["IdUsuario"].ToString());
            chamado.Anexo = UploadImagem.FileName;
            chamado.Status = "P";
            chamado.Atendente = Convert.ToInt32(DrpAtendente.SelectedValue);

            return chamado;
        }

        protected void LimpaCampos()
        {
            TxtAssunto.Value = string.Empty;
            TxtDescricao.Value = string.Empty;
            DrpCategoria.SelectedValue = "";
            DrpClassificacao.SelectedValue = "";
            DrpPrioridade.SelectedValue = "";
        }

        protected void LoadCategorias(Usuario usuario)
        {
            CategoriaBLL categoriaBLL = new CategoriaBLL();
            DataTable dt = new DataTable();

            dt = categoriaBLL.GetCategorias(usuario);

            DrpCategoria.DataSource = dt;
            DrpCategoria.DataBind();

            DrpCategoria.Items.Insert(0, "Selecione");
            DrpCategoria.Items[0].Value = "";
        }

        protected void LoadClassificacoes(Usuario usuario)
        {
            ClassificacaoBLL classificacaoBLL = new ClassificacaoBLL();
            DataTable dt = new DataTable();

            dt = classificacaoBLL.GetClassificacoes(usuario);
            DrpClassificacao.DataSource = dt;
            DrpClassificacao.DataBind();

            DrpClassificacao.Items.Insert(0, "Selecione");
            DrpClassificacao.Items[0].Value = "";
        }

        protected void LoadUsersPorEmpresa(Usuario usuario)
        {
            UsuarioBLL usuarioBLL = new UsuarioBLL();
            DataTable dt = new DataTable();

            dt = usuarioBLL.GetUsuarios(usuario.Empresa, usuario.IdUsuario);
            DrpAtendente.DataSource = dt;
            DrpAtendente.DataBind();

            DrpAtendente.Items.Insert(0, "Selecione");
            DrpAtendente.Items[0].Value = "";
        }

        #endregion
    }
}