using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Subimos para a memoria as entidades de dominio
using Unip.SuperSisAmigo.DataAccess;

//Subimos para memoria o serviços de dominio (interface)
using Unip.SuperSisAmigo.Entities.Repository;

//Subimos para memolria a namespace para usar a classe expression x=>x
using System.Linq.Expressions;

//Subimos pra memoria a namespace necessária pra habilitar a Enumeração com os estados do registro
using System.Data.Entity;

namespace Unip.SuperSisAmigo.DataAccess.Repository
{
    public sealed class AmigoRepository : IAmigoRepository
    {
        private readonly Conexao _conexao;
        public AmigoRepository(Conexao conexao_)
        {
            _conexao = conexao_;
        }
        public IEnumerable<Entities.Amigo> Listar()
        {
            return _conexao.Amigos.ToList();

            //Não faz cache das informações do banco
            //return _conexao.Amigos.AsNoTracking().ToList();

            //Visualizar o cache
            //return _conexao.Amigos.Local().ToList();
        }

        public IEnumerable<Entities.Amigo> Pesquisar(Expression<Func<Entities.Amigo, bool>> filtro)
        {
            return _conexao.Amigos.Where(filtro).ToList();
        }

        public void Cadastrar(Entities.Amigo registro)
        {
            _conexao.Amigos.Add(registro);
            _conexao.SaveChanges();
        }

        public void Atualizar(Entities.Amigo registro)
        {
            //async = await _conexao.saveCgangeAsync();
            _conexao.Entry(registro).State = EntityState.Modified;
            _conexao.SaveChanges();
        }

        public void Deletar(int codigo)
        {
            //Deletamos o registro da Tabela
            //Bucsa o registro e depois deletar
            //o FIND serve pra filtrar pelo campo CHAVE PRIMARIA e busca o registro primeiro na memoria
            var amigo = _conexao.Amigos.Find(codigo);

            //Apos capturar o registro mandamos deletar
            _conexao.Amigos.Remove(amigo);
            _conexao.SaveChanges();
        }
    }
}
