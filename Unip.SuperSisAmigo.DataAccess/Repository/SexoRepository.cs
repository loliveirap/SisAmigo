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
using Unip.SuperSisAmigo.Entities;

namespace Unip.SuperSisAmigo.DataAccess.Repository
{
    //Pra fazer CRUD temos que ter 2 arquivos
    //1 interface e 1 Classe pra cada tabela que vamos acessar
    public sealed class SexoRepository: ISexoRepository
    {
        //private Conexao _conexao = new Conexao();
        private Conexao _conexao;
        public SexoRepository(Conexao conexao_)
        {
            _conexao = conexao_;
        }
        public IEnumerable<Sexo> Listar()
        {
            return _conexao.Sexos.ToList();
        }

        public IEnumerable<Sexo> Pesquisar(Expression<Func<Entities.Sexo, bool>> filtro)
        {
            return _conexao.Sexos.Where(filtro).ToList(); ;
        }
    }
}
