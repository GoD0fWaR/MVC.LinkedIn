using ITI.LinkedIn.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI.LinkedIn.Models
{
    [Table("PostPhoto")]
    public class PostPhoto
    {
        public PostPhoto()
        {
            Date = DateTime.Now;
            FileType = FileType.Photo;
        }
        [Key]
        public int PostPhotoId { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }

        [StringLength(255)]
        public string PostPhotoName { get; set; }

        public string PostPhotoExtension { get; set; }
   
        public virtual Post Post { get; set; }

        [Column(TypeName ="datetime2")]
        public System.DateTime Date { get; set; }

        public FileType FileType { get; set; }

    }
}