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
            public UserProject()
            {
                this.EndDate = DateTime.Now;
                this.StartDate = DateTime.Now;
            }
            [Key]

            public int Id { get; set; }

            [ForeignKey("ApplicationUser")]

            public string UserId { get; set; }

            [Required(ErrorMessage = "Name is Required")]
            [MaxLength(50, ErrorMessage = " Name must be less than 50 characters")]
            public string Name { get; set; }
            [Required(ErrorMessage = "Start Year is Required")]
            [Display(Name = "Start Year")]
            [Column(TypeName = "datetime2")]
            public DateTime StartDate { get; set; }

            [Required(ErrorMessage = "Start Year is Required")]
            [Display(Name = "End Year")]
            [Column(TypeName = "datetime2")]
            public DateTime EndDate { get; set; }
            public string Url { get; set; }
            [MaxLength(255, ErrorMessage = "Description must be less than 255 characters")]
            public string Description { get; set; }
            public virtual ApplicationUser ApplicationUser { get; set; }

        }
    }
