namespace MikhunaEcuador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PasosChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pasos", "Paso", c => c.String(nullable: false, maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pasos", "Paso", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
