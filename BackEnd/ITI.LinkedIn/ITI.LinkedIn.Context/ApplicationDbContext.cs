using Microsoft.AspNet.Identity.EntityFramework;
using ITI.LinkedIn.Models;
using ITI.LinkedIn.Models.PivotModels;
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
        public virtual DbSet<UserProject> UserProject { get; set; }
        #endregion

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
