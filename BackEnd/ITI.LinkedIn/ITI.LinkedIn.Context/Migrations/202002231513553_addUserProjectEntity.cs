namespace ITI.LinkedIn.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserProjectEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 50),
                        StartDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Url = c.String(),
                        Description = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProject", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserProject", new[] { "UserId" });
            DropTable("dbo.UserProject");
        }
    }
}
