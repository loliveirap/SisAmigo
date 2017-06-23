using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Subimos pra memoria as entidades
using Unip.SuperSisAmigo.Entities;

//Subimos a namespace pra usar as classes de expressões
using System.Linq.Expressions;

//Repositorios > Classes que manipulam o CRUD
using Unip.SuperSisAmigo.DataAccess.Repository;
namespace Unip.SuperSisAmigos.Service
{
    //A camda de Application também faz parte do DDD, é a camada de Entrada do DDD
    //E essa camada que disponibiliza os dados do Dominio
    //E como se fosse um GARÇOM, CARDAPIO
    //Controller > Application (Services) > Infrastructure (Data Access) > Domain (Entities)
    //Quando temos classe agragadas AMIGO, SEXO, ESTADO CIVIL
    //Criamos apenas 1 servico pra classe principal (AMIGO) e todas as informações das Classes secundárias(AGREGADAS)
    //
    public sealed class AmigoService : Base.IAmigoService
    {
        //private readonly AmigoRepository _repositoryAmigo = new AmigoRepository();
        //private readonly SexoRepository _repositorySexo = new SexoRepository();
        //private readonly EstadoCivilRepository _repositorioCivil = new EstadoCivilRepository();
        private readonly AmigoRepository _repositoryAmigo;
        private readonly SexoRepository _repositorySexo;
        private readonly EstadoCivilRepository _repositorioCivil;
        
        //Quando trabalhamos com o padrão IOC normalmente recebemos os objetos no construtor, quem for inicializar o AmigoService
        //Vai ter que injetar, vai ter que passar pra dentro dele as 3 classes inicializadas (amigoRepository, Sexo e Civil)_
        public AmigoService(AmigoRepository repositoryAmigo_, SexoRepository repositorySexo_, EstadoCivilRepository repositoryCivil_)
        {
            _repositoryAmigo = repositoryAmigo_;
            _repositorySexo = repositorySexo_;
            _repositorioCivil = repositoryCivil_;
        }

        public IEnumerable<Amigo> ListarAmigo()
        {
            return _repositoryAmigo.Listar();
        }

        public IEnumerable<Sexo> ListarSexo()
        {
            return _repositorySexo.Listar();
        }

        public IEnumerable<EstadoCivil> ListarCivis()
        {
            return _repositorioCivil.Listar();
        }

        public IEnumerable<Amigo> PesquisarAmigos(Expression<Func<Amigo, bool>> filtro)
        {
            return _repositoryAmigo.Pesquisar(filtro);
        }

        public IEnumerable<Sexo> PesquisarSexos(Expression<Func<Sexo, bool>> filtro)
        {
            return _repositorySexo.Pesquisar(filtro);
        }

        //public IEnumerable<EstadoCivil> PesquisarCivis(Expression<Func<EstadoCivil, bool>> filtro)
        public IEnumerable<EstadoCivil> PesquisarCivis(EstadoCivil filtro)
        {
            return _repositorioCivil.Pesquisar(filtro);
        }

        public void CadastrarAmigo(Amigo amigoTela)
        {
            _repositoryAmigo.Cadastrar(amigoTela);
        }

        public void AtualizarAmigo(Amigo amigoTela)
        {
            _repositoryAmigo.Atualizar(amigoTela);
        }

        public void DeletarAmigo(int codigoAmigo)
        {
            _repositoryAmigo.Deletar(codigoAmigo);
        }
    }
}
