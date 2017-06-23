using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Unip.SuperSisAmigo.UI.Web.ViewModels
{
    public sealed class SexoViewModel
    {
        //Int = código usado no c# 
        //Integer = código usado no VB.NET
        //Int32 = CTS (Common Types System) da plataforma .NET (usado pra qualaquer linguagem da platforma .NET) no exemplo C# ou VB.NET
        public Int32 Codigo { get; set; }
        public String Descricao { get; set; }
    }
}