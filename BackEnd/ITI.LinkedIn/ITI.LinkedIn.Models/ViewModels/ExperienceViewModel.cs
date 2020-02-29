using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.LinkedIn.Models.ViewModels
{
    public class ExperienceViewModel
    {
        public List<Country> Countries { set; get; }
        public List<Company> Companies { set; get; }
        public ApplicationUser ApplicationUser { set; get; }
        public List<EmploymentType> EmploymentTypes { set; get; }
        public Experience Experience { get; set; }
    }
}