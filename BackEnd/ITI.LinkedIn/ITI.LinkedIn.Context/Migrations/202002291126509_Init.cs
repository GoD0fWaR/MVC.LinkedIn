namespace ITI.LinkedIn.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Certification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Url = c.String(nullable: false),
                        IssueDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UserId = c.String(maxLength: 128),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.CompanyId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        NumOfEmployees = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Experience",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, unicode: false, storeType: "text"),
                        HeadLine = c.String(nullable: false, maxLength: 255),
                        StartDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CurrentlyWorkingHere = c.Boolean(nullable: false),
                        UserId = c.String(maxLength: 128),
                        CountryId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        EmploymentTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.CompanyId)
                .ForeignKey("dbo.Country", t => t.CountryId)
                .ForeignKey("dbo.EmploymentType", t => t.EmploymentTypeId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CountryId)
                .Index(t => t.CompanyId)
                .Index(t => t.EmploymentTypeId);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Job",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        PublishDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        NumberOfApplicats = c.Int(nullable: false),
                        Level = c.String(nullable: false),
                        Mission = c.String(nullable: false, unicode: false, storeType: "text"),
                        Responsibilities = c.String(nullable: false, unicode: false, storeType: "text"),
                        Languages = c.String(nullable: false),
                        YearsOfExperiences = c.Int(nullable: false),
                        EmploymentTypeId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Country", t => t.CountryId)
                .ForeignKey("dbo.EmploymentType", t => t.EmploymentTypeId)
                .Index(t => t.EmploymentTypeId)
                .Index(t => t.CompanyId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.EmploymentType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        HeadLine = c.String(maxLength: 500),
                        About = c.String(unicode: false, storeType: "text"),
                        CurrenPosition = c.String(),
                        CountryId = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Country", t => t.CountryId)
                .Index(t => t.CountryId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Body = c.String(unicode: false, storeType: "text"),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UserId = c.String(maxLength: 128),
                        PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.CommentPhoto",
                c => new
                    {
                        CommentId = c.Int(nullable: false),
                        Path = c.String(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Comment", t => t.CommentId)
                .Index(t => t.CommentId);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Body = c.String(unicode: false, storeType: "text"),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PostPhoto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.UserLikedPost",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        PostId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => new { t.UserId, t.PostId })
                .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.UserSharedPost",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        PostId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => new { t.UserId, t.PostId })
                .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.Reply",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Body = c.String(unicode: false, storeType: "text"),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UserId = c.String(maxLength: 128),
                        CommentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comment", t => t.CommentId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CommentId);
            
            CreateTable(
                "dbo.ReplyPhoto",
                c => new
                    {
                        ReplyId = c.Int(nullable: false),
                        Path = c.String(),
                    })
                .PrimaryKey(t => t.ReplyId)
                .ForeignKey("dbo.Reply", t => t.ReplyId)
                .Index(t => t.ReplyId);
            
            CreateTable(
                "dbo.UserLikedReply",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        PostId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => new { t.UserId, t.PostId })
                .ForeignKey("dbo.Reply", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.UserLikedComment",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        CommentId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => new { t.UserId, t.CommentId })
                .ForeignKey("dbo.Comment", t => t.CommentId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CommentId);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Education",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Degree = c.String(nullable: false),
                        FieldOfStudy = c.String(nullable: false),
                        Grade = c.String(nullable: false),
                        StartYear = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndYear = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Description = c.String(unicode: false, storeType: "text"),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserConnection",
                c => new
                    {
                        SenderId = c.String(nullable: false, maxLength: 128),
                        ReceiverId = c.String(nullable: false, maxLength: 128),
                        IsAccepted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.SenderId, t.ReceiverId })
                .ForeignKey("dbo.AspNetUsers", t => t.ReceiverId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.SenderId, cascadeDelete: true)
                .Index(t => t.SenderId)
                .Index(t => t.ReceiverId);
            
            CreateTable(
                "dbo.UserLanguage",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LanguageId = c.Int(nullable: false),
                        Proficiency = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.LanguageId })
                .ForeignKey("dbo.Language", t => t.LanguageId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Language",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserPhoto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserProject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        StartDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Url = c.String(),
                        Description = c.String(unicode: false, storeType: "text"),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Skill",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.CourseApplicationUsers",
                c => new
                    {
                        Course_Id = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Course_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.Course", t => t.Course_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.Course_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.SkillApplicationUsers",
                c => new
                    {
                        Skill_Id = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Skill_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.Skill", t => t.Skill_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.Skill_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Certification", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Certification", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.Experience", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Experience", "EmploymentTypeId", "dbo.EmploymentType");
            DropForeignKey("dbo.Experience", "CountryId", "dbo.Country");
            DropForeignKey("dbo.SkillApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.SkillApplicationUsers", "Skill_Id", "dbo.Skill");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserProject", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserPhoto", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserLanguage", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserLanguage", "LanguageId", "dbo.Language");
            DropForeignKey("dbo.UserConnection", "SenderId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserConnection", "ReceiverId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Education", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CourseApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CourseApplicationUsers", "Course_Id", "dbo.Course");
            DropForeignKey("dbo.AspNetUsers", "CountryId", "dbo.Country");
            DropForeignKey("dbo.UserLikedComment", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserLikedComment", "CommentId", "dbo.Comment");
            DropForeignKey("dbo.Comment", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserLikedReply", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserLikedReply", "PostId", "dbo.Reply");
            DropForeignKey("dbo.Reply", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ReplyPhoto", "ReplyId", "dbo.Reply");
            DropForeignKey("dbo.Reply", "CommentId", "dbo.Comment");
            DropForeignKey("dbo.Comment", "PostId", "dbo.Post");
            DropForeignKey("dbo.UserSharedPost", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserSharedPost", "PostId", "dbo.Post");
            DropForeignKey("dbo.UserLikedPost", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserLikedPost", "PostId", "dbo.Post");
            DropForeignKey("dbo.Post", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PostPhoto", "PostId", "dbo.Post");
            DropForeignKey("dbo.CommentPhoto", "CommentId", "dbo.Comment");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Job", "EmploymentTypeId", "dbo.EmploymentType");
            DropForeignKey("dbo.Job", "CountryId", "dbo.Country");
            DropForeignKey("dbo.Job", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.Experience", "CompanyId", "dbo.Company");
            DropIndex("dbo.SkillApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.SkillApplicationUsers", new[] { "Skill_Id" });
            DropIndex("dbo.CourseApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.CourseApplicationUsers", new[] { "Course_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.UserProject", new[] { "UserId" });
            DropIndex("dbo.UserPhoto", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.UserLanguage", new[] { "LanguageId" });
            DropIndex("dbo.UserLanguage", new[] { "UserId" });
            DropIndex("dbo.UserConnection", new[] { "ReceiverId" });
            DropIndex("dbo.UserConnection", new[] { "SenderId" });
            DropIndex("dbo.Education", new[] { "UserId" });
            DropIndex("dbo.UserLikedComment", new[] { "CommentId" });
            DropIndex("dbo.UserLikedComment", new[] { "UserId" });
            DropIndex("dbo.UserLikedReply", new[] { "PostId" });
            DropIndex("dbo.UserLikedReply", new[] { "UserId" });
            DropIndex("dbo.ReplyPhoto", new[] { "ReplyId" });
            DropIndex("dbo.Reply", new[] { "CommentId" });
            DropIndex("dbo.Reply", new[] { "UserId" });
            DropIndex("dbo.UserSharedPost", new[] { "PostId" });
            DropIndex("dbo.UserSharedPost", new[] { "UserId" });
            DropIndex("dbo.UserLikedPost", new[] { "PostId" });
            DropIndex("dbo.UserLikedPost", new[] { "UserId" });
            DropIndex("dbo.PostPhoto", new[] { "PostId" });
            DropIndex("dbo.Post", new[] { "UserId" });
            DropIndex("dbo.CommentPhoto", new[] { "CommentId" });
            DropIndex("dbo.Comment", new[] { "PostId" });
            DropIndex("dbo.Comment", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "CountryId" });
            DropIndex("dbo.Job", new[] { "CountryId" });
            DropIndex("dbo.Job", new[] { "CompanyId" });
            DropIndex("dbo.Job", new[] { "EmploymentTypeId" });
            DropIndex("dbo.Experience", new[] { "EmploymentTypeId" });
            DropIndex("dbo.Experience", new[] { "CompanyId" });
            DropIndex("dbo.Experience", new[] { "CountryId" });
            DropIndex("dbo.Experience", new[] { "UserId" });
            DropIndex("dbo.Certification", new[] { "CompanyId" });
            DropIndex("dbo.Certification", new[] { "UserId" });
            DropTable("dbo.SkillApplicationUsers");
            DropTable("dbo.CourseApplicationUsers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Skill");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.UserProject");
            DropTable("dbo.UserPhoto");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Language");
            DropTable("dbo.UserLanguage");
            DropTable("dbo.UserConnection");
            DropTable("dbo.Education");
            DropTable("dbo.Course");
            DropTable("dbo.UserLikedComment");
            DropTable("dbo.UserLikedReply");
            DropTable("dbo.ReplyPhoto");
            DropTable("dbo.Reply");
            DropTable("dbo.UserSharedPost");
            DropTable("dbo.UserLikedPost");
            DropTable("dbo.PostPhoto");
            DropTable("dbo.Post");
            DropTable("dbo.CommentPhoto");
            DropTable("dbo.Comment");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.EmploymentType");
            DropTable("dbo.Job");
            DropTable("dbo.Country");
            DropTable("dbo.Experience");
            DropTable("dbo.Company");
            DropTable("dbo.Certification");
        }
    }
}
