using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.LinkedIn.Models
{
    [Table("Company")]
    public class Company
    {
        //company constructor
        public Company()
        {
            Jobs = new HashSet<Job>();
            Certifications = new HashSet<Certification>();
            Experiences = new HashSet<Experience>();
        }
        //Company Data
        [Key]
        public int Id { set; get; }

        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(50, ErrorMessage = "Company Name must be less than 50")]
        public string Name { set; get; }

        [Required(ErrorMessage = "NumOfEmployees is Required")]
        public int NumOfEmployees { set; get; }

        //Company Relations
        //company has list of jobs
        public virtual ICollection<Job> Jobs { set; get; }

        //not necessary so needs some testing
        //company has list of certifications
        public virtual ICollection<Certification> Certifications { set; get; }

        //not necessary so needs some testing
        //company has list of experiences
        public virtual ICollection<Experience> Experiences { set; get; }
    }
}