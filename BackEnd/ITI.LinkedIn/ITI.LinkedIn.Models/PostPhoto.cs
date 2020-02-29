using ITI.LinkedIn.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI.LinkedIn.Models
{
    [Table("PostPhoto")]
    public class PostPhoto
    {
        [Key]
        public int Id { get; set; }

        public string Path { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}