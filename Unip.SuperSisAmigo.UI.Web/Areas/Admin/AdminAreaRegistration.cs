using System.Web.Mvc;

namespace Unip.SuperSisAmigo.UI.Web.Areas.Admin
{
    //Criamos uma AREA Administrativa 
    //Todas as telas que forem referentes a usuario, login, permissão, grupo
    //Tudo isso é Admin e ficam dentro da Area Administrativa
    //Uma area nada mais é do que um modulo, sessão dentro do site principal

    //Portal Uol
    //Site principal - Blog(Area), Webmail(Area), Noticia(Area)

    //Unip
    //Site Principal - Area Alunos Presencial - Area Alunos A distancia
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}