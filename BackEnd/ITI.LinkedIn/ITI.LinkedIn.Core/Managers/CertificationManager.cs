using ITI.MVC.Layers.Context;
using ITI.MVC.Layers.Models;
using ITI.MVC.Layers.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.Layers.Core.Managers
{
    public class CertificationManager : Repository<Certification, ApplicationDbContext>, IDisposable
    {
        static CertificationManager manager;
        private CertificationManager(ApplicationDbContext context) : base(context)
        {
        }
        public static CertificationManager GetInstance(ApplicationDbContext context)
        {
            if (manager == null)
            {
                manager = new CertificationManager(context);
            }
            return manager;
        }

        public void Dispose()
        {
            manager = null;
        }
       

    }
}
