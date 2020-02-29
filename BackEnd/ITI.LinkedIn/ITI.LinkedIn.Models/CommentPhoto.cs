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
        [Column(Order = 1)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Comment")]
        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }

        public string Path { get; set; }
    }
}