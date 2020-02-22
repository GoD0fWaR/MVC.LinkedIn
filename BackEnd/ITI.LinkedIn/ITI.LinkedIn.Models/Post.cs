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
            this.PostPhotos = new HashSet<PostPhoto>();
            this.UserLikedPosts = new HashSet<UserLikedPost>();
            this.Comments = new HashSet<Comment>();
            this.UserSharedPosts = new HashSet<UserSharedPost>();
            this.Date = DateTime.Now;
        }
        public int PostId { get; set; }
        [Column(TypeName ="text")]
        public string Body { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<PostPhoto>  PostPhotos { get; set; }
        public virtual ICollection<UserLikedPost> UserLikedPosts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<UserSharedPost> UserSharedPosts { get; set; }

        [Column(TypeName = "datetime2")]
        public System.DateTime Date { get; set; }


    }
}