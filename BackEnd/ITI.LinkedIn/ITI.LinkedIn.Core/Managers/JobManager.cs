using ITI.MVC.Layers.Context;
using ITI.MVC.Layers.Models;
using ITI.MVC.Layers.Repository;
using System;
using System.Runtime.Remoting.Contexts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.Owin;

namespace ITI.MVC.Layers.Core.Managers
{
    public class JobManager : Repository<Job,ApplicationDbContext>, IDisposable
    {
        static JobManager manager;
        private IOwinContext ownContext;

       
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
