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
    public class JobManager : Repository<Job, ApplicationDbContext>, IDisposable
    {
        static JobManager manager;

        private JobManager(ApplicationDbContext context) : base(context)
        {
        }

        public static JobManager GetInstance(ApplicationDbContext context)
        {
            if (manager == null)
            {
                manager = new JobManager(context);
            }
            return manager;
        }

        public void Dispose()
        {
            manager = null;
        }
    }
}