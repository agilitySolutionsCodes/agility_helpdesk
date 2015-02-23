using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BO;
using BLL;

namespace BOffice.CentroCustos
{
    public partial class Cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["IdUsuario"] != null)
                {
                    if (Session["IdCentroCustoUpdate"] != null)
                    {
                        CentroCusto centroCusto = new CentroCusto();

                        DataTable dt = new DataTable();
                        CentroCustosBLL centroCustoBLL = new CentroCustosBLL();

                        dt = centroCustoBLL.ListaCentroCustoPorId(Convert.ToInt32(Session["IdCentroCustoUpdate"].ToString()));

                        //Remove session que contém o código da categoria
                        Session.Remove("IdCategoriaUpdate");

                        //Preenche objeto e salva em session para caso de atualização
                        centroCusto = PreencherCentroCustoUpdate(dt);
                        Session["objCentroCusto"] = centroCusto;

                        PreencherCampos(dt);
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
            //Instância de BLL
            CentroCustosBLL centroCustoBLL = new CentroCustosBLL();

            //Declaração de onjeto nulo
            CentroCusto centroCusto = null;

            //Verifica se o objeto é diferente de nulo
            if (Session["objCentroCusto"] != null)
            {
                //Instância objeto com valores da session
                centroCusto = (CentroCusto)Session["objCentroCusto"];
                //Remove a session criada
                Session.Remove("objCentroCusto");
            }

            else
                centroCusto = new CentroCusto();

            //Prrenche o objeto centroCusto com dados do formulário
            centroCusto = Preencher(centroCusto);

            //Se a validação estiver ok
            if (ValidaCampos(centroCusto) == true)
            {
                if (centroCusto.IdCentroCusto != 0)
                {
                    //Chama método de atualização BLL
                    centroCustoBLL.AtualizaCentroCustoPorId(centroCusto);
                    //Exibe mensagem de cadastro atualizado com sucesso
                    ScriptManager.RegisterClientScriptBlock(BtnCadastrar, BtnCadastrar.GetType(), "msgSucesso", "alert('Centro de Custo atualizado com sucesso.');", true);
                }

                else
                {
                    //Chama método de inserção BLL passando objeto como parâmetro
                    centroCustoBLL.InsereCentroCusto(centroCusto);
                    //Exibe mensagem de cadastro realizado com sucesso
                    ScriptManager.RegisterClientScriptBlock(BtnCadastrar, BtnCadastrar.GetType(), "msgSucesso", "alert('Centro de Custo cadastrado com sucesso.');", true);
                }
            }

            //Limpa campos após cadastro ser realizado
            LimpaCampos();
        }

        protected void BtnLimpar_ServerClick(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        #endregion

        #region Métodos

        protected CentroCusto PreencherCentroCustoUpdate(DataTable dt)
        {
            CentroCusto centroCusto = new CentroCusto();

            centroCusto.IdCentroCusto = Convert.ToInt32(dt.Rows[0]["IdCentroCusto"].ToString());
            centroCusto.Classe = dt.Rows[0]["Classe"].ToString();
            centroCusto.Descricao = dt.Rows[0]["Descricao"].ToString();
            centroCusto.Ativo = Convert.ToBoolean(dt.Rows[0]["Ativo"].ToString());

            return centroCusto;
        }

        protected CentroCusto Preencher(CentroCusto centroCusto)
        {
            if (centroCusto.IdCentroCusto == 0)
            {
                centroCusto = new CentroCusto();
            }

            //Se campos foram preenchidos atribui os valores ao objeto 

            if (!string.IsNullOrEmpty(TxtDescricao.Value))
            {
                centroCusto.Descricao = TxtDescricao.Value;
            }

            if (drpCentroCusto.SelectedValue != "")
            {
                centroCusto.Classe = drpCentroCusto.SelectedValue;
            }

            if (DrpAtivo.SelectedValue == "Sim")
            {
                centroCusto.Ativo = true;
            }

            else
            {
                centroCusto.Ativo = false;
            }

            centroCusto.Empresa = Convert.ToInt32(Session["EmpresaUsuario"].ToString());

            return centroCusto;
        }

        protected void PreencherCampos(DataTable objCentroCusto)
        {
            DataTable dt = objCentroCusto;

            TxtDescricao.Value = dt.Rows[0]["Descricao"].ToString();
            if (dt.Rows[0]["Classe"].ToString() == "A ")
            {
                drpCentroCusto.SelectedValue = "A";
            }

            else
            {
                drpCentroCusto.SelectedValue = "S";
            }

            Boolean ativo = Convert.ToBoolean(dt.Rows[0]["Ativo"].ToString());

            if (ativo == true)
            {
                DrpAtivo.SelectedValue = "Sim";
            }

            else
            {
                DrpAtivo.SelectedValue = "Nao";
            }
        }

        protected Boolean ValidaCampos(CentroCusto centroCusto)
        {
            Boolean varValidado = true;

            return varValidado;
        }

        protected void LimpaCampos()
        {
            TxtDescricao.Value = string.Empty;
            drpCentroCusto.SelectedValue = "";
            DrpAtivo.SelectedValue = "";
        }

        #endregion
    }
}