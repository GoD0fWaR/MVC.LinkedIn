using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.LinkedIn.Models
{
    [Table("Country")]
    public class Country
    {
        //Country Constructor
        public Country()
        {
            Users = new HashSet<ApplicationUser>();
            Jobs = new HashSet<Job>();
            Experiences = new HashSet<Experience>();
        }

        //Country Data
        [Key]
        public int Id { set; get; }
        [Required(ErrorMessage = "Country Name is Required")]

        [MaxLength(50, ErrorMessage = "Country Name must be less than 50")]
        public string Name { set; get; }

        //Country Relations
        public virtual ICollection<ApplicationUser> Users { set; get; }

        //not necessary so needs some testing
        public virtual ICollection<Job> Jobs { set; get; }

        //not necessary so needs some testing
        public virtual ICollection<Experience> Experiences { set; get; }
    }
}