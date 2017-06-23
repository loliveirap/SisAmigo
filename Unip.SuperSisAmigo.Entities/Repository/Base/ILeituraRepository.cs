using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Pra poder montar a nossa propria expressao lambda (X => x)
//Temos que utilizar a classe EXPRESSION essa classe esta dentro desssa namespace
using System.Linq.Expressions;

namespace Unip.SuperSisAmigo.Entities.Repository.Base
{
    //Existe um principio de orientação a objeto chamado Segregação de Interface
    //Significa modularizar, desmembrar o máximo possivel
    //Os comandos
    public interface ILeituraRepository<TEntidade>
    {
        //Qando falamos de listas, coleções, temos 3 tipos de coleções
        //1 Somente Leitura (I  enumerable)
        //2 Somente Gravação, Leitura e Pesquisa(IList)
        //3 Somente leitura e pesquisa (IQUERYABLE)
        //Tudo que colocamos com IList pra ganhar desempenho colocar ICOLLECTION, é uma implementação mais simples do ILIST
        IEnumerable<TEntidade> Listar();

        //Expression e pra montar a lambda x=>x
        //O func e pra falar qual classe é pra pesquisar
        //TEntidade e a classe que vamos pesquisar
        //Boolean é porque na lambda fazemos uma comparação de valores
        //x => x.Nome == "Zina"(Se for igual é TRUE, se não e FALSE
        //IEnumerable<TEntidade> Pesquisar(Expression<Func<TEntidade, Boolean>> filtro);
        IEnumerable<TEntidade> Pesquisar(TEntidade filtro);
    }
}
