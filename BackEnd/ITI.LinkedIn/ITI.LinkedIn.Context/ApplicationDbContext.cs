using Microsoft.AspNet.Identity.EntityFramework;
using ITI.LinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.LinkedIn.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        // To add a new Model
        //public virtual DbSet<Skill> Skills { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Reply> Replies { get; set; }
        public virtual DbSet<UserLikedComment> UserLikedComments { get; set; }
        public virtual DbSet<UserLikedPost> UserLikedPosts { get; set; }
        public virtual DbSet<UserLikedReply> UserLikedReplies { get; set; }
        public virtual DbSet<UserSharedPost> UserSharedPosts { get; set; }
        public virtual DbSet<CommentPhoto> CommentPhotos { get; set; }
        public virtual DbSet<ReplyPhoto> ReplyPhotos { get; set; }
        public virtual DbSet<PostPhoto> PostPhotos { get; set; }
        public virtual DbSet<UserPhoto> UserPhotos { get; set; }
    }
}
