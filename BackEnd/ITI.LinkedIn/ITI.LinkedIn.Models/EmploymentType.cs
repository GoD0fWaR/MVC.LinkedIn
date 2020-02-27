using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.Layers.Models
{
    [Table("EmploymentType")]
    public class EmploymentType
    {
        [Key]
        public int Id { set; get; }

        [Required(ErrorMessage = "Employment Type is Required")]
        public string Name { set; get; }
    }
}
