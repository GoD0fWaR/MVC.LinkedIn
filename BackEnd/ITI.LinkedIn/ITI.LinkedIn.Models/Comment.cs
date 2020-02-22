using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI.LinkedIn.Models
{
    [Table("Comment")]
    public class Comment
    {
        public Comment()
        {
            this.UserLikedComments = new HashSet<UserLikedComment>();
            this.Replies = new HashSet<Reply>();
        }
        [Key]
        public int CommentId { get; set; }

        [Column(TypeName ="text")]
        public string Body { get; set; }    

        [ForeignKey("User")]
        public string UserId { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<UserLikedComment> UserLikedComments { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
        public virtual CommentPhoto CommentPhoto { get; set; }

    }
}