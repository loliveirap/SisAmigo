using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unip.SuperSisAmigo.Entities.Repository.Base
{
    //Deixamos a interface flexivel atraves da técnica de tipos genéricos <>
    //é uma foram de deixar o codigo parametrizavel, flexivel fica facil de usar podemos passar qualquer classe pra dentro da interface
    //Ficou Polimórfico os comandos sofrem mutaçoes
    public interface IGravacaoRepository<TEntidade>
    {
        void Cadastrar(TEntidade registro);
        void Atualizar(TEntidade registro);
        void Deletar(Int32 codigo);
    }
}
