namespace Unip.SuperSisAmigo.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Unip.SuperSisAmigo.Entities;

    //Desde o EF 4.3 temos um recurso chamado Entity Framework Code First Migrations
    //Com ele conseguimos fazer Backups das tabelas
    //Ele faz backup do nome das tabelas
    //Abrir o power Shel e digitamos o comando enable-migrations
    internal sealed class Configuration : DbMigrationsConfiguration<Unip.SuperSisAmigo.DataAccess.Conexao>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Unip.SuperSisAmigo.DataAccess.Conexao";
        }

        //Sempre que aplicamos um backup internamente ele executa o comando SEED, o comando SEED server pra dar um carga inicial nas tabelas
        protected override void Seed(Unip.SuperSisAmigo.DataAccess.Conexao context)
        {
            //geramos uma carga inicial na tabela de sexos e de estados civil
            var feminino = new Sexo();
            feminino.Descricao = "Feminino";

            var masculino = new Sexo();
            masculino.Descricao = "Masculino";

            //Isso equivale a um INSERT
            //O comando AddOrUpdate equivlale ao not exists
            context.Sexos.AddOrUpdate(x => x.Descricao, feminino);
            context.Sexos.AddOrUpdate(x => x.Descricao, masculino);
        }
    }
}
