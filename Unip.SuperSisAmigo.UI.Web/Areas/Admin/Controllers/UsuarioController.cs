using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unip.SuperSisAmigo.UI.Web.Areas.Admin.ViewModels;

namespace Unip.SuperSisAmigo.UI.Web.Areas.Admin.Controllers
{
    public sealed class UsuarioController : Controller
    {
        #region(GET)
        //Uma tecnica de performance pra carregamento de telas é deixar a tela no cahe do servidor WEB 
        //para as telas carregarem mais rapidos
        //O tempo e baseado em segundos 1min = 60 seg
        //Lembrabdo que o conceito de Cache neste caso será somente para telas estáticas que nao mudam com frequencia.

        [OutputCache(Duration = 120)]
        public ActionResult Login()
        {
            return View();
        }
        #endregion

        #region(POST)
        [HttpPost]
        public ActionResult Login(UsuarioViewModel dadosTela)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("HACKER", "Então você quer dar uma de Hacker seu puto?");
                return View();
            }
            //Tomar cuidado ao navegar no projeto com areas, ele nao entende que e pra acessar o controler que esta no projeto 
            //principal, ele pensa que esta no projeto principal, colocar o parametro area em branco 
            return RedirectToAction("Index", "Home", new { Area = "" });
        }
        #endregion

        
    }
}