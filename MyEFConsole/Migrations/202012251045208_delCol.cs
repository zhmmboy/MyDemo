namespace MyEFConsole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delCol : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Classes", "FloorHeight");
            DropColumn("dbo.Classes", "AddUserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Classes", "AddUserID", c => c.Int(nullable: false));
            AddColumn("dbo.Classes", "FloorHeight", c => c.Int(nullable: false));
        }
    }
}
