using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.Layers.Models
{
    public class CertificationViewModel
    {
        public Certification Certification { get; set; }
        public List<Certification> Certifications { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public List<Company> Companies { get; set; }
    }
}
