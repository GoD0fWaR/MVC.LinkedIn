using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.LinkedIn.Models
{
    [Table("UserProject")]
    public class UserProject
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(255, ErrorMessage = " Name must be less than 255 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Start Year is Required")]
        [Display(Name = "Start Year")]
        [Column(TypeName = "datetime2")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Year is Required")]
        [Display(Name = "End Year")]
        [Column(TypeName = "datetime2")]
        public DateTime EndDate { get; set; }

        public string Url { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}