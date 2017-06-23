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

namespace Unip.SuperSisAmigo.DataAccess.Repository
{
    public sealed class EstadoCivilRepository : IEstadoCivilRepository
    {
        //private readonly Conexao _conexao = new Conexao();
        private readonly Conexao _conexao;
        public EstadoCivilRepository(Conexao conexao_)
        {
            _conexao = conexao_;
        }
        public IEnumerable<Entities.EstadoCivil> Listar()
        {
            return _conexao.Civis.ToList();
        }

        //public IEnumerable<Entities.EstadoCivil> Pesquisar(Expression<Func<Entities.EstadoCivil, bool>> filtro)
        public IEnumerable<Entities.EstadoCivil> Pesquisar(Entities.EstadoCivil filtro)
        {
            //return _conexao.Civis.Where(filtro).ToList();
            return _conexao.Civis.Where(x => x.Codigo == 10).ToList();
        }
    }
}
