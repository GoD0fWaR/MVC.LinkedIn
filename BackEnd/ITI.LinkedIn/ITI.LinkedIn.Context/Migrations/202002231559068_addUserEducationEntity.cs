namespace ITI.LinkedIn.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserEducationEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Education",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 50),
                        Degree = c.String(nullable: false),
                        FieldOfStudy = c.String(nullable: false),
                        Grade = c.String(nullable: false),
                        StartYear = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndYear = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Description = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Education", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Education", new[] { "UserId" });
            DropTable("dbo.Education");
        }
    }
}
