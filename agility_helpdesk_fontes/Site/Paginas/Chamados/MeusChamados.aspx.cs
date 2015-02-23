using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using BO;
using BLL;

namespace Site.Paginas.Chamados
{
    public partial class MeusChamados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["IdUsuario"] != null)
                {
                    if (Session["StatusChamadoFA"] != null)
                    {
                        ScriptManager.RegisterClientScriptBlock(GrdChamados, GrdChamados.GetType(), "msgSucesso", "alert('Chamado enviado com sucesso aguarde a aprovação.');", true);
                        Session.Remove("StatusChamadoFA");
                    }

                    CarregaChamados(Convert.ToInt32(Session["IdUsuario"].ToString()));
                }

                else
                {
                    Session.RemoveAll();
                    Response.Redirect("~/Conta");
                }
            }
        }

        #region Eventos

        protected void GrdChamados_RowCommand(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GrdChamados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GrdChamados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //Mudar código aqui para melhorar performance

            DataTable dt = new DataTable();
            ChamadosBLL chamadosBLL = new ChamadosBLL();
            dt = chamadosBLL.ListaChamadosPorId(Convert.ToInt32(Session["IdUsuario"].ToString()));

            GrdChamados.DataSource = dt;
            GrdChamados.PageIndex = e.NewPageIndex;

            if (dt.Rows.Count > 0)
            {
                GrdChamados.DataSource = dt;

                //Validação para mudança de valores no grid referente a status do chamado
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["StatusChamado"].ToString() == "P ")
                    {
                        dt.Rows[i]["StatusChamado"] = "Pendente";
                    }

                    if (dt.Rows[i]["StatusChamado"].ToString() == "A ")
                    {
                        dt.Rows[i]["StatusChamado"] = "Em atendimento";
                    }

                    if (dt.Rows[i]["StatusChamado"].ToString() == "F ")
                    {
                        dt.Rows[i]["StatusChamado"] = "Finalizado";
                    }
                }

                //Validação para mudança de valores no grid referente a prioridade do chamado
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Prioridade"].ToString() == "0 ")
                    {
                        dt.Rows[i]["Prioridade"] = "Alta";
                    }

                    if (dt.Rows[i]["Prioridade"].ToString() == "1 ")
                    {
                        dt.Rows[i]["Prioridade"] = "Média";
                    }

                    if (dt.Rows[i]["Prioridade"].ToString() == "2 ")
                    {
                        dt.Rows[i]["Prioridade"] = "Baixa";
                    }
                }

                GrdChamados.DataBind();
            }
        }

        protected void GrdChamados_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            ChamadosBLL chamadosBLL = new ChamadosBLL();
            DataTable dt = new DataTable();
            dt = chamadosBLL.ListaChamadosPorId(Convert.ToInt32(Session["IdUsuario"].ToString()));

            if (dt.Rows.Count > 0)
            {
                dt.DefaultView.Sort = e.SortExpression + " " + GetDirecaoSort(e.SortExpression);

                GrdChamados.DataSource = dt;

                //Validação para mudança de valores no grid referente a status do chamado
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["StatusChamado"].ToString() == "P ")
                    {
                        dt.Rows[i]["StatusChamado"] = "Pendente";
                    }

                    if (dt.Rows[i]["StatusChamado"].ToString() == "A ")
                    {
                        dt.Rows[i]["StatusChamado"] = "Em atendimento";
                    }

                    if (dt.Rows[i]["StatusChamado"].ToString() == "F ")
                    {
                        dt.Rows[i]["StatusChamado"] = "Finalizado";
                    }
                }

                //Validação para mudança de valores no grid referente a prioridade do chamado
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Prioridade"].ToString() == "0 ")
                    {
                        dt.Rows[i]["Prioridade"] = "Alta";
                    }

                    if (dt.Rows[i]["Prioridade"].ToString() == "1 ")
                    {
                        dt.Rows[i]["Prioridade"] = "Média";
                    }

                    if (dt.Rows[i]["Prioridade"].ToString() == "2 ")
                    {
                        dt.Rows[i]["Prioridade"] = "Baixa";
                    }
                }

                GrdChamados.DataBind();
            }
        }

        private string GetDirecaoSort(string coluna)
        {
            // Por padrão, a direção do sorteio é ascendente.
            string direcaoSorteio = "ASC";

            // Recupera a ultima coluna que foi sorteada.
            string sortExpression = ViewState["SortExpression"] as string;

            if (sortExpression != null)
            {
                // Compara se a mesma coluna foi sorteada.

                // Senão, o valor padrão é retornado.
                if (sortExpression == coluna)
                {
                    string ultimaDirecao = ViewState["DirecaoSort"] as string;
                    if ((ultimaDirecao != null) && (ultimaDirecao == "ASC"))
                    {
                        direcaoSorteio = "DESC";
                    }
                }
            }

            // Salva os novos valores em uma ViewState.
            ViewState["DirecaoSort"] = direcaoSorteio;
            ViewState["SortExpression"] = coluna;

            return direcaoSorteio;
        }

        #endregion

        #region Métodos

        protected void CarregaChamados(int IdUsuario)
        {
            DataTable dt = new DataTable();
            ChamadosBLL chamadosBLL = new ChamadosBLL();
            dt = chamadosBLL.ListaChamadosPorId(Convert.ToInt32(Session["IdUsuario"].ToString()));

            GrdChamados.DataSource = dt;

            //Validação para mudança de valores no grid referente a status do chamado

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["StatusChamado"].ToString() == "P ")
                {
                    dt.Rows[i]["StatusChamado"] = "Pendente";
                }

                if (dt.Rows[i]["StatusChamado"].ToString() == "A ")
                {
                    dt.Rows[i]["StatusChamado"] = "Em atendimento";
                }

                if (dt.Rows[i]["StatusChamado"].ToString() == "FA")
                {
                    dt.Rows[i]["StatusChamado"] = "Aguardando Aprovação";
                }

                if (dt.Rows[i]["StatusChamado"].ToString() == "F ")
                {
                    dt.Rows[i]["StatusChamado"] = "Finalizado";
                }
            }

            //Validação para mudança de valores no grid referente a prioridade do chamado

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["Prioridade"].ToString() == "A ")
                {
                    dt.Rows[i]["Prioridade"] = "Alta";
                }

                if (dt.Rows[i]["Prioridade"].ToString() == "M ")
                {
                    dt.Rows[i]["Prioridade"] = "Média";
                }

                if (dt.Rows[i]["Prioridade"].ToString() == "B ")
                {
                    dt.Rows[i]["Prioridade"] = "Baixa";
                }
            }

            GrdChamados.DataBind();

            if (dt.Rows.Count < 1)
            {
                //Oculta filtro de chamados
                Label lblOrdenar = (Label)Master.FindControl("LblOrdenar");
                lblOrdenar.Visible = false;

                DropDownList drpFiltro = (DropDownList)Master.FindControl("drpPrioridade");
                drpFiltro.Visible = false;

                //Exibe mensagem
                LblMsgmChamados.Text = "Você não possui chamados em atendimento no momento";
                LblMsgmChamados.Visible = true;
            }

            else
            {
                //Exibe mensagem
                LblMsgmChamados.Text = "Existem" + " " + Convert.ToString(dt.Rows.Count.ToString()) + " " + "chamados abertos no momento";
                LblMsgmChamados.Visible = true;
            }
        }

        #endregion
    }
}