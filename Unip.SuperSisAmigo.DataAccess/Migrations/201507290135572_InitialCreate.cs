namespace Unip.SuperSisAmigo.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    //O processo de atualização e backup das tabelas e sempre esses:
    //1 Alterar as entidades e fazer os mapeamentos de campos
    //2 - Gerar o backup (ADD-MIGRATION NOMEBACKUP)
    //3 - Apalicar backup (UPDATE-DATABASE)
    //pra ele nao perder quantos e quais backups ja aplicamos, no banco ele internamente salva os backups aplicados
    //Dentro da tabela_MigrationHistory
    //Ao rodar o comando UPDATE_DATABASE podemos passar alguns parametros:
    //-SCRIPT ele gera um script TSQL pra mandar pro DBA
    //-VERDOSE ele mostra os passos que serao executados
    //-TARGEMIGRATION ele serve pra aplciar uma versao especifica de backup
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_SEXO",
                c => new
                    {
                        ID_SEXO = c.Int(nullable: false, identity: true),
                        DS_SEXO = c.String(nullable: false, maxLength: 9, unicode: false),
                    })
                .PrimaryKey(t => t.ID_SEXO);
            
            CreateTable(
                "dbo.TB_ESTADO_CIVIL",
                c => new
                    {
                        ID_ESTADO_CIVIL = c.Int(nullable: false, identity: true),
                        DS_ESTADO_CIVIL = c.String(nullable: false, maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.ID_ESTADO_CIVIL);
            
            CreateTable(
                "dbo.TB_AMIGO",
                c => new
                    {
                        ID_AMIGO = c.Int(nullable: false, identity: true),
                        NM_AMIGO = c.String(nullable: false, maxLength: 40, unicode: false),
                        DS_EMAIL = c.String(nullable: false, maxLength: 30, unicode: false),
                        NR_TELEFONE = c.String(nullable: false, maxLength: 15, unicode: false),
                        DT_NASCIMENTO = c.DateTime(nullable: false, storeType: "date"),
                        ID_SEXO = c.Int(nullable: false),
                        ID_ESTADO_CIVIL = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_AMIGO)
                .ForeignKey("dbo.TB_ESTADO_CIVIL", t => t.ID_ESTADO_CIVIL, cascadeDelete: true)
                .ForeignKey("dbo.TB_SEXO", t => t.ID_SEXO, cascadeDelete: true)
                .Index(t => t.ID_SEXO)
                .Index(t => t.ID_ESTADO_CIVIL);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_AMIGO", "ID_SEXO", "dbo.TB_SEXO");
            DropForeignKey("dbo.TB_AMIGO", "ID_ESTADO_CIVIL", "dbo.TB_ESTADO_CIVIL");
            DropIndex("dbo.TB_AMIGO", new[] { "ID_ESTADO_CIVIL" });
            DropIndex("dbo.TB_AMIGO", new[] { "ID_SEXO" });
            DropTable("dbo.TB_AMIGO");
            DropTable("dbo.TB_ESTADO_CIVIL");
            DropTable("dbo.TB_SEXO");
        }
    }
}
