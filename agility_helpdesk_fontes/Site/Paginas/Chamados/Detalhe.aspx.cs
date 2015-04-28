using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BLL;
using BO;

namespace Site.Paginas.Chamados
{
    public partial class Detalhe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["IdUsuario"] != null)
                {
                    string valorUrlIdChamado = Request.QueryString["IdChamado"];

                    if (valorUrlIdChamado != "")
                    {
                        DataTable dt = new DataTable();
                        ChamadosBLL chamadoBLL = new ChamadosBLL();
                        dt = chamadoBLL.ListaDetalheChamados(Convert.ToInt32(valorUrlIdChamado));

                        if (dt.Rows.Count > 0)
                        {
                            Preencher(dt, Convert.ToInt32(Session["IdUsuario"].ToString()));

                            //Oculta filtro de chamados
                            Label lblOrdenar = (Label)Master.FindControl("LblOrdenar");
                            lblOrdenar.Visible = false;

                            DropDownList drpFiltro = (DropDownList)Master.FindControl("drpPrioridade");
                            drpFiltro.Visible = false;
                        }
                    }
                }

                else
                {
                    Session.RemoveAll();
                    Response.Redirect("~/Conta");
                }
            }
        }

        #region Eventos

        protected void BtnEncerrar_ServerClick(object sender, EventArgs e)
        {
            //Encerra Chamado e envia para aprovação
            Chamado chamado = new Chamado();
            ChamadosBLL chamadosBLL = new ChamadosBLL();

            string valorUrlIdChamado = Request.QueryString["IdChamado"];
            chamado.IdChamado = Convert.ToInt32(valorUrlIdChamado);

            if (TxtComentario.InnerText.Length == 0 && LblComentarioII.Text == string.Empty)
            {
                ScriptManager.RegisterClientScriptBlock(BtnEncerrar, BtnEncerrar.GetType(), "msgAlerta", "alert('Para finalizar o chamado insira um comentário.');", true);
                LblComentario.Visible = true;
                TxtComentario.Visible = true;
                TxtComentario.Focus();
            }

            else
            {
                chamado = chamadosBLL.FinalizarChamadoAprovar(Convert.ToInt32(Session["IdUsuario"].ToString()), chamado.IdChamado, chamado.Observacao);

                if (chamado.Ok == true)
                {
                    Session.Add("StatusChamadoFA", chamado.Ok);
                    Response.Redirect("~/Meus-Chamados");
                }

                else
                {
                    ScriptManager.RegisterClientScriptBlock(BtnEncerrar, BtnEncerrar.GetType(), "msgFalha", "alert('Não é possivel finalizar um chamado aberto por você.');", true);
                }
            }
        }

        protected void BtnFinalizar_ServerClick(object sender, EventArgs e)
        {
            //Finaliza chamado aqui
            string valorUrlIdChamado = Request.QueryString["IdChamado"];

            Chamado chamado = new Chamado();
            ChamadosBLL chamadosBLL = new ChamadosBLL();

            chamado.IdChamado = Convert.ToInt32(valorUrlIdChamado);
            chamado.Observacao = TxtComentario.Value;

            if (LblComentarioII.Text != string.Empty)
            {
                chamado = chamadosBLL.FinalizarChamado(Convert.ToInt32(Session["IdUsuario"].ToString()), chamado.IdChamado);
                ScriptManager.RegisterClientScriptBlock(BtnFinalizar, BtnFinalizar.GetType(), "msgSucesso", "alert('Chamado finalizado com sucesso.');", true);
            }
        }

        protected void BtnCancelar_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Meus-Chamados");
        }

        #endregion

        #region Métodos

        protected void Preencher(DataTable dtChamado, int idUsuario)
        {
            LblNumeroChamado.Text = dtChamado.Rows[0]["IdChamado"].ToString();
            LblDataAbertura.Text = dtChamado.Rows[0]["DataAbertura"].ToString();
            LblSolicitante.Text = dtChamado.Rows[0]["NomeSolicitante"].ToString();
            LblCategoria.Text = dtChamado.Rows[0]["NomeCategoria"].ToString();
            LblAssunto.Text = dtChamado.Rows[0]["Assunto"].ToString();

            if (dtChamado.Rows[0]["Anexo"].ToString() != "")
            {
                LinkAnexo.InnerHtml = dtChamado.Rows[0]["Anexo"].ToString();
                LinkAnexo.HRef = "~/Uploads/" + dtChamado.Rows[0]["Anexo"].ToString();
            }

            if (dtChamado.Rows[0]["Observacao"].ToString() != "")
            {
                LblComentario.Visible = true;
                LblComentarioII.Visible = true;
                LblComentarioII.Text = dtChamado.Rows[0]["Observacao"].ToString();
            }

            LtlDescricao.Text = dtChamado.Rows[0]["Descricao"].ToString();

            if (dtChamado.Rows.Count > 0)
            {
                //Validação para mudança de valores no grid referente a status do chamado
                for (int i = 0; i < dtChamado.Rows.Count; i++)
                {
                    if (dtChamado.Rows[i]["StatusChamado"].ToString() == "P ")
                    {
                        LblStatus.Text = "Pendente";
                    }

                    if (dtChamado.Rows[i]["StatusChamado"].ToString() == "A ")
                    {
                        LblStatus.Text = "Em atendimento";
                        BtnFinalizar.Visible = false;
                    }

                    if (dtChamado.Rows[i]["StatusChamado"].ToString() == "FA")
                    {
                        LblStatus.Text = "Aguardando Aprovação";
                    }

                    if (dtChamado.Rows[i]["StatusChamado"].ToString() == "F ")
                    {
                        LblStatus.Text = "Finalizado";
                        BtnEncerrar.Visible = false;
                        BtnFinalizar.Visible = false;
                        BtnCancelar.Visible = false;
                    }

                    if (dtChamado.Rows[i]["StatusChamado"].ToString() == "FA" && Convert.ToInt32(dtChamado.Rows[i]["Solicitante"].ToString()) == idUsuario)
                    {
                        BtnFinalizar.Visible = true;
                        BtnCancelar.Visible = false;
                    }

                    if (dtChamado.Rows[i]["StatusChamado"].ToString() == "A" && Convert.ToInt32(dtChamado.Rows[i]["Atendente"].ToString()) == idUsuario)
                    {
                        BtnEncerrar.Visible = true;
                        BtnCancelar.Visible = false;
                    }
                }

                //Validação para mudança de valores no grid referente a prioridade do chamado
                for (int i = 0; i < dtChamado.Rows.Count; i++)
                {
                    if (dtChamado.Rows[i]["Prioridade"].ToString() == "A ")
                    {
                        LblPrioridade.Text = "Alta";
                    }

                    if (dtChamado.Rows[i]["Prioridade"].ToString() == "M ")
                    {
                        LblPrioridade.Text = "Média";
                    }

                    if (dtChamado.Rows[i]["Prioridade"].ToString() == "B ")
                    {
                        LblPrioridade.Text = "Baixa";
                    }
                }
            }
        }

        #endregion
    }
}