using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.LinkedIn.Models
{
    [Table("Certification")]
    public class Certification
    {
        //Certification Data
        [Key]
        public int Id { set; get; }

        [Required(ErrorMessage = "Cerification Name is required")]
        public string Name { set; get; }

        [Required(ErrorMessage = "Certification Url is Required")]
        public string Url { set; get; }

        [Required(ErrorMessage = "Issue Date is Required")]
        [Column(TypeName = "datetime2")]
        public DateTime IssueDate { set; get; }

        //Certification Relation
        //user Id
        [ForeignKey("User")]
        public string UserId { set; get; }
        public virtual ApplicationUser User { set; get; }

        //Company Id
        [ForeignKey("Company")]
        public int CompanyId { set; get; }
        public virtual Company Company { set; get; }
    }
}