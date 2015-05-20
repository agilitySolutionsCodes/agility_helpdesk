using System;
using System.Text;
using System.Linq;
using System.Web;
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
    public partial class Login : System.Web.UI.Page
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

        protected void BtnLogar_ServerClick(object sender, EventArgs e)
        {
            // Lógica de botão aqui
            Usuario usuario = new Usuario();
            usuario.Email = TxtUsuario.Value;
            usuario.Senha = TxtSenha.Value;

            //Criptografa senha para autenticação
            var senha = CriptografarSenha(TxtSenha.Value);
            UsuarioBLL usuarioBLL = new UsuarioBLL();
            usuario = usuarioBLL.GetUsuarioPorSenha(usuario.Email, senha);

            if (ValidaCampos(usuario) == true)
            {
                //Abre novo ticket
                FormsAuthenticationTicket formTicket = new FormsAuthenticationTicket(usuario.IdUsuario,
                                                                                     usuario.Nome,
                                                                                     DateTime.Now,
                                                                                     DateTime.Now.AddMinutes(30),
                                                                                     true,
                                                                                     "",
                                                                                     FormsAuthentication.FormsCookiePath);

                Session.Add("IdUsuario", usuario.IdUsuario);
                Session.Add("NomeUsuario", usuario.Nome);
                Session.Add("ImagemUsuario", usuario.Imagem);
                Session.Add("EmpresaUsuario", usuario.Empresa);

                //Session criada com objeto usuário preenchido o mesmo poderá ser resgatado a qualquer momento em que se faça necessário seu uso dentro do contexto
                Session.Add("objetoUsuario", usuario);

                //Redireciona a página inicial
                Response.Redirect("~/Chamados-Fila");
            }
        }

        #endregion

        #region Métodos

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

        protected Boolean ValidaCampos(Usuario usuario)
        {
            Boolean varValidado = true;
            string pattern = TxtUsuario.Attributes["pattern"].ToString();
            Regex regex = new Regex(pattern);

            if (!regex.IsMatch(TxtUsuario.Value))
            {
                varValidado = false;
                ScriptManager.RegisterClientScriptBlock(BtnLogar, BtnLogar.GetType(), "msgFalha", "alert('E-mail inválido.');", true);
            }


            if (usuario.IdUsuario == 0)
            {
                ValidadorEmail.IsValid = false;
                ValidadorEmail.ErrorMessage = "Este usuário não foi localizado no sistema";
                ValidadorSenha.Visible = true;
                ValidadorEmail.SetFocusOnError = true;
                varValidado = false;
            }

            else if (usuario.Online == false)
            {
                ValidadorSenha.IsValid = false;
                ValidadorSenha.ErrorMessage = "*Atenção a senha digitada esta incorreta";
                ValidadorEmail.Visible = true;
                ValidadorSenha.SetFocusOnError = true;
                varValidado = false;
            }

            return varValidado;
        }

        #endregion
    }
}