namespace SRCONFI.Projeto.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alteracaocampo_inAtivo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TB_ATIVIDADES", "IN_INATIVO", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TB_ATIVIDADES", "IN_INATIVO", c => c.Boolean(nullable: false));
        }
    }
}
