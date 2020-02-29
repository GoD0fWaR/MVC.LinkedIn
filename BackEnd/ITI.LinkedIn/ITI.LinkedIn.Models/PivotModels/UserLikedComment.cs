using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI.LinkedIn.Models
{
    [Table("UserLikedComment")]
    public class UserLikedComment
    {
        public UserLikedComment()
        {
            Date = DateTime.Now;
        }
        [Key]
        [Column(Order = 1)]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Comment")]
        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }
    }
}