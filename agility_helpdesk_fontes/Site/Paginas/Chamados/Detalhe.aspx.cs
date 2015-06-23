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

                            ListaComentarios(Convert.ToInt32(valorUrlIdChamado));

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

        protected void BtnFinalizar_ServerClick(object sender, EventArgs e)
        {
            string valorUrlIdChamado = Request.QueryString["IdChamado"];

            Chamado chamado = new Chamado();
            ChamadosBLL chamadosBLL = new ChamadosBLL();

            chamado.IdChamado = Convert.ToInt32(valorUrlIdChamado);

            chamado = chamadosBLL.FinalizarChamado(Convert.ToInt32(Session["IdUsuario"].ToString()), chamado.IdChamado);
            ScriptManager.RegisterClientScriptBlock(BtnFinalizar, BtnFinalizar.GetType(), "msgSucesso", "alert('Chamado finalizado com sucesso.');", true);

        }

        protected void BtnCancelar_ServerClick(object sender, EventArgs e)
        {
            BtnFinalizar.Visible = true;
            LnkComentario.Visible = true;
            TxtComentario.Visible = false;
            BtnEnviar.Visible = false;
            BtnCancelar.Visible = false;
        }

        protected void LnkComentario_ServerClick(object sender, EventArgs e)
        {
            BtnFinalizar.Visible = false;
            LnkComentario.Visible = false;
            TxtComentario.Visible = true;
            BtnCancelar.Visible = true;
            BtnEnviar.Visible = true;
        }

        protected void BtnEnviarComentario_ServerClick(object sender, EventArgs e)
        {
            ChamadosBLL chamadoBLL = new ChamadosBLL();
            Chamado chamado = new Chamado();
            chamado.IdChamado = Convert.ToInt32(Request.QueryString["IdChamado"]);
            chamado.Solicitante = Convert.ToInt32(Session["IdUsuario"]);
            chamado.Observacao = TxtComentario.Value;
            chamado.DataModificacao = DateTime.Now;

            chamadoBLL.InsereComentarioChamado(chamado);

            ScriptManager.RegisterClientScriptBlock(BtnEnviar, BtnEnviar.GetType(), "msgAlerta", "alert('Comentário enviado com sucesso.');", true);
            LimparCampos();
            ListaComentarios(Convert.ToInt32(Request.QueryString["IdChamado"]));
            OcultaPainelComentario();
        }

        protected void ListaComentarios(int idChamado)
        {
            DataTable dt = new DataTable();
            ChamadosBLL chamadoBLL = new ChamadosBLL();

            dt = chamadoBLL.ListaHistoricoComentario(idChamado);

            if (dt.Rows.Count > 0)
            {
                rptComentarios.DataSource = dt;
                rptComentarios.DataBind();
            }
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

            LtlDescricao.Text = dtChamado.Rows[0]["Descricao"].ToString();

            if (dtChamado.Rows.Count > 0)
            {
                for (int i = 0; i < dtChamado.Rows.Count; i++)
                {
                    if (dtChamado.Rows[i]["StatusChamado"].ToString() == "P ")
                    {
                        LblStatus.Text = "Pendente";
                        BtnCancelar.Visible = false;
                    }

                    if (dtChamado.Rows[i]["StatusChamado"].ToString() == "A ")
                    {
                        LblStatus.Text = "Em atendimento";
                        BtnFinalizar.Visible = false;
                        BtnCancelar.Visible = false;
                    }

                    if (dtChamado.Rows[i]["StatusChamado"].ToString() == "FA")
                    {
                        LblStatus.Text = "Aguardando Aprovação";
                    }

                    if (dtChamado.Rows[i]["StatusChamado"].ToString() == "F ")
                    {
                        LblStatus.Text = "Finalizado";
                        BtnFinalizar.Visible = false;
                        BtnCancelar.Visible = false;
                    }

                    if (dtChamado.Rows[i]["StatusChamado"].ToString() == "P " || Convert.ToInt32(dtChamado.Rows[i]["Solicitante"].ToString()) == idUsuario)
                    {
                        BtnFinalizar.Visible = true;
                    }

                    if (dtChamado.Rows[i]["StatusChamado"].ToString() == "FA" && Convert.ToInt32(dtChamado.Rows[i]["Solicitante"].ToString()) == idUsuario)
                    {
                        BtnFinalizar.Visible = true;
                        BtnCancelar.Visible = false;
                    }

                    if (dtChamado.Rows[i]["StatusChamado"].ToString() == "A" && Convert.ToInt32(dtChamado.Rows[i]["Atendente"].ToString()) == idUsuario)
                    {
                        BtnCancelar.Visible = false;
                    }
                }

                #region Prioridade Chamado
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
                #endregion
            }
        }

        protected void OcultaPainelComentario()
        {
            BtnFinalizar.Visible = true;
            LnkComentario.Visible = true;
            TxtComentario.Visible = false;
            BtnEnviar.Visible = false;
            BtnCancelar.Visible = false;
        }

        protected void LimparCampos()
        {
            TxtComentario.Value = string.Empty;
        }

        #endregion
    }
}