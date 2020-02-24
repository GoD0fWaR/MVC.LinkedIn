namespace ITI.LinkedIn.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommentPhoto",
                c => new
                    {
                        CommentId = c.Int(nullable: false),
                        CommentPhotoName = c.String(),
                        CommentPhotoExtension = c.String(),
                        FileType = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Comment", t => t.CommentId)
                .Index(t => t.CommentId);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Body = c.String(unicode: false, storeType: "text"),
                        UserId = c.String(maxLength: 128),
                        PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Body = c.String(unicode: false, storeType: "text"),
                        UserId = c.String(maxLength: 128),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PostPhoto",
                c => new
                    {
                        PostPhotoId = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        PostPhotoName = c.String(maxLength: 255),
                        PostPhotoExtension = c.String(),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        FileType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostPhotoId)
                .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        HeadLine = c.String(maxLength: 255),
                        About = c.String(maxLength: 500),
                        CurrenPosition = c.String(),
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
                        UserPhotoId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.UserPhotoId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Reply",
                c => new
                    {
                        ReplyId = c.Int(nullable: false, identity: true),
                        Body = c.String(unicode: false, storeType: "text"),
                        UserId = c.String(maxLength: 128),
                        CommentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReplyId)
                .ForeignKey("dbo.Comment", t => t.CommentId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CommentId);
            
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
                "dbo.ReplyPhoto",
                c => new
                    {
                        ReplyId = c.Int(nullable: false),
                        ReplyPhotoName = c.String(),
                        ReplyPhotoExtension = c.String(),
                        FileType = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.ReplyId)
                .ForeignKey("dbo.Reply", t => t.ReplyId)
                .Index(t => t.ReplyId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ReplyPhoto", "ReplyId", "dbo.Reply");
            DropForeignKey("dbo.CommentPhoto", "CommentId", "dbo.Comment");
            DropForeignKey("dbo.Comment", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comment", "PostId", "dbo.Post");
            DropForeignKey("dbo.Post", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserSharedPost", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserSharedPost", "PostId", "dbo.Post");
            DropForeignKey("dbo.UserLikedPost", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserLikedPost", "PostId", "dbo.Post");
            DropForeignKey("dbo.UserLikedComment", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserLikedComment", "CommentId", "dbo.Comment");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserLikedReply", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserLikedReply", "PostId", "dbo.Reply");
            DropForeignKey("dbo.Reply", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reply", "CommentId", "dbo.Comment");
            DropForeignKey("dbo.UserPhoto", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PostPhoto", "PostId", "dbo.Post");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ReplyPhoto", new[] { "ReplyId" });
            DropIndex("dbo.UserSharedPost", new[] { "PostId" });
            DropIndex("dbo.UserSharedPost", new[] { "UserId" });
            DropIndex("dbo.UserLikedPost", new[] { "PostId" });
            DropIndex("dbo.UserLikedPost", new[] { "UserId" });
            DropIndex("dbo.UserLikedComment", new[] { "CommentId" });
            DropIndex("dbo.UserLikedComment", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.UserLikedReply", new[] { "PostId" });
            DropIndex("dbo.UserLikedReply", new[] { "UserId" });
            DropIndex("dbo.Reply", new[] { "CommentId" });
            DropIndex("dbo.Reply", new[] { "UserId" });
            DropIndex("dbo.UserPhoto", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.PostPhoto", new[] { "PostId" });
            DropIndex("dbo.Post", new[] { "UserId" });
            DropIndex("dbo.Comment", new[] { "PostId" });
            DropIndex("dbo.Comment", new[] { "UserId" });
            DropIndex("dbo.CommentPhoto", new[] { "CommentId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ReplyPhoto");
            DropTable("dbo.UserSharedPost");
            DropTable("dbo.UserLikedPost");
            DropTable("dbo.UserLikedComment");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.UserLikedReply");
            DropTable("dbo.Reply");
            DropTable("dbo.UserPhoto");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.PostPhoto");
            DropTable("dbo.Post");
            DropTable("dbo.Comment");
            DropTable("dbo.CommentPhoto");
        }
    }
}
