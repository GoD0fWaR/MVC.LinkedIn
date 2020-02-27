using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.Layers.Models
{
    [Table("Company")]
    public class Company
    {
        //company constructor
        public Company()
        {
            Jobs = new HashSet<Job>();
        }
        //Company Data
        [Key]
        public int Id { set; get; }

        [Required(ErrorMessage = "NumOfEmployees is Required")]
        public int NumOfEmployees { set; get; }

        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(50, ErrorMessage = "Company Name must be less than 50")]
        public string Name { set; get; }


        //Company Relations

        //company has list o jobs
        public virtual ICollection<Job> Jobs { set; get; }
        public virtual ICollection<Certification> Certifications { set; get; }

    }
}
