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
    public class EmploymentTypeManager : Repository<EmploymentType, ApplicationDbContext>, IDisposable
    {
        static EmploymentTypeManager manager;
        private EmploymentTypeManager(ApplicationDbContext context) : base(context)
        {
        }
        public static EmploymentTypeManager GetInstance(ApplicationDbContext context)
        {
            if (manager == null)
            {
                manager = new EmploymentTypeManager(context);
            }
            return manager;
        }

        public void Dispose()
        {
            manager = null;
        }
    }
}
