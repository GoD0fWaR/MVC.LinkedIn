using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI.LinkedIn.Models
{
    [Table("Reply")]
    public class Reply
    {
        public Reply()
        {
            Date = DateTime.Now;
            UserLikedReplies = new HashSet<UserLikedReply>();
        }

        [Key]
        public int Id { get; set; }

        [Column(TypeName = "text")]
        public string Body { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("Comment")]
        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }

        public virtual ReplyPhoto ReplyPhoto { get; set; }

        public virtual ICollection<UserLikedReply> UserLikedReplies { get; set; }
    }
}