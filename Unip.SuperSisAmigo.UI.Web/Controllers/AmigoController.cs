using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Unip.SuperSisAmigo.UI.Web.ViewModels;

//Pra poder levar e trazer os dados do banco
using Unip.SuperSisAmigos.Service;

//Pra poder fazer a transformação dos dados entre as classes vamos utilizar o AutoMapper para substituir os "NEWs e Foreach"
using AutoMapper;


//Pra visualizar os dados
using Unip.SuperSisAmigo.Entities;

//Sempre que criarmos um projeto temos que atualizar a versão do ASP.NET MVC
// A mais recente no momento é a 5.2.3
namespace Unip.SuperSisAmigo.UI.Web.Controllers
{
    //O controller agrupa as telas, é boa prática sempre quebar por módulos
    //Amigos (Listar, Cadastrar, Pesquisar) - AmigoController
    //Pacientes (ListarPacientes, Pesquisar) - PacienteController
    public sealed class AmigoController : Controller
    {
        //Acionamos a classe de serviço
        //private readonly AmigoService _servicoAmigo = new AmigoService();

        //Quando uma classe da new em outra classe isso é um forte acoplamento, uma classe ficou refem, dependente de outra classe
        //Tem um padrão de projeto chamado IOC (Inversão de Controle), que nos auxilia, nos ensina a nunca dar new wm outra classe
        private readonly AmigoService _servicoAmigo;
        
        //Criamos um construtor (inicializador) do controller
        public AmigoController(AmigoService servicoAmigo_)
        {
            //a variavel interna recebeu a variavel externa _ essa variavel externa vai ser inicializada no modulo injetor
            _servicoAmigo = servicoAmigo_;

            //pra nao ter que ficar repetindo codigo mantamos um construtor
            //Foreach
            //Classe de origem , classe de destino
            Mapper.CreateMap<Amigo, AmigoViewModel>();
            Mapper.CreateMap<Sexo, SexoViewModel>();
            Mapper.CreateMap<EstadoCivil, EstadoCivilViewModel>();

            //Configuramos a volta da tela
            Mapper.CreateMap<AmigoViewModel, Amigo>();
        }

        #region Action (GET = Leitura)        
        public ActionResult Listar()
        {
            //Buscamos os registros da tabela de amigos
            var amigosTabela = _servicoAmigo.ListarAmigo();            
            
            //Apos configurar ligamos a conversão
            var amigosTela = Mapper.Map<IEnumerable<Amigo>, IEnumerable<AmigoViewModel>>(amigosTabela);
            return View(amigosTela);
        }

        public ActionResult Cadastrar()
        {
            var sexosTabela = _servicoAmigo.ListarSexo();
            var civisTabela = _servicoAmigo.ListarCivis();

            //Ligamos o processo de conversao do AutoMapper
            var sexoTela = Mapper.Map<IEnumerable<Sexo>, IEnumerable<SexoViewModel>>(sexosTabela);
            var civisTela = Mapper.Map<IEnumerable<EstadoCivil>, IEnumerable<EstadoCivilViewModel>>(civisTabela);

            //Pra poder descer os dados pra tela (Listas) metodo que substitui o ViewBag
            var amigoTela = new AmigoViewModel();
            amigoTela.ListaSexos = new SelectList(sexosTabela, "Codigo","Descricao");
            amigoTela.ListaCivis = new SelectList(civisTabela, "Codigo","Descricao");
            return View(amigoTela);
        }

        public ActionResult Editar(Int32 id)
        {
            var amigosTabela = _servicoAmigo.PesquisarAmigos(x => x.Codigo == id).Single();

            var amigoTela = Mapper.Map<Amigo, AmigoViewModel>(amigosTabela);
            var sexosTabela = _servicoAmigo.ListarSexo();
            var civisTabela = _servicoAmigo.ListarCivis();

            

            //Ligamos o processo de conversao do AutoMapper
            var sexoTela = Mapper.Map<IEnumerable<Sexo>, IEnumerable<SexoViewModel>>(sexosTabela);
            var civisTela = Mapper.Map<IEnumerable<EstadoCivil>, IEnumerable<EstadoCivilViewModel>>(civisTabela);

            //Pra poder descer os dados pra tela (Listas) metodo que substitui o ViewBag
            //var amigoTela = new AmigoViewModel();
            amigoTela.ListaSexos = new SelectList(sexosTabela, "Codigo", "Descricao");
            amigoTela.ListaCivis = new SelectList(civisTabela, "Codigo", "Descricao");
            return View(amigoTela);
        }

        public ActionResult Excluir(Int32 id)
        {
            _servicoAmigo.DeletarAmigo(id);
            return RedirectToAction("Listar");
        }
        #endregion

        #region Action (POST = Gravação)

        [HttpPost]
        public ActionResult Cadastrar(AmigoViewModel dadosTela)
        {
            //Tomar cuidado com validações em JavaScript, se o usuário estiver mal intencionado ele vai desativar
            //O JavaScript (Para todas as validações) e o cara vai burlar e vai conseguir dar um POST
            //Temos que bloquear a execução caso algum campo esteja inválido
            //E no ModelState que ficam quais campos foram preenchidos e inclusive as mensagens
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("HACKER", "Então você quer dar uma de Hacker seu puto?");
                return View();
            }

            var amigoTabela = Mapper.Map<AmigoViewModel, Amigo>(dadosTela);
            _servicoAmigo.CadastrarAmigo(amigoTabela);
            _servicoAmigo.PesquisarAmigos()

            //Temos duas formas de mandar os dados pra tela as duarmas formas sao temporarias
            //ViewBag - Pra mandar informações pra propria tela
            //Se escreveu Return View() = Viewbag

            //TempData - Pra mandar informações pra outra tela
            //Se escreveu RedirectionToAction() = TempData

            TempData.Add("Sucesso", "Cadastrado com sucesso");
            return RedirectToAction ("Listar");
        }

        [HttpPost]
        public ActionResult Editar(AmigoViewModel dadosTela)
        {
            var amigoTabela = Mapper.Map<AmigoViewModel, Amigo>(dadosTela);
            _servicoAmigo.AtualizarAmigo(amigoTabela);

            TempData.Add("Sucesso", "Alterado com sucesso");
            return RedirectToAction("Listar");
        }

        #endregion

    }
}