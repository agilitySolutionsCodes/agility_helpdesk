using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Site;

namespace Site
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
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
            routes.Ignore("{resource}.axd/{*pathInfo}");

            //Mapeamento de rota Login
            routes.MapPageRoute("Conta", "Conta", "~/Paginas/Conta/Login.aspx");
            //Mapeamento de rota Recuperar Senha
            routes.MapPageRoute("Conta-Recuperar-Senha", "Conta-Recuperar-Senha", "~/Paginas/Conta/Recuperar.aspx");

            //Mapeamento de rota Busca
            routes.MapPageRoute("Busca", "Busca", "~/Paginas/Busca/Index.aspx");

            //Mapeamento de rota Fila de Chamados
            routes.MapPageRoute("Chamados-Fila", "Chamados-Fila", "~/Paginas/Chamados/Fila.aspx");
            //Mapeamento de rota Meus Chamados
            routes.MapPageRoute("Meus-Chamados", "Meus-Chamados", "~/Paginas/Chamados/MeusChamados.aspx");
            //Mapeamento de rota Novo Chamado
            routes.MapPageRoute("Chamados-Novo", "Chamados-Novo", "~/Paginas/Chamados/NovoChamado.aspx");
            //Mapeamento de rota Detalhe Chamado
            routes.MapPageRoute("Chamados-Detalhe", "Chamados-Detalhe", "~/Paginas/Chamados/Detalhe.aspx");

            //Mapeamento de rota Institucional Contato
            routes.MapPageRoute("Institucional-Contato", "Institucional-Contato", "~/Paginas/Institucional/Contato.aspx");
            //Mapeamento de rota Institucional Termos de Uso
            routes.MapPageRoute("Institucional-Termos-Uso", "Institucional-Termos-Uso", "~/Paginas/Institucional/TermosUso.aspx");

            //Mapeamento de rota Relatórios
            routes.MapPageRoute("Relatorios-Selecionar", "Relatorios-Selecionar", "~/Paginas/Relatorios/Selecionar.aspx");
            routes.MapPageRoute("Relatorios-Visualizar", "Relatorios-Visualizar", "~/Paginas/Relatorios/Index.aspx");

            //Mapeamento de rota de Erro
            routes.MapPageRoute("Error-404", "Error-404", "~/Paginas/Error/404.html");
        }
    }
}
