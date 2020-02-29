using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.LinkedIn.Models
{
    [Table("Job")]
    public class Job
    {
        //Job Attributes
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Job Title is Required")]
        [MaxLength(255, ErrorMessage = "Job Title Must be less than 255")]
        public string Title { set; get; }

        [Required(ErrorMessage = "Date is Required")]
        [Column(TypeName = "datetime2")]
        public DateTime PublishDate { set; get; }

        //[Required(ErrorMessage = "No Of Applicants is required")]
        public int NumberOfApplicats { set; get; } = 0;

        [Required(ErrorMessage = "Level is Required")]
        public string Level { set; get; }

        [Required(ErrorMessage = "Mission is Required")]
        [Column(TypeName = "text")]
        public string Mission { set; get; }

        [Required(ErrorMessage = "Resposibilities is Required")]
        [Column(TypeName = "text")]
        public string Responsibilities { set; get; }

        [Required(ErrorMessage = "Languages is Required")]
        public string Languages { set; get; }

        [Required(ErrorMessage = "YearsOfExperiences is Required")]
        public int YearsOfExperiences { set; get; }

        //Job Relations
        //Employment Type ID
        [ForeignKey("EmploymentType")]
        public int EmploymentTypeId { get; set; }
        public virtual EmploymentType EmploymentType { set; get; }

        //Company Id
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        //Country Id
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}