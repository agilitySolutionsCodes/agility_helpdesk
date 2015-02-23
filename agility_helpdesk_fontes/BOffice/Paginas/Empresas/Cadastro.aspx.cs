using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

using BO;
using BLL;

namespace BOffice.Empresas
{
    public partial class Cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["IdUsuario"] != null)
                {
                    if (Session["IdEmpresaUpdate"] != null)
                    {
                        Empresa empresa = new Empresa();

                        DataTable dt = new DataTable();
                        EmpresaBLL empresaBLL = new EmpresaBLL();
                        dt = empresaBLL.ListaEmpresaPorId(Convert.ToInt32(Session["IdEmpresaUpdate"].ToString()));

                        if (dt.Rows.Count > 0)
                        {
                            empresa = PreencherEmpresaUpdate(dt);
                            empresa.IdEmpresa = Convert.ToInt32(Session["IdEmpresaUpdate"].ToString());

                            Session["objEmpresa"] = empresa;
                            PreencherCampos(empresa);
                        }

                        //Remove a session que contém o código da empresa 
                        Session.Remove("IdEmpresaUpdate");
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
            Empresa empresa = null;

            if (Session["objEmpresa"] != null)
            {
                empresa = (Empresa)Session["objEmpresa"];
                Session.Remove("objEmpresa");
            }

            else
            {
                empresa = new Empresa();
            }

               empresa = Preencher(empresa);

            if (ValidaCampos(empresa) == true)
            {
                EmpresaBLL empresaBLL = new EmpresaBLL();

                if (empresa.IdEmpresa != 0)
                {
                    //Chama método de atualização BLL passando objeto como parâmetro
                    empresaBLL.AtualizaEmpresaPorId(empresa);

                    ScriptManager.RegisterClientScriptBlock(BtnCadastrar, BtnCadastrar.GetType(), "msgSucesso", "alert('Empresa atualizada com sucesso.');", true);
                }

                else
                {
                    //Valida se CNPJ ja existe na base
                    empresa.Ok = empresaBLL.ValidaCNPJ(empresa.Cnpj);

                    //Caso retorno Ok seja true
                    if (empresa.Ok == true)
                    {
                        //Chama método de inserção BLL passando objeto como parâmetro
                        empresaBLL.InsereEmpresa(empresa);

                        //Exibe mensagem de cadastro realizado com sucesso
                        ScriptManager.RegisterClientScriptBlock(BtnCadastrar, BtnCadastrar.GetType(), "msgSucesso", "alert('Empresa cadastrada com sucesso.');", true);
                    }

                    else
                    {
                        //Mensagem sobre CNPJ aqui
                        ScriptManager.RegisterClientScriptBlock(BtnCadastrar, BtnCadastrar.GetType(), "msgError", "alert('Atenção este CNPJ ja esta cadastrado favor verificar.');", true);
                    }
                }

                //Limpa campos após cadastro ser realizado
                LimpaCampos();
            }
        }

        protected void BtnLimpar_ServerClick(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        protected void DrpFilial_EventClick(object sender, EventArgs e)
        {
            if (DrpFilial.SelectedValue == "Sim")
            {
                DataTable dt = new DataTable();
                EmpresaBLL empresa = new EmpresaBLL();
                dt = empresa.ListaEmpresaPorId(Convert.ToInt32(Session["EmpresaUsuario"].ToString()));

                DrpEmpresaMatriz.Enabled = true;
                DrpEmpresaMatriz.DataSource = dt;
                DrpEmpresaMatriz.DataBind();

                DrpEmpresaMatriz.Items.Insert(0, "Selecione");
                DrpEmpresaMatriz.Items[0].Value = "";
            }
        }

        #endregion

        #region Métodos

        protected Empresa Preencher(Empresa empresa)
        {
            if (empresa.IdEmpresa == 0)
            {
                empresa = new Empresa();
            }
            //Se campos foram preenchidos atribui os valores aos objetos

            if (!string.IsNullOrEmpty(TxtCNPJ.Value))
            {
                empresa.Cnpj = TxtCNPJ.Value;
            }

            if (!string.IsNullOrEmpty(TxtRazaoSocial.Value))
            {
                empresa.RazaoSocial = TxtRazaoSocial.Value;
            }

            if (!string.IsNullOrEmpty(TxtNomeFantasia.Value))
            {
                empresa.NomeFantasia = TxtNomeFantasia.Value;
            }

            if (!string.IsNullOrEmpty(TxtEndereco.Value))
            {
                empresa.Endereco = TxtEndereco.Value;
            }

            if (DrpEstado.SelectedValue != "")
            {
                empresa.Uf = DrpEstado.SelectedValue;
            }

            if (!string.IsNullOrEmpty(TxtCidade.Value))
            {
                empresa.Cidade = TxtCidade.Value;
            }

            if (!string.IsNullOrEmpty(TxtCep.Value))
            {
                empresa.Cep = TxtCep.Value;
            }

            if (!string.IsNullOrEmpty(TxtEmail.Value))
            {
                empresa.Email = TxtEmail.Value;
            }

            if (DrpAtivo.SelectedValue == "Sim")
            {
                empresa.Ativo = true;
            }

            else
            {
                empresa.Ativo = false;
            }

            if (DrpFilial.SelectedValue == "Sim")
            {
                empresa.Matriz = false;
                empresa.CodigoMatriz = Convert.ToInt32(Session["EmpresaUsuario"].ToString());
            }

            else
            {
                empresa.CodigoMatriz = Convert.ToInt32(null);
            }

            return empresa;
        }

        protected Boolean ValidaCampos(Empresa empresa)
        {
            Boolean varValidado = true;

            if (IsCnpj(empresa.Cnpj) != true)
            {
                ScriptManager.RegisterClientScriptBlock(BtnCadastrar, BtnCadastrar.GetType(), "msgError", "alert('CNPJ inválido favor verificar.');", true);
                varValidado = false;
                ValidatorCNPJ.ErrorMessage = "CNPJ inválido";
            }

            return varValidado;
        }

        protected Empresa PreencherEmpresaUpdate(DataTable dt)
        {
            Empresa empresa = new Empresa();

            empresa.Cnpj = dt.Rows[0]["CNPJ"].ToString();
            empresa.RazaoSocial = dt.Rows[0]["RazaoSocial"].ToString();
            empresa.NomeFantasia = dt.Rows[0]["NomeFantasia"].ToString();
            empresa.Endereco = dt.Rows[0]["Endereco"].ToString();
            empresa.Uf = dt.Rows[0]["UF"].ToString();
            empresa.Cidade = dt.Rows[0]["Cidade"].ToString();
            empresa.Cep = dt.Rows[0]["Cep"].ToString();
            //TxtTelefone.Value = dt.Rows[0]["Telefone"].ToString();
            empresa.Email = dt.Rows[0]["Email"].ToString();
            empresa.Ativo = Convert.ToBoolean(dt.Rows[0]["Ativo"].ToString());
            empresa.Matriz = Convert.ToBoolean(dt.Rows[0]["Matriz"].ToString());

            return empresa;
        }

        protected void PreencherCampos(Empresa empresa)
        {
            TxtCNPJ.Value = empresa.Cnpj;
            TxtRazaoSocial.Value = empresa.RazaoSocial;
            TxtNomeFantasia.Value = empresa.NomeFantasia;
            TxtEndereco.Value = empresa.Endereco;
            DrpEstado.SelectedValue = empresa.Uf;
            TxtCidade.Value = empresa.Cidade;
            TxtCep.Value = empresa.Cep;
            //TxtTelefone.Value = dt.Rows[0]["Telefone"].ToString();
            TxtEmail.Value = empresa.Email;

            if (empresa.Ativo == true)
            {
                DrpAtivo.SelectedValue = "Sim";
            }

            else
            {
                DrpAtivo.SelectedValue = "Nao";
            }

            if (empresa.Matriz == true)
            {
                DrpFilial.SelectedValue = "Nao";
            }

            else
            {
                DrpFilial.SelectedValue = "Sim";
            }
        }

        public static bool IsCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }

        public string PopulaHtmlEmpresa(string caminhoHTML, string nomeUsuario, string nomeEmpresa, string cnpjEmpresa, string emailCadastro,
                                        string linkAcesso, DateTime dataEnvio)
        {
            string corpoEmail = "";
            StreamReader streamReader = new StreamReader(caminhoHTML);
            corpoEmail = streamReader.ReadToEnd();

            //Preenche campos do HTML com os dados do cadastro realizado
            corpoEmail = corpoEmail.Replace("{NomeUsuario}", nomeUsuario);
            corpoEmail = corpoEmail.Replace("{NomeEmpresa}", nomeEmpresa);
            corpoEmail = corpoEmail.Replace("{CnpjEmpresa}", cnpjEmpresa);
            corpoEmail = corpoEmail.Replace("{EmailCadastro}", emailCadastro);
            corpoEmail = corpoEmail.Replace("{LinkAcesso}", linkAcesso);
            corpoEmail = corpoEmail.Replace("{DataEnvio}", dataEnvio.ToString("{0:d/M/yyyy}"));

            return corpoEmail;
        }

        public void LimpaCampos()
        {
            TxtCNPJ.Value = string.Empty;
            TxtRazaoSocial.Value = string.Empty;
            TxtNomeFantasia.Value = string.Empty;
            TxtEndereco.Value = string.Empty;
            DrpEstado.SelectedValue = "";
            TxtCidade.Value = string.Empty;
            TxtCep.Value = string.Empty;
            TxtEmail.Value = string.Empty;
            DrpAtivo.SelectedValue = "";
            DrpFilial.SelectedValue = "";
        }

        #endregion
    }
}
