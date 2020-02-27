using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.Layers.Models
{
    public class JobViewModel
    {
        
        public List<Company> Companies { set; get; }
        public List<Country> Countries { set; get; }
        public Job Job { set; get; }
        public List<EmploymentType> EmploymentTypes { get; set; }
    }
}
