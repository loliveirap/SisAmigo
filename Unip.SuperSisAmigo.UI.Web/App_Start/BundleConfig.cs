using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Optimization;
namespace Unip.SuperSisAmigo.UI.Web
{
    //Uma tecnica de performance pra Web é agrupar os arquivos em 1 unico arquivão, essa tecnica se chama BUNDLE, pra carergar
    //mais rápido e pro navegador não precisar ficar indo toda hora para o navegador
    //Agrupamos os arquivos em 1 unico arquivo
    //Podemos agrupar (BUNDLE) de arquivos .JS ou .CSS
    public class BundleConfig
    {
        //Criamos um método pra fazer o agrupamento dos arquivos (CSS e JS)        
        // O parametro BundleCollection é onde ficam os agrupamentos        
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Criamos uma variavel pra agrupar os arquivos de Script
            var scripts = new ScriptBundle("~/JS");
            scripts.Include("~/Scripts/jquery-{version}.min.js",
                            "~/Scripts/jquery.validate.min.js",
                            "~/Scripts/jquery.validate.unobtrusive.min.js",
                            "~/Scripts/materialize/materialize.min.js",
                            "~/Scripts/jquery.maskedinput.min.js",
                            "~/Scripts/jquery.validate.pt-br.js"                            
                            );
            //"~/Scripts/jquery-ui-1.11.4.min.js"

            //Nunca esquecer de apos agrupar os arquivos jogar dentro do local de agrupamentos (BundleCollection)
            bundles.Add(scripts);

            //Apos juntar os arquivos ele faz o MINIFICATION (minificação)
            //Minificação são os arquivos .min, é remover espaçõs em brancos, comentários e quebras de linha nos códigos.
            BundleTable.EnableOptimizations = true;

            //Quando o MVC agrupa e minifica os arquivos ele salva como ~JS esse arquivo não é um arquivo fisico, é um arquivo de memória
            //e nesse arquivo ele gera um HUSH(Token, Identificador) pra saber a versão do arquivo (pra ele saber identificar quais arquivos ele agrupou)
        }
    }
}