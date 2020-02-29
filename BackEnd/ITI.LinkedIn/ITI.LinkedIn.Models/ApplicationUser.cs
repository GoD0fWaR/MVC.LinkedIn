using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ITI.LinkedIn.Models
{
    public class ApplicationUser : IdentityUser
    {

        public ApplicationUser()
        {
            Skills = new HashSet<Skill>();
            Courses = new HashSet<Course>();
            Photos = new HashSet<UserPhoto>();
            Following = new HashSet<UserConnection>();
            Followers = new HashSet<UserConnection>();

            Educations = new HashSet<Education>();
            Projects = new HashSet<UserProject>();
            Languages = new HashSet<UserLanguage>();

            Experiences = new HashSet<Experience>();
            Certifications = new HashSet<Certification>();

            Posts = new HashSet<Post>();
            Comments = new HashSet<Comment>();
            Replies = new HashSet<Reply>();
            UserLikedPosts = new HashSet<UserLikedPost>();
            UserLikedComments = new HashSet<UserLikedComment>();
            UserLikedReplies = new HashSet<UserLikedReply>();
            UserSharedPosts = new HashSet<UserSharedPost>();
        }

        // user data
        [Required(ErrorMessage = "First Name is Required")]
        [MaxLength(50, ErrorMessage = "First Name must be less than 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        [MaxLength(50, ErrorMessage = "Last Name must be less than 50 characters")]
        public string LastName { get; set; }

        [MaxLength(500, ErrorMessage = "Head line must be less than 500 characters")]
        public string HeadLine { get; set; }

        // text in database
        [Column(TypeName = "text")]
        public string About { get; set; }

        public string CurrenPosition { get; set; }

        //Relations
        #region Hossam
            public virtual ICollection<Skill> Skills { get; set; }

            public virtual ICollection<Course> Courses { get; set; }

            // user photos
            public virtual ICollection<UserPhoto> Photos { get; set; }

            // user followings
            [InverseProperty("Sender")]
            public virtual ICollection<UserConnection> Following { get; set; }

            // user followers
            [InverseProperty("Receiver")]
            public virtual ICollection<UserConnection> Followers { get; set; }
        #endregion

        #region Nora
            public virtual ICollection<Education> Educations { get; set; }

            public virtual ICollection<UserProject> Projects { get; set; }

            public virtual ICollection<UserLanguage> Languages { get; set; }
        #endregion

        #region Wafaa
            [ForeignKey("Country")]
            public int CountryId { get; set; }
            public virtual Country Country { get; set; }

            public virtual ICollection<Experience> Experiences { get; set; }

            public virtual ICollection<Certification> Certifications { get; set; }
        #endregion

        #region Ibrahim&Aya
            // user has posts
            public virtual ICollection<Post> Posts { get; set; }

            // user liked posts
            public virtual ICollection<UserLikedPost> UserLikedPosts { get; set; }

            // user has comments
            public virtual ICollection<Comment> Comments { get; set; }

            // user liked comments
            public virtual ICollection<UserLikedComment> UserLikedComments { get; set; }

            // user has replies
            public virtual ICollection<Reply> Replies { get; set; }

            // user liked comments
            public virtual ICollection<UserLikedReply> UserLikedReplies { get; set; }

            // may have some future problems
            // user shared posts
            public virtual ICollection<UserSharedPost> UserSharedPosts { get; set; }
        #endregion
        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        } 
    }
}
