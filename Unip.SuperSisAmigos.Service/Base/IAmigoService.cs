using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Subimos pra memoria as entidades
using Unip.SuperSisAmigo.Entities;

//Subimos a namespace pra usar as classes de expressões
using System.Linq.Expressions;

namespace Unip.SuperSisAmigos.Service.Base
{
    public interface IAmigoService
    {
        IEnumerable<Amigo> ListarAmigo();
        IEnumerable<Sexo> ListarSexo();
        IEnumerable<EstadoCivil> ListarCivis();
        
        IEnumerable<Amigo> PesquisarAmigos(Expression<Func<Amigo, Boolean>> filtro);
        IEnumerable<Sexo> PesquisarSexos(Expression<Func<Sexo, Boolean>> filtro);
        IEnumerable<EstadoCivil> PesquisarCivis(Expression<Func<EstadoCivil, Boolean>> filtro);
        
        void CadastrarAmigo(Amigo amigoTela);
        void AtualizarAmigo(Amigo amigoTela);
        void DeletarAmigo(Int32 codigoAmigo);


    }
}
