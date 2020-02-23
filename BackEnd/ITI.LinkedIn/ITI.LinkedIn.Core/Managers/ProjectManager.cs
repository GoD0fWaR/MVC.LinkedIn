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
    public class ProjectManager : Repository<UserProject, ApplicationDbContext>, IDisposable
    {
        static ProjectManager manager;
        public ProjectManager(ApplicationDbContext context) : base(context)
        {
        }
        public static ProjectManager GetInstance(ApplicationDbContext context)
        {
            if (manager == null)
            {
                manager = new ProjectManager(context);
            }
            return manager;
        }

        public void Dispose()
        {

            manager = null;
        }
    }
}
