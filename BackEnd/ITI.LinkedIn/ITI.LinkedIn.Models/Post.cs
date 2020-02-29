using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI.LinkedIn.Models
{
    [Table("Post")]
    public class Post
    {
        public Post()
        {
            Date = DateTime.Now;
            PostPhotos = new HashSet<PostPhoto>();
            UserLikedPosts = new HashSet<UserLikedPost>();
            Comments = new HashSet<Comment>();
            UserSharedPosts = new HashSet<UserSharedPost>();
        }

        [Key]
        public int Id { get; set; }

        [Column(TypeName = "text")]
        public string Body { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<PostPhoto> PostPhotos { get; set; }

        public virtual ICollection<UserLikedPost> UserLikedPosts { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<UserSharedPost> UserSharedPosts { get; set; }
    }
}