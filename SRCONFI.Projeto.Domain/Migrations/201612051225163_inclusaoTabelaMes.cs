namespace SRCONFI.Projeto.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inclusaoTabelaMes : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Mes", newName: "TB_MES");
            RenameColumn(table: "dbo.TB_MES", name: "mesID", newName: "ID_MES");
            RenameColumn(table: "dbo.TB_MES", name: "nomeMes", newName: "TX_NOME_MES");
            AlterColumn("dbo.TB_MES", "TX_NOME_MES", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TB_MES", "TX_NOME_MES", c => c.String());
            RenameColumn(table: "dbo.TB_MES", name: "TX_NOME_MES", newName: "nomeMes");
            RenameColumn(table: "dbo.TB_MES", name: "ID_MES", newName: "mesID");
            RenameTable(name: "dbo.TB_MES", newName: "Mes");
        }
    }
}
