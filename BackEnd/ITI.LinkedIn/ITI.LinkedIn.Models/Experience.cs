using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.Layers.Models
{
    [Table("Experience")]
    public class Experience
    {
        //Experience Data
        [Key]
        public int Id { set; get; }
            
        [Required(ErrorMessage ="Title is Required")]
        [MaxLength(50, ErrorMessage ="Title must be less then 50")]
        public string Title { set; get; }

       
       [Required(ErrorMessage = "Description is Required")]
        [MaxLength(50, ErrorMessage = "Description must be less then 500")]
        public string Description { set; get; }

        
        [Required(ErrorMessage = "HeadLine is Required")]
        [MaxLength(50, ErrorMessage = "HeadLine must be less then 50")]
        public string HeadLine { set; get; }

         [Required(ErrorMessage = "StartDate is Required")]
        
        public DateTime StartDate { set; get; }

        [Required(ErrorMessage = "EndDate is Required")]
        
        public DateTime EndDate { set; get; }
        public bool CurrentlyWorkingHere { get; set; }

        //Relations
        //UserId
       
        [ForeignKey("ApplicationUser")]
        public string UserId { set; get; }
        public virtual ApplicationUser ApplicationUser { set; get; }
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
