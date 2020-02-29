using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.LinkedIn.Models
{
    [Table("Experience")]
    public class Experience
    {
        //Experience Data
        [Key]
        public int Id { set; get; }

        [Required(ErrorMessage = "Title is Required")]
        [MaxLength(255, ErrorMessage = "Title must be less then 255")]
        public string Title { set; get; }

        [Required(ErrorMessage = "Description is Required")]
        [Column(TypeName = "text")]
        public string Description { set; get; }

        [Required(ErrorMessage = "HeadLine is Required")]
        [MaxLength(255, ErrorMessage = "HeadLine must be less then 255")]
        public string HeadLine { set; get; }

        [Required(ErrorMessage = "StartDate is Required")]
        [Column(TypeName = "datetime2")]
        public DateTime StartDate { set; get; }

        [Required(ErrorMessage = "EndDate is Required")]
        [Column(TypeName = "datetime2")]
        public DateTime EndDate { set; get; }

        public bool CurrentlyWorkingHere { get; set; }

        //Relations
        //UserId
        [ForeignKey("User")]
        public string UserId { set; get; }
        public virtual ApplicationUser User { set; get; }

        //Country Id
        [ForeignKey("Country")]
        public int CountryId { set; get; }
        public virtual Country Country { set; get; }

        //Company Id
        [ForeignKey("Company")]
        public int CompanyId { set; get; }
        public virtual Company Company { set; get; }

        //EmploymentType
        [ForeignKey("EmploymentType")]
        public int EmploymentTypeId { set; get; }
        public virtual EmploymentType EmploymentType { set; get; }
    }
}