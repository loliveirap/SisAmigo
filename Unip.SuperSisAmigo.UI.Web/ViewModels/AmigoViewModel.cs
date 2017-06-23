using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


//Model é um nome muito genérico aqui no Asp.Net Mvc
//As classes que levam ou trazem dados da tela (view) o nome bunitão é ViewModel
//ViewModel - Dados de tela
//DomainModel - Dados do banco

//Aqui n aplataforma .net temos uma técnica chamada DATA ANNOTATIONS é uma técnica que funciona no WPF, WEB FORMS
using System.ComponentModel.DataAnnotations;

//Importamos essa namespace pra poder utilizar a classe Select List<>
using System.Web.Mvc;

namespace Unip.SuperSisAmigo.UI.Web.ViewModels
{
    public sealed class AmigoViewModel
    {
        public Int32 Codigo { get; set; }

        //O campo é obrigatório, internamente lá no html são criados 2 atributos dentro do campo
        //Data -Val, Data-valRequired(HTML5)
        [StringLength(40, MinimumLength = 3, ErrorMessage = "O nome deve ter de 3 a 40 caracteres.")]
        [Required(ErrorMessage = "Informe seu Nome")]
        [Display(Name = "Nome")]
        public String Nome { get; set; }

        [StringLength(25, MinimumLength = 15, ErrorMessage = "O e-mail deve ter de 15 a 25 caracteres.")]
        [Required(ErrorMessage = "Informe seu e-mail pessoa")]
        [Display(Name = "E-mail")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Informe o número do seu celular")]
        [Display(Name = "Celular")]
        public String Telefone { get; set; }

        [Required(ErrorMessage = "Informe seu Nome")]
        [Display(Name= "Nascimento")]

        //Qando sincronizamos a view com o viewModel o textbox data de nascimento e carregado um valor padrão 01/01/0001
        //Pra corrigir o problema na tela temos que transformar esse campo em um NULLABLE TYPE
        //Podemos por Nullable em STRUCTS > INT, DECIMAL, BOOLEAN, DATETIME
        public Nullable<DateTime> DataNascimento { get; set; }

        public String Endereco { get; set; }
        public String Numero { get; set; }

        [Required(ErrorMessage = "Selecione um sexo.")]
        [Display(Name = "Sexo")]
        public Int32 CodigoSexo { get; set; }

        [Required(ErrorMessage = "Selecione um estado civil.")]
        [Display(Name = "Estado Civil")]
        public Int32 CodigoEstadoCivil { get; set; }

        public SexoViewModel Sexo { get; set; }
        public EstadoCivilViewModel EstadoCivil { get; set; }

        //Criamos duas propriedades pra armazenar a lista de sexos e a lista de estados civis
        //A classe Selectlist é exclusiva do MVC serve pra popular um ComboBox(Dropdawlist)
        //E dentro dela que armazenamos os itens do DropDown
        public SelectList ListaSexos { get; set; }
        public SelectList ListaCivis { get; set; }
    }
}