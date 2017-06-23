using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unip.SuperSisAmigo.Entities.Base
{
    //Criamos uma pasa BASE (Nome do DDD) dentro da pasta base ficam as classes pais (SUPER TIPOS)
    //A classe Entidade vai ser pai das classes (Sexo, Estado Civil, Amigo)

    //Quando criamos uma classe podemos consumir ela de duas formas:
    //1 - Instanica = New -> Bloquear a instância - Abstract
    //2 - Herança = : -> Bloquear a Herança - Sealed     
    
    public abstract class Entidade
    {
        //pra saber se o codigo esta legal ou não temos que entender de CODE SMELLS significa codigos que cheiram mal)
        //São sinotmas pedaços de codigos que analisamos e percebemos que não está legal e pode ser melhorado
        //Quando melhoramos o codigo se chama CODE REFACTORING (Refatoração de Codigo)
        //Melhoria de codigos visando boas práticas, orientação a objetos e performance
        //Primeiro sintoma - Campo Codigo duplicado em varias classes, levamos para a classe pai
        public Int32 Codigo { get; set; }
    }
}
