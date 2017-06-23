using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Quando fazemosmum software temos que penar sempre nos dados e nas regras de negocios
//Rede, hd, banco de dados tudo isso é secundário, o que importa de verdade são os dados e as regras de negócio(Consistência)
//Utilizando DDD (Domain Driven Design) (Desenvlvimento Orinenteado ao Dominio)
//Conseguimos fazer um software que atenda as necessidades do cliente, fazemos um software 100% voltado ao negócio
//Ao fazer o software começar sempre pelo Dominio (Domain)
//Domain (é onde fica os dados e as regras de negócio)
//Domain é o que a empresa faz ou vende, identificamos o dominio começamos a criar as entidades de dominio
//E DDD nada mais é do que conjuntos de principios, filozofias e praticas, não é um padrão de projeto e pode ser usado com qualquer
//linguagem ou tecnologia
//E pra entender o Domain(Dominio) temos que conversae com alguem do négocio o nome dessa pessoa é o DOMAIN EXPERT (Analista de sistemas de negócios)
//Sem DDD nós chamariamos de MODEL, com DDD Entities

namespace Unip.SuperSisAmigo.Entities
{
    //2) Fechamos (Selamos, Bloqueamos) a classe com o SEALED para não ser pai de ninguem. Para que ninguem quebre o esquema de orientação a Objeto
    //Os beneficios de colocar SEALED
    //1- Ninguem faz merda no codigo (Ninguem vai herdar a classe)
    //2 - A maquina Virtual (CLR) otimiza (Acesso rapido) Classes SEALEAD
    public sealed class Sexo : Base.Entidade
    {        
        public String Descricao { get; set; }
    }
}
