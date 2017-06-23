using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unip.SuperSisAmigo.Entities
{
    //Quando a classe não tem nenhuma visibilidade (Modificador de Acesso) ela é INTERNAL (Só é visivel nesse projeto)
    //Mas como estamos falando do Dominio (Dados) os dados tem que ser visivel em todas as DLLs da solução sempre PUBLIC
    public sealed class EstadoCivil : Base.Entidade
    {       
        public String Descricao { get; set; }
    }
}
