using ITI.LinkedIn.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.LinkedIn.Models
{
    [Table("ReplyPhoto")]
    public class ReplyPhoto
    {
        public ReplyPhoto()
        {
            Date = DateTime.Now;
            FileType = FileType.Photo;
        }
        [Key]
        [ForeignKey("Reply")]
        public int ReplyId { get; set; }
        public string ReplyPhotoName { get; set; }

        public string ReplyPhotoExtension { get; set; }

        public FileType FileType { get; set; }
        public virtual Reply Reply { get; set; }

        [Column(TypeName = "datetime2")]
        public System.DateTime Date { get; set; }
    }
}
