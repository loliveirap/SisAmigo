using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Pra fazer a geração e mapeamento de banco de dados vamos utilizar o EF 6.1.3 é Open Source é Gratuito
//E o que tem de mais top desde 2010 pra fazer um acesso a dados baixamos somente o Kernel (DLL Internas) do EF via Nuget
//Pra fazer a geração e mapeamento do banco e tabelas vamos utilizar a estratégia (Forma) (Estilo) COD FIRST
//Montaremos o banco a partir do codigo (Não tem nada Visual)
//Montamos o codigo e a aplicação se encarrega de montar o banco

//Subimos a DLL do EF pra memória
using System.Data.Entity;

//pra poder visualizar as classes de mapeamento subimos a pasta pra memoria/
using Unip.SuperSisAmigo.DataAccess.Mappings;

using Unip.SuperSisAmigo.Entities;
//Na Infrastructure manipulamos todos os recursos relacionados a INFRA ESTRUTURA da nossa aplicação
//IFRA - Protocolos, hd, manipulação de Arquivos, Banco de dados
namespace Unip.SuperSisAmigo.DataAccess
{
    //pra transformar a classe comum em uma classe de conexão temos que herdar da classe de conexão do EF (dbContext)
    public sealed class Conexao : DbContext
    {
        //E no construtor da nossa classe que passamos a string de conexão 
        //Levamos ela pro WEB.CONFIG pra ficar mais facil
        //De dar manutenção, quando rodams a aplicação ela automaticamente le do WEB.CONFIG

        //***MACHINE.CONFIG (pai das aplicações .NET
        public Conexao()
            : base("Name=SISAMIGOS")
        {

        }

        //Criamos 2 comandos a qualquer momento podemos criar ou deletar o banco de dados, nao precisamos mais do DBA
        //pra criação de banvo de dados e tabelas
        //FULL STACK é um programador que faz tudo (Banco, Web, Windows, Servidor, Front, Cloud)
        public void CriarBanco()
        {
            Database.Create();
        }

        public void DeletarBanco()
        {
            Database.Delete();
        }

        //Quando o EF form montar o banco de dados ele tem que executar tambem os arquivos de mapeamento (CREATE TABLE) pra poder
        //montaar as tabelas e os campos junto com o banco de dados
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //O comando pra rodar os mapeamentos e o OnMondelCreate, é um comando da classe DBCONTEXT, temos que sobreescrever
            //esse comando, deixar o mesmo nome e so vamos mudar o conteudo (O recheio)
            modelBuilder.Configurations.Add(new SexoMapping());
            modelBuilder.Configurations.Add(new EstadoCivilMapping());
            modelBuilder.Configurations.Add(new AmigoMapping());

            base.OnModelCreating(modelBuilder);
        }

        //Criammos as propriedades pra acessar as tabelas
        //Pra fazer CRUD nas tabelas temos que usar a classe DBSET
        //Dentro do DBSET temos que passar a classe de entidade(DOMINIO)
        public DbSet<Amigo> Amigos { get; set; }
        public DbSet<Sexo> Sexos { get; set; }
        public DbSet<EstadoCivil> Civis { get; set; }
    }
}
