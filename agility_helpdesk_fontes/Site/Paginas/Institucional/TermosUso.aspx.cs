using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site.Paginas.Institucional
{
    public partial class TermosUso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuaro"] != null)
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