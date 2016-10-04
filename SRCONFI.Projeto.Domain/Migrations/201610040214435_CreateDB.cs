namespace SRCONFI.Projeto.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_LOGS",
                c => new
                    {
                        ID_LOG = c.Int(nullable: false, identity: true),
                        DT_DATA_HORA_OPERACAO = c.DateTime(nullable: false),
                        TX_SENHA_USUARIO = c.String(nullable: false, maxLength: 500),
                        TX_LOGIN_USUARIO = c.String(nullable: false, maxLength: 50),
                        TX_CONTEXTO = c.String(nullable: false, maxLength: 500),
                        Usuario_usuarioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_LOG)
                .ForeignKey("dbo.TB_USUARIOS", t => t.Usuario_usuarioID, cascadeDelete: true)
                .Index(t => t.Usuario_usuarioID);
            
            CreateTable(
                "dbo.TB_USUARIOS",
                c => new
                    {
                        ID_USUARIO = c.Int(nullable: false, identity: true),
                        TX_NOME_USUARIO = c.String(nullable: false, maxLength: 100),
                        TX_LOGIN_USUARIO = c.String(nullable: false, maxLength: 50),
                        TX_SENHA_USUARIO = c.String(nullable: false, maxLength: 50),
                        TX_EMAIL_USUARIO = c.String(nullable: false, maxLength: 250),
                        NR_TELEFONE_USUARIO = c.Int(nullable: false),
                        IN_STATUS = c.Byte(nullable: false),
                        tipoUsuarioID = c.Int(),
                    })
                .PrimaryKey(t => t.ID_USUARIO)
                .ForeignKey("dbo.TB_TIPO_USUARIOS", t => t.tipoUsuarioID)
                .Index(t => t.tipoUsuarioID);
            
            CreateTable(
                "dbo.TB_TIPO_USUARIOS",
                c => new
                    {
                        ID_TIPO_USUARIO = c.Int(nullable: false, identity: true),
                        TX_DESC_TIPO_USUARIO = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ID_TIPO_USUARIO);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_LOGS", "Usuario_usuarioID", "dbo.TB_USUARIOS");
            DropForeignKey("dbo.TB_USUARIOS", "tipoUsuarioID", "dbo.TB_TIPO_USUARIOS");
            DropIndex("dbo.TB_USUARIOS", new[] { "tipoUsuarioID" });
            DropIndex("dbo.TB_LOGS", new[] { "Usuario_usuarioID" });
            DropTable("dbo.TB_TIPO_USUARIOS");
            DropTable("dbo.TB_USUARIOS");
            DropTable("dbo.TB_LOGS");
        }
    }
}
