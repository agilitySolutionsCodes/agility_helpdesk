using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using BO;
using BLL;
using AgilityHelpDesk.Util;

namespace BOffice.Categorias
{
    #region Categorias
    public partial class Cadastro : System.Web.UI.Page
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["IdUsuario"] != null)
                {
                    if (Session["IdCategoriaUpdate"] != null)
                    {
                        Categoria categoria = new Categoria();

                        DataTable dt = new DataTable();
                        CategoriaBLL categoriaBLL = new CategoriaBLL();
                        dt = categoriaBLL.ListaCategoriaPorId(Convert.ToInt32(Session["IdCategoriaUpdate"].ToString()));

                        //Remove session que contém o código da categoria
                        Session.Remove("IdCategoriaUpdate");

                        //Preenche objeto e salva em session para caso de atualização
                        categoria = PreencherCategoriaUpdate(dt);
                        Session["objCategoria"] = categoria;

                        PreencherCampos(dt);
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
            CategoriaBLL categoriaBLL = new CategoriaBLL();
            Categoria categoria = null;

            if (Session["objCategoria"] != null)
            {
                //Instância objeto com valores da session
                categoria = (Categoria)Session["objCategoria"];
                Session.Remove("objCategoria");
            }

            else
                categoria = new Categoria();

            //Preenche o objeto categoria com dados do formulário
            categoria = Preencher(categoria);

            //Se a validação estiver Ok
            if (ValidaCampos(categoria) == true)
            {
                if (categoria.IdCategoria != 0)
                {
                    categoriaBLL.AtualizaCategoriaPorId(categoria);
                    //Exibe mensagem de cadastro atualizado com sucesso
                    ScriptManager.RegisterClientScriptBlock(BtnCadastrar, BtnCadastrar.GetType(), "msgSucesso", "alert('Categoria atualizada com sucesso.');", true);
                }

                else
                {
                    //Chama método de inserção BLL passando objeto como parâmetro
                    categoriaBLL.InsereCategoria(categoria);
                    //string htmlEmail = "";
                    //Envia e-mail com dados do cadastro realizado
                    //Email email = new Email();
                    //Popula HTML e-mail
                    //htmlEmail = PopulaHtmlCategoria(Server.MapPath("~/Templates/EmailNovaCategoria.html"), Session["NomeUsuario"].ToString(), categoria.Nome, "", DateTime.Now);
                    // Envia E-mail
                    //email.SendEmail("yule.souza@outlook.com", "Novo Cadastro Categoria", htmlEmail, Session["NomeUsuario"].ToString(), "", DateTime.Now);
                    //Exibe mensagem de cadastro realizado com sucesso
                    ScriptManager.RegisterClientScriptBlock(BtnCadastrar, BtnCadastrar.GetType(), "msgSucesso", "alert('Categoria cadastrada com sucesso.');", true);
                }

                //Limpa campos após cadastro ser realizado
                LimpaCampos();
            }
        }

        protected void BtnLimpar_ServerClick(object sender, EventArgs e)
        {
            LimpaCampos();
        }
        #endregion

        #region Métodos
        protected Categoria Preencher(Categoria categoria)
        {
            if (categoria.IdCategoria == 0)
            {
                categoria = new Categoria();
            }

            if (!string.IsNullOrEmpty(TxtNome.Value))
            {
                categoria.Nome = TxtNome.Value;
            }

            if (!string.IsNullOrEmpty(TxtDescricao.Value))
            {
                categoria.Descricao = TxtDescricao.Value;
            }

            if (DrpAtivo.SelectedValue == "Sim")
            {
                categoria.Ativo = true;
            }

            else
            {
                categoria.Ativo = false;
            }

            categoria.Empresa = Convert.ToInt32(Session["EmpresaUsuario"].ToString());

            //Retorna Objeto
            return categoria;
        }

        protected Categoria PreencherCategoriaUpdate(DataTable dt)
        {
            Categoria categoria = new Categoria();

            categoria.IdCategoria = Convert.ToInt32(dt.Rows[0]["IdCategoria"].ToString());
            categoria.Nome = dt.Rows[0]["Nome"].ToString();
            categoria.Descricao = dt.Rows[0]["Descricao"].ToString();
            categoria.Ativo = Convert.ToBoolean(dt.Rows[0]["Ativo"].ToString());

            return categoria;
        }

        protected Boolean ValidaCampos(Categoria categoria)
        {
            Boolean varValidado = true;
            return varValidado;
        }

        protected void PreencherCampos(DataTable objCategoria)
        {
            DataTable dt = objCategoria;

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

        public string PopulaHtmlCategoria(string caminhoHTML, string nomeUsuario, string nomeCategoria, string linkAcesso, DateTime dataEnvio)
        {
            string corpoEmail = "";
            StreamReader streamReader = new StreamReader(caminhoHTML);
            corpoEmail = streamReader.ReadToEnd();

            //Preenche campos do HTML com os dados do cadastro realizado
            corpoEmail = corpoEmail.Replace("{NomeUsuario}", nomeUsuario);
            corpoEmail = corpoEmail.Replace("{NomeCategoria}", nomeCategoria);
            corpoEmail = corpoEmail.Replace("{linkAcesso}", linkAcesso);
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