namespace MyEFConsole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Classes",
            //    c => new
            //        {
            //            CID = c.String(nullable: false, maxLength: 128),
            //            CName = c.String(),
            //            Persons = c.Int(nullable: false),
            //            AddUserID = c.Int(nullable: false),
            //            AddDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.CID);
            
            //CreateTable(
            //    "dbo.StuClassesRelations",
            //    c => new
            //        {
            //            UID = c.String(nullable: false, maxLength: 128),
            //            CID = c.String(),
            //        })
            //    .PrimaryKey(t => t.UID);
            
            //CreateTable(
            //    "dbo.Students",
            //    c => new
            //        {
            //            UID = c.String(nullable: false, maxLength: 128),
            //            UName = c.String(),
            //            UAge = c.Int(nullable: false),
            //            Address = c.String(),
            //            Mobile = c.String(),
            //        })
            //    .PrimaryKey(t => t.UID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
            DropTable("dbo.StuClassesRelations");
            DropTable("dbo.Classes");
        }
    }
}
