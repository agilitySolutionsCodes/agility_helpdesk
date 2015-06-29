using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using BLL;
using BO;


namespace Site
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        #region Eventos

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["objetoUsuario"] != null)
                {
                    Usuario usuario = (Usuario)Session["objetoUsuario"];

                    if (Session["IdUsuario"] != null)
                    {
                        lblUsuario.InnerText = Session["NomeUsuario"].ToString();
                        //ImgUsuarioLogado.ImageUrl = Request.ApplicationPath + "Uploads/" + Session["ImagemUsuario"].ToString();
                        ImgUsuarioLogado.ImageUrl = Request.ApplicationPath + "/Uploads/" + Session["ImagemUsuario"].ToString();
                        ImgUsuarioLogado.Visible = true;
                        content_saudacao.Visible = true;
                        search.Visible = true;
                        left_nav.Visible = true;

                        if (usuario.Perfil == "S")
                        {
                            dvChamadosFila.Visible = false;
                            dvNovoChamado.Visible = true;
                        }

                        else
                        {
                            dvChamadosFila.Visible = true;
                            dvNovoChamado.Visible = false;
                        }
                    }
                }
            }
        }

        protected void BtnBuscar_ServerClick(object sender, EventArgs e)
        {
            Session.Add("palavraChave", txtBusca.Value);
            Response.Redirect("~/Busca");
        }

        protected void BtnSair_ServerClick(object sender, EventArgs e)
        {
            //Logout aqui
            Session.RemoveAll();
            Response.Redirect("~/Conta");
        }

        protected void drpPrioridade_Changed(object sender, EventArgs e)
        {
            GridView grv = (GridView)MainContent.FindControl("GrdChamados");
            grv.Sort(drpPrioridade.SelectedValue, SortDirection.Ascending);
        }

        private string GetSortDirection(string column)
        {

            // By default, set the sort direction to ascending.
            string sortDirection = "ASC";

            // Retrieve the last column that was sorted.
            string sortExpression = ViewState["SortExpression"] as string;

            if (sortExpression != null)
            {
                // Check if the same column is being sorted.
                // Otherwise, the default value can be returned.
                if (sortExpression == column)
                {
                    string lastDirection = ViewState["SortDirection"] as string;
                    if ((lastDirection != null) && (lastDirection == "ASC"))
                    {
                        sortDirection = "DESC";
                    }
                }
            }

            // Save new values in ViewState.
            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;

            return sortDirection;
        }

        #endregion

        #region Métodos

        #endregion
    }
}