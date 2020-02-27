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
    public class ExperienceManager : Repository<Experience, ApplicationDbContext>, IDisposable
    {
        static ExperienceManager manager;
        private ExperienceManager(ApplicationDbContext context) : base(context)
        {
        }
        public static ExperienceManager GetInstance(ApplicationDbContext context)
        {
            if (manager == null)
            {
                manager = new ExperienceManager(context);
            }
            return manager;
        }

        public void Dispose()
        {
            manager = null;
        }

       


    }
}
