using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Unip.SuperSisAmigo.UI.Web.Areas.Admin.ViewModels
{
    public sealed class UsuarioViewModel
    {
        public Int32 Codigo { get; set; }
        public String Nome { get; set; }

        [Required(ErrorMessage = "Informe o campo E-mail")]
        [Display(Name = "E-mail")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Informe o campo Senha")]
        public String Senha { get; set; }
    }
}