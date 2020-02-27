using ITI.LinkedIn.Context;
using ITI.LinkedIn.Models;
using ITI.LinkedIn.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.LinkedIn.Core.SingletonManagers
{
    public class SingletonEmploymentTypeManager : Repository<EmploymentType, ApplicationDbContext>
    {
        static SingletonEmploymentTypeManager manager;

        private SingletonEmploymentTypeManager(ApplicationDbContext context) : base(context)
        {
        }

        public static SingletonEmploymentTypeManager GetInstance(ApplicationDbContext context)
        {
            if (manager == null)
            {
                manager = new SingletonEmploymentTypeManager(context);
            }
            return manager;
        }
    }
}
