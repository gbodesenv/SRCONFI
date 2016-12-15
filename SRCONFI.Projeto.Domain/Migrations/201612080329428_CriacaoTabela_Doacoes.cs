namespace SRCONFI.Projeto.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriacaoTabela_Doacoes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_DOACOES",
                c => new
                    {
                        ID_DOACAO = c.Int(nullable: false, identity: true),
                        VL_VALOR_DOACAO = c.String(nullable: false),
                        TX_COMENTARIO_DOACAO = c.String(nullable: false, maxLength: 250),
                        DT_DATA_DOACAO = c.DateTime(nullable: false),
                        TX_NOME_DOADOR = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.ID_DOACAO);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TB_DOACOES");
        }
    }
}
