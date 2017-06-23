using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Existem diversos framworks de testes no mercado
//O da microsoft é o VSUT (Visual Studio Unit Test Framwork)
//O mais usado no mundo é o NUnit (Disponivel pra todas as linguagens de programação)
//Subimos o NUnit pra memória
using NUnit.Framework;

//Subimos pra memoria a DLL de Acesso a Dados
using Unip.SuperSisAmigo.DataAccess;

//O Visual Studido so consegue carregar dependencias de primeiro nivel
//1 DLL chamando 1 DLL (Primeiro Nivel)
//Caso tenha 2 ou mais niveis ele já nao encontra e te obriga a dar um ADD References em todas as DLL

//O NUNIT por padrao nao conversa com o Visual Studio, pra integrar o NUnit com VS temos que
//baixar o pacote NUnit Test Adapter é o integrador

namespace Unip.SuperSisAmigo.Test.DataAccess
{
    //Existem duas forams de testar
    //1 - Forma manual : Uma pessoa vai olhar o codigo e vai testar manualmente gerando plano de testes, 
    //roteiro de testes e Evidência
    //2 - Forma automatizda : Usamos ferramentas e frameworks que nos auxiliam a testar o codigo criamos um Robo 
    //que vao se encarregar de testar o codigo e falar se está Certo ou Errado
    
    [TestFixture]
    public sealed class ConexaoTest
    {
        //Essa é a classe de teste (ROBO)
        [Test]
        public void Testar_Criacao_Do_Banco()
        {
            var conexao = new Conexao();
            conexao.CriarBanco();
        }

        [Test]
        public void Testar_Exclusao_Do_Banco()
        {
            var conexao = new Conexao();
            conexao.DeletarBanco();
        }

        [Test]
        public void Testar_Selecao_De_Amigo()
        {
            var conexao = new Conexao();
            var amigo = conexao.Amigos.ToList();
        }
    }
}
