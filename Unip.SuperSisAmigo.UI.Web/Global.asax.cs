using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

//Subimos pra memoria a DLL de agrupamentos
using System.Web.Optimization;

namespace Unip.SuperSisAmigo.UI.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        //Assim que o projeto sobe pra memoria e disparado o enento Application Start
        //é um local de configurações iniciais do nosso projeto
        protected void Application_Start()
        {
            //Assim que a aplicação subiu pra memoria foram configuradas todas as areas do projeto
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //O asp.net mvc por padrao trabalha com 2 views Engines
            //View Engine -> Forma de Carregamento
            //A forma antiga (Legado) = Web Forms (Aspx e VBHTML)
            //O problema é que antes de buscar as paginas em razor (cshtml), primeiro ele tenta achar as paginas no 
            //modelo antigo(Web Forms) o que causa um processamento desnecessario (Porque nao tem nada em Web forms)
            //Ele passa por 4 locais até entrar no Razor
            /*
             *  ~/Views/Amigo/Zina.aspx
                ~/Views/Amigo/Zina.ascx
                ~/Views/Shared/Zina.aspx
                ~/Views/Shared/Zina.ascx
                ~/Views/Amigo/Zina.cshtml
                ~/Views/Amigo/Zina.vbhtml
                ~/Views/Shared/Zina.cshtml
                ~/Views/Shared/Zina.vbhtml
              */

            //Removemos as 2 formas de execução (Web Forms e Razor)
            ViewEngines.Engines.Clear();

            //Adiconamos somente a forma de execução Razor - Melhora a performance
            ViewEngines.Engines.Add(new RazorViewEngine());
            //Web Forms -> new WebFormViewEngine()

            //Inicializamos o agrupamento de arquivos JS
            //Esses bundles é onde ficam os agrupamentos
            //tudo que agrupamos temos que jogar dentro do Bundles
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
