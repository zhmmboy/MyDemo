namespace MyEFConsole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFloorHeight : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Classes", "FloorHeight", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Classes", "FloorHeight");
        }
    }
}
