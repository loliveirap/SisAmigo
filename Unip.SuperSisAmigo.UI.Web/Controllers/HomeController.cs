using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Unip.SuperSisAmigo.UI.Web.Controllers
{
    //Pra capturar os erros e redirecionar pra tela de erro do Asp .net mvc temos que utilizar a configuração abaixo
    //O HandleError fica monitorando o controller
    //Quando estourar um erro ele captura o objeto e mostra pra view _Error
    [HandleError]
    public sealed class HomeController : Controller
    {
        // GET: Home

        //[OutputCache(Duration = 120)]
        public ActionResult Index()
        {
            //Precisamos forçar um erro pra abrir a página genérica de erro
            //throw new Exception("Vishh de Erro nessa merda");
            return View();
        }
    }
}