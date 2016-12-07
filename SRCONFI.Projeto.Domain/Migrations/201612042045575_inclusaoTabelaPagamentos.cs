namespace SRCONFI.Projeto.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inclusaoTabelaPagamentos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_PAGAMENTOS",
                c => new
                    {
                        ID_PAGAMENTO = c.Int(nullable: false, identity: true),
                        DT_DATA_PAG = c.DateTime(nullable: false),
                        VL_VALOR_PAG = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TX_COMENTARIO_PAG = c.String(nullable: false, maxLength: 250),
                        TX_JUSTIFICATIVA_CANC = c.String(nullable: false, maxLength: 250),
                        DT_DATA_CANC = c.DateTime(nullable: false),
                        TX_JUSTIFICATIVA_RETIFICACAO = c.String(nullable: false, maxLength: 250),
                        DT_DATA_RETIFICACAO = c.String(nullable: false),
                        IN_CANCELADO = c.Byte(nullable: false),
                        ID_MES = c.Int(nullable: false),
                        ID_SOCIO = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_PAGAMENTO)
                .ForeignKey("dbo.Mes", t => t.ID_MES, cascadeDelete: true)
                .ForeignKey("dbo.TB_SOCIOS", t => t.ID_SOCIO, cascadeDelete: true)
                .Index(t => t.ID_MES)
                .Index(t => t.ID_SOCIO);
            
            CreateTable(
                "dbo.Mes",
                c => new
                    {
                        mesID = c.Int(nullable: false, identity: true),
                        nomeMes = c.String(),
                    })
                .PrimaryKey(t => t.mesID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_PAGAMENTOS", "ID_SOCIO", "dbo.TB_SOCIOS");
            DropForeignKey("dbo.TB_PAGAMENTOS", "ID_MES", "dbo.Mes");
            DropIndex("dbo.TB_PAGAMENTOS", new[] { "ID_SOCIO" });
            DropIndex("dbo.TB_PAGAMENTOS", new[] { "ID_MES" });
            DropTable("dbo.Mes");
            DropTable("dbo.TB_PAGAMENTOS");
        }
    }
}
