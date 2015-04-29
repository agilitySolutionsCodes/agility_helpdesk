using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using BOffice;

namespace BOffice
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            //Code that runs on application startup
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
            //AuthConfig.RegisterOpenAuth();
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleTable.EnableOptimizations = true;
            RegisterRoutes(RouteTable.Routes);
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            //Código rodado quando erro 404 é apresentado
            Global gb = (Global)sender;

            //Caso exista algum erro no contexto
            if (gb.Context.AllErrors.Length > 0)
            {
                Exception ex = gb.Context.AllErrors[0];
                if (ex.GetType() == typeof(HttpException))
                {
                    HttpException hex = ex as HttpException;
                    int errorcode = hex.GetHttpCode();

                    //Se o código do erro for 404
                    if (errorcode == 404)
                    {
                        Response.Redirect("~/Error-404");
                    }
                }
            }
        }

        void RegisterRoutes(RouteCollection routes)
        {
            //routes.Ignore("{resource}.axd/{*pathInfo}");

            //Mapeamento de rota Login
            routes.MapPageRoute("Conta", "Conta", "~/Paginas/Conta/Login.aspx");

            //Mapeamento de rota Home
            routes.MapPageRoute("Home", "Home", "~/Paginas/Home/Default.aspx");

            //Mapeamento de rota Seleção de Cadastro
            routes.MapPageRoute("Selecionar-Usuarios-Cadastro", "Selecionar-Usuarios-Cadastro", "~/Paginas/Selecionar/TipoCadastroUsuario.aspx");
            routes.MapPageRoute("Selecionar-Categorias-Cadastro", "Selecionar-Categorias-Cadastro", "~/Paginas/Selecionar/TipoCadastroCategoria.aspx");
            routes.MapPageRoute("Selecionar-Classificacoes-Cadastro", "Selecionar-Classificacoes-Cadastro", "~/Paginas/Selecionar/TipoCadastroClassificacao.aspx");
            routes.MapPageRoute("Selecionar-Centro-Custo-Cadastro", "Selecionar-Centro-Custo-Cadastro", "~/Paginas/Selecionar/TipoCadastroCentroCusto.aspx");

            //Mapeamento de rota Cadastros e Manutenção de Usuários
            routes.MapPageRoute("Usuarios-Cadastro", "Usuarios-Cadastro", "~/Paginas/Usuarios/Cadastro.aspx");
            routes.MapPageRoute("Usuarios-Manutencao", "Usuarios-Manutencao", "~/Paginas/Usuarios/Manutencao.aspx");

            //Mapeamento de rota Cadastros e Manutenção de Empresas
            routes.MapPageRoute("Empresas-Cadastro", "Empresas-Cadastro", "~/Paginas/Empresas/Cadastro.aspx");
            routes.MapPageRoute("Empresas-Manutencao", "Empresas-Manutencao", "~/Paginas/Empresas/Manutencao.aspx");

            //Mapeamento de rota Cadastros e Manutenção de Categorias
            routes.MapPageRoute("Categorias-Cadastro", "Categorias-Cadastro", "~/Paginas/Categorias/Cadastro.aspx");
            routes.MapPageRoute("Categorias-Manutencao", "Categorias-Manutencao", "~/Paginas/Categorias/Manutencao.aspx");

            //Mapeamento de rota Cadastros e Manutenção de Classificações
            routes.MapPageRoute("Classificacoes-Cadastro", "Classificacoes-Cadastro", "~/Paginas/Classificacoes/Cadastro.aspx");
            routes.MapPageRoute("Classificacoes-Manutencao", "Classificacoes-Manutencao", "~/Paginas/Classificacoes/Manutencao.aspx");

            //Mapeamento de rota Cadastros e Manutenção de Centro de Custo
            routes.MapPageRoute("Centro-Custo-Cadastro", "Centro-Custo-Cadastro", "~/Paginas/CentroCusto/Cadastro.aspx");
            routes.MapPageRoute("Centro-Custo-Manutencao", "Centro-Custo-Manutencao", "~/Paginas/CentroCusto/Manutencao.aspx");

            //Mapeamento de rotas para páginas institucionais
            routes.MapPageRoute("Ajuda", "Ajuda", "~/Paginas/Institucional/Ajuda.aspx");
            routes.MapPageRoute("Contato", "Contato", "~/Paginas/Institucional/Contato.aspx");
            routes.MapPageRoute("Termos-Uso", "Termos-Uso", "~/Paginas/Institucional/TermosUso.aspx");

            //Mapeamento de rota de Erro
            routes.MapPageRoute("Error-404", "Error-404", "~/Paginas/Error/404.html");
        }
    }
}
