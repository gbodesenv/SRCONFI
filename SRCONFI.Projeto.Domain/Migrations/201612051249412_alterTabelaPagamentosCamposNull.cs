namespace SRCONFI.Projeto.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterTabelaPagamentosCamposNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TB_PAGAMENTOS", "DT_DATA_PAG", c => c.DateTime());
            AlterColumn("dbo.TB_PAGAMENTOS", "VL_VALOR_PAG", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.TB_PAGAMENTOS", "TX_COMENTARIO_PAG", c => c.String(maxLength: 250));
            AlterColumn("dbo.TB_PAGAMENTOS", "TX_JUSTIFICATIVA_CANC", c => c.String(maxLength: 250));
            AlterColumn("dbo.TB_PAGAMENTOS", "DT_DATA_CANC", c => c.DateTime());
            AlterColumn("dbo.TB_PAGAMENTOS", "TX_JUSTIFICATIVA_RETIFICACAO", c => c.String(maxLength: 250));
            AlterColumn("dbo.TB_PAGAMENTOS", "IN_CANCELADO", c => c.Byte());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TB_PAGAMENTOS", "IN_CANCELADO", c => c.Byte(nullable: false));
            AlterColumn("dbo.TB_PAGAMENTOS", "TX_JUSTIFICATIVA_RETIFICACAO", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.TB_PAGAMENTOS", "DT_DATA_CANC", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TB_PAGAMENTOS", "TX_JUSTIFICATIVA_CANC", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.TB_PAGAMENTOS", "TX_COMENTARIO_PAG", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.TB_PAGAMENTOS", "VL_VALOR_PAG", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.TB_PAGAMENTOS", "DT_DATA_PAG", c => c.DateTime(nullable: false));
        }
    }
}
