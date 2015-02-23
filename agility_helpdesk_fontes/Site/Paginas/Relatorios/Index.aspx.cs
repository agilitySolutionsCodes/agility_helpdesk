using System;
using System.Web;
using System.Linq;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web.UI.DataVisualization.Charting;

using BO;
using BLL;

namespace Site.Paginas.Relatorios
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Instância de novo usuário
                Usuario usuario = null;
                //Converte a session com dados do usuário para objeto que acaba de ser criado
                usuario = (Usuario)Session["objetoUsuario"];

                if (Session["IdUsuario"] != null)
                {
                    //Caso a session do usuário não esteja vazia
                    if (usuario.Administrador != false)
                    {
                        //Oculta filtro de chamados
                        Label lblOrdenar = (Label)Master.FindControl("LblOrdenar");
                        lblOrdenar.Visible = false;

                        //Instância novo objeto Master Page
                        DropDownList drpFiltro = (DropDownList)Master.FindControl("drpPrioridade");
                        drpFiltro.Visible = false;

                        DataTable dt = new DataTable();

                        //Se a session estiver em branco o parâmetro deve ser null
                        if (Session["StatusFiltro"] == null)
                        {
                            //Carrega relatório com todos os chamados
                            dt = CarregaRelatorio(usuario.Empresa, "");
                        }

                        else
                        {
                            //Carrega relatório de acordo com filtro selecionado
                            dt = CarregaRelatorio(usuario.Empresa, Session["StatusFiltro"].ToString());
                        }
                    }

                    else
                    {
                            //Usuário não tem acesso a relatórios
                    }
                }

                else
                {
                    //Redireciona a página de login
                    Response.Redirect("~/Conta");
                }
            }
        }

        #region Métodos

        public DataTable CarregaRelatorio(int idEmpresa, string statusFiltro)
        {
            DataTable dt = new DataTable();
            //Instância de ChamadosBLL
            ChamadosBLL chamadosBLL = new ChamadosBLL();
            //Chama método BLL GetNumeroChamados
            dt = chamadosBLL.GetNumeroChamados(idEmpresa, statusFiltro);

            //Se o objeto dt não estiver vazio
            if (dt.Rows.Count > 0)
            {
                ChartReport.DataSource = dt;

                ChartReport.ChartAreas["ChartAreaReport"].AxisY.Title = "Número de Chamados";
                ChartReport.ChartAreas["ChartAreaReport"].AxisX.Title = "Categoria do Chamado";
                ChartReport.ChartAreas["ChartAreaReport"].AxisY.TitleFont = new System.Drawing.Font("Verdana, Geneva, sans-serif", 9.50F, System.Drawing.FontStyle.Bold);
                ChartReport.ChartAreas["ChartAreaReport"].AxisX.TitleFont = new System.Drawing.Font("Verdana, Geneva, sans-serif", 9.50F, System.Drawing.FontStyle.Bold);
                ChartReport.ChartAreas["ChartAreaReport"].AxisY.LabelStyle.Font = new System.Drawing.Font("Verdana, Geneva, sans-serif;", 9.05F, System.Drawing.FontStyle.Regular);
                ChartReport.ChartAreas["ChartAreaReport"].AxisX.LabelStyle.Font = new System.Drawing.Font("Verdana, Geneva, sans-serif;", 9.05F, System.Drawing.FontStyle.Regular);

                ChartReport.Series["SeriesReport"].YValueMembers = "NumeroOcorrencias";
                ChartReport.Series["SeriesReport"].XValueMember = "CategoriaDoChamado";

                ChartReport.DataBind();

            }

            else
            {
                //Exibe mensagem
                LblMsgmChamados.Text = "Existem" + " " + Convert.ToString(dt.Rows.Count.ToString()) + " " + "chamados abertos no momento";
                LblMsgmChamados.Visible = true;
            }

            return dt;
        }

        #endregion
    }
}