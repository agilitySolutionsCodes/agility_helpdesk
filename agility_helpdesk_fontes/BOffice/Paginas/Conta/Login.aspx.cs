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

using BO;
using BLL;

namespace BOffice.Conta
{
    #region Login
    public partial class Login : System.Web.UI.Page
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["IdUsuario"] != null)
                {
                    Response.Redirect("~/Home");
                }
            }
        }
        
        protected void BtnLogar_ServerClick(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.Email = TxtUsuario.Value;
            usuario.Senha = TxtSenha.Value;

            UsuarioBLL usuarioBLL = new UsuarioBLL();

            var senha = TxtSenha.Value;
            senha = usuarioBLL.CriptografarSenha(senha);
            usuario = usuarioBLL.GetUsuarioAdminPorSenha(usuario.Email, senha);

            if (ValidaCampos(usuario) == true)
            {
                //Abre novo ticket
                FormsAuthenticationTicket formTicket = new FormsAuthenticationTicket(usuario.IdUsuario,
                                                                                     usuario.Nome,
                                                                                     DateTime.Now,
                                                                                     DateTime.Now.AddMinutes(20),
                                                                                     true,
                                                                                     "",
                                                                                     FormsAuthentication.FormsCookiePath);

                Session.Add("IdUsuario", usuario.IdUsuario);
                Session.Add("NomeUsuario", usuario.Nome);
                Session.Add("EmpresaUsuario", usuario.Empresa);

                //Session criada com objeto usuário preenchido o mesmo poderá ser resgatado a qualquer momento em que se faça necessário seu uso dentro do contexto
                Session.Add("objetoUsuario", usuario);

                //Redireciona a página inicial
                Response.Redirect("~/Home");
            }
        }

        #endregion

        #region Métodos

        protected Boolean ValidaCampos(Usuario usuario)
        {
            Boolean varValidado = true;

            if (usuario.IdUsuario == 0)
            {
                ValidadorEmail.IsValid = false;
                ValidadorEmail.ErrorMessage = "Este usuário não foi localizado no sistema";
                ValidadorEmail.Visible = false;
                ValidadorEmail.SetFocusOnError = true;
                varValidado = false;
            }

            else if (usuario.Online == false)
            {
                ValidadorSenha.IsValid = false;
                ValidadorSenha.ErrorMessage = "*Atenção a senha digitada esta incorreta";
                ValidadorEmail.Visible = false;
                ValidadorSenha.SetFocusOnError = true;
                varValidado = false;
            }

            else if (usuario.Administrador == false)
            {
                ValidadorSenha.IsValid = false;
                ValidadorSenha.ErrorMessage = "*Atenção não foi possivel login no sistema entre em contato com o administrador";
                ValidadorEmail.Visible = false;
                ValidadorSenha.SetFocusOnError = true;
                varValidado = false;
            }

            return varValidado;
        }

        #endregion
    }
    #endregion 
}