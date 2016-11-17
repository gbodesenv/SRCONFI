namespace SRCONFI.Projeto.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntitySociosPropertyInStatus : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TB_SOCIOS", "IN_STATUS", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TB_SOCIOS", "IN_STATUS", c => c.Boolean(nullable: false));
        }
    }
}
