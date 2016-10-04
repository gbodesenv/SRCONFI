namespace SRCONFI.Projeto.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterRelacaoLogComUsuarioEUsuarioTipoUsuario : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TB_LOGS", "Usuario_usuarioID", "dbo.TB_USUARIOS");
            DropIndex("dbo.TB_LOGS", new[] { "Usuario_usuarioID" });
            RenameColumn(table: "dbo.TB_LOGS", name: "Usuario_usuarioID", newName: "usuarioID_FK");
            RenameColumn(table: "dbo.TB_USUARIOS", name: "tipoUsuarioID", newName: "tipoUsuarioID_FK");
            RenameIndex(table: "dbo.TB_USUARIOS", name: "IX_tipoUsuarioID", newName: "IX_tipoUsuarioID_FK");
            AlterColumn("dbo.TB_LOGS", "usuarioID_FK", c => c.Int());
            CreateIndex("dbo.TB_LOGS", "usuarioID_FK");
            AddForeignKey("dbo.TB_LOGS", "usuarioID_FK", "dbo.TB_USUARIOS", "ID_USUARIO");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_LOGS", "usuarioID_FK", "dbo.TB_USUARIOS");
            DropIndex("dbo.TB_LOGS", new[] { "usuarioID_FK" });
            AlterColumn("dbo.TB_LOGS", "usuarioID_FK", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.TB_USUARIOS", name: "IX_tipoUsuarioID_FK", newName: "IX_tipoUsuarioID");
            RenameColumn(table: "dbo.TB_USUARIOS", name: "tipoUsuarioID_FK", newName: "tipoUsuarioID");
            RenameColumn(table: "dbo.TB_LOGS", name: "usuarioID_FK", newName: "Usuario_usuarioID");
            CreateIndex("dbo.TB_LOGS", "Usuario_usuarioID");
            AddForeignKey("dbo.TB_LOGS", "Usuario_usuarioID", "dbo.TB_USUARIOS", "ID_USUARIO", cascadeDelete: true);
        }
    }
}
