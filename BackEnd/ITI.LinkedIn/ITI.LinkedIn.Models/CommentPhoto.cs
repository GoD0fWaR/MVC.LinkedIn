using ITI.LinkedIn.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI.LinkedIn.Models
{
    [Table("CommentPhoto")]
    public class CommentPhoto
    {
        public CommentPhoto()
        {
            Date = DateTime.Now;
            FileType = FileType.Photo;

        }
        [Key]
        [ForeignKey("Comment")]
        public int CommentId { get; set; }

        public string CommentPhotoName { get; set; }

        public string CommentPhotoExtension { get; set; }

        public FileType FileType { get; set; }

        public virtual Comment Comment { get; set; }

        [Column(TypeName = "datetime2")]
        public System.DateTime Date { get; set; }



    }
}