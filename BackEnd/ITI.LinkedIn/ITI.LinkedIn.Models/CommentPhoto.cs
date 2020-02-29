using ITI.LinkedIn.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI.LinkedIn.Models
{
    [Table("CommentPhoto")]
    public class CommentPhoto
    {
        [Key]
        public int Id { get; set; }

        public string Path { get; set; }

        [ForeignKey("Comment")]
        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }
    }
}