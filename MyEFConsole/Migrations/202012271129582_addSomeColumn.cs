namespace MyEFConsole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSomeColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Classes", "FloorHeight", c => c.Int(nullable: false));
            AddColumn("dbo.Classes", "FloorHeightUnit", c => c.String());
            AddColumn("dbo.Classes", "AddUserID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Classes", "AddUserID");
            DropColumn("dbo.Classes", "FloorHeightUnit");
            DropColumn("dbo.Classes", "FloorHeight");
        }
    }
}
