﻿using Microsoft.AspNet.Identity.EntityFramework;
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
        #region Hossam
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<EmploymentType> EmploymentTypes { get; set; }
        public virtual DbSet<UserPhoto> UserPhotos { get; set; }
        public virtual DbSet<UserConnection> UserConnections { get; set; }
        #endregion

        #region Nora
        public virtual DbSet<UserProject> UserProjects { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<UserLanguage> UserLanguages { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        #endregion

        #region Wafaa
        public virtual DbSet<Experience> Experiences { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Certification> Certifications { get; set; }
        #endregion

        #region Aya&Ibrahim
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Reply> Replies { get; set; }
        public virtual DbSet<UserLikedPost> UserLikedPosts { get; set; }
        public virtual DbSet<UserLikedComment> UserLikedComments { get; set; }
        public virtual DbSet<UserLikedReply> UserLikedReplies { get; set; }
        public virtual DbSet<UserSharedPost> UserSharedPosts { get; set; }
        public virtual DbSet<PostPhoto> PostPhotos { get; set; }
        public virtual DbSet<CommentPhoto> CommentPhotos { get; set; }
        public virtual DbSet<ReplyPhoto> ReplyPhotos { get; set; }
        #endregion

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
