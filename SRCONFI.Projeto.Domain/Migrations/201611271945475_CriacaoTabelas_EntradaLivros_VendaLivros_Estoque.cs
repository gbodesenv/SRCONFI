namespace SRCONFI.Projeto.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriacaoTabelas_EntradaLivros_VendaLivros_Estoque : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_ENTRADA_LIVROS",
                c => new
                    {
                        ID_ENTRADA = c.Int(nullable: false, identity: true),
                        TX_NOTA_FISCAL = c.String(nullable: false, maxLength: 50),
                        VL_VALOR_TOTAL_ENTRADA = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VL_UNITARIO_LIVRO = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DT_DATA_ENTRADA = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID_ENTRADA);
            
            CreateTable(
                "dbo.TB_ESTOQUE_LIVROS",
                c => new
                    {
                        ID_ESTOQUE = c.Int(nullable: false, identity: true),
                        NR_QUANTIDADE = c.Int(nullable: false),
                        VL_VALOR_UNITARIO = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ID_LIVRO = c.Int(nullable: false),
                        ID_ENTRADA = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_ESTOQUE)
                .ForeignKey("dbo.TB_ENTRADA_LIVROS", t => t.ID_ENTRADA, cascadeDelete: true)
                .ForeignKey("dbo.TB_LIVROS", t => t.ID_LIVRO, cascadeDelete: true)
                .Index(t => t.ID_LIVRO)
                .Index(t => t.ID_ENTRADA);
            
            CreateTable(
                "dbo.TB_VENDAS_LIVROS",
                c => new
                    {
                        ID_VENDA = c.Int(nullable: false, identity: true),
                        DT_DATA_VENDA = c.DateTime(nullable: false),
                        VALOR_DESCONTO = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VL_TOTAL_VENDA = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ID_ESTOQUE = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_VENDA)
                .ForeignKey("dbo.TB_ESTOQUE_LIVROS", t => t.ID_ESTOQUE, cascadeDelete: true)
                .Index(t => t.ID_ESTOQUE);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_VENDAS_LIVROS", "ID_ESTOQUE", "dbo.TB_ESTOQUE_LIVROS");
            DropForeignKey("dbo.TB_ESTOQUE_LIVROS", "ID_LIVRO", "dbo.TB_LIVROS");
            DropForeignKey("dbo.TB_ESTOQUE_LIVROS", "ID_ENTRADA", "dbo.TB_ENTRADA_LIVROS");
            DropIndex("dbo.TB_VENDAS_LIVROS", new[] { "ID_ESTOQUE" });
            DropIndex("dbo.TB_ESTOQUE_LIVROS", new[] { "ID_ENTRADA" });
            DropIndex("dbo.TB_ESTOQUE_LIVROS", new[] { "ID_LIVRO" });
            DropTable("dbo.TB_VENDAS_LIVROS");
            DropTable("dbo.TB_ESTOQUE_LIVROS");
            DropTable("dbo.TB_ENTRADA_LIVROS");
        }
    }
}
