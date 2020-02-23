namespace ITI.LinkedIn.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserlanguageEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Language",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserLanguages",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Proficiency = c.Int(nullable: false),
                        Language_Id = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Language", t => t.Language_Id)
                .Index(t => t.UserId)
                .Index(t => t.Language_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserLanguages", "Language_Id", "dbo.Language");
            DropForeignKey("dbo.UserLanguages", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserLanguages", new[] { "Language_Id" });
            DropIndex("dbo.UserLanguages", new[] { "UserId" });
            DropTable("dbo.UserLanguages");
            DropTable("dbo.Language");
        }
    }
}
