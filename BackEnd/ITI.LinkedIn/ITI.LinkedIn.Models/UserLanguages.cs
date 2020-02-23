using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.LinkedIn.Models
{
    public class UserLanguages
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        [Column(Order = 1)]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public Proficiency Proficiency { get; set; }

    }
}
