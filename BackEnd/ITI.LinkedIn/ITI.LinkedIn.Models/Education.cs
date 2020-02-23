
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.LinkedIn.Models
{
    [Table("Education")]
    public class Education
    {
        public Education()
        {
            this.StartYear = DateTime.Now;
            this.EndYear = DateTime.Now;
        }
        [Key]

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("ApplicationUser")]

        public string UserId { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(50, ErrorMessage = " Name must be less than 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Degree is Required")]
        public string Degree { get; set; }

        [Required(ErrorMessage = "Field Of Study is Required")]
        [Display(Name = "Field of Study")]
        public string FieldOfStudy { get; set; }

        [Required(ErrorMessage = "Grade is Required")]
        public string Grade { get; set; }

        [Required(ErrorMessage = "Start Year is Required")]
        [Display(Name = "Start Year")]
        [Column(TypeName = "datetime2")]
        public DateTime StartYear { get; set; }

        [Required(ErrorMessage = "End Year is Required")]
        [Display(Name = "End Year")]
        [Column(TypeName = "datetime2")]
        public DateTime EndYear { get; set; }

        [MaxLength(255, ErrorMessage = "Description must be less than 255 characters")]
        public string Description { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
