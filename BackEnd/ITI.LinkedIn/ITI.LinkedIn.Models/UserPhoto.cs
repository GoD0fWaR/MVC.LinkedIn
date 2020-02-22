using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI.LinkedIn.Models
{
    [Table("UserPhoto")]
    public class UserPhoto
    {
        public UserPhoto()
        {
            this.Date = DateTime.Now;
        }
        [Key]
        public int UserPhotoId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [Column(TypeName = "datetime2")]
        public System.DateTime Date { get; set; }

    }
}