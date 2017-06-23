using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Unip.SuperSisAmigo.UI.Web.Controllers
{
    public sealed class ErroController : Controller
    {
        //As telas de erro do asp.net são muito Feias, são muito genéricas
        //e as infomrações são muito técnicas, qualquer usuário que não seja da area
        //Da area de TI não vai entender
        public ActionResult Erro404()
        {
            return View();
        }
    }
}