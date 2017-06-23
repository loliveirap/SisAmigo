namespace Unip.SuperSisAmigo.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnderecoNumeroBackup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TB_AMIGO", "DS_ENDERECO", c => c.String(maxLength: 200, unicode: false));
            AddColumn("dbo.TB_AMIGO", "NR_RESIDENCIA", c => c.String(maxLength: 5, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TB_AMIGO", "NR_RESIDENCIA");
            DropColumn("dbo.TB_AMIGO", "DS_ENDERECO");
        }
    }
}
