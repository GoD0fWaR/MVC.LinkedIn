using ITI.LinkedIn.Context;
using ITI.LinkedIn.Models;
using ITI.LinkedIn.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.LinkedIn.Core.Managers
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