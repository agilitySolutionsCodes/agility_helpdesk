using System;
using System.Text;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

using BO;
using BLL;
using AgilityHelpDesk.Util;

namespace Site.Paginas.Conta
{
    public partial class Recuperar : System.Web.UI.Page
    {
        #region Objetos
        TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
        MD5CryptoServiceProvider md5Crypto = new MD5CryptoServiceProvider();

        //Chave para criptografia
        String Chave = "AgilityWD";
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["IdUsuario"] != null)
                {
                    Response.Redirect("~/Chamados-Fila");
                }
            }
        }

        protected void BtnRecuperar_ServerClick(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.Email = TxtUsuario.Value;

            if (ValidaCampos(usuario) == true)
            {
                UsuarioBLL usuarioBLL = new UsuarioBLL();
                usuario = usuarioBLL.GetUsuarioPorEmail(usuario.Email);
                if (usuario.IdUsuario == 0 && usuario.Email == string.Empty)
                {
                    //ScriptManager.RegisterClientScriptBlock(BtnRecuperar, BtnRecuperar.GetType(), "msgAlerta", "alert('O e-mail informado não foi localizado no sistema.');", true);
                    ValidadorEmail.IsValid = false;
                    ValidadorEmail.ErrorMessage = "O e-mail informado não foi localizado no sistema.";
                    ValidadorEmail.SetFocusOnError = true;
                }

                else
                {
                    //Envia e-mail com dados do cadastro realizado
                    EmailSite email = new EmailSite();
                    //Popula HTML e-mail
                    string htmlEmail = PopulaHtml(Server.MapPath("~/Templates/RecuperacaoSenha.html"), usuario.Nome, "", DateTime.Now);
                    // Envia E-mail
                    email.SendEmail("yule.souza@outlook.com", "Nova Senha Sistema Help-Desk", htmlEmail, Server.MapPath("~/Templates/EmailNovaCategoria.html"),
                                    usuario.Nome, usuario.Senha, DateTime.Now);
                    //Método de envio de e-mail aqui
                    ScriptManager.RegisterClientScriptBlock(BtnRecuperar, BtnRecuperar.GetType(), "msgAlerta", "alert('Uma nova senha foi enviada para seu e-mail.');", true);
                    LimpaCampos();
                }
            }
        }

        #endregion

        #region Métodos

        public void LimpaCampos()
        {
            TxtUsuario.Value = string.Empty;
        }

        protected String CriptografarSenha(string senha)
        {
            des.Key = md5Crypto.ComputeHash(ASCIIEncoding.ASCII.GetBytes(Chave));
            des.Mode = CipherMode.ECB;
            ICryptoTransform desdencrypt = des.CreateEncryptor();
            ASCIIEncoding MyASCIIEncoding = new ASCIIEncoding();
            var buff = ASCIIEncoding.ASCII.GetBytes(senha);
            senha = Convert.ToBase64String(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));
            return senha;
        }

        public Boolean ValidaCampos(Usuario usuario)
        {
            Boolean varValidado = true;            
            string pattern = TxtUsuario.Attributes["pattern"].ToString();
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(TxtUsuario.Value))
            {
                varValidado = false;
                ScriptManager.RegisterClientScriptBlock(BtnRecuperar, BtnRecuperar.GetType(), "msgFalha", "alert('E-mail inválido.');", true);
            }

            if (string.IsNullOrEmpty(TxtUsuario.Value))
            {
                varValidado = false;
            }

            return varValidado;
        }

        public string PopulaHtml(string caminhoHTML, string nomeUsuario, string novaSenha, DateTime dataEnvio)
        {
            string corpoEmail = "";
            StreamReader streamReader = new StreamReader(caminhoHTML);
            corpoEmail = streamReader.ReadToEnd();
            //Preenche campos do HTML com os dados do cadastro realizado
            corpoEmail = corpoEmail.Replace("{NomeUsuario}", nomeUsuario);
            corpoEmail = corpoEmail.Replace("{NovaSenha}", novaSenha);
            corpoEmail = corpoEmail.Replace("{DataEnvio}", dataEnvio.ToString("{0:d/M/yyyy}"));

            return corpoEmail;
        }

        #endregion
    }
}