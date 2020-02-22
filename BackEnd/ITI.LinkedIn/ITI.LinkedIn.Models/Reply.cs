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
            this.UserLikedReplies = new HashSet<UserLikedReply>();
        }
        [Key]
        public int ReplyId { get; set; }

        [Column(TypeName = "text")]
        public string Body { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        [ForeignKey("Comment")]
        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<UserLikedReply> UserLikedReplies { get; set; }

    }
}