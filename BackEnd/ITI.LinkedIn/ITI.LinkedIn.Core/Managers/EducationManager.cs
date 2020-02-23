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
    public class EducationManager : Repository<Education, ApplicationDbContext>, IDisposable
    {
        static EducationManager manager;
        public EducationManager(ApplicationDbContext context) : base(context)
        {
        }
        public static EducationManager GetInstance(ApplicationDbContext context)
        {
            if (manager == null)
            {
                manager = new EducationManager(context);
            }
            return manager;
        }

        public void Dispose()
        {
            manager = null;
        }
    }
}
