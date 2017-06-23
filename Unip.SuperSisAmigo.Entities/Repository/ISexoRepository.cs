using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unip.SuperSisAmigo.Entities.Repository
{
    //dentro do Dominio, alem de criar as entidades de dominio temos que criar tambem os servicos de dominio
    //DOMAIN SERVICE(Interfaces)
    //Uma interaface pra cada tabela de dominio que queremos acessar
    //E dentro dos servicos de dominio que vamos definir os comandos que queremos executar
    public interface ISexoRepository : Base.ILeituraRepository<Sexo>
    {

    }
}
