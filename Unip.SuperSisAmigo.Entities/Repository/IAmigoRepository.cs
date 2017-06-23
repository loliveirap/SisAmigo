using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unip.SuperSisAmigo.Entities.Repository
{
    public interface IAmigoRepository : Base.ILeituraRepository<Amigo>, Base.IGravacaoRepository<Amigo>
    {
    }
}
