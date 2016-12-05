namespace SRCONFI.Projeto.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterTabelaPagamentosCamposNull2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TB_PAGAMENTOS", "DT_DATA_RETIFICACAO", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TB_PAGAMENTOS", "DT_DATA_RETIFICACAO", c => c.String(nullable: false));
        }
    }
}
