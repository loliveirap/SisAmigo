using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Pra poder habilitar as classes que vao nos auxiliar a montar os HtmlHelpers temos que inportar a seguinte namespace
using System.Web.Mvc;

namespace Unip.SuperSisAmigo.UI.Web.Helpers
{
    /*Aqui no mvc temos diversos HTMLHELPERS
     Mas nem tudo tem HTMLHELPERS <tag> Html
     Neste caso podemos montar nossos proprios HTMLHELPERS*/
    public static class UnipHtmlHelpers
    {
        //Criamos um comando pra montar a TAG <BR />
        //Os helpers obrigatoriamente tem que ser STATIC (Não precisa da new)
        //E eles sempre vao retornar a classe MvcHtmlString
        //Pro comando BR grudar em alguma classe temos que utilizar a técnica de Métodos de Extensão
        //Conseguimos criar comandos "PARASITAS" 
        public static MvcHtmlString Br(this HtmlHelper classeHospedeiro)
        {
            //Consttruimos o comando br
            //Não colocar os delimitadores <> </>
            var quebraLinha = new TagBuilder("br");

            //Apos gerar o comando BR formatamos ele, colocamos os Delimitadores
            //Transformamos o comando BR em string (ToString()) e formatamos ele como um elemento através do create
            return MvcHtmlString.Create(quebraLinha.ToString(TagRenderMode.SelfClosing));
        }

        //Criamos um htmlhelper pra fazer a geração de botões <button>
        public static MvcHtmlString Button(
            this HtmlHelper classeHospedeira,
            String idBotao, String nameBotao,
            string typeBotao, String classBotao,
            String classItalico,
            String textBotao,
            String textItalico)
        {
            var botao = new TagBuilder("button");
            var italico = new TagBuilder("i");
            var span = new TagBuilder("span");

            //Apos gerar os comandos configuramos os atributos e classe css
            botao.Attributes.Add("id", idBotao);
            botao.Attributes.Add("name", idBotao);
            botao.Attributes.Add("type", idBotao);

            //Pra adicionar classe CSS temos o comando Especifico mas pode ser criado da forma acima
            botao.AddCssClass(classBotao);
            botao.AddCssClass(classItalico);

            //botao.SetInnerText(textBotao);
            botao.SetInnerText(textItalico);
            span.SetInnerText(textBotao);

            //Apos configurar os comandos, começamos a formata-los o italico tem que ficar dentro do botao
            var html = botao.ToString(TagRenderMode.StartTag);
            html += span.ToString(TagRenderMode.SelfClosing);
            html += span.ToString(TagRenderMode.EndTag);

            html += italico.ToString(TagRenderMode.StartTag);

            html += italico.ToString(TagRenderMode.EndTag);
            html += botao.ToString(TagRenderMode.EndTag);

            return MvcHtmlString.Create(html);
        }
    }
}