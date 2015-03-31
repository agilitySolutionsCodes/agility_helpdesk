using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BO;
using BLL;
using AgilityHelpDesk.Util;

namespace BOffice.Classificacoes
{
    #region Classificacoes
    public partial class Cadastro : System.Web.UI.Page
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["IdUsuario"] != null)
                {
                    if (Session["IdClassificacaoUpdate"] != null)
                    {
                        Classificacao classificacao = new Classificacao();

                        DataTable dt = new DataTable();
                        ClassificacaoBLL classificacaoBLL = new ClassificacaoBLL();
                        dt = classificacaoBLL.ListaClassificacaoPorId(Convert.ToInt32(Session["IdClassificacaoUpdate"].ToString()));

                        //Remove session que contém o código da classificação
                        Session.Remove("IdClassificacaoUpdate");

                        //Preenche objeto e salva em session para caso de atualização
                        classificacao = PreencherClassificacaoUpdate(dt);
                        Session["objClassificacao"] = classificacao;

                        CarregaClassificacao(dt);
                    }
                }

                else
                {
                    Session.RemoveAll();
                    Response.Redirect("~/Conta");
                }
            }
        }

        protected void BtnCadastrar_ServerClick(object sender, EventArgs e)
        {
            //Intância Classificação para preenchimento e validação
            Classificacao classificacao = new Classificacao();

            if (Session["objClassificacao"] != null)
            {
                classificacao = (Classificacao)Session["objClassificacao"];
                Session.Remove("objClassificacao");
            }

            //Preenche o objeto classificação com dados do formulário
            classificacao = Preencher(classificacao);

            //Se a validação estiver Ok
            if (ValidaCampos(classificacao) == true)
            {
                //Instância de BLL
                ClassificacaoBLL classificacaoBLL = new ClassificacaoBLL();

                if (classificacao.IdClassificacao != 0)
                {
                    //Chama método de atualização BLL passando objeto como parâmetro
                    classificacaoBLL.AtualizaClassificacao(classificacao);

                    //Exibe mensagem de cadastro realizado com sucesso
                    ScriptManager.RegisterClientScriptBlock(BtnCadastrar, BtnCadastrar.GetType(), "msgSucesso", "alert('Classificação atualizada com sucesso.');", true);
                }

                else
                {
                    //Chama método de inserção BLL passando objeto como parâmetro
                    classificacaoBLL.InsereClassificacao(classificacao);

                    string htmlEmail = "";

                    //Envia e-mail com dados do cadastro realizado
                    Email email = new Email();

                    //Popula HTML e-mail
                    htmlEmail = PopulaHtmlClassificacao(Server.MapPath("~/Templates/EmailNovaClassificacao.html"), Session["NomeUsuario"].ToString(), classificacao.Nome, "", DateTime.Now);

                    // Envia E-mail
                    email.SendEmail("yule.souza@outlook.com", "Novo Cadastro Categoria", htmlEmail, Session["NomeUsuario"].ToString(), "", DateTime.Now);

                    //Exibe mensagem de cadastro realizado com sucesso
                    ScriptManager.RegisterClientScriptBlock(BtnCadastrar, BtnCadastrar.GetType(), "msgSucesso", "alert('Classificação cadastrada com sucesso.');", true);
                }

                //Limpa campos do formulário após inserir
                LimpaCampos();
            }
        }

        protected void BtnLimpar_ServerClick(object sender, EventArgs e)
        {
            LimpaCampos();
        }
        #endregion

        #region Métodos

        protected Classificacao Preencher(Classificacao classificacao)
        {
            if (classificacao.IdClassificacao == 0)
            {
                classificacao = new Classificacao();
            }

            if (!string.IsNullOrEmpty(TxtNome.Value))
            {
                classificacao.Nome = TxtNome.Value;
            }

            if (!string.IsNullOrEmpty(TxtDescricao.Value))
            {
                classificacao.Descricao = TxtDescricao.Value;
            }

            if (DrpAtivo.SelectedValue == "Sim")
            {
                classificacao.Ativo = true;
            }

            else
            {
                classificacao.Ativo = false;
            }

            classificacao.Empresa =  Convert.ToInt32(Session["EmpresaUsuario"].ToString());

            return classificacao;
        }

        protected Classificacao PreencherClassificacaoUpdate(DataTable dt)
        {
            Classificacao classificacao = new Classificacao();

            classificacao.IdClassificacao = Convert.ToInt32(dt.Rows[0]["IdClassificacao"].ToString());
            classificacao.Nome = dt.Rows[0]["Nome"].ToString();
            classificacao.Descricao = dt.Rows[0]["Descricao"].ToString();
            classificacao.Ativo = Convert.ToBoolean(dt.Rows[0]["Ativo"].ToString());

            return classificacao;
        }

        protected Boolean ValidaCampos(Classificacao classificacao)
        {
            Boolean varValidado = true;

            return varValidado;
        }

        protected void CarregaClassificacao(DataTable objClassificacao)
        {
            DataTable dt = objClassificacao;

            TxtNome.Value = dt.Rows[0]["Nome"].ToString();
            TxtDescricao.Value = dt.Rows[0]["Descricao"].ToString();
            Boolean ativo = Convert.ToBoolean(dt.Rows[0]["Ativo"].ToString());

            if (ativo == true)
            {
                DrpAtivo.SelectedValue = "Sim";
            }

            else
            {
                DrpAtivo.SelectedValue = "Nao";
            }
        }

        public string PopulaHtmlClassificacao(string caminhoHTML, string nomeUsuario, string nomeClassificacao, string linkAcesso, DateTime dataEnvio)
        {
            string corpoEmail = "";
            StreamReader streamReader = new StreamReader(caminhoHTML);
            corpoEmail = streamReader.ReadToEnd();

            //Preenche campos do HTML com os dados do cadastro realizado
            corpoEmail = corpoEmail.Replace("{NomeUsuario}", nomeUsuario);
            corpoEmail = corpoEmail.Replace("{NomeClassificacao}", nomeClassificacao);
            corpoEmail = corpoEmail.Replace("{LinkAcesso}", linkAcesso);
            corpoEmail = corpoEmail.Replace("{DataEnvio}", dataEnvio.ToString("{0:d/M/yyyy}"));

            return corpoEmail;
        }

        protected void LimpaCampos()
        {
            TxtNome.Value = string.Empty;
            TxtDescricao.Value = string.Empty;
            DrpAtivo.SelectedValue = "";
        }

        #endregion
    }
    #endregion
}