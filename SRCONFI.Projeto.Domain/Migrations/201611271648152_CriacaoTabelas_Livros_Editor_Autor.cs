namespace SRCONFI.Projeto.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriacaoTabelas_Livros_Editor_Autor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_AUTORES",
                c => new
                    {
                        ID_AUTOR = c.Int(nullable: false, identity: true),
                        TX_NOME_AUTOR = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.ID_AUTOR);
            
            CreateTable(
                "dbo.TB_EDITORAS",
                c => new
                    {
                        ID_EDITORA = c.Int(nullable: false, identity: true),
                        TX_NOME_EDITORA = c.String(nullable: false, maxLength: 150),
                        TX_SIGLA_EDITORA = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID_EDITORA);
            
            CreateTable(
                "dbo.TB_LIVROS",
                c => new
                    {
                        ID_LIVRO = c.Int(nullable: false, identity: true),
                        TX_NOME_AUTOR = c.String(nullable: false),
                        ID_EDITORA = c.Int(nullable: false),
                        ID_AUTOR = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_LIVRO)
                .ForeignKey("dbo.TB_AUTORES", t => t.ID_AUTOR, cascadeDelete: true)
                .ForeignKey("dbo.TB_EDITORAS", t => t.ID_EDITORA, cascadeDelete: true)
                .Index(t => t.ID_EDITORA)
                .Index(t => t.ID_AUTOR);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_LIVROS", "ID_EDITORA", "dbo.TB_EDITORAS");
            DropForeignKey("dbo.TB_LIVROS", "ID_AUTOR", "dbo.TB_AUTORES");
            DropIndex("dbo.TB_LIVROS", new[] { "ID_AUTOR" });
            DropIndex("dbo.TB_LIVROS", new[] { "ID_EDITORA" });
            DropTable("dbo.TB_LIVROS");
            DropTable("dbo.TB_EDITORAS");
            DropTable("dbo.TB_AUTORES");
        }
    }
}
