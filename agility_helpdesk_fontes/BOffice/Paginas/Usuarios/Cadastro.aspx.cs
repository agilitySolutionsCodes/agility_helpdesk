using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

using BO;
using BLL;

namespace BOffice.Usuarios
{
    public partial class Cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["objetoUsuario"] != null)
                {
                    Usuario usuario = (Usuario)Session["objetoUsuario"];

                    if (Session["IdUsuarioUpdate"] != null)
                    {
                        DataTable dt = new DataTable();
                        UsuarioBLL usuarioBLL = new UsuarioBLL();
                        dt = usuarioBLL.ListaUsuarioPorId(Convert.ToInt32(Session["IdUsuarioUpdate"].ToString()));

                        if (dt.Rows.Count > 0)
                        {
                            LoadCentroCusto(usuario);

                            //Preenche objeto e salva em session para caso de atualização
                            usuario = PreencheUsuarioUpdate(dt);
                            Session["objUsuario"] = usuario;

                            PreencherCamposUpdate(usuario);
                        }
                    }

                    else
                    {
                        LoadCentroCusto(usuario);
                        LimpaCampos();
                    }
                }

                else
                {
                    Session.RemoveAll();
                    Response.Redirect("~/Conta");
                }

            }
        }

        #region Objetos

        #endregion

        #region Eventos

        protected void BtnCadastrar_ServerClick(object sender, EventArgs e)
        {
            if (Session["objetoUsuario"] != null)
            {
                //Instância de usuárioBLL
                UsuarioBLL usuarioBLL = new UsuarioBLL();
                Usuario usuario = new Usuario();
                Boolean varValidado = ValidaEmail();

                if (varValidado == true)
                {
                    varValidado = ValidaSenhas();    
                }

                //Metodo de Validação de dados
                if (varValidado != false)
                {
                    //Preenche Objeto com dados da página
                    usuario = Preencher(usuario);

                    if (Session["IdUsuarioUpdate"] != null)
                    {
                        //Validação para upload de foto 
                        if (!string.IsNullOrEmpty(usuario.Imagem))
                        {
                            if (UploadImagem.HasFile)
                            {
                                UploadImagem.SaveAs(Server.MapPath("~/Uploads/") + usuario.Imagem);
                            }
                        }

                        //Chama BLL e método de atualização de usuário
                        usuarioBLL.AtualizaUsuarioPorId(usuario);
                        //Exibe mensagem de cadastro realizado com sucesso
                        ScriptManager.RegisterClientScriptBlock(BtnCadastrar, BtnCadastrar.GetType(), "msgSucesso", "alert('Usuário atualizado com sucesso.');", true);

                        //Remove a session que contém o código do usuário 
                        Session.Remove("IdUsuarioUpdate");
                        LimpaCampos();
                    }

                    else
                    {
                        //Valida se e-mail ja existe na base
                        usuario.Ok = usuarioBLL.ValidaEmail(usuario.Email);

                        if (usuario.Ok == false)
                        {
                            ScriptManager.RegisterClientScriptBlock(BtnCadastrar, BtnCadastrar.GetType(), "msgFalha", "alert('O e-mail informado ja foi cadastrado.');", true);
                            TxtEmail.Focus();
                        }

                        else
                        {
                            if (UploadImagem.HasFile)
                            {
                                UploadImagem.SaveAs(Server.MapPath("~/Uploads/") + usuario.Imagem);
                            }

                            //Chama BLL e insere usuário
                            usuarioBLL.InsereUsuario(usuario);

                            //Exibe mensagem de cadastro realizado com sucesso
                            ScriptManager.RegisterClientScriptBlock(BtnCadastrar, BtnCadastrar.GetType(), "msgSucesso", "alert('Usuário cadastrado com sucesso.');", true);

                            //Limpa campos após cadastro ser realizado
                            LimpaCampos();
                        }
                    }
                }
            }
        }

        protected void BtnLimpar_ServerClick(object sender, EventArgs e)
        {
            //Chama método para limpar os campos do formulário
            LimpaCampos();
        }

        #endregion

        #region Métodos

        #region Validações

        protected Boolean ValidaSenhas()
        {
            //Variável de validação
            Boolean varValidado = true;

            if (TxtSenha.Value != TxtConfirmacaoSenha.Value)
            {
                varValidado = false;
                ScriptManager.RegisterClientScriptBlock(BtnCadastrar, BtnCadastrar.GetType(), "msgFalha", "alert('As senhas não conferem.');", true);
            }

            return varValidado;
        }

        protected Boolean ValidaEmail()
        {
            //Variável de validação
            Boolean varValidado = true;

            string pattern = TxtEmail.Attributes["pattern"].ToString();
            Regex regex = new Regex(pattern);


            if (!regex.IsMatch(TxtEmail.Value))
            {
                varValidado = false;
                ScriptManager.RegisterClientScriptBlock(BtnCadastrar, BtnCadastrar.GetType(), "msgFalha", "alert('E-mail inválido.');", true);
            }

            return varValidado;
        }

        protected Usuario Preencher(Usuario usuario)
        {
            if (usuario.IdUsuario == 0)
            {
                usuario = new Usuario();
            }

            if (Session["IdUsuarioUpdate"] != null)
            {
                usuario.IdUsuario = Convert.ToInt32(Session["IdUsuarioUpdate"]);
            }

            usuario.Nome = TxtNome.Value;
            usuario.Email = TxtEmail.Value;
            usuario.Departamento = Convert.ToInt32(DrpCentroCusto.SelectedValue);
            usuario.Cargo = TxtCargo.Value;
            usuario.Telefone = TxtTelefone.Value;
            usuario.Empresa = Convert.ToInt32(Session["EmpresaUsuario"]);
            usuario.Ramal = TxtRamal.Value;
            usuario.Imagem = UploadImagem.FileName;
            usuario.Senha = TxtConfirmacaoSenha.Value;
            usuario.Perfil = DrpPerfil.SelectedValue;

            if (DrpAtivo.SelectedValue == "Sim")
            {
                usuario.Ativo = true;
            }

            else
            {
                usuario.Ativo = false;
            }

            if (DrpAdmin.SelectedValue == "Sim")
            {
                usuario.Administrador = true;
            }

            else
            {
                usuario.Administrador = false;
            }

            return usuario;
        }

        public void PreencherCamposUpdate(Usuario usuario)
        {
            TxtNome.Value = usuario.Nome;
            TxtEmail.Value = usuario.Email;
            DrpCentroCusto.SelectedValue = usuario.Departamento.ToString();
            DrpPerfil.SelectedValue = usuario.Perfil;
            TxtCargo.Value = usuario.Cargo;
            TxtTelefone.Value = usuario.Telefone;

            TxtRamal.Value = usuario.Ramal;

            TxtSenha.Disabled = true;
            ValidatorSenha.Enabled = false;
            TxtSenha.Visible = false;
            TxtConfirmacaoSenha.Disabled = true;
            TxtConfirmacaoSenha.Visible = false;
            ValidatorConfSenha.Enabled = false;
            trSenhas.Visible = false;

            if (usuario.Ativo == true)
            {
                DrpAtivo.SelectedValue = "Sim";
            }

            else
            {
                DrpAtivo.SelectedValue = "Nao";
            }

            if (usuario.Administrador == true)
            {
                DrpAdmin.SelectedValue = "Sim";
            }

            else
            {
                DrpAdmin.SelectedValue = "Nao";
            }
        }

        protected Usuario PreencheUsuarioUpdate(DataTable dt)
        {
            Usuario usuario = new Usuario();

            usuario.IdUsuario = Convert.ToInt32(dt.Rows[0]["IdUsuario"].ToString());
            usuario.Nome = dt.Rows[0]["Nome"].ToString();
            usuario.Email = dt.Rows[0]["Email"].ToString();
            usuario.Cargo = dt.Rows[0]["Cargo"].ToString();
            usuario.Telefone = dt.Rows[0]["Telefone"].ToString();
            usuario.Ramal = dt.Rows[0]["Ramal"].ToString();
            usuario.Empresa = Convert.ToInt32(dt.Rows[0]["Empresa"].ToString());
            usuario.Ativo = Convert.ToBoolean(dt.Rows[0]["Ativo"].ToString());
            usuario.Administrador = Convert.ToBoolean(dt.Rows[0]["Administrador"].ToString());
            usuario.Imagem = dt.Rows[0]["Imagem"].ToString();
            usuario.Departamento = Convert.ToInt32(dt.Rows[0]["Departamento"].ToString());
            usuario.Perfil = dt.Rows[0]["Perfil"].ToString();

            return usuario;
        }

        #endregion

        protected void LoadCentroCusto(Usuario usuario)
        {
            EmpresaBLL empresaBLL = new EmpresaBLL();
            DataTable dt = new DataTable();

            dt = empresaBLL.GetCentroCusto(usuario);

            DrpCentroCusto.DataSource = dt;
            DrpCentroCusto.DataBind();

            DrpCentroCusto.Items.Insert(0, "Selecione");
            DrpCentroCusto.Items[0].Value = "";

        }

        public string PopulaHtmlUsuario(string caminhoHTML, string nomeUsuario, string emailUsuario, string linkAcesso, DateTime dataEnvio)
        {
            string corpoEmail = "";
            StreamReader streamReader = new StreamReader(caminhoHTML);
            corpoEmail = streamReader.ReadToEnd();

            //Preenche campos do HTML com os dados do cadastro realizado
            corpoEmail = corpoEmail.Replace("{NomeUsuario}", nomeUsuario);
            corpoEmail = corpoEmail.Replace("{EmailUsuario}", emailUsuario);
            corpoEmail = corpoEmail.Replace("{LinkAcesso}", linkAcesso);
            corpoEmail = corpoEmail.Replace("{DataEnvio}", dataEnvio.ToString("{0:d/M/yyyy}"));

            return corpoEmail;
        }

        protected void LimpaCampos()
        {
            TxtNome.Value = string.Empty;
            TxtEmail.Value = string.Empty;
            DrpCentroCusto.SelectedValue = "";
            TxtCargo.Value = string.Empty;
            TxtTelefone.Value = string.Empty;
            TxtRamal.Value = string.Empty;
            DrpPerfil.SelectedValue = "";
            DrpAtivo.SelectedValue = "";
            TxtSenha.Value = string.Empty;
            TxtConfirmacaoSenha.Value = string.Empty;
            DrpAdmin.SelectedValue = "";
        }

        #endregion
    }
}