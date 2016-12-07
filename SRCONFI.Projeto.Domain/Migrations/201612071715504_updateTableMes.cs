namespace SRCONFI.Projeto.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTableMes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_MES",
                c => new
                    {
                        ID_MES = c.Int(nullable: false, identity: true),
                        TX_NOME_MES = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID_MES);
            
            CreateTable(
                "dbo.TB_PAGAMENTOS",
                c => new
                    {
                        ID_PAGAMENTO = c.Int(nullable: false, identity: true),
                        DT_DATA_PAG = c.DateTime(),
                        VL_VALOR_PAG = c.Decimal(precision: 18, scale: 2),
                        TX_COMENTARIO_PAG = c.String(maxLength: 250),
                        TX_JUSTIFICATIVA_CANC = c.String(maxLength: 250),
                        DT_DATA_CANC = c.DateTime(),
                        TX_JUSTIFICATIVA_RETIFICACAO = c.String(maxLength: 250),
                        DT_DATA_RETIFICACAO = c.String(),
                        IN_CANCELADO = c.Byte(),
                        ID_MES = c.Int(nullable: false),
                        ID_SOCIO = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_PAGAMENTO)
                .ForeignKey("dbo.TB_MES", t => t.ID_MES, cascadeDelete: true)
                .ForeignKey("dbo.TB_SOCIOS", t => t.ID_SOCIO, cascadeDelete: true)
                .Index(t => t.ID_MES)
                .Index(t => t.ID_SOCIO);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_PAGAMENTOS", "ID_SOCIO", "dbo.TB_SOCIOS");
            DropForeignKey("dbo.TB_PAGAMENTOS", "ID_MES", "dbo.TB_MES");
            DropIndex("dbo.TB_PAGAMENTOS", new[] { "ID_SOCIO" });
            DropIndex("dbo.TB_PAGAMENTOS", new[] { "ID_MES" });
            DropTable("dbo.TB_PAGAMENTOS");
            DropTable("dbo.TB_MES");
        }
    }
}
