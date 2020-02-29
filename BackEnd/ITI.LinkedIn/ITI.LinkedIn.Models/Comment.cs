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
            Date = DateTime.Now;
            UserLikedComments = new HashSet<UserLikedComment>();
            Replies = new HashSet<Reply>();
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

        [ForeignKey("Post")]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }

        public virtual CommentPhoto CommentPhoto { get; set; }

        public virtual ICollection<UserLikedComment> UserLikedComments { get; set; }

        public virtual ICollection<Reply> Replies { get; set; }
    }
}