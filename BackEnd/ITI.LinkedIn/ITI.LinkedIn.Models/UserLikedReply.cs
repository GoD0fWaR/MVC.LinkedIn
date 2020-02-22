using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI.LinkedIn.Models
{
    [Table("UserLikedReply")]
    public class UserLikedReply
    {
        public UserLikedReply()
        {
            this.Date = DateTime.Now;
        }
        [Key]
        [Column(Order = 1)]
        [ForeignKey("User")]
        public string UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Reply")]
        public int PostId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Reply Reply { get; set; }

        [Column(TypeName = "datetime2")]
        public System.DateTime Date { get; set; }
    }
}