using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI.LinkedIn.Models
{
    [Table("UserSharedPost")]
    public class UserSharedPost
    {
        public UserSharedPost()
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
        [ForeignKey("Post")]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }
    }
}